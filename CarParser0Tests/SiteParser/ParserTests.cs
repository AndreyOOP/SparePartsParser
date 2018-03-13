using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.SiteParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarParser0Tests.SiteParser.ParserMocks;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            var Parsers = new List<IAbstractSiteParser>();
            Parsers.Add(new ParserMock("parser_1"));
            Parsers.Add(new ParserMock("parser_2"));

            var ids = new List<string>();
            ids.Add("id_1");
            ids.Add("id_2");
            ids.Add("id_3");


            Parser p = new Parser(Parsers, ids, new LogMock());

            var result = p.Execute();

            Assert.AreEqual(6, result.Count);
        }
    }
}