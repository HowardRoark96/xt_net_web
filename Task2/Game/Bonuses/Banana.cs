using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    class Banana : Bonus
    {
        public Banana(Field location) : base(location)
        {
            Location = location;
        }

        public override void Effect(Player p)
        {
            if (Location == p.Location)
            {
                p.Speed++;
            }
        }
    }
}
