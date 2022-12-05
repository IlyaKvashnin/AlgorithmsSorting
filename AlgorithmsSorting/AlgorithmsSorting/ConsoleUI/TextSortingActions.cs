using AlgorithmsSorting.TextSorting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.ConsoleUI
{
    /// <summary>
    /// Класс, для удобного вывода в консоль.
    /// </summary>
    public static class ArrayStringsExtension
    {
        public static void Print(this string[] array)
        {
            array.ToList().ForEach(x => Console.WriteLine(x));
        }
    }

    /// <summary>
    /// Класс, содержащий методы вывода работы сортировок.
    /// </summary>
    internal class TextSortingActions
    {
        
        public static void PrintSelectionSort()
        {
            ConsoleHelper.CleanScreen();
            FileWorker fileWorker = new FileWorker();
            SelectionSort selectionSort = new SelectionSort();
            StringsGenerator stringsGenerator = new StringsGenerator();

            int length = ConsoleHelper.ReadNumberOfLength();
            Console.WriteLine();
            StringBuilder data = stringsGenerator.GenerateData(length);
            fileWorker.WriteFile(FileWorker.PathToFile, data);

            var arr = fileWorker.ReadFile(FileWorker.PathToFile);

            int n = arr.Count();
            Console.WriteLine("Массив в файле до изменений: ");
            arr.Print();
            Console.WriteLine();
            int time = ConsoleHelper.ReadNumberTime();
            Console.WriteLine();

            selectionSort.Sort(arr,time);


            ConsoleHelper.PrintNumberElements(arr);
            Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arr.Print();

            fileWorker.WriteLogs(FileWorker.PathToLogsSelection, selectionSort.logger.Logs);
            selectionSort.logger.Logs.Clear();

        }

        public static void PrintRadixSort()
        {
            ConsoleHelper.CleanScreen();
            FileWorker fileWorker = new FileWorker();
            RadixSort radixSort = new RadixSort();
            StringsGenerator stringsGenerator = new StringsGenerator();

            int length = ConsoleHelper.ReadNumberOfLength();
            Console.WriteLine();
            StringBuilder data = stringsGenerator.GenerateData(length);
            fileWorker.WriteFile(FileWorker.PathToFile, data);

            var arr = fileWorker.ReadFile(FileWorker.PathToFile);

            int n = arr.Count();
            Console.WriteLine("Массив в файле до изменений: ");
            arr.Print();
            Console.WriteLine();
            int time = ConsoleHelper.ReadNumberTime();
            Console.WriteLine();

            radixSort.MSD_sort(arr, 0, n - 1, 0,time);

            ConsoleHelper.PrintNumberElements(arr);
            Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arr.Print();

            fileWorker.WriteLogs(FileWorker.PathToLogsRadix, radixSort.logger.Logs);
            radixSort.logger.Logs.Clear();

        }
    }
}
