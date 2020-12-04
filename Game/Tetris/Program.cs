using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static int X = 10;
        static int Y = 30;
        static int Point = 0;
        static void Main(string[] args)
        {
            List<Tetris> MainTetris = new List<Tetris>();
            //MainTetris.Add(new Tetris(0, 0));
            List<Tetris> tetries = GetTetris();
            Print_Corner();
            while (true)
            {
                Print_Point();
                tetries.ForEach(x => x.Y += 1);
                if (MainTetris.Any(x => x.Y ==2) || Point==100)
                {
                    break;
                }
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo PressedKey = Console.ReadKey(true);
                    KeyAvailable(tetries, PressedKey,MainTetris);
                }
                WinCheck(MainTetris);
                if (tetries.Any(x => MainTetris.Any(m => (m.Y - 1 == x.Y) && (m.X==x.X)))
                    || tetries.Any(x => x.Y >= 30))
                {
                    tetries.ForEach(x => MainTetris.Add(x));
                    tetries.ForEach(x => x.Print());
                    tetries = GetTetris();
                }
                tetries.ForEach(x => x.Print());
                Thread.Sleep(150);
                tetries.ForEach(x => x.Clear());
            }
        }
       static void Print_Point()
        {
            Console.SetCursorPosition(X + 5, Y / 2);
            Console.WriteLine($"Point is: {Point}");
        }
        static void WinCheck(List<Tetris> MainTeries)
        {
            if (!MainTeries.Any())
            {
                return;
            }
            for (int j = Y; j > 2; j--)
            {
                var isFull = true;
                for (int i = 0; i < X; i++)
                {
                    if (!MainTeries.Any(x => x.X == i && x.Y == j))
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    Point++;
                    MainTeries.ForEach(x => {
                        if (x.Y == j)
                        {
                            x.Clear();
                        }
                    });
                    MainTeries.RemoveAll(x => x.Y == j);
                    MainTeries.ForEach(x => {
                        if (x.Y < j)
                        {
                            x.Clear();
                            x.Y += 1;
                            x.Print();
                        }
                    });
                }
            }
            
        }
        static void Print_Corner()
        {
            for (int i = 0; i <=Y; i++)
            {
                Console.SetCursorPosition(X, i);
                Console.WriteLine("#");
            }
        }
        static TetrisTypes GetTetrisTypes()
        {
            Random rant = new Random();
            int n = rant.Next(0, 4);
            switch (n)
            {
                case 0:
                    return TetrisTypes.Square;
                case 1:
                    return TetrisTypes.L_Type;
                case 2:
                    return TetrisTypes.T_Type;
                case 3:
                default:
                    return TetrisTypes.Stick;
            }
        }
        static List<Tetris> GetTetris()
        {
            Tetris tetris = new Tetris(0,0);
            var type = GetTetrisTypes();
            //var type = TetrisTypes.Square; ;
            if (TetrisTypes.Square == type)
            {
                return tetris.SquareType();
            }
            else if (TetrisTypes.L_Type == type)
            {
                return tetris.L_Type();
            }
            else if (TetrisTypes.T_Type == type)
            {
                return tetris.T_Type();
            }
            else
            {
                return tetris.StickType();
            }
        }
        static void KeyAvailable(List<Tetris> tetries,ConsoleKeyInfo PressedKey, List<Tetris> Maintetries)
        {
            if (PressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (tetries.All(x => x.X >0) && 
                    tetries.All(x=>!Maintetries.Any(m=>m.X==x.X-1 && m.Y==x.Y)))
                { 
                    tetries.ForEach(x => x.X = x.X - 1);
                }
            }
            if (PressedKey.Key == ConsoleKey.RightArrow )
            {
                if (tetries.All(x => x.X < X-1) && 
                    tetries.All(x=>!Maintetries.Any(m=>m.X==x.X+1 && m.Y==x.Y)))
                {
                    tetries.ForEach(x => x.X = x.X + 1);
                }
            }
        }       
    }
}
