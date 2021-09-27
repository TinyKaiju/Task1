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
                switch(move)
                {
                    case movementEnum.Up: this.y++;
                        break;
                    case movementEnum.Down: this.y--;
                        break;
                    case movementEnum.Right: this.x++;
                        break;
                    case movementEnum.Left: this.x--;
                        break;
                }
                
            }
            public abstract movementEnum ReturnMove(movementEnum move);
            //public abstract override ToString() { }

            //vision Setting
            public void setVisionTiles()
            {
                visionTiles[0] = new EmptyTile(this.x - 1, this.y);
                visionTiles[1] = new EmptyTile(this.x + 1, this.y);
                visionTiles[2] = new EmptyTile(this.x, this.y - 1);
                visionTiles[3] = new EmptyTile(this.y, this.y + 1);
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

                //if statement?               

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
            private Random randNum;

            public Map(int wMin, int wMax, int hMin, int hMax, int e)
            {
                this.mapWidth = randNum.Next(wMin, wMax);
                this.mapHeight = randNum.Next(hMin, hMax);

                enemies = new Enemy[e];
                mapTiles = new Tile[mapWidth, mapHeight];

                player = (Hero)Create(Tile.tiletype.Hero); //cast????
                mapTiles[player.getX(), player.getY()] = player;
                
                for (int i = 0; i < e; i++)
                {
                    enemies[i] = (Enemy)Create(Tile.tiletype.Enemy);
                    mapTiles[enemies[i].getX(), enemies[i].getY()] = enemies[i];
                }

                UpdateVision();
                fillMap();
            }

            public void UpdateVision()
            {
                player.setVisionTiles();
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].setVisionTiles();
                }
            }

            private Tile Create(Tile.tiletype type)
            {
                int uniqueX = randNum.Next(mapWidth);
                int uniqueY = randNum.Next(mapHeight);
                while (mapTiles[uniqueX, uniqueY] != null)
                {
                    uniqueX = randNum.Next(mapWidth);
                    uniqueY = randNum.Next(mapHeight);
                }

                
                switch (type)  // create tile 
                {
                    case Tile.tiletype.Hero: return new Hero(uniqueX, uniqueY);
                    case Tile.tiletype.Enemy: return new Goblin(uniqueX, uniqueY);
                    default: return new EmptyTile(uniqueX, uniqueY);
                }
            }

            private void fillMap() 
            { 
                for (int x = 0; x < mapWidth; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        if (mapTiles[x,y] == null)
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
                Map map = new Map(widthMin, widthMax, heightMin, heightMax, enemyNum);
            }

            public bool MovePlayer()
            {
                if (true) // player can move
                {
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
                for(int i = 0; i < map.getWidth(); i++)
                {
                    output += obstacleChar;
                }
                for (int x = 0; x < map.getWidth(); x++)
                {
                    for (int y = 0; y < map.getHeight(); y++)
                    {
                        if (map.getMapTiles(x,y) == null)
                        {
                            output += "\n" + obstacleChar;
                            switch (map.getMapTiles(x, y))
                            {
                                case Hero: output += heroChar;
                                    break;
                                case Goblin: output += goblinChar;
                                    break;
                                case EmptyTile: output += emptyChar;
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
