using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Figures
{
    class Ring : Figure
    {
        private Round _outerRound;
        private Round _innerRound;

        public Ring(double outerR, double innerR) : base(0, 0)
        {
            if (innerR < outerR)
            {
                _outerRound = new Round(0, 0, outerR);
                _innerRound = new Round(0, 0, innerR);
            }
            else
            {
                throw new ArgumentException("Exception: Invalid argument. Outer radius must be greater than the inner radius of the ring.");
            }
        }
        public Ring(double x, double y, double outerR, double innerR) : base(x, y)
        {
            if (innerR < outerR)
            {
                _outerRound = new Round(x, y, outerR);
                _innerRound = new Round(x, y, innerR);
            }
            else
            {
                throw new ArgumentException("Exception: Invalid argument. Outer radius must be greater than the inner radius of the ring.");
            }
        }

        public double OuterRadius
        {
            get => _outerRound.Radius;
            set
            {
                if (value > InnerRadius)
                {
                    _outerRound.Radius = value;
                }
            }
        }
        public double InnerRadius
        {
            get => _innerRound.Radius;
            set
            {
                if (value < OuterRadius)
                {
                    _innerRound.Radius = value;
                }
            }
        }
        public double Length
        {
            get => _outerRound.Length + _innerRound.Length;
        }
        public double Area
        {
            get => _outerRound.Area - _innerRound.Area;
        }

        public override void Parametres()
        {
            Console.WriteLine("Figure : {0};\n" +
                              "Origin point : X = {1:0.#}, Y = {2:0.#};\n" +
                              "Outer radius : {3:0.#};\n" +
                              "Inner radius : {4:0.#};\n" +
                              "Length : {5:0.#};\n" +
                              "Area : {6:0.#};",
                              "Ring", X, Y, OuterRadius, InnerRadius, Length, Area);
        }
    }
}
