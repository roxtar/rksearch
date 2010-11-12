using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabinKarpSearch;
using SequenceGenerator;

namespace RkSearchCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            RkSearch rksearch = new RkSearch(4);
            SimpleSearch ssearch = new SimpleSearch();

            SeqGen gen = new SeqGen();
            string src = gen.Generate(100000000);

            string sub = src.Substring(85000000, 50);
            int idx = 0;

            Console.WriteLine(src.Length);

            DateTime start, end;


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
        }
    }
}
