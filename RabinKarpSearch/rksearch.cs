using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabinKarpSearch
{
    public class RkSearch
    {
        int m_base;
        public RkSearch(int hashBase)
        {
            m_base = hashBase;
        }

        public RkSearch()
        {
            m_base = 19;
        }

        public int Search(string src, string substr)
        {
            if (src.Length < substr.Length)
                return -1;

            RkSearchHash hash = new RkSearchHash(m_base);
            long target = hash.GenerateHash(substr);
            long rolHash = hash.GenerateHash(src.Substring(0, substr.Length));
            int i = 0;
            for (i = 0; i < src.Length - substr.Length; i++)
            {
                if (rolHash == target)
                {                    
                    return i;
                }
                rolHash = hash.GenerateRollingHash(src[i], src[i + substr.Length], rolHash, substr.Length);                
            }

            // Avoid per loop comparison, of i + susbstr.Length
            if (rolHash == target)
            {
                return i;
            }

            return -1;
        }
    }
}
