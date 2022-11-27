using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.TextSorting
{
    public class RadixSort
    {
        public Logger logger = new Logger();
        static int char_at(String str, int d)
        {
            if (str.Length <= d)
                return -1;
            else
                return (int)(str[d]);
        }
        public void MSD_sort(String[] str, int lo, int hi, int d)
        {
            // Условие для разрыва рекурсии
            if (hi <= lo)
            {
                return;
            }

            // Сохраняет значения ASCII
            logger.Logs.Add(new Record("Info", "Формируем массив для хранения символов в соответствии с значением ASCII"));
            int[] count = new int[256 + 1];

            // Temp создан для простой замены строк в []str
            logger.Logs.Add(new Record("Info", "Создаем словарь для промежуточного хранения нашего массива с выявленным порядком"));
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
                    logger.Logs.Add(new Record("Increment", String.Format("Увеличиваем для символа {0} c кодом {1} значение на 1", str[i][d], c)));
                }
                count[c + 2]++;
            }

            // Изменяем []count так, чтобы []count теперь содержал фактическую позицию этих цифр в []temp
            logger.Logs.Add(new Record("Info", "Изменяем []count так, чтобы []count теперь содержал фактическую позицию этих цифр в []temp"));
            for (int r = 0; r < 256; r++)
            {
                count[r + 1] += count[r];
                if (count[r + 1] != count[r])
                {
                    logger.Logs.Add(new Record("Replace", String.Format("Для кода {0} cо значением {1} меняем значение на {2}", r + 1, count[r + 1], count[r])));
                }

            }


            // Формируем temp
            logger.Logs.Add(new Record("Info", "Формируем наш словарь"));
            for (int i = lo; i <= hi; i++)
            {
                int c = char_at(str[i], d);
                temp.Add(count[c + 1]++, str[i]);
                logger.Logs.Add(new Record("Write", String.Format("{0} : {1}", count[c + 1] - 1, str[i])));
            }

            // Копируем все строки temp в []str, чтобы []str теперь содержал частично отсортированные строки.
            logger.Logs.Add(new Record("Info", "Копируем все строки из словаря в наш массив, чтобы он теперь содержал частично отсортированные строки. И получаем массив:"));
            for (int i = lo; i <= hi; i++)
            {
                str[i] = temp[i - lo];
                logger.Logs.Add(new Record("Write", String.Format("{0}", str[i])));
            }


            // Рекурсивно вызываем MSD_sort() для каждой частично отсортированной строки, установленной для сортировки их по следующему символу
            logger.Logs.Add(new Record("Call", "Рекурсивно вызываем следующую итерацию для сортировки оставшихся строк."));

            for (int r = 0; r < 256; r++)
                MSD_sort(str, lo + count[r],
                            lo + count[r + 1] - 1,
                            d + 1);
        }
    }
}
