using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0.DTO;
using CarParser0Tests.SiteParser.ParserMocks;
using System;
using System.IO;
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
            Auto911Parser Parser = new Auto911Parser(Service, "http://localhost:49242/911", Logger);

            List<SiteInfo> actual = Parser.Parse("MD619865");


            Assert.AreEqual("id: MD619865; site: 911auto; qty: -; price: 835"   , actual[0].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 59; price: 805"  , actual[1].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 957" , actual[2].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 1168", actual[3].ToString());
            Assert.AreEqual("id: MD619865; site: 911auto; qty: 100; price: 1168", actual[4].ToString());
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