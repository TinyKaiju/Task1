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
            protected Tile[] tiles; //In ArrayVision = North, East, South, West
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
            public Enemy(int x, int y, int Damage, int Maxhp, char Symbol)  //Constructor
            {
                int GetX() 
                { 
                    return x; 
                }
                int GetY()
                {
                    return y;
                }             
                Damage = getDamage();
                Maxhp = getMaxHp();
                Symbol = 'H';
                
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
                x = 
                this.maxHp = 10;
                this.damage = 1;          
            } 
            // public override ReturnMove()
            // public override ToString()
        }

        //Question 2.6
        public class Hero : Character
        {
            // Goblin() //Constructor
            // public override ReturnMove()
            // public override ToString()
        }

        //Question 3
        //Question 3.1
        public class Map
        {
            Tile[][] mapTiles;
            Hero player = new Hero();
            Enemy[] enemies;
            int mapWidth;
            int mapHeight;
            Random randNum;

        //Question 3.2
            //public void UpdateVision
            //private TileCreate(enum: tileType type)
            //own methods
        }

        //Question 3.3
        public class GameEngine
        {
            private Map map;

            //public getMap()
            //GameEngine()
            //public bool MovePlayer()
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
