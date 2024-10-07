using PROJECT.BlackJack;
using System;

public class Game
{
    private Deck deck;
    private IPlayer player;
    private IDealer dealer;
    private decimal playerMoney = 100;  
    private decimal currentBet;

    public Game() { }

    //Начало игры
    public void Start()
    {
        do // Цикл для новой игры
        {
            deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("Введите имя игрока:");
            string playerName = Console.ReadLine();
            player = new Player(playerName, deck);
            dealer = new Dealer(deck);

            PlaceBet(); 

            
            for (int i = 0; i < 2; i++)
            {
                player.AddCard(deck.DealCard());
            }

            dealer.AddCard(deck.DealCard());
            dealer.AddCard(deck.DealCard());

            player.ShowPlayerHand();
            dealer.ShowFirstCard();

            HandlePlayerChoices();

            if (!player.HasBusted())
            {
                Console.WriteLine($"{dealer} показывает свои карты:");
                dealer.ShowHand();
                DealerTurn();
            }

            DetermineWinner();
        } while (PlayAgain()); // Новый цикл игры
    }

    //Ставка
    private void PlaceBet()
    {
        Console.WriteLine($"Ваш баланс: ${playerMoney}");
        Console.WriteLine("Выберите ставку: 10, 25, 50 или 100");

        while (true)
        {
            if (decimal.TryParse(Console.ReadLine(), out currentBet) &&
                (currentBet == 10 || currentBet == 25 || currentBet == 50 || currentBet == 100) &&
                currentBet <= playerMoney)
            {
                playerMoney -= currentBet;
                break;
            }
            else
            {
                Console.WriteLine("Некорректная ставка. Попробуйте снова.");
            }
        }

        Console.WriteLine($"Вы сделали ставку: ${currentBet}");
    }

    // Обработка действий игрока (включая Double Down и Split)
    private void HandlePlayerChoices()
    {
        while (true)
        {
            player.ShowPlayerHand();
            dealer.ShowFirstCard();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Выберите действие: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("'H'");
            Console.ResetColor();
            Console.Write(" - Взять карту\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("'S'");
            Console.ResetColor();
            Console.Write(" -Остановиться\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("'D'");
            Console.ResetColor();
            Console.Write(" -Double Down\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("'P' ");
            Console.ResetColor();
            Console.Write("-Split\n"); 

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.H) 
            {
                Card drawnCard = deck.DealCard();
                player.AddCard(drawnCard);

                if (player.HasBusted())
                {
                    break;
                }
            }
            else if (keyInfo.Key == ConsoleKey.S) 
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.D && player.Hand.cards.Count == 2) 
            {
                currentBet *= 2;  
                Console.WriteLine($"Ставка удвоена до: ${currentBet}");
                playerMoney -= currentBet / 2;  

                Card drawnCard = deck.DealCard();
                player.AddCard(drawnCard);

                break; 
            }
            else if (keyInfo.Key == ConsoleKey.P && player.Hand.cards.Count == 2 &&
                     player.Hand.cards[0].Value == player.Hand.cards[1].Value) 
            {
                Console.WriteLine("Вы выбрали Split!");
                Hand secondHand = player.Hand.Split(); 
                playerMoney -= currentBet;  
                Console.WriteLine($"Вторая рука создана, новая ставка: ${currentBet}");

                
                PlayHand(player.Hand);
                PlayHand(secondHand);

                break; 
            }
        }
    }

    // Игра с одной рукой (для сплита)
    private void PlayHand(Hand hand)
    {
        while (!hand.IsBusted())
        {
            Console.WriteLine($"Текущие карты: {hand}");
            Console.WriteLine("Нажмите 'H' чтобы взять карту, или 'S' чтобы остановиться.");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.H)
            {
                Card drawnCard = deck.DealCard();
                hand.AddCard(drawnCard);
                Console.WriteLine($"Вы получили карту: {drawnCard}");
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
                break;
            }
        }
    }

    //Ход дилера
    private void DealerTurn()
    {
        while (dealer.Hand.CalculateValue() < 17)
        {
            Card dealerDrawnCard = deck.DealCard();
            dealer.AddCard(dealerDrawnCard);
            Console.WriteLine($"{dealer} получает карту: {dealerDrawnCard}");
            dealer.ShowHand();
        }
    }

    //Определение победителя
    private void DetermineWinner()
    {
        int playerPoints = player.Hand.CalculateValue();
        int dealerPoints = dealer.Hand.CalculateValue();

        if (playerPoints > 21)
        {
            Console.WriteLine($"{player.Name} проиграл 💔 Перебор очков 😭");
        }
        else if (dealerPoints > 21 || playerPoints > dealerPoints)
        {
            Console.WriteLine($"{player.Name} выиграл 💖");
            playerMoney += currentBet * 2;  
        }
        else if (playerPoints < dealerPoints)
        {
            Console.WriteLine("Дилер выиграл 💖");
        }
        else
        {
            Console.WriteLine("Ничья 👌");
            playerMoney += currentBet; 
        }

        Console.WriteLine($"Ваш текущий баланс: ${playerMoney}");
    }

    //Для игры заново
    private bool PlayAgain()
    {
        Console.WriteLine("Хотите сыграть еще раз? (Y/N)");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        return keyInfo.Key == ConsoleKey.Y;
    }
}
