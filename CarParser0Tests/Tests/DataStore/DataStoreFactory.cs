using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using CarParser0.ConfigNS;
using CarParser0Tests.SiteParser.ParserMocks;
using CarParser0.ConfigF.enums;

namespace CarParser0.DataStore.Tests
{
    [TestClass()]
    public class DataStoreFactoryTests
    {
        Configuration Config;

        [TestInitialize()]
        public void Setup()
        {
            Config = new Configuration();
        }

        [TestMethod()]
        public void CreateCSVDataStoreTest()
        {
            Config.StorePath = "TestFiles/DataStore/factory-storage.csv";
            Config.StoreType = DataStoreType.CSV;

            var DataStore = DataStoreFactory.CreateDataStore(Config, new LoggerMock());

            Assert.AreEqual(typeof(StoreToCSV), DataStore.GetType());
        }

        [TestMethod()]
        public void CreateHTMLDataStoreTest()
        {
            Config.StorePath = "TestFiles/DataStore/factory-storage.html";
            Config.StoreType = DataStoreType.HTML;

            var DataStore = DataStoreFactory.CreateDataStore(Config, new LoggerMock());

            Assert.AreEqual(typeof(StoreToHtml), DataStore.GetType());
        }

        [TestMethod()]
        public void CreateDataStoreNotImplementedTypeTest()
        {
            var Logger = new LoggerMock();

            DataStoreType[] types = new DataStoreType[] { DataStoreType.EXCEL, DataStoreType.SQL };

            foreach (DataStoreType type in types)
            {
                Config.StoreType = type;

                Assert.ThrowsException<NotImplementedException>(
                        () => DataStoreFactory.CreateDataStore(Config, Logger)
                    );
            }
        }

        [TestMethod()]
        public void CreateDataStoreIncorrectTypeTest()
        {
            Config.StoreType = (DataStoreType)(-1);

            try
            {
                DataStoreFactory.CreateDataStore(Config, new LoggerMock());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Unknown Data store type -1", ex.Message);
            }
        }
    }
}