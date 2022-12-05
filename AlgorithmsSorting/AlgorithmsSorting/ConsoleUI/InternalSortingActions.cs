using AlgorithmsSorting.Internal_sorting;
using AlgorithmsSorting.TextSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.ConsoleUI
{
    public static class ArrayIntExtension
    {
        public static void Print(this int[] array)
        {
            array.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
    internal class InternalSortingActions
    {
        public static void PrintBubbleSort()
        {
            ConsoleHelper.CleanScreen();
            FileWorker fileWorker = new FileWorker();

            int[] arr = new int[] { 1, 5, 6, 30, 100, 10423, 423, 53, 234, -234, 23, -123, 59387, -99, 2352, 8954, 4, 78, -77 };

            Console.WriteLine("Массив в файле до изменений: ");
            arr.Print();
            Console.WriteLine();
            int time = ConsoleHelper.ReadNumberTime();
            Console.WriteLine();

            Sorts sorts = new Sorts(arr);
            Console.WriteLine();
            arr = sorts.BubbleSort(time);

            Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arr.Print();

            fileWorker.WriteLogs(FileWorker.PathToLogsBubble, sorts.logger.Logs);
            sorts.logger.Logs.Clear();
        }

        public static void PrintQuickSort()
        {
            ConsoleHelper.CleanScreen();
            FileWorker fileWorker = new FileWorker();

            int[] arr = new int[] { 1, 5, 6, 30, 100, 10423, 423, 53, 234, -234, 23, -123, 59387, -99, 2352, 8954, 4, 78, -77 };

            Console.WriteLine("Массив в файле до изменений: ");
            arr.Print();
            Console.WriteLine();
            int time = ConsoleHelper.ReadNumberTime();
            Console.WriteLine();

            Sorts sorts = new Sorts(arr);
            Console.WriteLine();
            arr = sorts.QuickSort(time);

            Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arr.Print();

            fileWorker.WriteLogs(FileWorker.PathToLogsBubble, sorts.logger.Logs);
            sorts.logger.Logs.Clear();
        }
    }
}
