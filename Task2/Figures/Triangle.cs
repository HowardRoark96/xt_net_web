using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Figures
{
    class Triangle : Figure
    {
        public Triangle(double a, double b, double c) : base(0, 0)
        {
            SetSides(a, b, c);
        }

        public Triangle(double x, double y, double a, double b, double c) : base(x, y)
        {
            SetSides(a, b, c);
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public double Perimeter
        {
            get => A + B + C;
        }

        public double Area
        {
            get => Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - A) * (Perimeter / 2 - B) * (Perimeter / 2 - C));
        }
        public override void Parametres()
        {
            Console.WriteLine("Figure : {0};\n" +
                              "Origin point : X = {1:0.#}, Y = {2:0.#};\n" +
                              "A side : {3:0.#};\n" +
                              "B side : {4:0.#};\n" +
                              "C side : {5:0.#};\n" +
                              "Area : {6:0.#};\n" +
                              "Perimeter : {7:0.#};",
                              "Triangle", X, Y, A, B, C, Area, Perimeter);
        }

        private void SetSides(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentException("Exception: Invalid arguments. The sides of the triangle must be positive");
            }
            if (a < b + c && a > Math.Abs(b - c))
            {
                A = a;
                B = b;
                C = c;
            }
            else
                throw new ArgumentException("Exception: Invalid arguments. A triangle with such sides does not exist");
        }
    }
}
