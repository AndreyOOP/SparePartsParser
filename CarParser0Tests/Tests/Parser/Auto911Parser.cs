using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0.DTO;
using CarParser0Tests.SiteParser.ParserMocks;
using System;
using System.IO;
using OpenQA.Selenium.IE;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()] //todo how to correctly test it ?
    public class Auto911ParserTests
    {
        InternetExplorerDriver Driver;
        Auto911Parser Parser;

        [TestInitialize]
        public void Setup()
        {
            Driver = new InternetExplorerDriver("Resources/");

            Parser = new Auto911Parser("http://localhost:49242/911", Driver, new LoggerMock());
        }

        [TestMethod()]
        public void ParseTest()
        {
            List<SiteInfo> actual = Parser.Parse("MD619865");

            Assert.AreEqual("id: MD619865; site: 911auto; qty: -; price: 835", actual[0].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 59; price: 805", actual[1].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 957", actual[2].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 1168", actual[3].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 1168", actual[4].ToString());
        }

        [TestMethod()]
        public void CannotParseTest()
        {
            List<SiteInfo> actual = Parser.Parse("MDzzz");

            Assert.AreEqual(0, actual.Count);
        }

        //add test case when one of tables are available

        [TestCleanup]
        public void Clean()
        {
            Driver.Quit();
        }
        //TODO add test cases if not found price, is it necessary to throw exception (if it is error) (if it is possible not found price - ok)
    }
}