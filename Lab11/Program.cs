using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries_Lab11;

using static System.Console;

namespace Lab11
{

    class Program
    {
        /* Задачи
        Имена всех монархов на заданном континенте
        Количество жителей данного континента
        */

        protected static IEnumerable<string>
            ContinentMonarchs(IEnumerable<Country> countries, string continent)
        {
            foreach (Country c in countries)
            {
                Monarchy t = c as Monarchy;
                if (t?.Continent == continent)
                    yield return t?.Ruler;
            }
            //return countries.Select(c => c as Monarchy).Select(t => t?.Ruler);
        }

        protected static ulong
            ContinentPeople(IEnumerable<Country> countries, string continent)
        {
            ulong result = 0;
            foreach (Country c in countries)
                if (c.Continent == continent)
                    result = result + (ulong)c.Population;
            return result;
            //return countries.Where(c => c.Continent == continent).Aggregate<Country, double>(0, (current, c) => current + c.Population);
        }


        protected static int SelectorY (string[] items)
        {
            ResetColor();
            CursorVisible = false;
            int top = CursorTop, left = 4;
            int currentSelection = 0, previousSelection = 1;

            for (int i = 0; i < items.Length; i++)
            {
                SetCursorPosition(left, top + i);
                WriteLine(items[i]);
            }

            bool selected = false;
            do
            {
                SetCursorPosition(left, top + previousSelection);
                WriteLine(items[previousSelection]);

                SetCursorPosition(left, top + currentSelection);
                {
                    ConsoleColor temp = BackgroundColor;
                    BackgroundColor = ForegroundColor;
                    ForegroundColor = temp;
                }
                WriteLine(items[currentSelection]);
                {
                    ConsoleColor temp = BackgroundColor;
                    BackgroundColor = ForegroundColor;
                    ForegroundColor = temp;
                }


                previousSelection = currentSelection;
                switch (ReadKey(true).Key)
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

            CursorTop = top + items.Length;
            ClearLines(items.Length);
            SetCursorPosition(left, top);
            WriteLine(items[currentSelection]);

            CursorTop++;
            CursorVisible = true;
            return currentSelection;
        }
        protected static void ClearLines (int numberOfLines)
        {
            CursorTop -= numberOfLines;
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < WindowWidth - 1; j++)
                    Write(" ");
                CursorTop++;
                CursorLeft = 0;
            }
            CursorTop -= numberOfLines;
        }



        static void Main(string[] args)
        {
            var CountryList = new List<Country>(0);

            var m = new Monarchy("1",1110,"Россия","Путин");
            CountryList.Add(m);
            WriteLine(m);

            var m1 = (Monarchy)m.Clone();
            CountryList.Add(m1);
            WriteLine(m1);
            WriteLine();

            m1.Population = 9000;
            m1.Name = "Украина";
            m1.Ruler = "Порошенко";
            var m2 = new Kingdom("1", 890, "Люксембург", "Король Люксембурга");
            CountryList.Add(m2);

            WriteLine(m1);
            WriteLine(m);
            WriteLine(m2);
            WriteLine();

            var uk = new Kingdom("2",55555,"Соединённое королевство","Елизавета 2");
            WriteLine(uk);
            CountryList.Add(uk);
            WriteLine();

            var new_uk = (Kingdom)uk.Clone();
            WriteLine(new_uk);

            new_uk.King = "Чарльз???";
            new_uk.Population = 44445;
            WriteLine(new_uk);

            CountryList.Add(new_uk);
            WriteLine();


            var america = new Republic
                ("3", 12345,"америка","Трамп",new []{"номер 1","номер 2","номер 3"});
            CountryList.Add(america);

            var brazil = new Monarchy
                ("3",11111,"Бразилия","Главный чел Бразилии");
            CountryList.Add(brazil);

            WriteLine(america);
            WriteLine(brazil);
            WriteLine();

            WriteLine(ContinentPeople(CountryList, "1"));
            WriteLine(ContinentPeople(CountryList, "2"));
            WriteLine(ContinentPeople(CountryList, "3"));
            WriteLine();

            foreach (string s in ContinentMonarchs(CountryList, "1"))
                WriteLine(s);
            WriteLine();

            foreach (string s in ContinentMonarchs(CountryList, "2"))
                WriteLine(s);
            WriteLine();

            foreach (string s in ContinentMonarchs(CountryList, "3"))
                WriteLine(s);
            WriteLine();




            ReadKey(true);
        }
    }
}