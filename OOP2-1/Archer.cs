using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_1
{
    internal class Archer : Person
    {

        public Archer()
        {
            this.name = "archer";
            this.health = 8;
            this.range = 6;
            this.damage = 2;
            this.speed = 3;
            this.armor = 1;
        }
    }
}
