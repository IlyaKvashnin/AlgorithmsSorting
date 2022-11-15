using AlgorithmsSorting.TextSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.ConsoleUI
{
    internal class TextSortingActions
    {
        public static void PrintSelectionSort()
        {

            ConsoleHelper.CleanScreen();
            FileWorker fileWorker = new FileWorker();
            SelectionSort sort = new SelectionSort();

            var arr = fileWorker.ReadFile(FileWorker.PathToFile);


            Console.WriteLine("Массив в файле до изменений: ");
            arr.ToList().ForEach(x =>  Console.WriteLine(x));

            Console.WriteLine("\nТекст после сортировки: ");
            sort.Sort(arr).ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
