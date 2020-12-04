using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TikTok
{
    class Board
    {
        public Board()
        {
            str = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        }
        public string[] str { get; set; }
        public void Print()
        {
            int n = 0;
            for (int i = 0; i <=6; i++)
            {
                for (int j = 0; j <=6; j++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write("_");
                    }
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        Console.Write("|");
                    }
                    if (i % 2 != 0 && j % 2 != 0)
                    {
                        Console.Write(str[n]);
                        n++;
                    }
                }
                Console.WriteLine();
            }
        }
        public bool Full_Board_Check()
        {
            return str.All(x=>x!=" ");
        }
        public string Win_Check()
        {
            if(str[0]==str[1] && str[1] == str[2])
            {
                return str[0];
            }
            if (str[3] == str[4] && str[4] == str[5])
            {
                return str[3];
            }
            if (str[6] == str[7] && str[7] == str[8])
            {
                return str[6];
            }
            if (str[0] == str[3] && str[3] == str[6])
            {
                return str[0];
            }
            if (str[4] == str[1] && str[1] == str[7])
            {
                return str[4];
            }
            if (str[5] == str[2] && str[8] == str[2])
            {
                return str[2];
            }
            if (str[0] == str[4] && str[0] == str[8])
            {
                return str[0];
            }
            if (str[2] == str[4] && str[6] == str[2])
            {
                return str[2];
            }
            return "Not Win";
        }
        public bool Player_Check()
        {
            if (Win_Check() == "X")
            {
                Console.WriteLine("Player1 win");
                return true;
            }
            else if (Win_Check() == "O")
            {
                Console.WriteLine("Player2 win");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Put_element(bool first)
        {
            Console.Write("enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            string strg=" ";
            strg = first ? "X" : "O";
            if(str[num]==" ")
            {
                str[num] = strg;
            }
            else
            {
                Put_element(first);
            }
        }
    }
}
