using PROJECT.BlackJack;
using System.Collections.Generic;

public class Hand
{
    public List<Card> cards;
    private Card hiddenCard;

    public Hand()
    {
        cards = new List<Card>();
    }

    // Добавление карты в руку
    public void AddCard(Card card, bool isHidden = false)
    {
        if (isHidden)
        {
            hiddenCard = card; // Скрытая карта для дилера
        }
        else
        {
            cards.Add(card);
        }
    }

    // Счёт очков с учётом тузов
    public int CalculateValue()
    {
        int totalValue = 0;
        int aceCount = 0;

        foreach (var card in cards)
        {
            totalValue += card.Value;

            // Считаем количество тузов
            if (card.Rank == "A")
            {
                aceCount++;
            }
        }

        // Если у нас есть туз, и сумма больше 21, считаем туз как 1 очко, а не 11
        while (totalValue > 21 && aceCount > 0)
        {
            totalValue -= 10;
            aceCount--;
        }

        return totalValue;
    }

    // Проверка, если очков больше 21
    public bool IsBusted()
    {
        return CalculateValue() > 21;
    }

    // Создание новой руки для сплита
    public Hand Split()
    {
        if (cards.Count == 2 && cards[0].Value == cards[1].Value)
        {
            Hand newHand = new Hand();
            newHand.AddCard(cards[1]);  // Вторую карту переносим в новую руку
            cards.RemoveAt(1);  // Удаляем вторую карту из текущей руки
            return newHand;
        }
        return null;  // Если карты не одинаковы, вернуть null
    }

    // Отображение карт в руке
    public override string ToString()
    {
        string handDescription = "Карты в руке: ";
        foreach (var card in cards)
        {
            handDescription += $"{card} ";
        }

        // Если есть скрытая карта, не показываем ее
        if (hiddenCard != null)
        {
            handDescription += "(одна карта скрыта)";
        }
        return handDescription;
    }

    // Возвращаем количество карт в руке, включая скрытую
    public int CardsRemaining()
    {
        return cards.Count + (hiddenCard != null ? 1 : 0);
    }

    // Отображение только открытых карт
    public string ShowVisibleCards()
    {
        string visibleCardsDescription = "Открытые карты: ";
        foreach (var card in cards)
        {
            visibleCardsDescription += $"{card} ";
        }
        return visibleCardsDescription.Trim();
    }

    // Получение скрытой карты 
    public Card GetHiddenCard()
    {
        return hiddenCard;
    }

    // Метод для сброса скрытой карты
    public void RevealHiddenCard()
    {
        if (hiddenCard != null)
        {
            cards.Add(hiddenCard);  // Добавляем скрытую карту в видимые
            hiddenCard = null;  // Сбрасываем скрытую карту
        }
    }
}
