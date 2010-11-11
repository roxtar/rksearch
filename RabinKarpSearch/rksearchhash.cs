using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabinKarpSearch
{
    public class RkSearchHash
    {
        int m_base;

        public RkSearchHash()
        {
            m_base = 19;
        }

        public RkSearchHash(int hashbase)
        {
            m_base = hashbase;
        }

        /// <summary>
        /// Generates rolling hash from a previously generated hash
        /// </summary>
        /// <param name="mostSig">The most significant character of the previous string</param>
        /// <param name="leastSig">The least significant character of the previous string</param>
        /// <param name="previous">Previous rolling hash</param>
        /// <param name="len">Length of the string</param>
        /// <returns>Next rolling hash</returns>
        public long GenerateRollingHash(char mostSig, char leastSig, long previous, int len)
        {
            // Assuming alphabet is A, C, T, G

            long hash = previous;
            hash = ((previous - BaseValue(mostSig, len - 1)) * m_base) + BaseValue(leastSig, 0);
            return hash;
        }

        public long GenerateHash(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            long hash = 0;

            // Treat the string from left to right.
            // The left most character is the most significant
            // whereas the right most is the least significant
            for (int i = 0; i < s.Length; i++)
            {
                hash += BaseValue(s[i], s.Length - 1 - i);
            }

            return hash;
        }

        private long BaseValue(char c, int position)
        {
            return (CharValue(c) * (long)Math.Pow(m_base, position));
        }

        private int CharValue(char c)
        {
            switch (c)
            {
                case 'A':
                case 'a':
                    return 1;
                case 'C':
                case 'c':
                    return 2;
                case 'G':
                case 'g':
                    return 3;
                case 'T':
                case 't':
                    return 4;
            }

            return -1000000;
                       
        }
    
    }
}
