using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.ExternalSortingAlgorithms
{
    public class DirectMergeSort
    {
        public string FileInput { get; set; }
        private int _columnNumber = 0;
        private ColumnType _columnType = ColumnType.str;
        private long iterations, segments;

        public DirectMergeSort(string filename)
        {
            FileInput = filename;
            iterations = 1; // степень двойки, количество элементов в каждой последовательности
        }
        public DirectMergeSort(string filename, int columnNumber, ColumnType type)
        {
            FileInput = filename;
            _columnNumber = columnNumber;
            _columnType = type;
            iterations = 1;

        }
        public DirectMergeSort(string filename, int columnNumber)
        {
            FileInput = filename;
            _columnNumber = columnNumber;
            iterations = 1;
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
        public void SortAsInt()
        {
            while (true)
            {
                SplitToFiles();
                if (segments == 1)
                {
                    break;
                }
                MergePairsAsInt();
            }
        }
        public void SortAsString()
        {
            while (true)
            {
                SplitToFiles();
                if (segments == 1)
                {
                    break;
                }
                MergePairsAsString();
            }
        }
        private void SplitToFiles()
        {
            segments = 1;
            using (StreamReader sr = new StreamReader(FileInput))
            using (StreamWriter writerA = new StreamWriter("a.txt"))
            using (StreamWriter writerB = new StreamWriter("b.txt"))
            {
                long counter = 0;
                bool flag = true;

                while (!sr.EndOfStream)
                {
                    if (counter == iterations)
                    {
                        flag = !flag;
                        counter = 0;
                        segments++;
                    }
                    string element = sr.ReadLine();

                    if (flag)
                    {
                        writerA.WriteLine(element);
                        Console.WriteLine($"Считываем элемент {element} с файла \"{FileInput}\" и записываем в файл a.txt.");
                    }
                    else
                    {
                        writerB.WriteLine(element);
                        Console.WriteLine($"Считываем элемент {element} с файла \"{FileInput}\" и записываем в файл b.txt.");
                    }
                    counter++;
                }
            }
            Console.WriteLine();
        }

        private void MergePairsAsInt()
        {
            using StreamReader readerA = new StreamReader(File.OpenRead("a.txt"));
            using StreamReader readerB = new StreamReader(File.OpenRead("b.txt"));
            using StreamWriter sr = new StreamWriter(File.Create(FileInput));
            long counterA = iterations, counterB = iterations;
            int elementA = 0, elementB = 0;
            string strA = null, strB = null;
            bool pickedA = false, pickedB = false;
            while (!readerA.EndOfStream || !readerB.EndOfStream || pickedA || pickedB)
            {
                if (counterA == 0 && counterB != 0)
                {
                    Console.WriteLine($"Серия a закончилась, дописываем {counterB} элементов серии b.");
                }
                if (counterB == 0 && counterA != 0)
                {
                    Console.WriteLine($"Серия b закончилась, дописываем {counterA} элементов серии a.");
                }
                if (counterA == 0 && counterB == 0)
                {
                    counterA = iterations;
                    counterB = iterations;
                }

                if (!readerA.EndOfStream)
                {
                    if (counterA > 0 && !pickedA)
                    {
                        strA = readerA.ReadLine();
                        elementA = int.Parse(strA.Split(";")[_columnNumber]);
                        Console.WriteLine($"Считываем элемент {elementA} с файла \"a.txt\".");
                        pickedA = true;
                    }
                }

                if (!readerB.EndOfStream)
                {
                    if (counterB > 0 && !pickedB)
                    {
                        strB = readerB.ReadLine();
                        elementB = int.Parse(strB.Split(";")[_columnNumber]);
                        Console.WriteLine($"Считываем элемент {elementB} с файла \"b.txt\".");
                        pickedB = true;
                    }
                }

                if (pickedA)
                {
                    if (pickedB)
                    {
                        if (elementA < elementB)
                        {
                            Console.WriteLine($"Добавляем {elementA} из файла \"a.txt\" в файл \"{FileInput}\".");
                            sr.WriteLine(strA);
                            counterA--;
                            pickedA = false;
                        }
                        else
                        {
                            Console.WriteLine($"Добавляем {elementB} из файла \"b.txt\" в файл \"{FileInput}\".");
                            sr.WriteLine(strB);
                            counterB--;
                            pickedB = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Добавляем {elementA} из файла \"a.txt\" в файл \"{FileInput}\".");
                        sr.WriteLine(strA);
                        counterA--;
                        pickedA = false;
                    }
                }
                else if (pickedB)
                {
                    Console.WriteLine($"Добавляем {elementB} из файла \"b.txt\" в файл \"{FileInput}\".");
                    sr.WriteLine(strB);
                    counterB--;
                    pickedB = false;
                }
            }
            sr.Close();
            readerA.Close();
            readerB.Close();
            iterations *= 2;
            Console.WriteLine();
            Console.WriteLine($"Увеличиваем размер серии в 2 раза(теперь она равна {iterations}).");
            Console.WriteLine();


        }

        private void MergePairsAsString()
        {
            using (StreamReader readerA = new StreamReader("a.txt"))
            using (StreamReader readerB = new StreamReader("b.txt"))
            using (StreamWriter sr = new StreamWriter(FileInput))
            {
                long counterA = iterations, counterB = iterations;
                string elementA = null, elementB = null;
                string strA = null, strB = null;
                bool pickedA = false, pickedB = false;
                while (!readerA.EndOfStream || !readerB.EndOfStream || pickedA || pickedB)
                {
                    if (counterA == 0 && counterB != 0)
                    {
                        Console.WriteLine($"Серия a закончилась, дописываем {counterB} элементов серии b.");
                    }
                    if (counterB == 0 && counterA != 0)
                    {
                        Console.WriteLine($"Серия b закончилась, дописываем {counterA} элементов серии a.");
                    }
                    if (counterA == 0 && counterB == 0)
                    {
                        counterA = iterations;
                        counterB = iterations;
                    }

                    if (!readerA.EndOfStream)
                    {
                        if (counterA > 0 && !pickedA)
                        {
                            strA = readerA.ReadLine();
                            elementA = strA.Split(";")[_columnNumber];
                            Console.WriteLine($"Считываем элемент {elementA} с файла \"a.txt\".");
                            pickedA = true;
                        }
                    }

                    if (!readerB.EndOfStream)
                    {
                        if (counterB > 0 && !pickedB)
                        {
                            strB = readerB.ReadLine();
                            elementB = strB.Split(";")[_columnNumber];
                            Console.WriteLine($"Считываем элемент {elementB} с файла \"b.txt\".");
                            pickedB = true;
                        }
                    }

                    if (pickedA)
                    {
                        if (pickedB)
                        {
                            if (String.CompareOrdinal(elementA, elementB) < 0)
                            {
                                Console.WriteLine($"Добавляем {elementA} из файла \"a.txt\" в файл \"{FileInput}\".");
                                sr.WriteLine(strA);
                                counterA--;
                                pickedA = false;
                            }
                            else
                            {
                                Console.WriteLine($"Добавляем {elementB} из файла \"b.txt\" в файл \"{FileInput}\".");
                                sr.WriteLine(strB);
                                counterB--;
                                pickedB = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Добавляем {elementA} из файла \"a.txt\" в файл \"{FileInput}\".");
                            sr.WriteLine(strA);
                            counterA--;
                            pickedA = false;
                        }
                    }
                    else if (pickedB)
                    {
                        Console.WriteLine($"Добавляем {elementB} из файла \"b.txt\" в файл \"{FileInput}\".");
                        sr.WriteLine(strB);
                        counterB--;
                        pickedB = false;
                    }
                }
                iterations *= 2;
                Console.WriteLine();
                Console.WriteLine($"Увеличиваем размер серии в 2 раза (теперь она равна {iterations}).");
                Console.WriteLine();
            }

        }
        private static bool NeedToReorder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }


    }
}
