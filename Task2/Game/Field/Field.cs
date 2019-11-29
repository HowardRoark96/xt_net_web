using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Game
{
    class Field
    {
        public Point Coordinates { get; set; }

        public int Width { get; set; }
        public int Length { get; set; }

        public Field(Point position, int width, int length)
        {
            Coordinates = position;
            Width = width;
            Length = length;
        }
        public Field(int x, int y, int width, int length)
        {
            Coordinates = new Point(x, y);
            Width = width;
            Length = length;
        }
    }
}
