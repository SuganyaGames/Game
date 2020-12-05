using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Player
    {
        public string  Name { get; set; }
        public List<Card> Cards { get; set; }
        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }
        public int GetPoint()
        {
            int Count = 0;
            foreach (var item in Cards)
            {
                Count +=(int)item.cardValue;
            }
            return Count;
        }
        public void print()
        {
            Console.WriteLine(Name);
            foreach (var item in Cards)
            {
                Console.WriteLine(item.cardValue+" "+item.cardType+" = "+ (int)item.cardValue);
                Console.WriteLine();
            }
        }
    }
}
