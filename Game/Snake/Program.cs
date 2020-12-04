using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Snake
{
    class Program
    {
        static List<Snake> snakes { get; set; }
        static void Main(string[] args)
        {
            Console.BufferWidth = Console.WindowWidth = 80;
            Console.BufferHeight = Console.WindowHeight = 30;
            ConsoleKey Direction = ConsoleKey.RightArrow;
            var sneaks = SnakePrint();
            sneaks.ForEach(x => x.Print());
            var snakeFood = FoodPoint();
            var snakesDangerous = DangerousPoint();
            snakesDangerous.ForEach(x => x.Print());
            snakeFood.Print();
            int Point = 50;
            int Time = 0;
            while (Point > 0)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo PressedKey = Console.ReadKey(true);
                    Direction = PressedKey.Key;
                }

                var snake = KeyAvailable(Direction);
                snake.Print();
                if(snakes.Any(x=>x.X==snake.X && x.Y == snake.Y))
                {
                    //Point = Point - 10;
                    break;
                }
                snakes.Insert(snakes.Count, snake);
                if (!GetFood(snake, snakeFood))
                {
                    snakes[0].Clear();
                    snakes.RemoveAt(0);
                }
                else
                {
                    snakeFood = FoodPoint();
                    snakeFood.Print();
                }
                
                
                if (Time > 50)
                {
                    snakeFood.Clear();
                    snakeFood = FoodPoint();
                    snakeFood.Print();
                    Time = 00;
                }
                var hitsnake = HitSnake(snakesDangerous, snake);
                Point = hitsnake ? Point -= 10 : Point;
                Time++;
                Print_Time_point(Time, Point);
                Thread.Sleep(300);
            }
        }
        static List<Snake> SnakePrint()
        {
            snakes = new List<Snake>();
            snakes.Add(new Snake(15, 20, SnakeTypes.Snake));
            snakes.Add(new Snake(16, 20, SnakeTypes.Snake));
            snakes.Add(new Snake(17, 20, SnakeTypes.Snake));
            snakes.Add(new Snake(18, 20, SnakeTypes.Snake));
            return snakes;
        }
        static Snake KeyAvailable(ConsoleKey Direction)
        {
            var head = snakes[snakes.Count - 1];
            var newHead = new Snake(snakes[0].X, snakes[0].Y, SnakeTypes.Snake);
            if (Direction == ConsoleKey.LeftArrow)
            {
                newHead.X = head.X - 1;
                newHead.Y = head.Y;
                //Tail.X = Tail.X <= 0 ? Console.WindowWidth - 1 : Tail.X;
            }
            else if (Direction == ConsoleKey.RightArrow)
            {
                newHead.X = head.X + 1;
                newHead.Y = head.Y;
                //Tail.X = Tail.X >= Console.WindowWidth - 1 ? 0 : Tail.X;
            }
            else if (Direction == ConsoleKey.UpArrow)
            {
                newHead.Y = head.Y - 1;
                newHead.X = head.X;
                //Tail.Y = Tail.Y <= 0 ? Console.WindowHeight - 1 : Tail.Y;
            }
            else if (Direction == ConsoleKey.DownArrow)
            {
                newHead.Y = head.Y + 1;
                newHead.X = head.X;
                //Tail.Y = Tail.Y >= Console.WindowHeight - 1 ? 0 : Tail.Y;
            }
            return newHead;
        }
        static List<Snake> DangerousPoint()
        {
            var snakes = new List<Snake>();
            snakes.Add(new Snake(20, 15, SnakeTypes.Dangerous));
            snakes.Add(new Snake(15, 15, SnakeTypes.Dangerous));
            snakes.Add(new Snake(5, 7, SnakeTypes.Dangerous));
            snakes.Add(new Snake(10, 25, SnakeTypes.Dangerous));
            return snakes;
        }
        static Snake FoodPoint()
        {
            Random rant = new Random();
            int X = rant.Next(1, 50);
            int Y = rant.Next(1, 30);
            SnakeTypes snakeType = SnakeTypes.Food;
            Snake snake = new Snake(X, Y, snakeType);
            return snake;
        }
        static bool GetFood(Snake snake, Snake snakeFood)
        {
            if (snake.X == snakeFood.X && snake.Y == snakeFood.Y)
            {
                return true;
            }
            return false;
        }
        static bool HitSnake(List<Snake> dangerous, Snake snake)
        {
            Random rant = new Random();
            int X = rant.Next(1, 80);
            int Y = rant.Next(1, 30);
            SnakeTypes snakeType = SnakeTypes.Dangerous;
            if (dangerous.Any(x => x.X == snake.X && x.Y == snake.Y))
            {
                var danger = new Snake(X, Y, snakeType);
                danger.Print();
                dangerous.Add(danger);
                return true;
            }
            return false;
        }
        static void Print_Time_point(int Time, int Point)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(50, 10);
            Console.WriteLine($"TIme is: {Time}  ");
            Console.SetCursorPosition(50, 12);
            Console.WriteLine($"Point is: {Point}");
        }
    }
}
