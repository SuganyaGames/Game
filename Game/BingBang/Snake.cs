using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingBang
{
    class Snake
    {
        public  Direction Direction { get; set; }
        public List<Point> Points { get; set; }
        public Snake(int x,int y,ConsoleColor color,Direction direction)
        {
            Point point = new Point();
            point.X = x;
            point.Y = y;
            point.Color = color;
            point.Print();
            Direction =direction;
            Points = new List<Point>();
            Points.Add(point);
        }
        public bool Move(Snake oppsSnake)
        {
            var Head = Points[Points.Count - 1];
            var new_Head = new Point();
            new_Head.X = Head.X;
            new_Head.Y = Head.Y;
            new_Head.Color = Head.Color;
            switch (Direction)
            {
                case Direction.Left:
                    new_Head.X--;
                    break;
                case Direction.Right:
                    new_Head.X++;
                    break;
                case Direction.Down:
                    new_Head.Y++;
                    break;
                case Direction.Up:
                default:
                    new_Head.Y--;
                    break;
            }
            if (IS_Out(new_Head, oppsSnake))
            {
                return true;
            }
            Points.Add(new_Head);
            new_Head.Print();
            return false;
        }
        public bool IS_Out(Point newHead, Snake oppsSnake)
        {
            if (newHead.X < 0 || newHead.Y<0 || newHead.X>=Console.WindowWidth
                || newHead.Y >=Console.WindowHeight)
            {
                return true;
            }
            if(Points.Any(x=>x.X== newHead.X && x.Y == newHead.Y))
            {
                return true;
            }
            if (oppsSnake.Points.Any(x => x.X == newHead.X && x.Y == newHead.Y))
            {
                return true;
            }
            return false;
        }
    }
}
