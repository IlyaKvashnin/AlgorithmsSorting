﻿using AlgorithmsSorting.ExternalSortingAlgorithms;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ConsoleHelper.CleanScreen();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filename = "data.txt";
            Console.WriteLine("Before sort: ");
            OutputData(filename);
            DirectMergeSort dm = new DirectMergeSort(filename, 1, ColumnType.str);
            dm.Sort();
            Console.WriteLine("After sort: ");
            OutputData(filename);
            sw.Stop();
            Console.WriteLine($"Elapsed: {(double)sw.ElapsedMilliseconds / 1000} seconds");
        }
        public static void PrintNaturalMergeSort()
        {
            ConsoleHelper.CleanScreen();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filename = "data.txt";
            Console.WriteLine("Before sort: ");
            OutputData(filename);
            NaturalMergeSort dm = new NaturalMergeSort(filename, 1, ColumnType.str);
            dm.Sort();
            Console.WriteLine("After sort: ");
            OutputData("result.txt");
            sw.Stop();
            Console.WriteLine($"Elapsed: {(double)sw.ElapsedMilliseconds / 1000} seconds");
        }
        public static void PrintMultipathMergeSort()
        {
            ConsoleHelper.CleanScreen();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string filename = "data.txt";
            Console.WriteLine("Before sort: ");
            OutputData(filename);
            MultipathMergeSort dm = new MultipathMergeSort(filename, 0, ColumnType.str);
            dm.Sort();
            Console.WriteLine("After sort: ");
            OutputData("result.txt");
            sw.Stop();
            Console.WriteLine($"Elapsed: {(double)sw.ElapsedMilliseconds / 1000} seconds");
        }

    }
}