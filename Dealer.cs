using PROJECT.BlackJack;

public class Dealer : IDealer
{
    private Hand hand; 
    private Deck deck;

    public Dealer(Deck deck)
    {
        this.deck = deck;
        hand = new Hand();
    }

    public Hand Hand 
    {
        get { return hand; }
    }

    //Добавляем карту
    public void AddCard(Card card)
    {
        hand.AddCard(card);
    }

    //Ход дилера в зависимосте от игрока
    public void PlayTurn(bool playerBusted)
    {

        int totalValue = hand.CalculateValue();
        if (!playerBusted) 
        {
            while (hand.CalculateValue() <= 17) 
            {
                AddCard(deck.DealCard());
                Console.WriteLine(hand);
                Console.WriteLine($"Очки1: {totalValue}");
            }
        }
     
        else
        {
            AddCard(deck.DealCard());
            Console.WriteLine(hand);
            Console.WriteLine($"Очки: {totalValue}");
        }
    }

    //Показываем открытую карту дилера
    public void ShowFirstCard()
    {
        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.WriteLine($"Первая карта дилера:");
        Console.ResetColor(); 
        Console.WriteLine($"Карта: {hand.cards[0]}");

        Console.WriteLine(new string('=', 30)); 
    }

    //Показываем руку дилера
        public void ShowHand()
        {
            Console.WriteLine(new string('=', 30)); 
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine($"Дилер имеет следующие карты:");
            Console.ResetColor(); 
            Console.WriteLine(hand);
            Console.WriteLine($"Очки: {Hand.CalculateValue()}");

            Console.WriteLine(new string('=', 30)); 
        }

    }

