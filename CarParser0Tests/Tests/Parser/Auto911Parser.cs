using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0.DTO;
using CarParser0Tests.SiteParser.ParserMocks;
using System;
using System.IO;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()] //todo how to correctly test it ?
    public class Auto911ParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            Auto911Parser parser = new Auto911Parser("Resources/", new LoggerMock());
            parser.url = "http://localhost:49242/911";


            List<SiteInfo> actual = parser.Parse("MD619865");

            Assert.AreEqual("id: MD619865; site: 911auto; qty: -; price: 835", actual[0].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 59; price: 805", actual[1].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 957", actual[2].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 1168", actual[3].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 1168", actual[4].ToString());
        }

        //TODO add test cases if not found price, is it necessary to throw exception (if it is error) (if it is possible not found price - ok)
    }
}