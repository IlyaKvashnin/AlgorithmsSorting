using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsSorting.ExternalSortingAlgorithms
{
    public class NaturalMergeSort
    {
        private int _timeout = 0;
        public Logger logger = new Logger();
        private int _columnNumber = 0;
        private ColumnType _columnType = ColumnType.str;
        string FileInput = "data.txt";
        int _segments = 1;
        public NaturalMergeSort(string filename, int columnNumber, ColumnType type, int timeout)
        {
            FileInput = filename;
            _columnNumber = columnNumber;
            _columnType = type;
            _timeout = timeout;
            
        }
        public NaturalMergeSort(string filename, int columnNumber, int timeout)
        {
            FileInput = filename;
            _columnNumber = columnNumber;
            _timeout = timeout;
        }
        public void Sort()
        {
            if (_columnType == ColumnType.str)
            {
                SortAsString();
            }
            if (_columnType == ColumnType.integer)
            {
                SortAsInt();
            }
        }
        public void SortAsString()
        {
            while (true)
            {
                SplitToFilesAsString();
                if (_segments == 1)
                {
                    break;
                }
                MergePairsAsString();
            }
        }
        public void SortAsInt()
        {
            while (true)
            {
                SplitToFilesAsInt();
                if (_segments == 1)
                {
                    break;
                }
                MergePairsAsInt();
            }
        }

        

        private void SplitToFilesAsInt()
        {
            _segments = 1;
            logger.AddLog(new Record("Info", "Разделение на два файла"), _timeout);
            using StreamReader br = new StreamReader(File.OpenRead(FileInput));
            using StreamWriter writerA = new StreamWriter(File.Create("a.txt"));
            using StreamWriter writerB = new StreamWriter(File.Create("b.txt"));
            bool flag = true;
            string str1 = null;
            string str2;
            int element1 = 0;
            int element2 = 0;
            while (true)
            {
                if (str1 is null)
                {
                    str1 = br.ReadLine();
                    element1 = int.Parse(str1?.Split(";")[_columnNumber]);
                    writerA.WriteLine(str1);
                }

                str2 = br.ReadLine();
                if (str2 is null | String.Compare(str2, "", StringComparison.Ordinal) == 0) break;
                element2 = int.Parse(str2.Split(";")[_columnNumber]);

                if (element1 > element2)
                {
                    flag = !flag;
                    _segments++;
                }

                if (flag)
                {
                    writerA.WriteLine(str2);
                }
                else
                {
                    writerB.WriteLine(str2);
                }

                str1 = str2;
                element1 = element2;
            }
            br.Close();
            writerA.Close();
            writerB.Close();
        }
        private void MergePairsAsInt()
        {
            using StreamReader readerA = new StreamReader(File.OpenRead("a.txt"));
            using StreamReader readerB = new StreamReader(File.OpenRead("b.txt"));
            using StreamWriter bw = new StreamWriter(File.Create(FileInput));
            int elementA = 0, elementB = 0;
            string strA = null, strB = null;
            bool pickedA = false, pickedB = false, endA = false, endB = false;
            while (!endA || !endB)
            {
                if (!endA & !pickedA)
                {
                    strA = readerA.ReadLine();
                    if (strA is null | String.Compare(strA, "", StringComparison.Ordinal) == 0) endA = true;
                    else
                    {
                        elementA = int.Parse(strA.Split(";")[_columnNumber]);
                        pickedA = true;
                    }
                }

                if (!endB & !pickedB)
                {
                    strB = readerB.ReadLine();
                    if (strB is null | String.Compare(strB, "", StringComparison.Ordinal) == 0) endB = true;
                    else
                    {
                        elementB = int.Parse(strB.Split(";")[_columnNumber]);
                        pickedB = true;
                    }
                }

                if (pickedA)
                {
                    if (pickedB)
                    {
                        logger.AddLog(new Record("Compare", $"Сравнение {elementA} и {elementB}"), _timeout);
                        if (elementA < elementB)
                        {
                            bw.WriteLine(strA);
                            logger.AddLog(new Record("Info", $"Запись {elementA}"), _timeout);
                            pickedA = false;
                        }
                        else
                        {
                            bw.WriteLine(strB);
                            logger.AddLog(new Record("Info", $"Запись {elementB}"), _timeout);
                            pickedB = false;
                        }
                    }
                    else
                    {
                        bw.WriteLine(strA);
                        logger.AddLog(new Record("Info", $"Запись {elementA}"), _timeout);
                        pickedA = false;
                    }
                }
                else
                {
                    bw.WriteLine(strB);
                    logger.AddLog(new Record("Info", $"Запись {elementB}"), _timeout);
                    pickedB = false;
                }
            }
        }

        private void SplitToFilesAsString()
        {
            _segments = 1;
            logger.AddLog(new Record("Info", "Разделение на два файла"), _timeout);
            using StreamReader sr = new StreamReader(File.OpenRead(FileInput));
            using StreamWriter writerA = new StreamWriter(File.Create("a.txt"));
            using StreamWriter writerB = new StreamWriter(File.Create("b.txt"));
            bool flag = true;
            string str1 = null;
            string str2;
            string element1 = null;
            string element2;
            while (true)
            {
                if (str1 is null)
                {
                    str1 = sr.ReadLine();
                    element1 = str1.Split(";")[_columnNumber];
                    writerA.WriteLine(str1);
                }

                str2 = sr.ReadLine();
                if (str2 is null | String.Compare(str2, "", StringComparison.Ordinal) == 0) break;
                element2 = str2.Split(";")[_columnNumber];

                if (String.CompareOrdinal(element1, element2) > 0)
                {
                    flag = !flag;
                    _segments++;
                }

                if (flag)
                {
                    writerA.WriteLine(str2);
                }
                else
                {
                    writerB.WriteLine(str2);
                }

                str1 = str2;
                element1 = element2;
            }
            sr.Close();
            writerA.Close();
            writerB.Close();
        }

        private void MergePairsAsString()
        {
            using StreamReader readerA = new StreamReader(File.OpenRead("a.txt"));
            using StreamReader readerB = new StreamReader(File.OpenRead("b.txt"));
            using StreamWriter sw = new StreamWriter(File.Create(FileInput));
            string elementA = null, elementB = null, strA = null, strB = null;
            bool pickedA = false, pickedB = false, endA = false, endB = false;
            while (!endA || !endB)
            {
                if (!endA & !pickedA)
                {
                    strA = readerA.ReadLine();
                    if (strA is null | String.Compare(strA, "", StringComparison.Ordinal) == 0) endA = true;
                    else
                    {
                        elementA = strA.Split(";")[_columnNumber];
                        pickedA = true;
                    }
                }

                if (!endB & !pickedB)
                {
                    strB = readerB.ReadLine();
                    if (strB is null | String.Compare(strB, "", StringComparison.Ordinal) == 0) endB = true;
                    else
                    {
                        elementB = strB.Split(";")[_columnNumber];
                        pickedB = true;
                    }
                }

                if (pickedA)
                {
                    if (pickedB)
                    {
                        logger.AddLog(new Record("Info", $"Сравнение {elementA} и {elementB}"), _timeout);
                        if (String.CompareOrdinal(elementA, elementB) < 0)
                        {
                            sw.WriteLine(strA);
                            logger.AddLog(new Record("Info", $"Запись {elementA}"), _timeout);
                            pickedA = false;
                        }
                        else
                        {
                            sw.WriteLine(strB);
                            logger.AddLog(new Record("Info", $"Запись {elementB}"), _timeout);
                            pickedB = false;
                        }
                    }
                    else
                    {
                        sw.WriteLine(strA);
                        logger.AddLog(new Record("Info", $"Запись {elementA}"), _timeout);
                        pickedA = false;
                    }
                }
                else
                {
                    sw.WriteLine(strB);
                    logger.AddLog(new Record("Info", $"Запись {elementB}"), _timeout);
                    pickedB = false;
                }
            }
        }

    }
}
