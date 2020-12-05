using System;
using System.Threading;

namespace SnakeAndLader
{
    class Program
    {
        static void Main(string[] args)
        {
            bool first = true;
            Board board = new Board();
            board.Print();
            board.MovePoint(first);
            while (true)
            {
                board.PointValue();
                if (board.MovePoint(first))
                {
                    string p = first ? "Player1" : "Player2";
                    Console.WriteLine($"\n{p} win");
                    break;
                }
                first = !first;
                Thread.Sleep(500);
            }
        }
    }
}
