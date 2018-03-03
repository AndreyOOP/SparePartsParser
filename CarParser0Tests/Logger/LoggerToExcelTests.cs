using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0Tests;
using System.Threading;

namespace CarParser0.Logger.Tests
{
    [TestClass()]
    public class LoggerToExcelTests
    {
        [TestMethod()]
        public void LoggerToExcelTest()
        {
            string path = T.TEST_FOLDER + T.LOGGER + "x.xlsx";

            ILogger Logger = new LoggerToExcel(path, new TimeProvider());

            Logger.Log("Hello x");

            //Thread.Sleep(1100);
            Logger.Log("Hello 2x");

            //Thread.Sleep(1100);
            Logger.Log("Привет!x");

            //LoggerToExcel le = new LoggerToExcel(path, new TimeProvider());

            //such way disposes an object but we have to manually call Dispose method
            //LoggerToExcel le = (LoggerToExcel)Logger; 
            //le.Dispose();
        }
    }
}