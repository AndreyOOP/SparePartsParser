using CarParser0.ParserNS;
using CarParser0.ParserNS.SiteParsers;
using CarParser0Tests.SiteParser.ParserMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;

namespace CarParser0Tests.Tests.Parser
{
    [TestClass()]
    public class AutoKladTest
    {
        InternetExplorerDriver Driver;
        ParseService Service;
        LoggerMock Logger;

        [TestInitialize]
        public void Setup()
        {
            Driver  = new InternetExplorerDriver("Resources/");
            Logger  = new LoggerMock();
            Service = new ParseService(Driver, Logger);
        }

        [TestMethod()]
        public void AutoKladServiceParse()
        {
            var siteParser = new AutoKlad(Service, "http://localhost:49242/AutoKlad/", Logger);

            var siteInfo = siteParser.Parse("MD619865.htm");


            Assert.AreEqual("983 грн" , siteInfo[0].price);
            Assert.AreEqual("1086 грн", siteInfo[1].price);
            Assert.AreEqual("1816 грн", siteInfo[2].price);
        }

        [TestMethod()]
        public void AutoKladServiceNotFound()
        {
            var siteParser = new AutoKlad(Service, "http://localhost:49242/AutoKlad/", Logger);

            var siteInfo = siteParser.Parse("zzz");

            Assert.AreEqual("zzz - Not Found, query - #central-column .search_element a", Logger.Message);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}