using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.TextSorting
{
    public class RadixSort
    {
        public List<string> logger = new List<string>();
        static int char_at(String str, int d)
        {
            if (str.Length <= d)
                return -1;
            else
                return (int)(str[d]);
        }

        /// <summary>
        /// Функция для сортировки массива с помощью MSD Radix Sort рекурсивно
        /// </summary>
        /// <param name="str">Входной массив</param>
        /// <param name="lo"></param>
        /// <param name="hi">Размер массива</param>
        /// <param name="d"></param>
        // 
        public void MSD_sort(String[] str, int lo, int hi, int d)
        {
            // Условие для разрыва рекурсии
            if (hi <= lo)
            {
                return;
            }

            // Сохраняет значения ASCII
            logger.Add("Формируем массив для хранения символов в соответствии с значением ASCII");
            Console.WriteLine("Формируем массив для хранения символов в соответствии с значением ASCII");
            int[] count = new int[256 + 1];

            // Temp создан для простой замены строк в []str

            logger.Add("Создаем словарь для промежуточного хранения нашего массива с выявленным порядком");
            Console.WriteLine("Создаем словарь для промежуточного хранения нашего массива с выявленным порядком");
            Dictionary<int,
                    String> temp = new Dictionary<int,
                                                    String>();

            // Сохраняем вхождения наиболее значимого символа из каждой строки в []count
            for (int i = lo; i <= hi; i++)
            {
                //Определяем десятичный код этого символа
                int c = char_at(str[i], d);
                //Увеличиваем значение на 1 для этого символа
                if (str.Length <= d)
                {
                    Console.WriteLine(String.Format("Увеличиваем для символа {0} c кодом {1} значение на 1", str[i][d], c));
                    logger.Add(String.Format("Увеличиваем для символа {0} c кодом {1} значение на 1", str[i][d], c));
                }
                count[c+2]++;
            }

            // Изменяем []count так, чтобы []count теперь содержал фактическую позицию этих цифр в []temp
            logger.Add("Изменяем []count так, чтобы []count теперь содержал фактическую позицию этих цифр в []temp");
            Console.WriteLine("Изменяем []count так, чтобы []count теперь содержал фактическую позицию этих цифр в []temp");
            for (int r = 0; r < 256; r++)
            {
                count[r + 1] += count[r];
                if (count[r + 1] != count[r])
                {
                    Console.WriteLine(String.Format("Для кода {0} cо значением {1} меняем значение на {2}", r + 1, count[r + 1], count[r]));
                    logger.Add(String.Format("Для кода {0} cо значением {1} меняем значение на {2}", r + 1, count[r + 1], count[r]));
                }
                    
            }


            // Формируем temp
            logger.Add("Формируем наш словарь");
            for (int i = lo; i <= hi; i++)
            {
                int c = char_at(str[i], d);
                temp.Add(count[c+1]++, str[i]);
                Console.WriteLine(String.Format("{0} : {1}", count[c + 1] - 1, str[i]));
                logger.Add(String.Format("{0} : {1}", count[c + 1] - 1, str[i]));
            }

            // Копируем все строки temp в []str, чтобы []str теперь содержал частично отсортированные строки.
            logger.Add("Копируем все строки из словаря в наш массив, чтобы он теперь содержал частично отсортированные строки. И получаем массив:");
            Console.WriteLine("Копируем все строки из словаря в наш массив, чтобы он теперь содержал частично отсортированные строки. И получаем массив:");
            for (int i = lo; i <= hi; i++)
            {
                str[i] = temp[i - lo];
                Console.WriteLine(String.Format("{0}", str[i]));
                logger.Add(String.Format("{0}",str[i]));
            }


            // Рекурсивно вызываем MSD_sort() для каждой частично отсортированной строки, установленной для сортировки их по следующему символу
            logger.Add("Рекурсивно вызываем следующую итерацию для сортировки оставшихся строк.");
            Console.WriteLine("Рекурсивно вызываем следующую итерацию для сортировки оставшихся строк.");
            Console.WriteLine();
            logger.Add(" ");
            for (int r = 0; r < 256; r++)
                MSD_sort(str, lo + count[r],
                            lo + count[r + 1] - 1,
                            d + 1);
        }

        public void WriteLogsData(string path, string[] array)
        {
            if (File.Exists(path)) {
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
