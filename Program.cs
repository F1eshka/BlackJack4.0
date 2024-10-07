using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.BlackJack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Animation animation = new Animation();
            animation.ShowAnimation();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu menu = new Menu();  
            menu.StartMenu();  
        }

        }
    }


    

