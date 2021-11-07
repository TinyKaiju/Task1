using System; // Yunus Joosub & Thoriso Tlale
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE6122
{
    public partial class Form1 : Form
    {
        //Question 2.1
        public abstract class Tile
        {
            protected int x;
            protected int y;

            public enum tiletype { Hero, Enemy, Gold, Weapon };
            public tiletype type;

            public Tile(int a, int b) //Constructor
            {
                this.x = a;
                this.y = b;
            }

            public int getX()
            {
                return this.x;
            }
            public int getY()
            {
                return this.y;
            }

            public tiletype getTiletype()
            {
                return type;
            }
        }

        public class Obstacle : Tile
        {
            public Obstacle(int x, int y) : base(x, y)
            { }
        }

        public class EmptyTile : Tile
        {
            public EmptyTile(int x, int y) : base(x, y)
            { }
        }
        //Question 2.2
        public abstract class Character : Tile
        {
            protected int hp;
            protected int maxHp;
            protected int damage;
            protected Tile[] visionTiles = new Tile[4]; //In ArrayVision = North, East, South, West
            public enum movementEnum { None, Up, Down, Left, Right };

            private char symbol;

            //Get methods
            public int getHp()
            {
                return this.hp;
            }
            public int getMaxHp()
            {
                return this.maxHp;
            }
            public int getDamage()
            {
                return this.damage;
            }

            public char getSymbol()
            {
                return symbol;
            }

            public Character(int a, int b, char symbol) : base(a, b) // constructor
            {
                this.symbol = symbol;
            }

            public virtual void Attack(Character target)
            { }
            public bool isDead()
            {
                if (this.hp <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public virtual bool CheckRange(Character target)
            {
                if ((DistanceTo(target)) == 1)
                {
                    return true;
                }
                return false;
            }
            private int DistanceTo(Character target) // Incomplete
            {
                int x = target.getX();
                int y = target.getY();

                int distance = (Math.Abs(this.getX() - x)) + Math.Abs((this.getY() - y));

                return distance;
            }
            public void Move(movementEnum move)
            {
                switch (move)
                {
                    case movementEnum.Up:
                        this.x--;
                        break;
                    case movementEnum.Down:
                        this.x++;
                        break;
                    case movementEnum.Right:
                        this.y++;
                        break;
                    case movementEnum.Left:
                        this.y--;
                        break;
                }

            }
            public abstract movementEnum ReturnMove(movementEnum move);
            //public abstract override ToString() { }

            //vision Setting
            public void setVisionTiles(Tile upVis, Tile downVis, Tile rightVis, Tile leftVis)
            {
                this.visionTiles[0] = upVis;
                this.visionTiles[1] = downVis;
                this.visionTiles[2] = rightVis;
                this.visionTiles[3] = leftVis;
            }

            public void damaged(int dmg)
            {
                this.hp -= dmg;
            }
        }

        //Question 2.4
        public abstract class Enemy : Character
        {
            protected Random randNum;

            public Enemy(int x, int y, int Damage, int Maxhp, char Symbol) : base(x, y, Symbol) //Constructor
            {
                this.damage = Damage;
                this.maxHp = Maxhp;
                this.hp = Maxhp;
                this.type = tiletype.Enemy;
            }

            public override string ToString()
            {
                return "Goblin at [" + x + "," + y + "] (" + damage + ")"; // double check 
            }
        }

        //Question 2.5
        public class Goblin : Enemy
        {
            public Goblin(int x, int y) : base(x, y, 1, 10, 'G')//Constructor
            { }
            public override movementEnum ReturnMove(movementEnum move)
            {
                move = movementEnum.None;
                int direct = randNum.Next(4);
                while (move == movementEnum.None)
                {
                    switch (direct)
                    {
                        case 0:
                            type = visionTiles[0].getTiletype();
                            move = movementEnum.Up;
                            break;
                        case 1:
                            type = visionTiles[1].getTiletype();
                            move = movementEnum.Down;
                            break;
                        case 2:
                            type = visionTiles[2].getTiletype();
                            move = movementEnum.Right;
                            break;
                        case 3:
                            type = visionTiles[3].getTiletype();
                            move = movementEnum.Left;
                            break;
                    }
                    if ((type == tiletype.Hero) || (type == tiletype.Hero))
                    {
                        move = movementEnum.None;
                        direct = randNum.Next(4);
                    }
                }
                return move;
            }
        }

        //Question 2.6
        public class Hero : Character
        {
            public Hero(int x, int y, int hp) : base(x, y, 'H')//Constructor
            {
                this.damage = 2;
                this.maxHp = hp;
                this.hp = hp;
                this.type = tiletype.Hero;
            }
            public override movementEnum ReturnMove(movementEnum move)
            {
                return move;
            }
            public override string ToString()
            {
                return ("Player Stats:\n HP: " + hp + "/" + maxHp + "\n Damage: " + damage + "\n [" + getX() + "," + getY() + "]");
            }

            public override bool CheckRange(Character target)
            {
                return base.CheckRange(target);
            }

            public override void Attack(Character target)
            {
                target.damaged(this.damage);
            }
        }

        //Question 3
        //Question 3.1
        public class Map
        {

            private Tile[,] mapTiles;
            private Hero player;
            private Enemy[] enemies;
            private int mapWidth;
            private int mapHeight;
            private Random randomNum = new Random();

            public Map(int wMin, int wMax, int hMin, int hMax, int enemyNum)
            {
                mapWidth = randomNum.Next(wMin, wMax) + 2;
                mapHeight = randomNum.Next(hMin, hMax) + 2;

                enemies = new Enemy[enemyNum];
                mapTiles = new Tile[mapWidth, mapHeight];

                fillMap();

                player = (Hero)Create(Tile.tiletype.Hero); //cast
                mapTiles[player.getX(), player.getY()] = player;

                for (int i = 0; i < enemyNum; i++)
                {
                    enemies[i] = (Enemy)Create(Tile.tiletype.Enemy);
                    mapTiles[enemies[i].getX(), enemies[i].getY()] = enemies[i];
                }

                UpdateVision();

            }

            public void UpdateVision() // used to set vision after moving
            {
                int x = player.getX();
                int y = player.getY();

                int up, down, right, left;
                up = x - 1;
                down = x + 1;
                right = y + 1;
                left = y - 1;

                player.setVisionTiles(mapTiles[up, y], mapTiles[down, y], mapTiles[x, right], mapTiles[x, left]);
                for (int i = 0; i < enemies.Length; i++)
                {
                    x = enemies[i].getX();
                    y = enemies[i].getY();
                    up = x - 1;
                    down = x + 1;
                    right = y + 1;
                    left = y - 1;

                    enemies[i].setVisionTiles(mapTiles[up, y], mapTiles[down, y], mapTiles[x, right], mapTiles[x, left]);
                }

            }

            private Tile Create(Tile.tiletype type)
            {
                int uniqueX = randomNum.Next(mapWidth - 1);
                int uniqueY = randomNum.Next(mapHeight - 1);
                while ((mapTiles[uniqueX, uniqueY] is not EmptyTile) && (mapTiles[uniqueX, uniqueY] is not EmptyTile))
                {
                    uniqueX = randomNum.Next(mapWidth - 1);
                    uniqueY = randomNum.Next(mapHeight - 1);
                }


                switch (type)  // create tile 
                {
                    case Tile.tiletype.Hero:
                        return new Hero(uniqueX, uniqueY, 10);
                    case Tile.tiletype.Enemy:
                        return new Goblin(uniqueX, uniqueY);
                    default: return new EmptyTile(uniqueX, uniqueY);
                }
            }

            public void fillMap()
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        mapTiles[x, y] = new EmptyTile(x, y);
                    }
                }
                for (int x = 0; x < mapWidth; x++)
                {
                    mapTiles[x, 0] = new Obstacle(x, 0);
                    mapTiles[x, mapHeight - 1] = new Obstacle(x, mapHeight - 1);
                }
                for (int y = 0; y < mapHeight; y++)
                {
                    mapTiles[0, y] = new Obstacle(0, y); //top row
                    mapTiles[mapWidth - 1, y] = new Obstacle(mapWidth - 1, y);//bottom row
                }
            }

            public int getWidth()
            {
                return mapWidth;
            }
            public int getHeight()
            {
                return mapHeight;
            }
            public Tile getMapTiles(int x, int y)
            {
                return mapTiles[x, y];
            }

            public int getPlayerX()
            {
                return player.getX();
            }
            public int getPlayerY()
            {
                return player.getY();
            }

            public void Move(Character.movementEnum move)
            {
                int oldX = getPlayerX();
                int oldY = getPlayerY();
                player.Move(move);

                mapTiles[oldX, oldY] = new EmptyTile(oldX, oldY);
                mapTiles[getPlayerX(), getPlayerY()] = player;
            }

            public List<Enemy> getTargetEnemies() // Creates list of enemies in range of attack
            {
                int n = 0;
                List<Enemy> enemyTargets = new List<Enemy>();

                for (int t = 0; t < enemies.Length; t++)
                {
                    
                    if (player.CheckRange(enemies[t]))
                    {
                        enemyTargets.Add(enemies[t]);
                        n++;
                    }
                }
                return enemyTargets;
            }

            public string tryAttack(Enemy target) // Check to see if attack is possible and successful
            {
                List<Enemy> enemies= getTargetEnemies();
                if (enemies.Contains(target))
                {
                    player.Attack(target);

                    if (!target.isDead())
                    {
                        return target.ToString() + "HP: " + Convert.ToString(target.getHp());
                    }
                    else
                    {
                        int x = target.getX();
                        int y = target.getY();
                        String output = "Killed " + target.ToString();

                        mapTiles[x, y] = new EmptyTile(x, y);
                        removeEnemy(target);

                        return output;
                    }
                }
                else
                {
                    return "Attack failed";
                }
            }

            public void removeEnemy(Enemy target) // Removes enemy from array and resizes it
            {
                int j = 0;
                Enemy[] temp = new Enemy[enemies.Length - 1];

                for ( int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i] != target)
                    {
                        temp[j] = enemies[i];
                        j++;
                    }
                }
                enemies = new Enemy[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    enemies[i] = temp[i];
                }
            }

            public virtual string getPlayerInfo()
            {
                return player.ToString();
            }

            public virtual string getEnemyInfo(Enemy target)
            {
                return target.ToString() + "\nHP: " + Convert.ToString(target.getHp()) ;
            }
        }

        //Question 3.3
        public class GameEngine
        {
            private const char heroChar = 'H';
            private const char goblinChar = 'G';
            private const char emptyChar = '#';
            private const char obstacleChar = 'X';
            private Map map;

            public GameEngine(int widthMin, int widthMax, int heightMin, int heightMax, int enemyNum) // constructor
            {
                map = new Map(widthMin, widthMax, heightMin, heightMax, enemyNum);
            }

            public bool MovePlayer(Character.movementEnum moveType)
            {
                int x, y;
                x = map.getPlayerX();
                y = map.getPlayerY();

                switch (moveType)
                {
                    case Character.movementEnum.Up:
                        x--;
                        break;
                    case Character.movementEnum.Down:
                        x++;
                        break;
                    case Character.movementEnum.Right:
                        y++;
                        break;
                    case Character.movementEnum.Left:
                        y--;
                        break;
                }

                if (map.getMapTiles(x, y) is EmptyTile) // player can move
                {
                    map.Move(moveType);
                    return true;
                }
                else
                {
                    return false; //nothing
                }
            }
            
            public string getPlayerInfo()
            {
                return map.getPlayerInfo();
            }
            public string getEnemyInfo(Enemy target)
            {
                return map.getEnemyInfo(target);
            }
            public override string ToString()
            {
         
                string output = "";
                for (int x = 0; x < map.getWidth(); x++)
                {
                    for (int y = 0; y < map.getHeight(); y++)
                    {
                        if (map.getMapTiles(x, y) is Character)
                        {
                            Character temp = (Character)map.getMapTiles(x, y);
                            output += temp.getSymbol();
                        }
                        else
                        {
                            switch (map.getMapTiles(x, y))
                            {
                                case Obstacle:
                                    output += obstacleChar;
                                    break;

                                case EmptyTile:
                                    output += emptyChar;
                                    break;
                            }
                        }
                    }
                    output += "\n";
                }
                return output;
            }
            
            public List<Enemy> getTargets()
            {
                return map.getTargetEnemies();
            }

            public string tryAttack(Enemy target)
            {
                return map.tryAttack(target);
            }
        }
        GameEngine game;
        public Form1()
        {
            InitializeComponent();
            game = new GameEngine(10, 20, 10, 20, 5);
            updateForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Up);
            updateForm();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Down);
            updateForm();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Left);
            updateForm();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            game.MovePlayer(Character.movementEnum.Right);
            updateForm();
        }

        public void updateAttackList()
        {
            CmbEnemyList.Items.Clear();
            CmbEnemyList.Text = "";
            for (int i = 0; i < game.getTargets().Count(); i++)
            {
                CmbEnemyList.Items.Add(game.getTargets().ElementAt(i));
            }
            if (CmbEnemyList.Items.Count != 0)
            {
                CmbEnemyList.SelectedIndex = 0;
                updateEnemy();
            }
        }

        public void updateForm()
        {
            rtbMap.Clear();
            rtbMap.Text = game.ToString();
            MemoPlayerInfo.Text = game.getPlayerInfo();
            updateAttackList();
            updateEnemy();
            lblOutput.Text = "";
        }

        private void BtnAttack_Click(object sender, EventArgs e)
        {

            if (CmbEnemyList.Items.Count != 0)
            {
                int i = CmbEnemyList.SelectedIndex;
                Enemy target = (Enemy)CmbEnemyList.Items[i];
                lblOutput.Text = game.tryAttack(target);
                rtbMap.Clear();
                rtbMap.Text = game.ToString();
                updateAttackList();
                updateEnemy();
            }
            else
            {
                lblOutput.Text = "No Targets Available";
            }
        }

        private void CmbEnemyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEnemy();
        }

        public void updateEnemy()
        {
            MemoEnemyInfo.Clear();
            if (CmbEnemyList.Items.Count != 0)
            {
                int i = CmbEnemyList.SelectedIndex;
                Enemy target = (Enemy)CmbEnemyList.Items[i];
                MemoEnemyInfo.Text = game.getEnemyInfo(target);
            }
        }
    }
}
