using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting
{
    public static class RecordExtenstion
    {

        public static string toString(this Record record)
        {
            return String.Format("[{0}] {1}", record.Action, record.Message);
        }
    }
    public class Record
    {
        public string Action { get; }
        public string Message { get; }

        public Record(string action, string message)
        {
            this.Action = action;
            this.Message = message;
        }

        public static void PrintLog(Record record)
        {
            Console.WriteLine(String.Format("[{0}] {1}", record.Action, record.Message));
        }

    }
}
