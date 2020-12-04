using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Point(1,10);
            var b = a;
            a.Print();
            b.Print();
            b.X += 1;
            a.Print();
            b.Print();

            var c = 5;
            var d = c;
            Console.WriteLine(c+" "+d);
            d++;
            Console.WriteLine(c+" "+d);
            var e = "su";
            var f = e;
            Console.WriteLine(e+" "+f);
            f = f + "l";
            Console.WriteLine(e+" "+f);
            

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
            public void Print()
            {
                Console.WriteLine(X + " " + Y);
            }
        }
        
    }
}
