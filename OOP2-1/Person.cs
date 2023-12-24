using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP2_1
{
    internal class Person
    {
        public string name;
        public int health;
        public int damage;
        public int range;
        public int speed;
        public int armor;
        public Person()
        {
            this.health = 1;
            this.damage = 1;
            this.range = 1;
            this.speed = 1;
            this.armor = 0;
    }

        new public int getHealth()
        {
            return this.health;
        }
        new public int attack(int distance)
        {
            if (distance <= this.range)
            {
                return this.damage;
            }
            else { return 0; }
        }
        new public bool isAlive()
        {
            if (this.health <= 0)
            {
                return false;
            }
            else { return true; }
        }
        new public int move() {
            return this.speed;
        }

    }
}