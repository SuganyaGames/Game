using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new List<Point>();
            board.Add(new Point(2,15));
            board.Add(new Point(2,16));
            var tetris = new List<Point>();
            tetris.Add(new Point(3, 15));
            tetris.Add(new Point(3, 16));
            // left
            var tet = !tetris.Any(x => board.Any(y => y.X==x.X-1 && y.Y == x.Y));
            var tet = tetris.All(x => !board.Any(y => y.X==x.X&&y.Y==x.Y));

            Console.WriteLine(tet);//false
        }
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
}
