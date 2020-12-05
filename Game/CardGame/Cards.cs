using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Cards
    {
        public List<Card> cards { get; set; }
        public Cards()
        {
            cards = new List<Card>();
            for (int i = 1 ; i <=4; i++)
            {
                for (int j = 1; j <=13; j++)
                {
                    cards.Add(new Card((CardType)i,(CardValue)j));
                }
            }
        }
        public void Print()
        {
            foreach (var item in cards)
            {
                Console.Write(item.cardType+" of "+item.cardValue+", ");
            }
        }
        public void Shuffle()
        {
            var rnd = new Random();
            cards = cards.OrderBy(item => rnd.Next()).ToList();
        }
        public Card TakeElement()
        {
            var firstCard = cards[0];
            cards.Remove(firstCard);
            return firstCard;
        }
    }
}
