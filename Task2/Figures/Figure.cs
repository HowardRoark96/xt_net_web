using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Figures
{
    abstract class Figure
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Figure(double x, double y)
        {
            X = x;
            Y = y;
        }

        public abstract void Parametres();
    }
}
