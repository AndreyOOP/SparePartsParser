using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CarParser0Tests;

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
            Assert.AreEqual("test_type", config.LogType);

            Console.WriteLine(config.LogPath);
            Console.WriteLine(config.LogType);
        }
    }
}