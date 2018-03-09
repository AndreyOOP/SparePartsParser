using CarParser0.ConfigNS;
using CarParser0.DataStore;
using CarParser0.DTO;
using CarParser0.InputReaderFolder;
using CarParser0.Logger;
using CarParser0.SiteParser;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarParser0
{
    class MainLogic
    {
        private static Config config;

        private static ILogger Logger;
        private static List<IAbstractSiteParser> parsers;
        private static IReader reader;
        private static IDataStore store;
        private static List<String> ids;
        private static Parser parser;

        static void Main(string[] args)
        {
            Config config = LoadConfig(args);

            if (config == null)
            {
                Console.ReadKey();
                return;
            }


            Initialization(config);

            ids = reader.ReadData();
            
            //Parser parser = new Parser(parsers, ids, Logger);

            List<SiteInfo> info = parser.Execute(); //add ids here to execute

            foreach(SiteInfo i in info)
            {
                store.Save(i);
            }

            Console.ReadKey();
        }

        static Config LoadConfig(string[] args)
        {
            String path = "config.xml";

            if(args.Length > 0)
            {
                path = args[0];
            }

            try
            {
                return new Config(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        static void Initialization(Config config)
        {
            Logger = LoggerFactory.Instantiate(config);
            Logger.Log("Logger Initialized");

            parsers = new List<IAbstractSiteParser>();
            parsers.Add(new Auto911Parser());
            Logger.Log("Parsers Initialized");

            reader = InputReaderFactory.CreateReader(config);
            Logger.Log("Reader Initialized");

            store = DataStoreFactory.CreateDataStore(config);
            Logger.Log("DataStore Initialized");

            ids = new List<String>();

            //ids.Add("MD619865");
            //ids.Add("MD619865");
            //Logger.Log("Models Added");

            parser = new Parser(parsers, ids, Logger); //ids have to be moved out

            Logger.Log("Initialization Complete");
        }
    }
}
