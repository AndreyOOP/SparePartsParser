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
        [TestMethod()]
        public void CreateCSVDataStoreTest()
        {
            var config = new Config();

            SetProperty(config, "StorePath", "storage.csv");
            SetProperty(config, "StoreType", DataStoreType.CSV);

            var DataStore = DataStoreFactory.CreateDataStore(config, new LoggerMock());

            Assert.AreEqual(typeof(StoreToCSV), DataStore.GetType());
        }

        [TestMethod()]
        public void CreateHTMLDataStoreTest()
        {
            var config = new Config();

            SetProperty(config, "StorePath", "storage.html");
            SetProperty(config, "StoreType", DataStoreType.HTML);

            var DataStore = DataStoreFactory.CreateDataStore(config, new LoggerMock());

            Assert.AreEqual(typeof(StoreToHtml), DataStore.GetType());
        }

        [TestMethod()]
        public void CreateDataStoreNotImplementedTypeTest()
        {
            var Logger = new LoggerMock();
            var Conf = new Config();

            DataStoreType[] types = new DataStoreType[] { DataStoreType.EXCEL, DataStoreType.SQL };

            foreach(DataStoreType type in types)
            {
                SetProperty(Conf, "StoreType", type);

                Assert.ThrowsException<NotImplementedException>(
                        () => DataStoreFactory.CreateDataStore(Conf, Logger)
                    );
            }
        }

        [TestMethod()]
        public void CreateDataStoreIncorrectTypeTest()
        {
            var config = new Config();

            SetProperty(config, "StoreType", -1); //"unnknown type"

            try
            {
                DataStoreFactory.CreateDataStore(config, new LoggerMock());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Unknown Data store type -1", ex.Message);
            }
        }


        private void SetProperty(Object obj, String propertyName, Object propertyValue)
        {
            PropertyInfo Property = obj.GetType().GetProperty(propertyName);

            Property.SetValue(obj, propertyValue);
        }
    }
}