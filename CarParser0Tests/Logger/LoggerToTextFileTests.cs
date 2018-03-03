using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0Tests.Logger;
using System.IO;
using CarParser0Tests;

namespace CarParser0.Logger.Tests
{
    [TestClass()]
    public class LoggerToTextFileTests
    {
        string pathToLog = T.TEST_FOLDER + T.LOGGER + "test_log.txt";

        [TestInitialize()]
        public void Initialize()
        {
            File.Delete(pathToLog);
        }

        [TestMethod()]
        public void LoggerToTextFile_LogTest()
        {
            ILogger Logger = new LoggerToTextFile(pathToLog, new TestTimer());

            Logger.Log("Test");
            Logger.Log("привет!");

            Assert.AreEqual("28.02.2018|19:51:36|Test\r\n28.02.2018|19:51:36|привет!\r\n", File.ReadAllText(pathToLog));
        }
    }
}