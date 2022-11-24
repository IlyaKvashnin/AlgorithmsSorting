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

            //ConsoleHelper.CleanScreen();
            //FileWorker fileWorker = new FileWorker();
            //SelectionSort sort = new SelectionSort();

            //fileWorker.WriteFile(FileWorker.PathToFile);
            //var arr = fileWorker.ReadFile(FileWorker.PathToFile);


            //Console.WriteLine("Массив в файле до изменений: ");
            //arr.Print();

            //Console.WriteLine("\nПроцесс сортировки: ");
            //sort.Sort(arr);
            //Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.WriteLine();
            //sort.WriteLogsData(FileWorker.PathToLogsSelection,arr);
            
            //arr.Print();

        }

        public static void PrintRadixSort()
        {

            ConsoleHelper.CleanScreen();
            FileWorker fileWorker = new FileWorker();
            RadixSort radixSort = new RadixSort();
            var arr = fileWorker.ReadFile(FileWorker.PathToFile);
            
            int n = arr.Count();
            Console.WriteLine("Массив в файле до изменений: ");
            arr.Print();
            radixSort.MSD_sort(arr, 0, n - 1, 0);
            radixSort.logger.PrintLogs();
            
            Console.WriteLine("\nМассив после сортировки: ", Console.BackgroundColor = ConsoleColor.DarkGreen);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            arr.Print();
            fileWorker.WriteLogs(FileWorker.PathToLogsRadix, radixSort.logger.Logs);
            radixSort.logger.Logs.Clear();
        }
    }
}
