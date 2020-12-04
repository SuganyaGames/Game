using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Tetris
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TetrisTypes TetrisType { get; set; }
        public Tetris(int x,int y)
        {
            X = x;
            Y = y;
        }
        public List<Tetris> SquareType()
        {
            List<Tetris> tetries = new List<Tetris>();
            tetries.Add(new Tetris(5,1));
            tetries.Add(new Tetris(6,1));
            tetries.Add(new Tetris(5,2));
            tetries.Add(new Tetris(6,2));
            return tetries;
        }
        public List<Tetris> L_Type()
        {
            List<Tetris> tetries = new List<Tetris>();
            tetries.Add(new Tetris(5, 1));
            tetries.Add(new Tetris(5, 2));
            tetries.Add(new Tetris(5, 3));
            tetries.Add(new Tetris(6, 3));
            return tetries;
        }
        public List<Tetris> T_Type()
        {
            List<Tetris> tetries = new List<Tetris>();
            tetries.Add(new Tetris(5, 1));
            tetries.Add(new Tetris(6, 1));
            tetries.Add(new Tetris(7, 1));
            tetries.Add(new Tetris(6, 2));
            return tetries;
        }
        public List<Tetris> StickType()
        {
            List<Tetris> tetries = new List<Tetris>();
            tetries.Add(new Tetris(5, 1));
            tetries.Add(new Tetris(5, 2));
            tetries.Add(new Tetris(5, 3));
            tetries.Add(new Tetris(5, 4));
            return tetries;
        }
        public List<Tetris> OthresType()
        {
            List<Tetris> tetries = new List<Tetris>();
            tetries.Add(new Tetris(0,0));
            tetries.Add(new Tetris(0,0));
            tetries.Add(new Tetris(0,0));
            tetries.Add(new Tetris(0,0));
            return tetries;
        }
        public void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*");
        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
        }
    }
}
