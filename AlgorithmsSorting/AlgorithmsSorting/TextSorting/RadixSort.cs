using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.TextSorting
{
    public class RadixSort
    {
        List<string> logger = new List<string>();
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
            int[] count = new int[256 + 1];

            // Temp создан для простой замены строк в []str

            logger.Add("Создаем словарь для промежуточного хранения нашего массива с выявленным порядком");
            Dictionary<int,
                    String> temp = new Dictionary<int,
                                                    String>();

            // Сохраняем вхождения наиболее значимого символа из каждой строки в []count
            for (int i = lo; i <= hi; i++)
            {
                //Определяем десятичный код этого символа
                Console.WriteLine(str[i][d]);
                int c = char_at(str[i], d);
                //Увеличиваем значение на 1 для этого символа
                count[c+2]++;
            }

            // Изменяем []count так, чтобы []count теперь содержал фактическую позицию этих цифр в []temp
            for (int r = 0; r < 256; r++)
                count[r + 1] += count[r];

            // Формируем temp
            for (int i = lo; i <= hi; i++)
            {
                int c = char_at(str[i], d);
                temp.Add(count[c+1]++, str[i]);
            }

            // Копируем все строки temp в []str, чтобы []str теперь содержал частично отсортированные строки.
            for (int i = lo; i <= hi; i++)
                str[i] = temp[i - lo];

            // Рекурсивно вызываем MSD_sort() для каждой частично отсортированной строки, установленной для сортировки их по следующему символу
            for (int r = 0; r < 256; r++)
                MSD_sort(str, lo + count[r],
                            lo + count[r + 1] - 1,
                            d + 1);
        }
    }
}
