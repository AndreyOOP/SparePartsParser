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
        private static Config Config;

        private static ILogger Logger;
        private static List<IAbstractSiteParser> parsers;
        private static IInputProvider reader;
        private static IDataStore store;
        private static List<String> ids;
        private static Parser parser;

        static void Main(string[] args)
        {
            Config = LoadConfig(args);

            if (Config == null)
            {
                Console.ReadKey();
                return;
            }

            Initialization(Config);

            ids = reader.GetInputData();
            
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
                return new Config().Load(path);
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

            parsers = new List<IAbstractSiteParser>(); //parsers factory ?
            parsers.Add(new Auto911Parser());
            Logger.Log("Parsers Initialized");

            reader = InputProviderFactory.CreateInputReader(config);
            Logger.Log("Reader Initialized, type: " + reader.GetType().Name);

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
