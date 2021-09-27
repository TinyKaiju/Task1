using System;
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
            protected Tile[] visionTiles; //In ArrayVision = North, East, South, West
            public enum movementEnum { None, Up, Down, Left, Right };
            movementEnum movement;

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

            public Character(int a, int b, char symbol) : base(a, b) // constructor
            { }

            public virtual void Attack(Character target)
            { }
            public bool isDead()
            {
                if (this.hp == 0)
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

                int distance = (this.getX() - x) + (this.getY() - y);

                return distance;
            }
            public void Move(movementEnum move)
            {
                switch (move)
                {
                    case movementEnum.Up:
                        this.y++;
                        break;
                    case movementEnum.Down:
                        this.y--;
                        break;
                    case movementEnum.Right:
                        this.x++;
                        break;
                    case movementEnum.Left:
                        this.x--;
                        break;
                }

            }
            public abstract movementEnum ReturnMove(movementEnum move);
            //public abstract override ToString() { }

            //vision Setting
            public void setVisionTiles(Tile upVis, Tile downVis, Tile rightVis, Tile leftVis)
            {/*
                tiletype tileTemp = upVis.getTiletype();

                if (tileTemp == tiletype.Hero)
                { 
                    visionTiles[0] = new Hero(upVis.getX(), upVis.getY());
                }
                if (tileTemp == tiletype.Enemy)
                {
                    visionTiles[0] = new Goblin(upVis.getX(), upVis.getY());
                }
                else
                { 
                    visionTiles[0] = new EmptyTile(upVis.getX(), upVis.getY());
                }

                if (tileTemp == tiletype.Hero) //down
                {
                    visionTiles[1] = new Hero(downVis.getX(), downVis.getY());
                }
                if (tileTemp == tiletype.Enemy)
                {
                    visionTiles[1] = new Goblin(downVis.getX(), downVis.getY());
                }
                else
                {
                    visionTiles[1] = new EmptyTile(downVis.getX(), downVis.getY());
                }

                if (tileTemp == tiletype.Hero)
                {
                    visionTiles[2] = new Hero(rightVis.getX(), rightVis.getY());
                }
                if (tileTemp == tiletype.Enemy)
                {
                    visionTiles[2] = new Goblin(rightVis.getX(), rightVis.getY());
                }
                else
                {
                    visionTiles[2] = new EmptyTile(rightVis.getX(), rightVis.getY());
                }
                if (tileTemp == tiletype.Hero)
                {
                    visionTiles[3] = new Hero(leftVis.getX(), leftVis.getY());
                }
                if (tileTemp == tiletype.Enemy)
                {
                    visionTiles[3] = new Goblin(leftVis.getX(), leftVis.getY());
                }
                else
                {
                    visionTiles[3] = new EmptyTile(leftVis.getX(), leftVis.getY());
                }*/
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


            public Hero(int x, int y) : base(x, y, 'H')//Constructor
            {
                this.damage = 2;
                this.maxHp = getMaxHp();
                this.hp = getHp();
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

            public Map(int wMin, int wMax, int hMin, int hMax, int e)
            {
                mapWidth = randomNum.Next(wMin, wMax);
                mapHeight = randomNum.Next(hMin, hMax);

                enemies = new Enemy[e];
                mapTiles = new Tile[mapWidth, mapHeight];

                player = (Hero)Create(Tile.tiletype.Hero); //cast????
                mapTiles[player.getX(), player.getY()] = player;

                for (int i = 0; i < e; i++)
                {
                    enemies[i] = (Enemy)Create(Tile.tiletype.Enemy);
                    mapTiles[enemies[i].getX(), enemies[i].getY()] = enemies[i];
                }

                fillMap();
                UpdateVision();
                
            }

            public void UpdateVision()
            {
                int x = player.getX();
                int y = player.getY();

                int up, down, right, left;
                up = y + 1;
                down = y - 1;
                right = x + 1;
                left = x - 1;

                if(up >= mapHeight)
                {
                    up = y;
                }
                if (down <= 0)
                {
                    down = y;
                }
                if (right >= mapHeight)
                {
                    up = y;
                }
                if (left <= 0)
                {
                    down = y;
                }

                player.setVisionTiles(mapTiles[x, up], mapTiles[x, down], mapTiles[right, y], mapTiles[left, y]);
                for (int i = 0; i < enemies.Length; i++)
                {
                    x = enemies[i].getX();
                    y = enemies[i].getY();
                    up = y + 1;
                    down = y - 1;
                    right = x + 1;
                    left = x - 1;

                    if (up >= mapHeight)
                    {
                        up = y;
                    }
                    if (down <= 0)
                    {
                        down = y;
                    }
                    if (right >= mapHeight)
                    {
                        up = y;
                    }
                    if (left <= 0)
                    {
                        down = y;
                    }

                    enemies[i].setVisionTiles(mapTiles[x, up], mapTiles[x, down], mapTiles[right, y], mapTiles[left, y]);
                }
            }

            private Tile Create(Tile.tiletype type)
            {
                int uniqueX = randomNum.Next(mapWidth);
                int uniqueY = randomNum.Next(mapHeight);
                while (mapTiles[uniqueX, uniqueY] != null)
                {
                    uniqueX = randomNum.Next(mapWidth);
                    uniqueY = randomNum.Next(mapHeight);
                }


                switch (type)  // create tile 
                {
                    case Tile.tiletype.Hero:
                        return new Hero(uniqueX, uniqueY);
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
                        if (mapTiles[x, y] == null)
                        {
                            mapTiles[x, y] = new EmptyTile(x, y);
                        }
                    }
                }
            }

            public int getWidth()
            {
                return mapWidth;
            }
            public int getHeight()
            {
                return mapWidth;
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
                player.Move(move);

            }

        }

        //Question 3.3
        public class GameEngine
        {
            private const char heroChar = 'H';
            private const char goblinChar = 'G';
            private const char emptyChar = '.';
            private const char obstacleChar = '#';
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
                        y++;
                        break;
                    case Character.movementEnum.Down:
                        y--;
                        break;
                    case Character.movementEnum.Right:
                        x++;
                        break;
                    case Character.movementEnum.Left:
                        x--;
                        break;
                }

                EmptyTile tempTile = new EmptyTile(x, y);

                if (map.getMapTiles(x, y).type == tempTile.type) // player can move
                {
                    map.Move(moveType);
                    map.fillMap();
                    return true;
                }
                else
                {
                    return false; //nothing
                }
            }

            public override string ToString()
            {
                string output = "";
                for (int i = 0; i < map.getWidth(); i++)
                {
                    output += obstacleChar;
                }
                for (int x = 0; x < map.getWidth(); x++)
                {
                    for (int y = 0; y < map.getHeight(); y++)
                    {
                        if (map.getMapTiles(x, y) == null)
                        {
                            output += "\n" + obstacleChar;
                            switch (map.getMapTiles(x, y))
                            {
                                case Hero:
                                    output += heroChar;
                                    break;
                                case Goblin:
                                    output += goblinChar;
                                    break;
                                case EmptyTile:
                                    output += emptyChar;
                                    break;
                            }
                            output += obstacleChar;
                        }
                    }
                }
                for (int i = 0; i < map.getWidth(); i++)
                {
                    output += "\n" + obstacleChar;
                }
                return output;
            }
        }
        public Form1()
        {
            InitializeComponent();
            GameEngine game = new GameEngine(10, 20, 10, 20, 5);
            richTextBox1.Text = game.ToString();
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

    }
}
