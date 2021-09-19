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
        public abstract class Tile
        {
            protected int x;
            protected int y;

            public enum tiletype { Hero, Enemy, Gold, Weapon };
            //Tile(int a, int b, enum: tiletype type) //Constructor
        }
        public abstract class Character : Tile
        {
            protected int hp;
            protected int maxHp;
            protected int damage;
            protected Tile[] tiles;
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

            //Methods
            //Character() // constructor


            //public virtual void Attack(Character target)
            //public bool isDead()
            //public virtual bool CheckRange(Character target)
            //public int DistanceTo()
            //public void Move(enum : movement move)
            //public abstract override ToString()    
        }

        public abstract class Enemy : Character
        {
            protected Random randNum;
            //Enemy() //Constructor
            //public override ToString()
        }

        public class Goblin : Enemy
        {
            // Goblin() //Constructor
            // public override ReturnMove()
            // public override ToString()
        }

        public class Hero : Character
        {
            // Goblin() //Constructor
            // public override ReturnMove()
            // public override ToString()
        }

        public class Map
        {
            Tile[][] mapTiles;
            Hero player = new Hero();
            Enemy[] enemies;
            int mapWidth;
            int mapHeight;
            Random randNum;

            //public void UpdateVision
            //private TileCreate(enum: tileType type)
            //own methods
        }

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
