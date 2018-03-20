using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CarParser0.Tests
{
    [TestClass()]
    public class MainLogicTests //TODO 
    {
        [TestInitialize()]
        public void Initialization()
        {
            if (File.Exists("IT_Storage.csv"))
                File.Delete("IT_Storage.csv");
        }

        [TestMethod()]
        public void MainTest()
        {
            var args = new String[] { "Integration Test/config.xml" }; //todo path to config

            MainLogic.Main(args);

            Assert.IsTrue(File.Exists("IT_Storage.csv"));
        }
    }
}