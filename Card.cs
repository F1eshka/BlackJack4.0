using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.BlackJack
{
    public class Card
    {
        public string Suit;
        public string Rank;

        public static  List<string> Suits = new List<string> { "♥", "♦", "♣", "♠" };
        public static List<string> Ranks = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public void SetSuit(string Suit)
        {
            this.Suit = Suit;
        }
        public string GetSuit()
        {
            return Suit;
        }
        public void SetRank(string Rank)
        {
            this.Rank = Rank;
        }
        public string GetRank()
        {
            return Rank;
        }



        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Card()
        {
        }

        // Возвращение очков соответствующих карт 
        public int Value
        {
            get
            {
                if (Rank == "J" ||  Rank == "Q" || Rank == "K")
                {
                    return 10;
                }else if (Rank == "A")
                {
                    return 11;
                }else
                {
                    return int.Parse(Rank); 
                }
            }
        }

        //Отображение масти и ранга
        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }

    }
}
