using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabinKarpSearch
{
    public class RkSearchHash
    {
        const int m_base = 4;
        long[] m_powtables;

        public RkSearchHash()
        {
                   
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
         
            long hash = 0;            
            // Treat the string from left to right.
            // The left most character is the most significant
            // whereas the right most is the least significant
            int sLen = s.Length;

            m_powtables = new long[sLen];
            for (int i = 0; i < sLen; i++)
            {
                hash += BaseValue(s[i], sLen - 1 - i);
            }

            return hash;
        }

        private long BaseValue(char c, int position)
        {
            return (CharValue(c) * Power(m_base, position));
        }

        private long Power(int x, int n)
        {
            long result = 1;
            
            if (m_powtables[n] != 0)
                return m_powtables[n];

            for (int i = 0; i < n; i++)
            {
                m_powtables[i] = result;
                result *= x;                
            }
            return result;
        }

        private int CharValue(char c)
        {
            switch (c)
            {
                
                case 'a':
                    return 0;
                
                case 'c':
                    return 1;
                
                case 'g':
                    return 2;
                
                case 't':
                    return 3;
            }

            return -1000000;
                       
        }
    
    }
}
