using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CarParser0Tests;

namespace CarParser0.InputReaderFolder.Tests
{
    [TestClass()]
    public class CSVReaderTests
    {
        [TestMethod()]
        public void ReadDataTest()
        {
            String path = T.TEST_FOLDER + T.READER + "in.csv";

            CSVReader Reader = new CSVReader(path);

            List<String> data = Reader.GetInputData();

            Assert.AreEqual(5, data.Count);
        }
    }
}