using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Figures
{
    class Circle : Figure
    {
        private double _radius;

        public Circle(double radius) : base(0, 0)
        {
            Radius = radius;
        }

        public Circle(double x, double y, double radius) : base(x, y)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => _radius;
            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
                else
                {
                    throw new ArgumentException("Exception: Invalid argument. Radius must be a positive value.");
                }
            }
        }

        public double Length
        {
            get => Math.PI * _radius * 2;
        }

        public override void Parametres()
        {
            Console.WriteLine("Figure : {0};\n" +
                              "Origin point : X = {1:0.#}, Y = {2:0.#};\n" +
                              "Radius : {3:0.#};\n" +
                              "Length : {4:0.#};",
                              "Circle", X, Y, Radius, Length);
        }
    }
}
