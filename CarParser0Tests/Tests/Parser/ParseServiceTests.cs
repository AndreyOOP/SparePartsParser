using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.ParserNS;
using System;
using OpenQA.Selenium.IE;
using System.Collections.Generic;

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

        [TestMethod()]
        public void GetElementsTest()
        {
            Service.NavigateToSite("http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm", () => { return true; });

            var PriceElements = Service.GetElements("#central-column .search_element .search_price", (str) => { });

            List<String> Actual = new List<String>();
            foreach (var el in PriceElements)
            {
                Actual.Add(el.Text);
            }

            Assert.AreEqual(2, PriceElements.Count);
            Assert.AreEqual("998 грн" , Actual[0]);
            Assert.AreEqual("1816 грн", Actual[1]);
        }

        [TestMethod()]
        public void CouldNotGetElementsTest()
        {
            Service.NavigateToSite("http://localhost:49242/ParseService/NavigatetoUrl/MD619865.htm", () => { return true; });

            var PriceElements = Service.GetElements("#zzz", (str) => { Console.WriteLine("Could not get element"); });

            Assert.AreEqual(0, PriceElements.Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}