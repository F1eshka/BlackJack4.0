using PROJECT.BlackJack;
using System;
using System.Collections.Generic;

public class Player : IPlayer
{
    public string Name { get; private set; }
    public Hand Hand { get; private set; }
    public Hand SecondHand { get; private set; } 
    public decimal Bet { get; private set; }
    private Deck deck;
    private bool hasSplit; 

    public Player(string name, Deck deck)
    {
        Name = name;
        Hand = new Hand();
        SecondHand = null; 
        this.deck = deck;
        hasSplit = false;
    }

    // Установка ставки
    public void PlaceBet(decimal bet)
    {
        Bet = bet;
        Console.WriteLine($"{Name} поставил: ${bet}");
    }

    // "Double Down" — удваивает ставку и добавляет только одну карту
    public void DoubleDown()
    {
        Bet *= 2;
        AddCard(deck.DealCard());
        Console.WriteLine($"{Name} удвоил ставку до ${Bet} и получает одну дополнительную карту.");
    }

    // "Split" — разделение руки на две
    public void Split()
    {
        if (Hand.cards.Count == 2 && Hand.cards[0].Value == Hand.cards[1].Value)
        {
            hasSplit = true;
            SecondHand = new Hand();
            SecondHand.AddCard(Hand.cards[1]); 
            Hand.cards.RemoveAt(1); 

            Console.WriteLine($"{Name} сделал сплит. Теперь у игрока две руки.");
        }
        else
        {
            Console.WriteLine("Сплит невозможен. Карты должны быть одинакового ранга.");
        }
    }

    // Добавляем игроку карту в первую или вторую руку
    public void AddCard(Card card, bool toSecondHand = false)
    {
        if (hasSplit && toSecondHand)
        {
            SecondHand.AddCard(card);
            Console.WriteLine($"{Name} получает карту в свою вторую руку: {card}");
        }
        else
        {
            Hand.AddCard(card);
            Console.WriteLine($"{Name} получает карту: {card}");
        }
    }

    // Показ руки игрока
    public void ShowPlayerHand()
    {
        Console.Clear();
        Console.WriteLine(new string('=', 30));
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{Name} имеет следующие карты:");
        Console.ResetColor();
        Console.WriteLine(Hand);
        Console.WriteLine($"Очки первой руки: {Hand.CalculateValue()}");

        if (hasSplit && SecondHand != null)
        {
            Console.WriteLine("Вторая рука:");
            Console.WriteLine(SecondHand);
            Console.WriteLine($"Очки второй руки: {SecondHand.CalculateValue()}");
        }

        if (HasBusted())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} проиграл! Перебор очков.");
            Console.ResetColor();
        }

        Console.WriteLine(new string('=', 30));
    }

    // Проверка перебора очков для первой руки
    public bool HasBusted()
    {
        return Hand.IsBusted();
    }

    // Проверка перебора очков для второй руки (если был сплит)
    public bool SecondHandHasBusted()
    {
        return hasSplit && SecondHand.IsBusted();
    }
}
