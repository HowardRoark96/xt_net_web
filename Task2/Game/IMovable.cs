﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    interface IMovable
    {
        int Speed { get; set; }
        byte Direction { get; set; }
    }
}
