using AlgorithmsSorting.TextSorting;
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
        public const string PathToLogsBubble = "../../../InternalSorting/log_bubble.txt";
        public const string PathToLogsQuick = "../../../InternalSorting/log_quick.txt";
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
            File.WriteAllText(path,str.ToString());
        }

        public void WriteLogs(string path, List<Record> logs)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using StreamWriter sw = new StreamWriter(path, true);
            List<string> strings = new();
            foreach (var item in logs)
            {
                strings.Add(item.toString());
            }
            strings.ForEach(s => sw.WriteLine(s));
        }
    }
}
