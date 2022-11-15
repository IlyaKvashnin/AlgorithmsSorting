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
        public string[] ReadFile(string path)
        {
            string text = File.ReadAllText(path);

            return text.Split(" ");
        }
    }
}
