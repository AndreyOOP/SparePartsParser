using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CarParser0Tests;
using CarParser0.ConfigF.enums;
using CarParser0.ConfigF;
using System.Xml;

namespace CarParser0.ConfigNS.Tests
{
    [TestClass()]
    public class ConfigTests
    {

        [TestMethod()]
        public void ConfigTest()
        {
            String path = T.TEST_FOLDER + T.CONFIG + "test_config.xml";

            Config config = new Config(path);


            Assert.AreEqual("test_path", config.LogPath);
            Assert.AreEqual("test_path_2", config.ReaderPath);

            Assert.AreEqual(LoggerType.TXT, config.LogType);
            Assert.AreEqual(InputType.EXCEL, config.ReaderType);
        }

        [TestMethod()]
        public void ConfigFileNotFoundTest()
        {
            String path = T.TEST_FOLDER + T.CONFIG + "not_existing_file.xml";

            Assert.ThrowsException<FileNotFoundException>( () => new Config(path) );
        }

        [TestMethod()]
        public void ConfigFileExceptionTest()
        {
            String path = T.TEST_FOLDER + T.CONFIG + "err_config.xml";

            Assert.ThrowsException<XmlException>( () => new Config(path) );
        }
    }
}