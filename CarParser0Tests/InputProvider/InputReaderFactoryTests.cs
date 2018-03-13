using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.ConfigNS;
using System;
using CarParser0.ConfigF;
using System.Reflection;

namespace CarParser0.InputReaderFolder.Tests
{
    /*
     * How to test properly ?
     * 
     * To test InputReaderFactory i have to input Config mock to it.
     * 
     * I tried to create mock via inheritance but it has private set propertis, i could not find a way to create mock
     * try inheritance when config loaded in constructor - it call base class which have to load not existed file
     * try to override properties - appears two set of properties and as factory use Config (not ConfigMock) - base class properties appears
     * 
     * Now the only possible solution i found - is to use reflection to set required fields...
     * 
     * Maybe do not inject Config at all, pass only required properties (path & type)
     * but what to do if appears db reader - there are will be another set of prperties, so method signature have to be changed
     * 
     * As well it is good to add logger to factory but it is static, so either it should not be static or log have to be done outside... or add to method
     */
    [TestClass()]
    public class InputReaderFactoryTests
    {
        [TestMethod()]
        public void CreateInputReaderCSVTest()
        {
            Config config = new Config();

            SetProperty(config, "ReaderType", InputType.CSV);


            var CSVReader = InputProviderFactory.CreateInputReader(config); //or use just what have t be used ? path & type but what to do with database ?

            Assert.AreEqual(typeof(CSVReader), CSVReader.GetType());
        }

        [TestMethod()]
        public void CreateInputReaderExcelTest()
        {
            Config config = new Config();

            SetProperty(config, "ReaderType", InputType.EXCEL);

            Assert.ThrowsException<NotImplementedException>(() => InputProviderFactory.CreateInputReader(config));
        }

        [TestMethod()]
        public void CreateInputReaderSQLTest()
        {
            Config config = new Config();

            SetProperty(config, "ReaderType", InputType.SQL);

            Assert.ThrowsException<NotImplementedException>(() => InputProviderFactory.CreateInputReader(config));
        }

        [TestMethod()]
        public void CreateInputReaderErrorTypeTest()
        {
            Config config = new Config();

            SetProperty(config, "ReaderType", -1);

            try
            {
                InputProviderFactory.CreateInputReader(config);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Could not find appropriative type to instantiate", ex.Message);
            }
        }

        private void SetProperty(Object obj, String propertyName, Object propertyValue)
        {
            PropertyInfo Property = obj.GetType().GetProperty(propertyName);

            Property.SetValue(obj, propertyValue);
        }
    }
}