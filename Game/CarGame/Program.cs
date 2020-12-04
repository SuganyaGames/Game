using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CarGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rant = new Random();
            int a = 10;
            int b = 20;
            int point = 0;
            int LifeCOunt = 5;
            var type = CarType.Car;
            List<Car> cars = new List<Car>();
            Car car1 = new Car(type, a, b);
            while (LifeCOunt>0)
            {
                while (Console.KeyAvailable)
                {
                    var PressedKey = Console.ReadKey(true);
                    if (PressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (car1.X > 0)
                        {
                            car1.X--;
                        }
                    }
                    if (PressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (car1.X < a)
                        {
                            car1.X++;
                        }
                    }
                }
                int x = rant.Next(0,11);
                int y = 1;
                var Type = GetCar();
                Car car = new Car(Type,x,y);
                cars.Add(car);
                car1.Print();
                cars.ForEach(x => x.Print());
                if (cars.Any(x => x.X == car1.X && x.Y == car1.Y))
                {
                    var hitCar = cars.First(x => x.X == car1.X && x.Y == car1.Y);
                    if (hitCar.type == CarType.PointCar)
                    {
                        point = point + 10;
                        if (point == 50)
                        {
                            LifeCOunt++;
                            point = 0;
                        }
                    }
                    if (hitCar.type == CarType.LifeCar)
                    {
                        LifeCOunt++;
                    }
                    if (hitCar.type  == CarType.EnemyCar)
                    {
                        LifeCOunt--;
                        Car car2 = new Car(CarType.Others, hitCar.X, hitCar.Y);
                        car2.Print();
                        if (LifeCOunt == 0)
                        {
                            Console.Clear();
                            cars.Clear();
                            Console.SetCursorPosition(20, 8);
                            Console.WriteLine("game is Over\n press any buttton");
                            break;
                        }
                    }
                }
                
            cars.RemoveAll(x => x.Y >= car1.Y);
            foreach (var item in cars)
            {
                item.Y++;
            }
            PrintPoint(LifeCOunt, point);
            Thread.Sleep(300);
            Console.Clear();
            }
        }
        static void PrintPoint(int LifeCOunt, int point)
        {
            Console.SetCursorPosition(20, 10);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"LifeCount:{LifeCOunt}");
            Console.SetCursorPosition(20, 12);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Point:{point}");

        }
        static CarType GetCar()
        {
            Random rant = new Random();
            int num=rant.Next(1, 13);
            if (num <= 6)
            {
                return CarType.EnemyCar;
            }
            else if (num<=10)
            {
                return CarType.LifeCar;
            }
            else if(num<=12)
            {
                return CarType.PointCar;
            }
            return CarType.Car;
        }
    }
}
