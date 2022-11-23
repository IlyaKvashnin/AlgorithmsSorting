using AlgorithmsSorting.ConsoleUI;
using AlgorithmsSorting.TextSorting;
using System;

namespace AlgorithmsSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FileWorker fileWorker = new FileWorker();
            //var str = fileWorker.ReadFile(FileWorker.PathToFile);
            ////String[] str = { "midnight", "badge", "bag",
            ////        "worker", "banner", "wander" };

            //// Size of the string
            //int n = str.Length;

            //Console.Write("Unsorted array : ");

            //// Print the unsorted array
            //RadixSort.Print(str, n);

            //// Function Call
            //RadixSort.MSD_sort(str, 0, n - 1, 0);

            //Console.Write("Sorted array : ");

            //// Print the sorted array
            //RadixSort.Print(str, n);

            MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            mainMenu.Run();

            //FileWorker fileWorker = new FileWorker();
            //var arr = fileWorker.ReadFile(FileWorker.PathToFile);
            //SelectionSort sort = new SelectionSort();
        }
    }
}