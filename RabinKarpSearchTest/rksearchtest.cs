﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabinKarpSearch;
using SequenceGenerator;

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
            SeqGen gen = new SeqGen();
            string src = gen.Generate(1000);

            // 13 is the  max limit due to size of long
            string sub = src.Substring(900, 23);
            RkSearch search = new RkSearch(5);
            int idx = search.Search(src, sub);
            Assert.IsTrue(idx > 0);
            Assert.IsTrue(idx == 900);
        }
    }
}
