using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.TextSorting
{
    /// <summary>
    /// Класс сортировки выборками
    /// </summary>
    public class SelectionSort
    {
        public List<string> logger = new List<string>();
        /// <summary>
        /// Метод сортировки выборками.
        /// </summary>
        /// <param name="source">Входной массив</param>
        public void Sort(string[] source)
        {
            int min;
            for (int i = 0; i < source.Count() - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < source.Count(); j++)
                {
                    logger.Add(String.Format("Сравниваем {0} и {1}", source[j], source[min]));
                    Console.WriteLine("Сравниваем {0} и {1}", source[j], source[min]);
                    if (source[j].CompareTo(source[min]) < 0)
                    {
                        logger.Add(String.Format("{0} по алфавиту находится раньше чем {1}", source[j], source[min]));
                        Console.WriteLine("{0} по алфавиту находится раньше чем {1}", source[j], source[min]);
                        min = j;
                    }
                }
                if (i != source.Count() - 2)
                    logger.Add(String.Format("Меняем местами {0} и {1}", source[i], source[min]));
                    Console.WriteLine("Меняем местами {0} и {1}", source[i], source[min]);
                var temp = source[i];
                source[i] = source[min];
                source[min] = temp;
                Console.WriteLine("Получаем массив: ");
                logger.Add("Получаем массив: ");
                source.ToList().ForEach(x => { 
                    Console.WriteLine(x + " ");
                    logger.Add($"{x}");
                });
                Console.WriteLine();
                logger.Add(" ");
            }
        }

        public void WriteLogsData(string path, string[] array)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using StreamWriter sw = new StreamWriter(path, true);
            foreach (var line in logger)
            {
                sw.WriteLine(line);
            }
            logger.Clear();
            var list = new List<string>();
            foreach (var item in array)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            sw.WriteLine("Количество уникальных слов: " + list.Count());
            Console.WriteLine("Количество уникальных слов: " + list.Count());
        }
    }
}
