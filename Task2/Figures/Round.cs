using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Figures
{
    class Round : Circle
    {
        public Round(double radius) : base(radius) { }
        public Round(double x, double y, double radius) : base(x, y, radius) { }

        public double Area
        {
            get => Math.Pow(Radius, 2) * Math.PI;
        }

        public override void Parametres()
        {
            Console.WriteLine("Figure : {0};\n" +
                              "Origin point : X = {1:0.#}, Y = {2:0.#};\n" +
                              "Radius : {3:0.#};\n" +
                              "Length : {4:0.#};\n" +
                              "Area : {5:0.#};",
                              "Round", X, Y, Radius, Length, Area);
        }
    }
}
