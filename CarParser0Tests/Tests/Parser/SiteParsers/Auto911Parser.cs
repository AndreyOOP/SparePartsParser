using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0.DTO;
using CarParser0Tests.SiteParser.ParserMocks;
using System;
using OpenQA.Selenium.IE;
using CarParser0.ParserNS;

namespace CarParser0.SiteParser.Tests
{
    [TestClass]
    public class Auto911ParserTests
    {
        InternetExplorerDriver Driver;
        LoggerMock Logger;
        ParseService Service;

        [TestInitialize]
        public void Setup()
        {
            Driver  = new InternetExplorerDriver("Resources/");
            Logger  = new LoggerMock();
            Service = new ParseService(Driver, Logger);
        }

        [TestMethod]
        public void ParseTest()
        {
            List<String> expected = new List<String>() {
                "id: MD619865; site: 911auto; qty: -; price: 835",
                "id: MD619865; site: 911auto; qty: 59; price: 805",
                "id: MD619865; site: 911auto; qty: 100; price: 957",
                "id: MD619865; site: 911auto; qty: 100; price: 1168",
                "id: MD619865; site: 911auto; qty: 100; price: 1168"
            };

            Auto911Parser Parser = new Auto911Parser(Service, "http://localhost:49242/911", Logger);

            List<SiteInfo> actual = Parser.Parse("MD619865");


            for(int i=0; i<5; i++)
            {
                Assert.AreEqual(expected[i], actual[i].ToString());
            }
        }

        [TestMethod]
        public void CannotParseTest()
        {
            Auto911Parser Parser = new Auto911Parser(Service, "http://localhost:49242/911", Logger);

            List<SiteInfo> actual = Parser.Parse("zzz");


            Assert.AreEqual(0 , actual.Count);
            Assert.IsNull(Logger.Message);
        }

        [TestCleanup]
        public void Clean()
        {
            Driver.Quit();
        }
    }
}