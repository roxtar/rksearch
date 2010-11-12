using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabinKarpSearch
{
    public class RkSearch
    {               
        public RkSearch()
        {
            
        }

        public int Search(string src, string substr)
        {
            int srcLen = src.Length;
            int subLen = substr.Length;
            if (srcLen < subLen)
                return -1;

            RkSearchHash hash = new RkSearchHash();
            long target = hash.GenerateHash(substr);            
            long rolHash = hash.GenerateHash(src.Substring(0, subLen));
            int i = 0;
            int limit = srcLen - subLen;
            for (i = 0; i < limit; i++)
            {
                if (rolHash == target)
                {                    
                    return i;
                }
                rolHash = hash.GenerateRollingHash(src[i], src[i + subLen], rolHash, subLen);                
            }

            // Avoid per loop comparison, of i + susbstr.Length
            if (rolHash == target)
            {
                return i;
            }

            return -1;
        }

        public int SearchWithDiff(string src, string sub, int diff)
        {
            return -1;
        }

        
    }
}
