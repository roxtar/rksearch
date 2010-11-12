using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace RabinKarpSearchTest
{
    [TestClass]
    public class seqgentest
    {
        [TestMethod]
        public void TestGenerateSequence()
        {
            SeqGen gen = new SeqGen();
            string s = gen.Generate(4);
            Assert.AreEqual(s.Length, 4);
            Console.WriteLine(s);

            s = gen.Generate(100);
            Assert.AreEqual(s.Length, 100);
            Console.WriteLine(s);
        }
    }
}
