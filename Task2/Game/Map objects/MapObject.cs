﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    abstract class MapObject : Unit
    {
        public override Field Location { get; set; }
    }
}
