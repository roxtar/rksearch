using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabinKarpSearch
{
    public class DumbSearch
    {        
        public int Search(string src, string sub)
        {
            if (src.Length < sub.Length)
                return -1;          

            for (int i = 0; i < src.Length - sub.Length + 1; i++)
            {
                bool found = true;
                for (int j = 0; j < sub.Length; j++)
                {
                    if (src[i + j] != sub[j])
                    {
                        found = false;
                    }
                }

                if (found)
                {
                    return i;
                }
            }

            return -1;
        }

        public int SearchWithDiff(string src, string sub, int diff)
        {
            if (src.Length < sub.Length)
                return -1;

            for (int i = 0; i < src.Length - sub.Length + 1; i++)
            {
                bool found = true;
                int diffCount = 0;
                for (int j = 0; j < sub.Length; j++)
                {
                    if (src[i + j] != sub[j])
                    {
                        diffCount++;
                        if (diffCount > diff)
                        {
                            found = false;         
                        }
                    }
                }
                if (found)
                    return i;
            }
            return -1;
        }
    }
}
