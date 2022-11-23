using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsSorting.TextSorting
{
    public class StringsGenerator
    {
        private readonly Random _random = new Random();

        public StringBuilder GenerateArray(int count)
        {
            var builder = new StringBuilder(count);

            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    builder.Append(RandomString(_random.Next(1, 15), true));
                }
                else
                {
                    builder.Append(RandomString(_random.Next(1, 15), true) + " ");
                }

            }
            return builder;
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
