using AlgorithmsSorting.Internal_sorting;
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
            Console.WriteLine("Массив до изменений: ");
            int[] arr = new int[] { 1, 5, 6, 30, 100, 10423, 423, 53, 234, -234, 23, -123, 59387, -99, 2352, 8954, 4, 78, -77 };
            arr.Print();
            Sorts sorts = new Sorts(arr);
            Console.WriteLine();
            arr = sorts.Bubblesort();
            int time = ConsoleHelper.ReadNumberTime();
            Output.Print("bubblesort.txt", time);
            Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arr.Print();
        }

        public static void PrintQuickSort()
        {
            ConsoleHelper.CleanScreen();
            Console.WriteLine("Массив до изменений: ");
            int[] arr = new int[] { 1, 5, 6, 30, 100, 10423, 423, 53, 234, -234, 23, -123, 59387, -99, 2352, 8954, 4, 78, -77 };
            arr.Print();
            Sorts sorts = new Sorts(arr);
            Console.WriteLine();
            arr = sorts.Quicksort();
            int time = ConsoleHelper.ReadNumberTime();
            Output.Print("quicksort.txt", time);
            Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arr.Print();
        }
    }
}
