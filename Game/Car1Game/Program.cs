using System;
using System.Collections.Generic;
using System.Threading;

namespace Car1Game
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int LifeCount = 5;
            int Point = 0;
            List<Car> Cars = new List<Car>();
            Car mainCar = MainCar();

            while (LifeCount>0)
            {
                Cars.Add(GetCarType());
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo PressedKey = Console.ReadKey(true);
                    KeyAvailable(PressedKey,mainCar);    
                }
                mainCar.Print();
                Cars.ForEach(x => x.Print());
                Print_Life_Point(LifeCount,Point);
                bool hitenemycar=HitEnemyCar(Cars, mainCar);
                if (hitenemycar)
                {
                    CarType carType = CarType.Others;
                    Car car = new Car(mainCar.X,mainCar.Y,carType);
                    car.Print();
                    LifeCount--;
                    Cars = new List<Car>();
                }
                bool hitlifecar = HitLifeCar(Cars, mainCar);
                if (hitlifecar)
                {
                    LifeCount++;
                }
                bool hitpointcar = HitPointCar(Cars, mainCar);
                if (hitpointcar)
                {

                    Point = Point + 10;
                    if (Point == 50)
                    {
                        LifeCount++;
                        Point = 0;
                    }
                }
                Cars.RemoveAll(x => x.Y >= mainCar.Y);
                Cars.ForEach(x => x.Y++);
                Thread.Sleep(300);
                Console.Clear();
            }
        }
        static void Print_Life_Point(int LifeCount,int Point)
        {
            int X1 = 20;
            int Y1= 5;
            Console.SetCursorPosition(X1, Y1);
            Console.ForegroundColor =ConsoleColor.DarkCyan;
            Console.WriteLine($"LifeCount is: {LifeCount}");
            int X2 = 20;
            int Y2 = 7;
            Console.SetCursorPosition(X2, Y2);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"point is: {Point}");
            Console.WriteLine();
        }
        static Car GetCarType()
        {
            Random rant = new Random();
            int X = rant.Next(0, 11);
            int Y = 1;
            int n = rant.Next(0, 12);
            CarType Cartype = n<=6 ? CarType.EnemyCar : (n<=8 ? CarType.LifeCar : CarType.PointCar);            
            Car car = new Car(X,Y,Cartype);
            return car;
        }
        static Car MainCar()
        {
            int X = 10;
            int Y = 20;
            CarType Cartype = CarType.Car;
            Car car = new Car(X,Y,Cartype);
            return car;
        }
        static void KeyAvailable(ConsoleKeyInfo PressedKey,Car mainCar)
        {
            int X = 10;
            if (PressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (mainCar.X > 0)
                {
                    mainCar.X--;
                }
            }
            if (PressedKey.Key == ConsoleKey.RightArrow)
            {
                if (mainCar.X < X)
                {
                    mainCar.X++;
                }
            }
        }
        static bool HitLifeCar(List<Car> cars, Car mainCar)
        {
            foreach (var item in cars)
            {
                if (item.X == mainCar.X && item.Y == mainCar.Y && item.Cartype == CarType.LifeCar)
                {
                    return true;
                }
            }
            return false;
        }
        static bool HitPointCar(List<Car> cars, Car mainCar)
        {
            foreach (var item in cars)
            {
                if (item.X == mainCar.X && item.Y == mainCar.Y && item.Cartype == CarType.PointCar)
                {
                    return true;
                }
            }
            return false;
        }
        static bool HitEnemyCar(List<Car> cars, Car mainCar)
        {
            foreach (var item in cars)
            {
                if (item.X == mainCar.X && item.Y == mainCar.Y && item.Cartype == CarType.EnemyCar)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
