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
    public class rksearchtest
    {
        [TestMethod]
        public void RkSearchTest()
        {
            string src = "acgtaaactgggacct";
            string sub = "ctg";
            RkSearch search = new RkSearch();
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

        [TestMethod]
        public void RkSearchRandomSequence()
        {
            SeqUtils gen = new SeqUtils();
            string src = gen.GenerateSequence(1000);

            // 13 is the  max limit due to size of long
            string sub = src.Substring(900, 23);
            RkSearch search = new RkSearch();
            int idx = search.Search(src, sub);
            Assert.IsTrue(idx > 0);
            Assert.IsTrue(idx == 900);
        }

        [TestMethod]
        public void RkSearchWithDiff()
        {
            SeqUtils util = new SeqUtils();
            string src = util.GenerateSequence(1000);
            string sub = src.Substring(900, 23);
            RkSearch search = new RkSearch();
            sub = util.InsertDiff(sub, 5);

            int idx = search.SearchWithDiff(src, sub, 5);
            Assert.IsTrue(idx > 0);

        }
    }
}
