using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0Tests.SiteParser.ParserMocks;
using CarParser0.DTO;
using System;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()]
    public class AutoKladTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            AutoKlad parser = new AutoKlad("Resources/", new LoggerMock());

            parser.url = "http://localhost:49242/";

            List<SiteInfo> actual = parser.Parse("MD619865");

            Assert.AreEqual("id: MD619865; site: AutoKlad; qty: -; price: 998" , actual[0].ToString());
            Assert.AreEqual("id: MD619865; site: AutoKlad; qty: -; price: 1816", actual[1].ToString());
        }

        
        //TODO ?

        //[TestMethod()]
        //public void CouldNotFoundPriceIdParseTest()
        //{
        //    Assert.Fail();
        //}
    }
}