using CarParser0.ConfigF;
using CarParser0.ConfigF.enums;
using CarParser0.Interfaces;
using System;
using System.IO;
using System.Xml;

namespace CarParser0.ConfigNS
{
    public class Configuration
    {
        public String        LogPath    { get; set; }
        public String        ReaderPath { get; set; }
        public InputType     ReaderType { get; set; }
        public String        StorePath  { get; set; }
        public DataStoreType StoreType  { get; set; }


        public Configuration Load(String path) //looks ugly... for instance have to call method with path
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Config file not found");

            XmlDocument xml = new XmlDocument();

            xml.Load(path);

            LogPath = GetNodeText(xml, "root/logger/path");

            ReaderPath = GetNodeText(xml, "root/input/path");
            ReaderType = GetReaderType(xml, "root/input/type");

            StorePath = GetNodeText(xml, "root/store/path");
            StoreType = GetStoreType(xml, "root/store/type");

            return this;
        }

        private String GetNodeText(XmlDocument xml, String xmlPath)
        {
            XmlNode node = xml.SelectSingleNode(xmlPath);

            if (node == null)
                throw new XmlException("Could not load property " + xmlPath);

            return node.InnerText;
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
                    throw new Exception("Incorrect input reader type");
            }
        }

        private DataStoreType GetStoreType(XmlDocument xml, String path)
        {
            switch (GetNodeText(xml, path))
            {
                case "csv":
                    return DataStoreType.CSV;

                case "html":
                    return DataStoreType.HTML;

                case "excel":
                    return DataStoreType.EXCEL;

                case "sql":
                    return DataStoreType.SQL;

                default:
                    throw new Exception("Incorrect data store type");
            }
        }
    }
}