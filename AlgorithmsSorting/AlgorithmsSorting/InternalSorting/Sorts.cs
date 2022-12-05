namespace AlgorithmsSorting.Internal_sorting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

public class Sorts
{
        private int[] array { get; set; }
        public Logger logger = new Logger();
        private List<string> arrayChanges;

        public Sorts(int[] arr)
        {
            array = arr;
            arrayChanges = new List<string>();
            arrayChanges.Add(GetArray(arr));
        }

        public int[] BubbleSort(int timeout)
        {   
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);

            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = i + 1; j < temp.Length; j++)
                {
                    //logs.Add(j + " - j");
                    logger.AddLog(new Record("Compare",$"Сравниваем элементы {temp[i]} и {temp[j]}"),timeout);

                    if (temp[i] > temp[j])
                        Swap(temp, i, j,timeout);
                }
            }

            return temp;
        }

        public int[] QuickSort(int timeout)
        { 
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);
            int[] result = Sort(temp, 0, temp.Length - 1, timeout);

            return result;
        }

        private int[] Sort(int[] arr, int left, int right,int timeout)
        {
            if (left < right)
            {
                logger.AddLog(new Record("Info", "Левый индекс меньше правого"), timeout);

                int pivot = Partition(arr, left, right,timeout);

                if (pivot > 1)
                {
                    logger.AddLog(new Record("Call", $"pivot > 1. Вызываем QuickSort({left}, {pivot - 1})"), timeout);
                    Sort(arr, left, pivot - 1,timeout);
                }
                if (pivot + 1 < right)
                {
                    logger.AddLog(new Record("Call", $"pivot + 1 < правого индекса. Вызываем QuickSort({pivot + 1}, {right})"), timeout);
                    Sort(arr, pivot + 1, right,timeout);
                }
            }

            return arr;
        }

        private int Partition(int[] arr, int left, int right,int timeout)
        {
            logger.AddLog(new Record("Info", "\nВходим в блок partition"), timeout);
            logger.AddLog(new Record("Info", $"pivot = {arr[left]}"), timeout);

            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    logger.AddLog(new Record("Info", $"{arr[left]} < {pivot}, поэтому смотрим следующий элеменет"), timeout);
                    left++;
                }

                while (arr[right] > pivot)
                {
                    logger.AddLog(new Record("Info", $"{arr[right]} > {pivot}, поэтому смотрим предыдущий элеменет"), timeout);
                    right--;
                }

                if (left < right)
                {
                    logger.AddLog(new Record("Info", "Левый индекс меньше правого"), timeout);
                    if (arr[left] == arr[right]) return right;

                    Swap(arr, left, right,timeout);
                }
                else
                { 
                    logger.AddLog(new Record("Info", "Правый индекс меньше левого. Возвращаем правый индекс"), timeout);
                    logger.AddLog(new Record("Info", "Выходим из блока partition\n"), timeout);
                    return right;
                }
            }
        }

        public void Swap(int[] array, int i, int j,int timeout)
        {
            logger.AddLog(new Record("Info", $"Меняем местами элементы {array[i]} и {array[j]} с индексами {i} и {j}. \n" +
                $"Array :{GetArray(array)}"), timeout);

            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            arrayChanges.Add(GetArray(array));
        }

        private string GetArray(int[] arr)
        {
            var res = new StringBuilder();
            for(int i = 0; i < arr.Length - 1; i++)
            {
                res.Append($"{arr[i]}, ");
            }
            res.Append(arr[arr.Length - 1]);
            return res.ToString();
        }
}