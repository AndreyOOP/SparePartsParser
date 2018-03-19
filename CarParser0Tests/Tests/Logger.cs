using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0Tests.Logger;
using System.IO;
using CarParser0.Interfaces;

namespace CarParser0.Logger.Tests
{
    [TestClass()]
    public class LoggerTests
    {
        string pathToLog = "TestFiles/Logger/test_log.txt";

        [TestInitialize()]
        public void Initialize()
        {
            File.Delete(pathToLog);
        }

        [TestMethod()]
        public void LoggerTest()
        {
            ILogger Logger = new Logger(pathToLog, new TimeProviderMock());

            Logger.Log("Test");
            Logger.Log("привет!");

            Assert.AreEqual("28.02.2018|19:51:36|Test\r\n28.02.2018|19:51:36|привет!\r\n", File.ReadAllText(pathToLog));
        }
    }
}