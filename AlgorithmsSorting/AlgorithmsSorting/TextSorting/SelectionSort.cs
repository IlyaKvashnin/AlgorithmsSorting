using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.TextSorting
{
    public class SelectionSort
    {
        public string[] Sort(string[] source)
        {
            int min;
            for (int i = 0; i < source.Count() - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < source.Count(); j++)
                {
                    if (source[j].CompareTo(source[min]) < 0)
                    {
                        min = j;
                    }
                }
                var temp = source[i];
                source[i] = source[min];
                source[min] = temp;
            }

            return source;
        }
    }
}
