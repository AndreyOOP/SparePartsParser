using CarParser0.ConfigF;
using CarParser0.ConfigF.enums;
using System;
using System.IO;
using System.Xml;

namespace CarParser0.ConfigNS
{
    public class Config
    {
        private String path;

        public String     LogPath { get; }
        public LoggerType LogType { get; }

        public String    ReaderPath { get; }
        public InputType ReaderType { get; }


        public Config(String path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Config file not found");

            this.path = path;

            XmlDocument xml = new XmlDocument();

            xml.Load(path);

            LogPath = GetNodeText(xml, "root/logger/path");

            LogType = GetLoggerType(xml, "root/logger/type");

            ReaderPath = GetNodeText(xml, "root/input/path");

            ReaderType = GetReaderType(xml, "root/input/type");
        }

        private String GetNodeText(XmlDocument xml, String path)
        {
            XmlNode node = xml.SelectSingleNode(path);

            if (node == null)
                throw new XmlException("Could not load property " + path);

            return node.InnerText;
        }

        private LoggerType GetLoggerType(XmlDocument xml, String path)
        {
            switch (GetNodeText(xml, path))
            {
                case "txt"  :
                    return LoggerType.TXT;

                case "excel":
                    return LoggerType.EXCEL;

                default:
                    throw new Exception("Incorrect logger type");
            }
        }

        private InputType GetReaderType(XmlDocument xml, String path)
        {
            switch (GetNodeText(xml, path))
            {
                case "csv":
                    return InputType.CSV;

                case "excel":
                    return InputType.EXCEL;

                default:
                    throw new Exception("Incorrect input type");
            }
        }
    }
}
