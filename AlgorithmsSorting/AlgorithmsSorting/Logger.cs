using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting
{
    public class Logger
    {
        public List<Record> Logs = new List<Record>();

        public void AddLog(Record record, int timeout)
        {
            Logs.Add(record);
            Console.WriteLine(record.toString());
            Thread.Sleep(timeout);
        }

        public void PrintLogs()
        {
            string inputChar;
            do
            {
                System.Console.WriteLine("Если вы хотите постепенно просматривать записи в логах, управляя нажатием \"enter\" введите y/yes");
                inputChar = System.Console.ReadLine();
                var needInputChar = inputChar?.ToLower();
                if ((needInputChar == "y") || (needInputChar == "yes"))
                {
                    foreach (var item in Logs)
                    {
                        Console.WriteLine(item.toString());
                        Console.ReadLine();
                    }
                    break;
                }
                    
                else
                {
                    foreach (var item in Logs)
                    {
                        Console.WriteLine(item.toString());
                    }
                    break;
                }
            } while (true);
        }

        
    }
}
