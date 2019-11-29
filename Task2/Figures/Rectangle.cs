using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Figures
{
    class Rectangle : Figure
    {
        private double _length;
        private double _width;

        public Rectangle(double length, double width) : base(0, 0)
        {
            Length = length;
            Width = width;
        }
        public Rectangle(double x, double y, double length, double width) : base(x, y)
        {
            Length = length;
            Width = width;
        }

        public double Length
        {
            get => _length;
            set
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    throw new ArgumentException("Exception: Invalid argument. Value must be positive.");
                }
            }
        }
        public double Width
        {
            get => _width;
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentException("Exception: Invalid argument. Value must be positive.");
                }
            }
        }
        public double Perimeter
        {
            get => (Length + Width) * 2;
        }
        public double Area
        {
            get => Length * Width;
        }

        public override void Parametres()
        {
            Console.WriteLine("Figure : {0};\n" +
                              "Origin point : X = {1:0.#}, Y = {2:0.#};\n" +
                              "Length side : {3:0.#};\n" +
                              "Width side : {4:0.#};\n" +
                              "Area : {5:0.#};\n" +
                              "Perimeter : {6:0.#};",
                              "Rectangle", X, Y, Length, Width, Area, Perimeter);
        }
    }
}
