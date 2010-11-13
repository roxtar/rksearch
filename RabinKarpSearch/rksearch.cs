using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

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
            int srcLen = src.Length;
            int subLen = sub.Length;
           

            if (srcLen < subLen)
                return -1;
            RkSearchHash hash = new RkSearchHash();
            long target = hash.GenerateHash(sub);
            long rolHash = hash.GenerateHash(src.Substring(0, subLen));
            int i = 0;
            int limit = srcLen - subLen;            
            int rolDiff = 0;
            for (i = 0; i < limit; i++)
            {
                rolDiff = CountSetPairs((ulong)(target ^ rolHash));
                if (rolDiff <= diff)
                {                    
                    return i;
                }
                rolHash = hash.GenerateRollingHash(src[i], src[i + subLen], rolHash, subLen);
            }

            rolDiff = CountSetPairs((ulong)(target ^ rolHash));
            if (rolDiff <= diff)
            {
                return i;
            }
            return -1;
        }

        public int CountSetPairs2(ulong i)
        {
            int c = 0;
            while (i != 0)
            {
                if ((i & 3) != 0)
                    c++;
                i >>= 2;
            }
            return c;
        }

        private int CountSetBits(ulong i)
        {
            // See http://stackoverflow.com/questions/2709430/count-number-of-bits-in-a-64-bit-long-big-integer
            i = i - ((i >> 1) & 0x5555555555555555UL);
            i = (i & 0x3333333333333333UL) + ((i >> 2) & 0x3333333333333333UL);
            return (int)(unchecked(((i + (i >> 4)) & 0xF0F0F0F0F0F0F0FUL) * 0x101010101010101UL) >> 56); 
        }

        public int CountSetPairs(ulong x)
        {
            x = (x | (x >> 1)) & 0x5555555555555555;            
            return CountSetBits(x);            
        }

        
    }
}
