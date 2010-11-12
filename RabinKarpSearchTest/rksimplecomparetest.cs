using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabinKarpSearch;
using Utilities;
namespace RabinKarpSearchTest
{
    [TestClass]
    public class rksimplecomparetest
    {
        [TestMethod]
        public void RkSimpleSearchCompareTest()
        {
            RkSearch rksearch = new RkSearch();
            SimpleSearch ssearch = new SimpleSearch();

            SeqGen gen = new SeqGen();
            string src = gen.Generate(1000);

            string sub = src.Substring(850, 15);
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
