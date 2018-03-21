using CarParser0.ParserNS;
using CarParser0.ParserNS.SiteParsers;
using CarParser0Tests.SiteParser.ParserMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParser0Tests.Tests.Parser
{
    [TestClass()]
    public class AutoKladServiceTest
    {
        [TestMethod()]
        public void AutoKladServiceParse()
        {
            var Dr = new InternetExplorerDriver("Resources/");
            var Service = new ParseService(Dr, new LoggerMock());

            var s = new AutoKladService(Service, "http://localhost:49242/AutoKlad/", new LoggerMock());

            var info = s.Parse("MD619865.htm");

            Dr.Quit();

            Assert.AreEqual("983 грн", info[0].price);
            Assert.AreEqual("1086 грн", info[1].price);
            Assert.AreEqual("1816 грн", info[2].price);
        }
    }
}
