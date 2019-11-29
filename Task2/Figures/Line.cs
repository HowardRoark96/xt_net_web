using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Figures
{
    class Line : Figure
    {
        public Line(double x, double y) : base(0, 0)
        {
            if (x != 0 && y != 0)
            {
                X1 = x;
                Y1 = y;
            }
            else
            {
                throw new ArgumentException("Exception: Invalid arguments. Origin and end points of the line should not match.");
            }
        }
        public Line(double x, double y, double x1, double y1) : base(x, y)
        {
            if (x1 != x || y1 != y)
            {
                X1 = x1;
                Y1 = y1;
            }
            else
            {
                throw new ArgumentException("Exception: Invalid arguments. Origin and end points of the line should not match.");
            }
        }

        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double Length
        {
            get => Math.Sqrt(Math.Pow(X1 - X, 2) + Math.Pow(Y1 - Y, 2));
        }

        public override void Parametres()
        {
            Console.WriteLine("Figure : {0};\n" +
                              "Origin point : X = {1:0.#}, Y = {2:0.#};\n" +
                              "End point : X = {3:0.#}, Y = {4:0.#};\n" +
                              "Length : {5:0.#};",
                              "Line", X, Y, X1, Y1, Length);
        }
    }
}
