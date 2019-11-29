using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    abstract class Bonus : Unit
    {
        public override Field Location { get; set; }

        public Bonus(Field location)
        {
            Location = location;
        }

        public abstract void Effect(Player p);
    }
}
