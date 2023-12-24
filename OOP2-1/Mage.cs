using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_1
{
    internal class Mage : Person
    {

        public Mage()
        {
            this.name = "mage";
            this.health = 5;
            this.range = 4;
            this.damage = 7;
            this.speed = 2;
            this.armor = 0;
        }
    }
}
