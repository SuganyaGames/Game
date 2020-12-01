using System;
using System.Collections.Generic;
using System.Text;

namespace CarGame
{
    class Car
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CarType type { get; set; }
        public Car(CarType Type,int x,int y)
        {
            type = Type;
            X = x;
            Y = y;
        }
        public char CarSymbol(CarType type)
        {
            if (CarType.Car==type)
            {
                return '@';
            }
            else if (CarType.EnemyCar == type)
            {
                return '#';
            }
            else if (CarType.LifeCar == type)
            {
                return '*';
            }
            else if (CarType.PointCar == type)
            {
                return '-';
            }
            else
            {
                return 'X';
            }
        }
        public ConsoleColor CarColor(CarType type)
        {
            if (CarType.Car == type)
            {
                return ConsoleColor.Green;
            }
            else if (CarType.EnemyCar == type)
            {
                return ConsoleColor.DarkBlue;
            }
            else if (CarType.LifeCar == type)
            {
                return ConsoleColor.DarkYellow;
            }
            else if (CarType.PointCar == type)
            {
                return ConsoleColor.White;
            }
            else
            {
                return ConsoleColor.DarkMagenta;
            }
        }
        public void Print()
        {
            Console.ForegroundColor = CarColor(type);
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(CarSymbol(type));
        }
    }
}
