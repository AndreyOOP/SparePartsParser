using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.SiteParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarParser0.DTO;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()]
    public class Auto911ParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            Auto911Parser parser = new Auto911Parser();

            List<SiteInfo> l = parser.Parse("zzz");

            Assert.AreEqual(1, l.Count);
        }
    }
}