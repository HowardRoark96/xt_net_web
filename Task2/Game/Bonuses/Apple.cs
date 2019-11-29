using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    class Apple : Bonus
    {
        public Apple(Field location) : base(location)
        {
            Location = location;
        }

        public override void Effect(Player p)
        {
            if (Location == p.Location)
            {
                p.MaxHealth++;
            }
        }
    }
}
