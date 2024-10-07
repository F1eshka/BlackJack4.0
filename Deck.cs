using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.BlackJack
{
    public class Deck
    {
        private List<Card> cards;

        // Генерация всех карт
        public Deck()
        {
            cards = new List<Card>();

            foreach (var Suit in Card.Suits)
            {
                foreach (var Rank in Card.Ranks)
                {
                    cards.Add(new Card(Rank, Suit));
                }
            }

        }

        // Перемешиваем колоду
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        //Действия с картами
        public Card DealCard()
        {
            Card dealcard = cards[0];
            cards.RemoveAt(0); 
            return dealcard; 
        }

    }
}
