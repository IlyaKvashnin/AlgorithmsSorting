using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.ConsoleUI
{
    public static class StringExtension
    {
        public static void Center(this string text)
        {
            int width = System.Console.WindowWidth;
            int padding = width / 2 + text.Length / 2;

            System.Console.WriteLine("{0," + padding + "}", text);
        }
    }
    public class ConsoleHelper
    {
        
        public static void CleanScreen()
        {
            for (int i = 0; i < System.Console.WindowHeight; i++)
            {
                System.Console.SetCursorPosition(0, i);
                System.Console.Write(new String(' ', System.Console.WindowWidth));
            }

            System.Console.SetCursorPosition(0, 0);
        }

        public static int ReadNumber()
        {
            Console.WriteLine("Введите числом количество слов для сортировки");
            string input = Console.ReadLine();
            int number;

            bool success = int.TryParse(input, out number);
            if (success)
            {
                return number;
            }
            else
            {
                return ReadNumber();
            }
        }

        public static int ReadNumberTime()
        {
            Console.WriteLine("Введите числом период отображения записей");
            string input = Console.ReadLine();
            int number;

            bool success = int.TryParse(input, out number);
            if (success)
            {
                return number;
            }
            else
            {
                return ReadNumberTime();
            }
        }

        public static void PrintNumberElements(string[] array)
        {
            Console.WriteLine("Количество повторений для каждого слова в тексте." , Console.BackgroundColor = ConsoleColor.DarkRed);
            Console.BackgroundColor = ConsoleColor.Black;
            Dictionary<string,int> dict = new Dictionary<string,int>();

            foreach (var item in array)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 1);
                }
                else
                {
                    dict[item]++;
                }
            }
           foreach (var item in dict)
            {
                Console.WriteLine(String.Format("Слово {0} вcтречается {1} раз(a)",item.Key,item.Value));
            }
        }
    }
}
