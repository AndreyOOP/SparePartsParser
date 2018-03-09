using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.SiteParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()]
    public class ParserSampleTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            ParserSample ps = new ParserSample();

            ps.Parse();
        }
    }
}