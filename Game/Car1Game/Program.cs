using System;
using System.Collections.Generic;
using System.Threading;

namespace Car1Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int LifeCount = 0;
            int Point = 0;
            List<Car> Cars = new List<Car>();
            var mainCar = MainCar();
            while (LifeCount>0)
            {
                Cars.Add(GetCarType());
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo PressedKey = Console.ReadKey(true);
                    KeyAvailable(PressedKey, mainCar);    
                }
                Cars.ForEach(x => x.Print());
                CarshCar(Cars,mainCar,LifeCount,Point);
                Cars.RemoveAll(x => x.Y >= mainCar.Y);
                Cars.ForEach(x => x.Y++);
                Thread.Sleep(300);
            }
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
        static void KeyAvailable(ConsoleKeyInfo PressedKey, Car car)
        {
            int X = 10;
            if (PressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (car.X <= 0)
                {
                    car.X++;
                }
            }
            if (PressedKey.Key == ConsoleKey.RightArrow)
            {
                if (car.X <= X)
                {
                    car.X--;
                }
            }
        }
        static void CarshCar(List<Car> cars, Car mainCar,int LifeCount,int Point)
        {
            foreach (var item in cars)
            {
                if(item.X==mainCar.X && item.Y==mainCar.Y && item.Cartype == CarType.EnemyCar)
                {
                    int X = 20;
                    int Y = 5;
                    CarType carType = CarType.Others;
                    Car car = new Car(X, Y, carType);
                    LifeCount--;
                    cars = new List<Car>();
                    Console.Clear();
                }
                if(item.X==mainCar.X && item.Y==mainCar.Y && item.Cartype == CarType.LifeCar)
                {
                    LifeCount++;
                }
                if(item.X==mainCar.X && item.Y==mainCar.Y && item.Cartype == CarType.PointCar)
                {
                    Point = Point + 10;
                    if (Point == 50)
                    {
                        LifeCount++;
                        Point = 0;
                    }
                }
            }
        }
    }
}
