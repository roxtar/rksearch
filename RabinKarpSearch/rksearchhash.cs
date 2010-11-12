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
        int[] m_chartables;
        

        public RkSearchHash()
        {
            m_chartables = new int[Convert.ToInt32('t') + 1];
            m_chartables[Convert.ToInt32('a')] = 0;
            m_chartables[Convert.ToInt32('c')] = 1;
            m_chartables[Convert.ToInt32('g')] = 2;
            m_chartables[Convert.ToInt32('t')] = 3;
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
            GenPowers(sLen);
            for (int i = 0; i < sLen; i++)
            {
                hash += BaseValue(s[i], sLen - 1 - i);
            }

            return hash;
        }

        private void GenPowers(int len)
        {
            m_powtables[0] = 1;
            for (int i = 1; i < len; i++)
            {
                m_powtables[i] = m_powtables[i - 1] * m_base;
            }
        }

        private long BaseValue(char c, int position)
        {
            return (m_chartables[Convert.ToInt32(c)] * m_powtables[position]);
        }                
    
    }
}
