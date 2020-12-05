using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Card
    {
        public CardType cardType { get; set; }
        public CardValue cardValue { get; set; }
        public Card(CardType cardtype,CardValue cardvalue)
        {
            cardType = cardtype;
            cardValue = cardvalue;
        }
    }
}
