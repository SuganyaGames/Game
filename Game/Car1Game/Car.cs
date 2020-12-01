using System;
using System.Collections.Generic;
using System.Text;

namespace Car1Game
{
    class Car
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CarType Cartype { get; set; }
        public Car(int x,int y, CarType cartype)
        {
            X = x;
            Y = y;
            Cartype = cartype;
        }
        public CarType GetCarType()
        {
            if (Cartype == CarType.Car)
            {
                return CarType.Car;
            }
            else if (Cartype == CarType.EnemyCar)
            {
                return CarType.EnemyCar;
            }
            else if (Cartype == CarType.LifeCar)
            {
                return CarType.LifeCar;
            }
            else if (Cartype == CarType.PointCar)
            {
                return CarType.PointCar;
            }
            else
            {
                return CarType.Others;
            }
        }
        public char GetSymbol()
        {
            if (Cartype == CarType.Car)
            {
                return '@';
            }
            else if (Cartype == CarType.EnemyCar)
            {
                return '#';
            }
            else if (Cartype == CarType.LifeCar)
            {
                return '*';
            }
            else if (Cartype ==CarType.PointCar)
            {
                return '$';
            }
            else
            {
                return 'X';
            }
        }
        public ConsoleColor GetColor()
        {
            if (Cartype == CarType.Car)
            {
                return ConsoleColor.Green;
            }
            else if (Cartype == CarType.EnemyCar)
            {
                return ConsoleColor.DarkBlue;
            }
            else if (Cartype == CarType.LifeCar)
            {
                return ConsoleColor.DarkYellow;
            }
            else if (Cartype == CarType.PointCar)
            {
                return ConsoleColor.DarkMagenta;
            }
            else
            {
                return ConsoleColor.DarkRed;
            }
        }
        public void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = GetColor();
            Console.WriteLine(GetSymbol());
        }
    }
}
