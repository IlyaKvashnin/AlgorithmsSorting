using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.TextSorting
{
    public class SelectionSort
    {
        public Logger logger = new Logger();

        public void Sort(string[] source)
        {
            int min;
            for (int i = 0; i < source.Count() - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < source.Count(); j++)
                {
                    logger.Logs.Add(new Record("Compare",String.Format("Сравниваем {0} и {1}", source[j], source[min])));
                    if (source[j].CompareTo(source[min]) < 0)
                    {
                        logger.Logs.Add(new Record("Info",String.Format("{0} по алфавиту находится раньше чем {1}", source[j], source[min])));
                        min = j;
                    }
                }
                if (i != source.Count() - 2)
                    logger.Logs.Add(new Record("Swap",String.Format("Меняем местами {0} и {1}", source[i], source[min])));
                var temp = source[i];
                source[i] = source[min];
                source[min] = temp;
            }
        }
    }
}
