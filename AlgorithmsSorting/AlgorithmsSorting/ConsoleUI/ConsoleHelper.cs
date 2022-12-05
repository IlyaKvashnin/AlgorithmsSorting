using AlgorithmsSorting.ExternalSortingAlgorithms;
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

        public static int ReadNumberOfLength()
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
                return ReadNumberOfLength();
            }
        }
        public static int ReadColumnNumber()
        {
            Console.WriteLine("Введите номер столбца, по которому сортировать (нумерация с 0)");
            string input = Console.ReadLine();
            int number;

            bool success = int.TryParse(input, out number);
            if (success)
            {
                return number;
            }
            else
            {
                return ReadNumberOfLength();
            }
        }
        public static ColumnType ReadColumnType()
        {
            string inputChar;
            do
            {
                System.Console.WriteLine("Введите int/integer или str/string в соответствии с типом данных в столбце");
                inputChar = System.Console.ReadLine();
                var needInputChar = inputChar?.ToLower();
                if ((needInputChar == "int") || (needInputChar == "integer"))
                    return ColumnType.integer;
                else if ((needInputChar == "str") || (needInputChar == "string"))
                    return ColumnType.str;
            } while (true);
        }
        public static int ReadMaxWaysNumber()
        {
            Console.WriteLine("Введите количество путей для многопутевой сортировки");
            string input = Console.ReadLine();
            int number;

            bool success = int.TryParse(input, out number);
            if (success)
            {
                return number;
            }
            else
            {
                return ReadNumberOfLength();
            }
        }

        public static int ReadNumberTime()
        {
            Console.WriteLine("Введите число, которое будет соответствовать задержки в милисекундах между шагами сортировки.");
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
            Console.WriteLine();
            Console.WriteLine("Количество повторений для каждого слова в тексте." , Console.BackgroundColor = ConsoleColor.DarkRed);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

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
