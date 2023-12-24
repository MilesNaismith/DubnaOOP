using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_1
{
    internal class Orc : Person
    {

        public Orc()
        {
            this.name = "Orc";
            this.health = 8;
            this.range = 1;
            this.damage = 3;
            this.speed = 3;
            this.armor = 1;
        }
    }
}
