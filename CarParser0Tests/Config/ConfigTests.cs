using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CarParser0.ConfigF.enums;
using CarParser0.ConfigF;
using System.Xml;

namespace CarParser0.ConfigNS.Tests
{
    /*
     * Try to implement as singleton, no need to have few instances
     * as well looks strange -> new Config().Load(path), create an instance just to call one method
     * 
     * When try singleton everything become static... how correctly use? impossible to inject as dependency
     */
    [TestClass()]
    public class ConfigTests
    {
        String folder = "Config/TestFiles/";

        [TestMethod()]
        public void ConfigTest()
        {
            String path = folder + "test_config.xml";

            Config config = new Config().Load(path);


            Assert.AreEqual("logger path"     , config.LogPath);
            Assert.AreEqual("data reader path", config.ReaderPath);
            Assert.AreEqual("data store path" , config.StorePath);

            Assert.AreEqual(InputType.EXCEL  , config.ReaderType);
            Assert.AreEqual(DataStoreType.CSV, config.StoreType);
        }

        [TestMethod()]
        public void ConfigFileNotFoundTest()
        {
            String path = "not_existing_file.xml";

            Assert.ThrowsException<FileNotFoundException>( () => new Config().Load(path) );
        }

        [TestMethod()]
        public void ConfigFileExceptionTest()
        {
            String path = folder + "err_config.xml";

            Assert.ThrowsException<XmlException>( () => new Config().Load(path) );
        }
    }
}