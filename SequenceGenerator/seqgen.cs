using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceGenerator
{
    public class SeqGen
    {
        const string m_alphabet = "actg";
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public string Generate(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = m_alphabet[Convert.ToInt32(Math.Floor(m_alphabet.Length * random.NextDouble()))];
                builder.Append(ch);
            }

            return builder.ToString();
        }

    }
}
