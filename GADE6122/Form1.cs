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
            //Tile(int a, int b, enum: tiletype type) //Constructor
        }
        //Question 2.2
        public abstract class Character : Tile
        {
            protected int hp;
            protected int maxHp;
            protected int damage;
            protected Tile[] tiles; //In ArrayVision = North, East, South, West
            public enum movement { No_movement, Up, Down, Left, Right };

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

            //Question 2.3

            //Methods.
            //Character() // constructor


            //public virtual void Attack(Character target)
            //public bool isDead()
            //public virtual bool CheckRange(Character target)
            //private int DistanceTo()
            //public void Move(enum : movement move)
            //public abstract ReturnMove(enum : movement move)*
            //public abstract override ToString()    
        }

        //Question 2.4
        public abstract class Enemy : Character
        {
            protected Random randNum;
            //Enemy() //Constructor
            //public override ToString()
            
        }

        //Question 2.5
        public class Goblin : Enemy
        {
            // Goblin() //Constructor
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
