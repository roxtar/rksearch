using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabinKarpSearch;
namespace RabinKarpSearchTest
{
    [TestClass]
    public class simplesearchtest
    {
        [TestMethod]
        public void SimpleSearchTest()
        {
            string src = "acgtaaactgggacct";
            string sub = "ctg";
            SimpleSearch search = new SimpleSearch();
               
            int idx = search.Search(src, sub);
            Assert.IsTrue(idx > 0);
            Assert.IsTrue(idx == 7);
            Console.WriteLine("Found at {0}", idx);

            sub = "a";
            idx = search.Search(src, sub);
            Assert.IsTrue(idx >= 0);
            Assert.IsTrue(idx == 0);

            sub = "acct";
            idx = search.Search(src, sub);
            Assert.IsTrue(idx >= 0);
            Assert.IsTrue(idx == src.Length - sub.Length);

            sub = "tttt";
            idx = search.Search(src, sub);
            Assert.IsTrue(idx < 0);
        }

    }
}
