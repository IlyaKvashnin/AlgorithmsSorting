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
        }
    }
}