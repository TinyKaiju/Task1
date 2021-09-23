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
            tiletype type;

            
            public Tile()
            { }
            public Tile(int a, int b) //Constructor
            {
                this.x = a;
                this.y = b;
            }
            public Tile(int a, int b,tiletype typeTile) //Constructor
            {
                this.x = a;
                this.y = b;
                this.type = typeTile;
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
            public Obstacle()
            {
                this.getX();
                this.getY();
            }
        }

        public class EmptyTile : Tile 
        {
            public EmptyTile()
            {
                this.getX();
                this.getY();
            }
        }
        //Question 2.2
        public abstract class Character : Tile
        {
            protected int hp;
            protected int maxHp;
            protected int damage;
            protected Tile[] visionTiles; //In ArrayVision = North, East, South, West
            public enum movementEnum { No_movement, Up, Down, Left, Right };
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
            public Character()
            { }
            public Character(int a, int b, int damage, int maxHP, char symbol) // constructor
            {
                this.x = a;
                this.y = b;
            }
            
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
                DistanceTo(target);
                if ((target.getX() - this.x) == 1)
                {
                    return true;
                }
                return false;
            }
            private int DistanceTo(Character target)
            {
                return 0;
            }
            public void Move(movementEnum move)
            { }
            public abstract movementEnum ReturnMove(movementEnum move);
            //public abstract override ToString() { }
        }

        //Question 2.4
        public abstract class Enemy : Character
        {
            protected Random randNum;
            public Enemy() { }
            public Enemy(int x, int y, int Damage, int Maxhp, char Symbol)  //Constructor

            {
                this.x = x;
                this.y = y;

                Damage = getDamage();
                Maxhp = getMaxHp();
                Symbol = 'G';
                
                
            }        
            public override string ToString()
            {
                return  "Goblin at [" + x + "," + y + "] (" + damage + ")";  
            }
            
        }

        //Question 2.5
        public class Goblin : Enemy
        {
            Goblin(int x, int y) //Constructor
            {
                this.x = x;
                this.y = y;
                this.maxHp = 10;
                this.damage = 1;          
            }
            public override movementEnum ReturnMove(movementEnum move) 
            {

                //if statement?               

                return move;
            }
        }

        //Question 2.6
        public class Hero : Character
        {
            Hero(int x, int y) //Constructor
            {
                this.x = x;
                this.y = y;
                this.damage = 2;
                this.maxHp = getMaxHp();
                this.hp = getHp();
                char SymbolHero = 'H';
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
        public class Map : Tile
        {

            Tile[,] mapTiles;
            Hero player = new Hero();
            Enemy[] enemies;
            int mapWidth;
            int mapHeight;
            Random randNum;

            public Map(int wMin, int wMax, int hMin, int hMax, int e)
            {
                this.mapWidth = randomizer(wMin, wMax);
                this.mapHeight = randomizer(wMin, wMax);
                enemies = new Enemy[e];
                mapTiles = new Tile[mapWidth, mapHeight];
                //create Hero 
                //create enemies
                
            }

            /*public void UpdateVision(class target)
            {
                target.visionTiles[0] = target.getX - 1;
                target.visionTiles = target.getX + 1;
                target.visionTiles = target.getY - 1;
                target.visionTiles = target.getY + 1;
            }*/

            private Tile Create(tiletype type)
            {
                switch (type)
                {
                    case tiletype.Hero: return new Hero();
                    //case tiletype.Enemy: return new Enemy(1, 1, 1, 'E');
                    case tiletype.Gold: return new Hero();
                    case tiletype.Weapon: return new Hero();
                    default: return new EmptyTile();
                }
            }

            private int randomizer(int min, int max)
            {
                return randNum.Next(min, max);
            }
        }

        //Question 3.3
        public class GameEngine
        {
            private Map map;

            public GameEngine() //default constructor
            { }

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
