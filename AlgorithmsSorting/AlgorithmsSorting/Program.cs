using AlgorithmsSorting.ConsoleUI;
using AlgorithmsSorting.TextSorting;
using System;

namespace AlgorithmsSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            mainMenu.Run();

            //FileWorker fileWorker = new FileWorker();
            //var arr = fileWorker.ReadFile(FileWorker.PathToFile);
            //SelectionSort sort = new SelectionSort();
            //foreach(var item in sort.Sort(arr))
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}