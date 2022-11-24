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

        public void PrintLogs()
        {
            string inputChar;
            do
            {
                System.Console.WriteLine("Если вы хотите постепенно просматривать записи в логах, управляя нажатием клавиш введите y/yes");
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
