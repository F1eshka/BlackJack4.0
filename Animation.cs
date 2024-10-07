using System;
using System.Threading;

public class Animation
{
    public void ShowAnimation()
    {
        Console.Clear();
        DisplayCenteredText("Shuffling the deck...");
        Thread.Sleep(1000);

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            DisplayShufflingEffect();
            Thread.Sleep(300);
        }

        Console.Clear();
        DisplayCenteredText("WISH YOU LUCK!!!");
        Thread.Sleep(1500);
    }

    // Метод для центрирования текста
    private void DisplayCenteredText(string message)
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        // Рассчитываем позицию по центру
        int x = (windowWidth - message.Length) / 2;
        int y = windowHeight / 2;

        // Устанавливаем курсор и выводим текст
        Console.SetCursorPosition(x, y);
        Console.WriteLine(message);
    }

    // Эффект карт
    private void DisplayShufflingEffect()
    {
        char[] suits = { '♥', '♦', '♣', '♠' };
        string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int suitIndex = rand.Next(0, suits.Length);
            int rankIndex = rand.Next(0, ranks.Length);

            string card = $"{ranks[rankIndex]} {suits[suitIndex]}";
            Console.SetCursorPosition(rand.Next(0, Console.WindowWidth - 5), rand.Next(0, Console.WindowHeight - 2));
            Console.Write(card);
        }
    }
}
