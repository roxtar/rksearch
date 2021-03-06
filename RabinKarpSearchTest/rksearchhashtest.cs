﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabinKarpSearch;
namespace RabinKarpSearchTest
{
    [TestClass]
    public class RkSearchHashTest
    {
        [TestMethod]
        public void TestHash()
        {
            RkSearchHash hash = new RkSearchHash();
            long h = hash.GenerateHash("ACGT");
            Console.WriteLine("h: {0}", h);
            

            //Generate rolling hash for CGTA
            h = hash.GenerateRollingHash('A', 'A', h, 4);
            Console.WriteLine("h: {0}", h);
            Assert.AreEqual(h, hash.GenerateHash("CGTA"));

            //Generate rolling hash for GTAG from CGTA
            h = hash.GenerateRollingHash('C', 'G', h, 4);
            Console.WriteLine("h: {0}", h);
            Assert.AreEqual(h, hash.GenerateHash("GTAG"));
        }
    }
}
