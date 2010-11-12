using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace RabinKarpSearchTest
{
    [TestClass]
    public class sequtilstest
    {
        [TestMethod]
        public void TestGenerateSequence()
        {
            SeqUtils gen = new SeqUtils();
            string s = gen.GenerateSequence(4);
            Assert.AreEqual(s.Length, 4);
            Console.WriteLine(s);

            s = gen.GenerateSequence(100);
            Assert.AreEqual(s.Length, 100);
            Console.WriteLine(s);
        }

        [TestMethod]
        public void TestInsertDiff()
        {
            SeqUtils util = new SeqUtils();
            string s = util.GenerateSequence(10);
            Assert.AreEqual(s.Length, 10);
            Console.WriteLine(s);

            string snew = util.InsertDiff(s, 5);
            Assert.AreEqual(snew.Length, 10);
            Console.WriteLine(snew);

            int diff = util.HammingDistance(s, snew);
            Assert.AreEqual(diff, 5);

            s = util.GenerateSequence(1000);
            snew = util.InsertDiff(s, 103);
            diff = util.HammingDistance(s, snew);
            Assert.AreEqual(diff, 103);
        }
    }
}
