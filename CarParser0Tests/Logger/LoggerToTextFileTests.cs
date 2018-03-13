using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0Tests.Logger;
using System.IO;

namespace CarParser0.Logger.Tests
{
    [TestClass()]
    public class LoggerToTextFileTests
    {
        string pathToLog = "test_log.txt";

        [TestInitialize()]
        public void Initialize()
        {
            if(File.Exists(pathToLog))
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