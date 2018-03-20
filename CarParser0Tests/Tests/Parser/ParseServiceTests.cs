using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.ParserNS;
using System;
using OpenQA.Selenium.IE;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()]
    public class ParseServiceTests
    {
        InternetExplorerDriver Driver;
        ParseService Service;

        [TestInitialize]
        public void Setup()
        {
            Driver = new InternetExplorerDriver("Resources/");

            Service = new ParseService(Driver);
        }

        [TestMethod()]
        public void NavigateToSiteSuccessTest()
        {
            String Url = "http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm";

            Func<Boolean> isCorrectPage = () =>
            {
                var elem = Driver.FindElementsById("ak_rev");

                return elem.Count > 0;
            };

            Assert.IsTrue( Service.NavigateToSite(Url, isCorrectPage));
        }

        [TestMethod()]
        public void NavigateToWrongSiteTest()
        {
            String Url = "http://localhost:49242/error.htm";

            Func<Boolean> isCorrectPage = () =>
            {
                var elem = Driver.FindElementsById("ak_rev");

                return elem.Count > 0;
            };

            Assert.IsFalse( Service.NavigateToSite(Url, isCorrectPage));
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}