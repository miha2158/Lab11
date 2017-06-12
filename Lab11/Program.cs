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
        protected static int SelectorY(string[] items)
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
                else
                    if (currentSelection == items.Length)
                        currentSelection = 0;
            }
            while (!selected);

            CursorTop = top + items.Length;
            ClearLines(items.Length);
            SetCursorPosition(left, top);
            WriteLine(items[currentSelection]);

            CursorTop++;
            CursorVisible = true;
            return currentSelection;
        }
        protected static void ClearLines(int numberOfLines)
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
        
        protected static IEnumerable<string>
            ContinentMonarchs(IEnumerable<Country> countries, string continent)
        {
            foreach (Country c in countries)
            {
                Monarchy t = c as Monarchy;
                if (t?.Continent == continent)
                    yield return t.Ruler;
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
            //return countries.Where(c => c.Continent == continent).Aggregate<Country, ulong>(0, (current, c) => current + c.Population);
        }

        protected static IEnumerable<string> 
            ContinentCountry(IEnumerable<Country> countries, string continent)
        {
            foreach (Country c in countries)
            {
                Monarchy t = c as Monarchy;
                if (t?.Continent == continent)
                    yield return t.Name;
            }
        }



        static void Main(string[] args)
        {
            var countryList = new List<Country>(0);

            WriteLine("Формирование массива");

            var m = new Monarchy("1",1110,"Россия","Путин");
            countryList.Add(m);
            WriteLine("\nСоздал: {0}",m);

            var m1 = (Monarchy)m.Clone();
            countryList.Add(m1);
            WriteLine("Скопировал: {0}", m1);
            WriteLine();


            WriteLine("\nИзменяю {0}", m1);
            m1.Population = 9000;
            m1.Name = "Украина";
            m1.Ruler = "Порошенко";
            WriteLine("\nИзменил (напрямую): {0}", m1);

            var m2 = new Kingdom("1", 890, "Люксембург", "Король Люксембурга");
            countryList.Add(m2);
            WriteLine("\nСоздал: {0}", m2);

            WriteLine();
            foreach (Country c in countryList)
                WriteLine("   {0}",c);
            WriteLine();

            var uk = new Kingdom("2",55555,"Соединённое королевство","Елизавета 2");
            WriteLine("\nСоздал: {0}",uk);
            countryList.Add(uk);
            WriteLine();

            var new_uk = (Kingdom)uk.Clone();
            WriteLine("\nСкопировал: {0}",new_uk);
            countryList.Add(new_uk);

            countryList[4].Ruler = "Чарльз???";
            countryList[4].Population = 44445;
            WriteLine("\nИзменил (виртуальные методы): {0}",new_uk);

            WriteLine();
            
            WriteLine();
            foreach (Country c in countryList)
                WriteLine("   {0}",c);
            WriteLine();

            var america = new Republic
                ("3", 12345,"америка","Трамп",new []{"номер 1","номер 2","номер 3"});
            countryList.Add(america);
            WriteLine("\nСоздал: {0}", america);

            var brazil = new Monarchy
                ("3",11111,"Бразилия","Президент");
            countryList.Add(brazil);
            WriteLine("\nСоздал: {0}", brazil);


            WriteLine();
            foreach (Country c in countryList)
                WriteLine("   {0}", c);
            WriteLine();


            WriteLine();
            WriteLine("На континенте 1 ровно {0} людей", ContinentPeople(countryList, "1"));
            WriteLine("На континенте 2 ровно {0} людей", ContinentPeople(countryList, "2"));
            WriteLine("На континенте 3 ровно {0} людей", ContinentPeople(countryList, "3"));
            WriteLine();
            
            WriteLine("Монархи континента 1");
            foreach (string s in ContinentMonarchs(countryList, "1"))
                WriteLine(s);
            WriteLine();

            WriteLine("Монархи континента 2");
            foreach (string s in ContinentMonarchs(countryList, "2"))
                WriteLine(s);
            WriteLine();

            WriteLine("Монархи континента 3");
            foreach (string s in ContinentMonarchs(countryList, "3"))
                WriteLine(s);
            WriteLine();

            WriteLine("Страны кортинента 1");
            foreach(string s in ContinentCountry(countryList, "1"))
                WriteLine(s);
            WriteLine();


            var countryArray = countryList.ToArray();
            Array.Sort(countryArray,new Countries_Lab11.SortByName());
            countryList = countryArray.ToList();
            

            WriteLine();
            foreach (Country c in countryList)
                WriteLine("   {0}", c);
            WriteLine();

            ReadKey(true);
        }
    }
}