using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeAndLader
{
    class Board
    {
        public string  Player1 { get; set; }
        public string Player2 { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public ConsoleColor Color1 { get; set; }
        public ConsoleColor Color2 { get; set; }
        public Board()
        {
            Player1 = "S";
            Player2 = "V";
            P1 = 1;
            P2 = 1;
            Color1 = ConsoleColor.Green;
            Color2 = ConsoleColor.DarkYellow;
        }
        public int SnakeLaderPoint(int n)
        {
            switch (n)
            {
                case 4:
                    return 14;
                case 8:
                    return 10;
                case 1:
                    return 38;
                case 21:
                    return 42;
                case 28:
                    return 74;
                case 50:
                    return 67;
                case 88:
                    return 99;
                case 71:
                    return 92;
                case 62:
                    return 18;
                case 34:
                    return 16;
                case 87:
                    return 24;
                case 48:
                    return 26;
                case 32:
                    return 10;
                case 97:
                    return 78;
                case 95:
                    return 56;
                default:
                    return n;
            }
        }
        public bool MovePoint(bool first)
        {
            Random rant = new Random();
            int p= rant.Next(1, 7);
            if (first && P1 + p <= 100)
            {
                ClearPoint(P1);
                P1 = P1 + p;
                P1=SnakeLaderPoint(P1);
                PrintPoint(P1, first);
            }
            if (!first && P2 + p <= 100)
            {
                ClearPoint(P2);
                P2 = P2 + p;
                P2 = SnakeLaderPoint(P2);
                PrintPoint(P2, first);
            }
            if (P1>=100 || P2 >= 100)
            {
                return true;
            }
            return false;
        }
        public void PrintPoint(int n,bool first)
        {
            Point point = new Point(n);
            Console.SetCursorPosition(point.X,point.Y);
            if (first)
            {
                Console.ForegroundColor = Color1;
                Console.WriteLine(Player1);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = Color2;
                Console.WriteLine(Player2);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ClearPoint(int n)
        {
            Point point = new Point(n);
            Console.SetCursorPosition(point.X, point.Y);
            Console.WriteLine(" ");
        }
        public void Print()
        {
            int count = 1;
            Console.WriteLine("________________________________________");
            for (int i = 1; i <=10; i++)
            {
                for (int j = 1; j <=10; j++)
                {
                    if (j == 1)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(" ");
                    Console.Write(" | ");
                    if (j % 10 == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("________________________________________");
                    }
                    count++;
                }
                
            }
        }
        public void PointValue()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(45, 10);
            Console.WriteLine($"Player1 {Player1} Value: {P1}");
            Console.SetCursorPosition(45, 12);
            Console.WriteLine($"Player2 {Player2} Value: {P2}");
        }
    }
}
