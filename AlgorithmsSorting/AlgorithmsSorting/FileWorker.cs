﻿using AlgorithmsSorting.TextSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting
{ 
    public class FileWorker
    {
        public const string PathToFile = "../../../TextSorting/test.txt";
        public const string PathToLogsRadix = "../../../TextSorting/log_radix.txt";
        public const string PathToLogsSelection = "../../../TextSorting/log_selection.txt";
        public string[] ReadFile(string path)
        {
            string text = File.ReadAllText(path);

            return text.Split(" ");
        }   

        public void WriteFile(string path, StringBuilder str)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(str);
        }

        public void WriteLogs(string path, List<Record> logs)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using StreamWriter sw = new StreamWriter(path, true);
            StringBuilder str = new();
            foreach (var item in logs)
            {
                str.Append(item.toString());
            }
            sw.WriteLine(str);

        }
    }
}
