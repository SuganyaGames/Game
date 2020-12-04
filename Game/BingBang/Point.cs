using System;
using System.Collections.Generic;
using System.Text;

namespace BingBang
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.WriteLine("*");
        }
    }
}
