using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BingBang
{
    class Program
    {   
        static void Main(string[] args)
        {
            Snake snake1 = new Snake(0, 15, ConsoleColor.Red, Direction.Right);
            Snake snake2 = new Snake(Console.WindowWidth - 1, 15, ConsoleColor.Green, Direction.Left);
            //Snake snake3 = new Snake((Console.WindowWidth - 1)/2, 0, ConsoleColor.Yellow, Direction.Down);
            while (true)
            {
                if (snake1.Move(snake2))
                {
                    Console.WriteLine("playter 1 out");
                    break;              
                }
                
                if(snake2.Move(snake1))
                {
                    Console.WriteLine("playter 2 out");
                    break;
                }
                //snake3.Move();
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo PressedKey = Console.ReadKey(true);
                    
                    switch (PressedKey.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            snake1.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake1.Direction = Direction.Right;
                            break;
                        case ConsoleKey.DownArrow:
                            snake1.Direction = Direction.Down;
                            break;
                        case ConsoleKey.UpArrow:
                            snake1.Direction = Direction.Up;
                            break;
                        case ConsoleKey.A:
                            snake2.Direction = Direction.Left;
                            break;
                        case ConsoleKey.D:
                            snake2.Direction = Direction.Right;
                            break;
                        case ConsoleKey.W:
                            snake2.Direction = Direction.Up;
                            break;
                        case ConsoleKey.S:
                            snake2.Direction = Direction.Down;
                            break;

                    }
                }
                Thread.Sleep(200);
            }
        }


    }
}
