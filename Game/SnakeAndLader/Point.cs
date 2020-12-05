using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAndLader
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int count)
        {
            X = (count - 1) % 10 * 4 + 2;
            Y = (count - 1) / 10 * 2 + 1;
        }
    }
}
