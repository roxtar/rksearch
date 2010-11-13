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
            RkSearch rksearch = new RkSearch();
            SimpleSearch ssearch = new SimpleSearch();
            DumbSearch dsearch = new DumbSearch();

            SeqUtils gen = new SeqUtils();
            string src = gen.GenerateSequence(2000000);

            string sub = src.Substring(850001, 25);
            int idx = 0;            

            DateTime start, end;

            start = DateTime.Now;
            idx = dsearch.Search(src, sub);
            end = DateTime.Now;
            Console.WriteLine("Dumb Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            start = DateTime.Now;
            idx = ssearch.Search(src, sub);
            end = DateTime.Now;
            Console.WriteLine("Simple Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            start = DateTime.Now;
            idx = rksearch.Search(src, sub);
            end = DateTime.Now;
            Console.WriteLine("RK Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            Console.WriteLine("Searching with differences");
            int diff = 10;
            sub = gen.InsertDiff(sub, diff);

            start = DateTime.Now;
            idx = dsearch.SearchWithDiff(src, sub, diff);
            end = DateTime.Now;
            Console.WriteLine("Dumb Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            start = DateTime.Now;
            idx = ssearch.SearchWithDiff(src, sub, diff);
            end = DateTime.Now;
            Console.WriteLine("Simple Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);

            start = DateTime.Now;
            idx = rksearch.SearchWithDiff(src, sub, diff);
            end = DateTime.Now;
            Console.WriteLine("RK Search Time: {0}ms", (end - start).TotalMilliseconds);
            Console.WriteLine("Index: {0}", idx);
            

        }
    }
}
