using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Cards cards = new Cards();
            cards.Shuffle();
            Player player1 = new Player("Sugu");
            Player player2 = new Player("Venkat");
            player1.Cards.Add(cards.TakeElement());
            player1.Cards.Add(cards.TakeElement());
            player2.Cards.Add(cards.TakeElement());
            player2.Cards.Add(cards.TakeElement());
            var isFirstPlayer = true;
            while (true)
            {
                var player = isFirstPlayer ? player1 : player2;
                Console.WriteLine($"{player.Name} enter 'Hit' or 'Stand': ");
                string str = Console.ReadLine();
                if (str == "Hit")
                {
                    player.Cards.Add(cards.TakeElement());
                }
                else
                {
                    if (isFirstPlayer)
                    {
                        isFirstPlayer = false;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            int ValueP1 = player1.GetPoint();
            int ValueP2 = player2.GetPoint();
            if (ValueP1 > 21 && ValueP2<=21)
            {
                Console.WriteLine($"{player2.Name} win");
            }
            else if (ValueP2 > 21 && ValueP1<=21)
            {
                Console.WriteLine($"{player1.Name} win");
            }
            else if(ValueP1>ValueP2)
            {
                Console.WriteLine($"{player1.Name} win");
            }
            else if (ValueP2 > ValueP1)
            {
                Console.WriteLine($"{player2.Name} win");
            }
            else if (ValueP2 == ValueP1)
            {
                Console.WriteLine($"{player2.Name} and {player1.Name} win");
            }
            else
            {
                Console.WriteLine("No person win");
            }
            player1.print();
            player2.print();
            Console.WriteLine("Game end");
        }
    }
}
