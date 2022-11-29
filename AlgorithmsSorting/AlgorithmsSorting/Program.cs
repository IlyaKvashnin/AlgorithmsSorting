using AlgorithmsSorting.ConsoleUI;
using AlgorithmsSorting.ExternalSortingAlgorithms;
using System;
using System.Diagnostics;

namespace AlgorithmsSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            //mainMenu.Run();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filename = "data.txt";
            //LargeFileGeneration(filename);
            Console.WriteLine("Before sort: ");
            OutputData(filename);
            //NaturalMergeSort dm = new NaturalMergeSort(filename, 0, ColumnType.str);
            MultipathMergeSort dm = new MultipathMergeSort(filename, 1, ColumnType.str);
            dm.Sort();
            Console.WriteLine("After sort: ");
            OutputData(filename);
            sw.Stop();
            Console.WriteLine($"Elapsed: {(double)sw.ElapsedMilliseconds / 1000} seconds");
        }
        public static void LargeFileGeneration(string file)
        {
            using (StreamWriter bw = new StreamWriter(File.Create(file)))
            {
                Random rnd = new Random();
                for (int i = 0; i < 256; i++)
                {
                    bw.WriteLine(rnd.Next(0, 256));
                    //bw.Write(" ");
                }
            }
        }

        public static void OutputData(string file) // вывод первых 100 чисел для проверки
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            {
                long length = sr.BaseStream.Length;
                long position = 0;
                for (int i = 0; i < 100; i++)
                {
                    if (position == length)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{sr.ReadLine()} ");
                        position += 4;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}