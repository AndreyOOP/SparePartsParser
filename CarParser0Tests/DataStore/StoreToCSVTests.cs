using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CarParser0.DTO;
using System.IO;

namespace CarParser0.DataStore.Tests
{
    [TestClass()]
    public class StoreToCSVTests
    {
        String Storage = "store.csv";

        [TestInitialize]
        public void Initialize()
        {
            if (File.Exists(Storage))
                File.Delete(Storage);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var CSVDataStore = new StoreToCSV(Storage);
            var Info         = new SiteInfo("MD51", "123.4", "4", "some site");

            CSVDataStore.Save(Info);

            var expected = "\r\n" +
                           "id; sit; qty; price\r\n" +
                           "MD51; some site; 4; 123.4\r\n";

            Assert.AreEqual(expected, File.ReadAllText(Storage));
        }
    }
}