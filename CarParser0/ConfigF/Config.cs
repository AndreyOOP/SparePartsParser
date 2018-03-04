using System;
using System.Xml;

namespace CarParser0.ConfigNS
{
    public class Config
    {
        private String path;

        public String LogPath { get; }
        public String LogType { get; }

        public Config(String path)
        {
            this.path = path;

            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            LogPath = xml.SelectSingleNode("logger/path").InnerText;

            LogType = xml.SelectSingleNode("logger/type").InnerText;

            if (LogPath == null || LogType == null)
                throw new Exception();

        }
    }
}
