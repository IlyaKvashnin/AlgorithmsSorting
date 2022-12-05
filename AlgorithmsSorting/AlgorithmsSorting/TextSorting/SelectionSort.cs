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

        public void Sort(string[] source,int timeout)
        {
            int min;
            for (int i = 0; i < source.Count() - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < source.Count(); j++)
                {
                    logger.AddLog(new Record("Compare",String.Format("Сравниваем {0} и {1}", source[j], source[min])),timeout);
                    if (source[j].CompareTo(source[min]) < 0)
                    {
                        logger.AddLog(new Record("Info",String.Format("{0} по алфавиту находится раньше чем {1}", source[j], source[min])),timeout);
                        min = j;
                    }
                }
                if (i != source.Count() - 2)
                    logger.AddLog(new Record("Swap",String.Format("Меняем местами {0} и {1}", source[i], source[min])),timeout);
                var temp = source[i];
                source[i] = source[min];
                source[min] = temp;
            }
        }
    }
}
