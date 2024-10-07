using System;

namespace PROJECT.BlackJack
{
    internal class Menu
    {
        private string[] menuOptions = { "Начать игру", "Правила игры", "О разработчике" };
        private int currentSelection = 0; 

        public void DisplayMenu()
        {
            Console.Clear(); 
            Console.Title = "Black Jack Game"; 
            DrawTitle();  
            ShowOptions();
        }

        // Отображение заголовка
        private void DrawTitle()
        {
            string title = "====BLACK JACK====";
            int screenWidth = Console.WindowWidth;
            int titlePosition = (screenWidth / 2) - (title.Length / 2);

            Console.SetCursorPosition(titlePosition, 2);
            Console.WriteLine(title);
        }

        // Отображение пунктов меню
        private void ShowOptions()
        {
            int screenWidth = Console.WindowWidth;

            for (int i = 0; i < menuOptions.Length; i++)
            {
                int optionPosition = (screenWidth / 2) - (menuOptions[i].Length / 2);
                Console.SetCursorPosition(optionPosition, 5 + i * 2);

              
                if (i == currentSelection)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;  
                    Console.ForegroundColor = ConsoleColor.Black; 
                }

                Console.WriteLine(menuOptions[i]);

                Console.ResetColor();
            }

            Console.SetCursorPosition((screenWidth / 2) - 12, 5 + menuOptions.Length * 2);
            Console.WriteLine("Используйте стрелки вверх/вниз и нажмите Enter");
        }

        // Запуск меню
        public void StartMenu()
        {
            while (true)
            {
                DisplayMenu(); 

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentSelection--; 
                        if (currentSelection < 0)
                            currentSelection = menuOptions.Length - 1; 
                        break;
                    case ConsoleKey.DownArrow:
                        currentSelection++; 
                        if (currentSelection >= menuOptions.Length)
                            currentSelection = 0; 
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (currentSelection)
                        {
                            case 0:
                                Console.WriteLine(new string('=', 30)); 
                                Console.WriteLine("Добро пожаловать в игру BlackJack");
                                Console.WriteLine(new string('=', 30));
                                Game game = new Game();
                                game.Start();
                                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                                break;
                            case 1:
                                ShowRules();
                                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                                break;
                            case 2:
                                ShowAbout();
                                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                                break;
                        }
                        break;
                }

               
            }
        }

        // Правила игры
        private void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Правила игры:");
            Console.WriteLine("\n1. Цель игры\nЦель игрока — набрать количество очков, максимально близкое к 21, не превышая это число. " +
                             "Игроки играют против дилера, а не друг против друга");
            Console.WriteLine("\n2. Значения карт\nЧисловые карты (2-10): номинальное значение.\nКарты с лицами (Валет, Дама, Король): 10 очков.\n" +
                             "Туз: может стоить 1 или 11 очков (выбирается в зависимости от ситуации).");
            Console.WriteLine("\n3. Начало игры\nКаждый игрок и дилер получают по две карты.\n" +
                             "Игроки обычно видят свои карты, а одна карта дилера открыта (показываемая), а другая закрыта (призрачная)");
            Console.WriteLine("\n4. Ход игры \nHit(взять карту): игрок может взять дополнительную карту, чтобы увеличить свою сумму очков\n" +
                             "Stand(остановиться): игрок решает не брать больше карт и сохраняет текущую сумму\n" +
                             "Double Down(удвоить): игрок удваивает свою ставку и получает только одну дополнительную карту\n" +
                             "Split(разделить): если у игрока две карты одинаковой ценности, он может разделить их на два отдельных рук, сделав дополнительную ставку на вторую руку\n");
            Console.WriteLine("\n5. Завершение раунда\n" +
                             "После того как игроки закончили свои ходы, дилер открывает свою закрытую карту\n" +
                             "Дилер должен брать карты, пока его сумма очков не достигнет 17 или больше");
            Console.WriteLine("\n6. Начало игры\nКаждый игрок и дилер получают по две карты.\n" +
                             "Игроки обычно видят свои карты, а одна карта дилера открыта (показываемая), а другая закрыта (призрачная)");
            Console.WriteLine("\n7. Победа и проигрыш\n" +
                             "Если сумма очков игрока превышает 21, он 'бусти' и автоматически проигрывает\n" + 
                             "Если сумма очков игрока выше, чем у дилера(но не более 21), игрок выигрывает и получает выплату 1:1\n" +
                             "Если у дилера сумма очков больше, игрок проигрывает\n" +
                             "Если у игрока и дилера одинаковая сумма, это считается 'ничьей', и ставка возвращается");
            Console.WriteLine("\n8. Особые случаи\n" +
                             "BlackJack: если у игрока на первых двух картах туз и 10(или карта с лицом), это называется 'BlackJack' Обычно выплата за это составляет 3:2" +
                             "Страховка: если у дилера открытый туз, игроки могут сделать дополнительную ставку на то, что у дилера будетBlackJack");
        }

        //О разработчике
        private void ShowAbout()
        {
            Console.Clear();
            Console.WriteLine("О разработчике:");
            Console.WriteLine("Разработчик: Беноева Малика П26");
        }
    }
}
