using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SnakeTypes Type { get; set; }
        public Snake(int x,int y,SnakeTypes type)
        {
            X = x;
            Y = y;
            Type = type;
        }
        public char GetSymbol()
        {
            return SnakeTypes.Snake == Type ? '*' : (SnakeTypes.Food == Type) ? '*' : (SnakeTypes.Dangerous == Type) ? '#' : ' '; 
        }
        public ConsoleColor GetColor()
        {
            if (Type == SnakeTypes.Snake)
            {
                return ConsoleColor.DarkCyan;
            }
            else if (Type == SnakeTypes.Food)
            {
                return ConsoleColor.Yellow;
            }
            else
            {
                return ConsoleColor.DarkMagenta;
            }
        }
        public void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = GetColor();
            Console.WriteLine(GetSymbol());
        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
        }
    }
}
