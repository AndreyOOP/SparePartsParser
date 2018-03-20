using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarParser0.InputReaderFolder.Tests
{
    [TestClass()]
    public class CSVReaderTests
    {
        [TestMethod()]
        public void ReadDataTest()
        {
            List<String> Expected = new List<String>(new String[] { "aaa", "eee", "b", "c", "k" });
            CSVReader Reader = new CSVReader("TestFiles/InputProvider/in.csv");

            List<String> Actual = Reader.GetInputData();

            for (int i = 0; i < Expected.Count; i++)
                Assert.AreEqual(Expected[i], Actual[i]);
        }

        [TestMethod()]
        public void InputDataFileNotExistTest()
        {
            try
            {
                new CSVReader("incorrect file path");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("File with input data could not be found", ex.Message);
            }
        }
    }
}