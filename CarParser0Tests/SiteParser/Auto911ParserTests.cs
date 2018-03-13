using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0.DTO;
using CarParser0Tests.SiteParser.ParserMocks;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()] //todo how to correctly test it ?
    public class Auto911ParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            Auto911Parser parser = new Auto911Parser("SiteParser/IE Driver/", new LogMock());

            List<SiteInfo> actual = parser.Parse("MD619865");

            Assert.AreEqual("id: MD619865; site: 911auto; qty: -; price: 822", actual[0].ToString());
        }
    }
}