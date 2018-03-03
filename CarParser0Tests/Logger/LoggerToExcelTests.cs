using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0Tests;
using System.Threading;

namespace CarParser0.Logger.Tests
{
    [TestClass()]
    public class LoggerToExcelTests
    {
        [TestMethod()]
        public void LoggerToExcelTest() //how to test ?
        {
            string path = T.TEST_FOLDER + T.LOGGER + "x.xlsx";

            ILogger Logger = new LoggerToExcel(path, new TimeProvider());

            Logger.Log("Hello x");

            Thread.Sleep(1100);
            Logger.Log("Hello 2x");

            Thread.Sleep(1100);
            Logger.Log("Привет!x");
        }
    }
}