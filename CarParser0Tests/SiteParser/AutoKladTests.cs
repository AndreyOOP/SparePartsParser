using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0Tests.SiteParser.ParserMocks;
using CarParser0.DTO;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()]
    public class AutoKladTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            AutoKlad parser = new AutoKlad("SiteParser/IE Driver/", new LogMock());

            List<SiteInfo> actual = parser.Parse("MD619865");

            Assert.AreEqual("id: MD619865; site: AutoKlad; qty: -; price: 983 грн", actual[0].ToString());
        }
    }
}