using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.ExternalSortingAlgorithms
{
    public class MergeSort
    {
        public class Result
        {
            public double time { get; set; }
            public int compares { get; set; }
            public int passes { get; set; }
        }

        private static void Sort(StreamWriter buf1, StreamWriter buf2, StreamReader buf3, StreamReader buf4, int size, int step, Result res)
        {
            ReadNum(buf3, out int num1);
            ReadNum(buf4, out int num2);
            bool err = false;
            for (int it = 0; it < size; it += step * 2)
            {
                res.compares++;
                int count1 = 0, count2 = 0;
                while (count1 < step && count2 < step)
                {
                    res.compares += 3;
                    if (num2 < num1)
                    {
                        if (!err)
                            buf1.Write(num2 + "\n");
                        count2++;
                        res.compares++;
                        err = !ReadNum(buf4, out num2);
                        if (err || count2 >= step)
                        {
                            do
                            {
                                buf1.Write(num1 + "\n");
                                res.compares += 2;
                                count1++;
                            } while (ReadNum(buf3, out num1) && count1 < step);
                            break;
                        }
                        res.compares += 3;
                    }
                    else
                    {
                        buf1.Write(num1 + "\n");
                        count1++;
                        res.compares += 2;
                        if (!ReadNum(buf3, out num1) || count1 >= step)
                        {
                            do
                            {
                                if (!err)
                                    buf1.Write(num2 + "\n");
                                res.compares += 3;
                                count2++;
                                err = !ReadNum(buf4, out num2);
                            } while (!err && count2 < step);
                            break;
                        }
                    }
                }
                res.compares += 2;
                Swap(ref buf1, ref buf2);
            }
        }

        public static Result Sort(string fileName, string outFile)
        {
            Result res = new Result();
            DateTime start = DateTime.Now;
            StreamReader file = new StreamReader(fileName);
            StreamWriter buf1 = new StreamWriter("buffer1.txt");
            StreamWriter buf2 = new StreamWriter("buffer2.txt");
            StreamReader buf3 = null;
            StreamReader buf4 = null;
            int size = 0;
            while (ReadNum(file, out int num))
            {
                buf1.Write(num + "\n");
                Swap(ref buf1, ref buf2);
                size++;
                res.passes = 1;
            }
            buf1.Dispose();
            buf2.Dispose();
            file.Dispose();
            bool oddIter = true;
            for (int step = 1; step < size / 2; step *= 2)
            {
                res.compares += 2;
                if (oddIter)
                {
                    buf3 = new StreamReader("buffer1.txt");
                    buf4 = new StreamReader("buffer2.txt");
                    buf1 = new StreamWriter("buffer3.txt");
                    buf2 = new StreamWriter("buffer4.txt");
                }
                else
                {
                    buf3 = new StreamReader("buffer3.txt");
                    buf4 = new StreamReader("buffer4.txt");
                    buf1 = new StreamWriter("buffer1.txt");
                    buf2 = new StreamWriter("buffer2.txt");
                }
                Sort(buf1, buf2, buf3, buf4, size, step, res);
                res.passes++;
                buf1.Dispose();
                buf2.Dispose();
                buf3.Dispose();
                buf4.Dispose();
                oddIter = !oddIter;
            }
            res.compares++;
            StreamWriter oFile = new StreamWriter(outFile);
            res.compares++;
            if (oddIter)
            {
                buf3 = new StreamReader("buffer1.txt");
                buf4 = new StreamReader("buffer2.txt");
            }
            else
            {
                buf3 = new StreamReader("buffer3.txt");
                buf4 = new StreamReader("buffer4.txt");
            }
            Merge(buf3, buf4, oFile, size, res);
            buf3.Dispose();
            buf4.Dispose();
            oFile.Dispose();
            res.time = (DateTime.Now - start).TotalMilliseconds;
            return res;
        }

        private static void Merge(StreamReader sr1, StreamReader sr2, StreamWriter oFile, int size, Result res)
        {
            ReadNum(sr1, out int n1);
            ReadNum(sr2, out int n2);
            for (int i = 0; i < size; i++)
            {
                res.compares += 2;
                if (n2 < n1)
                {
                    oFile.Write(n2 + "\n");
                    res.compares++;
                    if (!ReadNum(sr2, out n2))
                    {
                        do
                        {
                            oFile.Write(n1 + "\n");
                            res.compares++;
                        } while (ReadNum(sr1, out n1));
                        break;
                    }
                }
                else
                {
                    oFile.Write(n1 + "\n");
                    res.compares++;
                    if (!ReadNum(sr1, out n1))
                    {
                        do
                        {
                            oFile.Write(n2 + "\n");
                            res.compares++;
                        } while (ReadNum(sr2, out n2));
                        break;
                    }
                }
            }
            res.compares++;
        }

        private static bool ReadNum(StreamReader stream, out int res)
        {
            return Int32.TryParse(stream?.ReadLine()?.Trim(' '), out res);
        }

        private static void Swap<T>(ref T el1, ref T el2)
        {
            T tmp = el1;
            el1 = el2;
            el2 = tmp;
        }
    }
}
