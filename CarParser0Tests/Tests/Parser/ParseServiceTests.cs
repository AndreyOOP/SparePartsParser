using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.ParserNS;
using System;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using CarParser0Tests.SiteParser.ParserMocks;
using OpenQA.Selenium;

namespace CarParser0.SiteParser.Tests
{
    [TestClass]
    public class ParseServiceTests
    {
        InternetExplorerDriver Driver;
        ParseService Service;
        LoggerMock Logger;

        [TestInitialize]
        public void Setup()
        {
            Driver = new InternetExplorerDriver("Resources/");

            Logger = new LoggerMock();

            Service = new ParseService(Driver, Logger);
        }

        [TestMethod]
        public void NavigateToSiteSuccessTest()
        {
            String Url = "http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm";

            Service.NavigateToSite(Url);

            Assert.AreEqual(1, Driver.FindElementsById("ak_rev").Count);
        }

        [TestMethod]
        public void NavigateToWrongSiteTest()
        {
            String Url = "http://localhost:49242/error.htm";

            Service.NavigateToSite(Url);

            Assert.AreEqual(0, Driver.FindElementsById("ak_rev").Count);
        }

        [TestMethod]
        public void GetElementsTest()
        {
            Service.NavigateToSite("http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm");

            var elements = Service.GetElements("#central-column .search_element .search_price");

            List<IWebElement> actual = new List<IWebElement>();
            actual.AddRange(elements);


            Assert.AreEqual("998 грн" , actual[0].Text);
            Assert.AreEqual("1816 грн", actual[1].Text);
        }

        [TestMethod]
        public void CouldNotGetElementsTest()
        {
            Service.NavigateToSite("http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm");

            var elements = Service.GetElements("#zzz", "MD619865");


            Assert.AreEqual(0, elements.Count);
            Assert.AreEqual("MD619865 - Not Found, query - #zzz", Logger.Message);
        }

        [TestMethod]
        public void CouldNotGetElementsIgnoreNotFoundTest()
        {
            Service.NavigateToSite("http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm");

            var elements = Service.GetElements("#zzz", "MD619865", false);


            Assert.AreEqual(0, elements.Count);
            Assert.IsNull(Logger.Message);
        }

        [TestMethod]
        public void GetElementsFromIWebElementTest()
        {
            Service.NavigateToSite("http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm");

            var element = Driver.FindElementById("central-column");

            var prices = Service.GetElements(element, ".search_price");


            Assert.AreEqual("998 грн" , prices[0].Text);
            Assert.AreEqual("1816 грн", prices[1].Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}