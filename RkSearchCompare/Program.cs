using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabinKarpSearch;
using Utilities;

namespace RkSearchCompare
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreeBillionRkSearch();
        }

        private static void ThreeBillionRkSearch()
        {
            RkSearch rksearch = new RkSearch();
            SeqUtils util = new SeqUtils();
            SimpleSearch ssearch = new SimpleSearch();
            
            // We generate really large strings, which total up to 3 billion in the end. 
            // The substring which we are searching for is 27 characters in length

            string sub = util.GenerateSequence(27);
            List<int> rkmatch = new List<int>();
            List<int> ssmatch = new List<int>();
            TimeSpan rkspan = TimeSpan.Zero, sspan = TimeSpan.Zero;
            DateTime start, end;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Iteration {0}", i);
                for (int j = 0; j < 3000; j++)
                {
                    string src = util.GenerateSequence(1000000);
                    start = DateTime.Now;
                    rkmatch.AddRange(rksearch.SearchWithDiffAll(src, sub, 5));
                    end = DateTime.Now;

                    rkspan += (end - start);

                    start = DateTime.Now;
                    ssmatch.AddRange(ssearch.SearchWithDiffAll(src, sub, 5));
                    end = DateTime.Now;

                    sspan += (end - start);

                    src = null;
                }
            }
            
            Console.WriteLine("Rabin Karp Time taken: {0} s", rkspan.TotalSeconds);
            for (int i = 0; i < rkmatch.Count; i++)
            {
                Console.WriteLine(rkmatch[i]);
            }

            Console.WriteLine("Simple Search Time Taken: {0} s", sspan.TotalSeconds);
            for (int i = 0; i < rkmatch.Count; i++)
            {
                Console.WriteLine(ssmatch[i]);
            }
            
            bool equal = true;
            for (int i = 0; i < rkmatch.Count; i++)
            {
                if (rkmatch[i] != ssmatch[i])
                {
                    equal = false;
                    break;
                }
            }

            Console.WriteLine("Rabin Karp and Simple Search matches are equal: {0}", equal);

        }


        private static void BasicDemo()
        {
            RkSearch rksearch = new RkSearch();
            SimpleSearch ssearch = new SimpleSearch();
            DumbSearch dsearch = new DumbSearch();

            SeqUtils gen = new SeqUtils();
            int seqLen = 200000000;
            Console.Write("Generating sequence of length {0} ....", seqLen);           
            string src = gen.GenerateSequence(200000000);
            Console.WriteLine("Done.");

            
            int subPos = 85000001;
            int subLen = 25;
            Console.WriteLine("Substring of length {0} and at position {1}", subLen, subPos);
            string sub = src.Substring(85000001, 25);  
          
            PlainSearch(src, sub);
            
            int diff = 4;
            sub = gen.InsertDiff(sub, diff);
            DiffSearch(src, sub, diff);     
        }

        private static void DiffSearch(string src, string sub, int diff)
        {
            RkSearch rksearch = new RkSearch();
            SimpleSearch ssearch = new SimpleSearch();
            DumbSearch dsearch = new DumbSearch();

            DateTime start, end;
            int idx = 0;

            Console.WriteLine("Searching with differences");
            Console.WriteLine("Dumb Search ... ");
            start = DateTime.Now;
            idx = dsearch.SearchWithDiff(src, sub, diff);
            end = DateTime.Now;
            Console.WriteLine("Dumb Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            Console.WriteLine("Simple Search ... ");
            start = DateTime.Now;
            idx = ssearch.SearchWithDiff(src, sub, diff);
            end = DateTime.Now;
            Console.WriteLine("Simple Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            Console.WriteLine("Rabin Karp Search ... ");
            start = DateTime.Now;
            idx = rksearch.SearchWithDiff(src, sub, diff);
            end = DateTime.Now;
            Console.WriteLine("RK Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);
        }

        private static void PlainSearch(string src, string sub)
        {
            RkSearch rksearch = new RkSearch();
            SimpleSearch ssearch = new SimpleSearch();
            DumbSearch dsearch = new DumbSearch();

            DateTime start, end;
            int idx = 0;

            Console.WriteLine("Searching");
            Console.WriteLine("Dumb Search ... ");
            start = DateTime.Now;
            idx = dsearch.Search(src, sub);
            end = DateTime.Now;
            Console.WriteLine("Dumb Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            Console.WriteLine("Simple Search ... ");
            start = DateTime.Now;
            idx = ssearch.Search(src, sub);
            end = DateTime.Now;
            Console.WriteLine("Simple Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            Console.WriteLine("Rabin Karp Search ... ");
            start = DateTime.Now;
            idx = rksearch.Search(src, sub);
            end = DateTime.Now;
            Console.WriteLine("RK Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);
        }
    }
}
