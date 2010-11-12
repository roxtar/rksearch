using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class SeqUtils
    {
        const string m_alphabet = "actg";
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public string GenerateSequence(int size)
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

        public int HammingDistance(string s1, string s2)
        {
            int d = 0;
            if (s1.Length != s2.Length)
                return -1;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    d++;
            }
            return d;
        }

        public string InsertDiff(string s, int d)
        {
            int sLen = s.Length;
            int i = 0;
            StringBuilder str = new StringBuilder(s);
            while (i < d)
            {
                // choose a random position
                int pos = Convert.ToInt32(Math.Floor(sLen * random.NextDouble()));
                
                // There is already a diff at this place, don't try again.
                if (str[pos] != s[pos])
                    continue;
                                
                // choose a random alphabet
                char ch = m_alphabet[Convert.ToInt32(Math.Floor(m_alphabet.Length * random.NextDouble()))];
                while (ch == str[pos])
                {
                    ch = m_alphabet[Convert.ToInt32(Math.Floor(m_alphabet.Length * random.NextDouble()))];
                }

                str[pos] = ch;
                i++;
            }
            return str.ToString();
        }

    }
}
