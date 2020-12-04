using System;

namespace TikTok
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            bool first = true;
            while (true)
            {
                board.Print();
                if (board.Full_Board_Check())
                {
                    Console.WriteLine("board is full");
                    break;
                }
                board.Win_Check();
                if (board.Player_Check())
                {
                    Console.WriteLine("game over");
                    break;
                }
                board.Put_element(first);
                first = !first;
                Console.Clear();
            }
        }
    }
}
