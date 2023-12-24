using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_1
{
    internal class Warrior:Person
    {
        
        public Warrior()
        {
            this.name = "warrior";
            this.health = 10;
            this.range = 1;
            this.damage = 4;
            this.speed = 3;
            this.armor = 2;
        }
    }
}
