using CarParser0.ConfigNS;
using CarParser0.DataStore;
using CarParser0.InputReaderFolder;
using CarParser0.Logger;
using CarParser0.SiteParser;
using System;
using System.Collections.Generic;

namespace CarParser0
{
    public class MainLogic
    {
        private static Config Config;

        private static ILogger Logger;
        private static List<IAbstractSiteParser> Parsers;
        private static IInputProvider Reader;
        private static IDataStore Store;

        public static void Main(string[] args)
        {
            Config = LoadConfig(args);

            if(Config != null)
            {
                Initialization(Config);

                var Ids = Reader.GetInputData();
                Logger.Log("Read " + Ids.Count + " ids from " + Config.ReaderPath);

                var DataScrapper = new Parser(Ids, Parsers, Store, Logger);
                Logger.Log("Initialize data scrapper");

                DataScrapper.Execute();
                Logger.Log("Execution complete");
            }

            #if DEBUG == false
                Console.ReadKey();
            #endif
        }

        static Config LoadConfig(string[] args)
        {
            String path = "1 Files/config.xml";

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
            Logger = new LoggerToTextFile(config.LogPath, new TimeProvider());
            Logger.Log("Logger initialized");

            Reader = InputProviderFactory.CreateInputReader(config);
            Logger.Log("Reader of type " + Reader.GetType().Name + " initialized");

            Parsers = new List<IAbstractSiteParser>() { new Auto911Parser("SiteParser/IE Driver/", Logger) };
            Logger.Log("Site parsers initialized");

            Store = DataStoreFactory.CreateDataStore(config, Logger);
            Logger.Log("DataStore of type " + Store.GetType() + "Initialized");
        }
    }
}
