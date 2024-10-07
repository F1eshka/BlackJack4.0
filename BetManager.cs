using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BetManager
{
    public int Balance { get; private set; }
    public int CurrentBet { get; private set; }

    public BetManager()
    {
        Balance = 100; // Начальный баланс игрока
    }

    // Метод для установки ставки
    public bool PlaceBet(int amount)
    {
        if (amount <= Balance && (amount == 10 || amount == 25 || amount == 50 || amount == 100))
        {
            CurrentBet = amount;
            Balance -= amount; // Вычитаем ставку из баланса
            return true;
        }
        else
        {
            Console.WriteLine("Недостаточно средств или некорректная ставка.");
            return false;
        }
    }

    // Метод для выплат
    public void Payout(bool playerWon, bool blackjack = false)
    {
        if (playerWon)
        {
            int payout = blackjack ? (int)(CurrentBet * 2.5) : CurrentBet * 2; // 3:2 за BlackJack, 1:1 за обычную победу
            Balance += payout;
            Console.WriteLine($"Вы выиграли! Выплата: {payout}$.");
        }
        else
        {
            Console.WriteLine($"Вы проиграли. Ставка {CurrentBet}$ потеряна.");
        }
        CurrentBet = 0; // Обнуляем текущую ставку
    }

    // Метод для ничьи
    public void Push()
    {
        Balance += CurrentBet; // Возвращаем ставку
        CurrentBet = 0;
        Console.WriteLine("Ничья. Ваша ставка возвращена.");
    }

    // Метод для удвоенной ставки
    public bool DoubleDown()
    {
        if (Balance >= CurrentBet)
        {
            Balance -= CurrentBet; // Удваиваем ставку
            CurrentBet *= 2;
            return true;
        }
        else
        {
            Console.WriteLine("Недостаточно средств для удвоения ставки.");
            return false;
        }
    }

    // Метод для отображения баланса
    public void ShowBalance()
    {
        Console.WriteLine($"Ваш текущий баланс: {Balance}$.");
    }
}

