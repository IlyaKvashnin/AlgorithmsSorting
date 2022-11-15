using AlgorithmsSorting.TextSorting;
using System;
using System.Collections.Generic;
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
            SelectionSort sort = new SelectionSort();

            var arr = fileWorker.ReadFile(FileWorker.PathToFile);


            Console.WriteLine("Массив в файле до изменений: ");
            arr.Print();

            Console.WriteLine("\nТекст после сортировки: ");
            sort.Sort(arr);
            arr.Print();

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

            Console.WriteLine("\nТекст после сортировки: ");
            radixSort.MSD_sort(arr, 0, n - 1, 0);
            arr.Print();

        }
    }
}
