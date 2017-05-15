using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{

    class Program
    {
        protected static string[] AllMonarchs(Country[] countries, string continent)
        {
            
        }

        protected static int SelectorY(string[] items)
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            int top = Console.CursorTop, left = 4;
            int currentSelection = 0, previousSelection = 1;

            for (var i = 0; i < items.Length; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.WriteLine(items[i]);
            }

            bool selected = false;
            do
            {
                Console.SetCursorPosition(left, top + previousSelection);
                Console.WriteLine(items[previousSelection]);

                Console.SetCursorPosition(left, top + currentSelection);
                {
                    var temp = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = temp;
                }
                Console.WriteLine(items[currentSelection]);
                {
                    var temp = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = temp;
                }


                previousSelection = currentSelection;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        currentSelection++;
                        break;
                    case ConsoleKey.UpArrow:
                        currentSelection--;
                        break;
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                }

                if (currentSelection < 0)
                    currentSelection = items.Length - 1;
                else if (currentSelection == items.Length)
                    currentSelection = 0;
            } while (!selected);

            Console.CursorTop = top + items.Length;
            ClearLines(items.Length);
            Console.SetCursorPosition(left, top);
            Console.WriteLine(items[currentSelection]);

            Console.CursorTop++;
            Console.CursorVisible = true;
            return currentSelection;
        }
        protected static void ClearLines(int numberOfLines)
        {
            Console.CursorTop -= numberOfLines;
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < Console.WindowWidth - 1; j++)
                    Console.Write(" ");
                Console.CursorTop++;
                Console.CursorLeft = 0;
            }
            Console.CursorTop -= numberOfLines;
        }

        /*
        Имена всех монархов на заданном континенте
        Количество жителей данного континента
        */

        static void Main(string[] args)
        {


        }
    }
}