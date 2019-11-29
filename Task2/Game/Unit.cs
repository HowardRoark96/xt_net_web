using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Game;

namespace Task2.Game
{
    abstract class Unit
    {
        public abstract Field Location { get;  set; }
    }
}
