using AlgorithmsSorting.ExternalSortingAlgorithms;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsSorting.TextSorting;

namespace AlgorithmsSorting.ConsoleUI
{
    internal class ExternalSortingActions
    {
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
        public static void PrintDirectMergeSort()
        {
            FileWorker fileWorker = new FileWorker();
            ConsoleHelper.CleanScreen();
            var columnNumber = ConsoleHelper.ReadColumnNumber();
            ConsoleHelper.CleanScreen();
            var type = ConsoleHelper.ReadColumnType();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filename = "data.txt";
            Console.WriteLine("Before sort: ");
            OutputData(filename);
            int time = ConsoleHelper.ReadNumberTime();
            DirectMergeSort dm = new DirectMergeSort(filename, columnNumber, type, time);
            dm.Sort();
            Console.WriteLine("After sort: ");
            OutputData(filename);
            sw.Stop();
            Console.WriteLine($"Elapsed: {(double)sw.ElapsedMilliseconds / 1000} seconds");
            fileWorker.WriteLogs(FileWorker.PathToLogsDirectMerge, dm.logger.Logs);
            dm.logger.Logs.Clear();
        }
        public static void PrintNaturalMergeSort()
        {
            FileWorker fileWorker = new FileWorker();
            ConsoleHelper.CleanScreen();
            var columnNumber = ConsoleHelper.ReadColumnNumber();
            ConsoleHelper.CleanScreen();
            var type = ConsoleHelper.ReadColumnType();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filename = "data.txt";
            Console.WriteLine("Before sort: ");
            OutputData(filename);
            int time = ConsoleHelper.ReadNumberTime();
            NaturalMergeSort dm = new NaturalMergeSort(filename, columnNumber, type, time);
            dm.Sort();
            Console.WriteLine("After sort: ");
            OutputData("result.txt");
            sw.Stop();
            Console.WriteLine($"Elapsed: {(double)sw.ElapsedMilliseconds / 1000} seconds");
            fileWorker.WriteLogs(FileWorker.PathToLogsNaturalMerge, dm.logger.Logs);
            dm.logger.Logs.Clear();
        }
        public static void PrintMultipathMergeSort()
        {
            FileWorker fileWorker = new FileWorker();
            ConsoleHelper.CleanScreen();
            var maxWays = ConsoleHelper.ReadMaxWaysNumber();
            ConsoleHelper.CleanScreen();
            var columnNumber = ConsoleHelper.ReadColumnNumber();
            ConsoleHelper.CleanScreen();
            var type = ConsoleHelper.ReadColumnType();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filename = "data.txt";
            Console.WriteLine("Before sort: ");
            OutputData(filename);
            int time = ConsoleHelper.ReadNumberTime();
            MultipathMergeSort dm = new MultipathMergeSort(filename, columnNumber, type, maxWays, time);
            dm.Sort();
            Console.WriteLine("After sort: ");
            OutputData("result.txt");
            sw.Stop();
            Console.WriteLine($"Elapsed: {(double)sw.ElapsedMilliseconds / 1000} seconds");
            fileWorker.WriteLogs(FileWorker.PathToLogsMultipathMerge, dm.logger.Logs);
            dm.logger.Logs.Clear();
        }

    }
}
