using CarParser0.ConfigNS;
using CarParser0.DataStore;
using CarParser0.InputReaderFolder;
using CarParser0.Interfaces;
using CarParser0.Logger;
using CarParser0.SiteParser;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace CarParser0
{
    public class MainLogic
    {
        private static Configuration Config;

        private static ILogger Logger;
        private static List<IAbstractSiteParser> Parsers;
        private static IInputProvider Reader;
        private static IDataStore Store;
        private static InternetExplorerDriver Driver;

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

                Driver.Quit();
                Logger.Log("IE Driver Closed");
            }

            #if DEBUG == false
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            #endif
        }

        static Configuration LoadConfig(string[] args)
        {
            String path = "1 Files/config.xml"; //todo move out

            if(args.Length > 0)
            {
                path = args[0];
            }

            try
            {
                return Config.Load(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        static void Initialization(Configuration config)
        {
            Logger = new Logger.Logger(config.LogPath, new TimeProvider());
            Logger.Log("Logger initialized");

            Reader = InputProviderFactory.CreateInputReader(config);
            Logger.Log("Reader of type " + Reader.GetType().Name + " initialized");

            Driver = new InternetExplorerDriver("Resources/");
            Logger.Log("InternetExplorerDriver initialized");

            Parsers = new List<IAbstractSiteParser>() {
                new Auto911Parser("http://911auto.com.ua/search/", Driver, Logger),
                new AutoKlad("SiteParser/IE Driver/", Logger)
            };
            Logger.Log("Site parsers initialized");

            Store = DataStoreFactory.CreateDataStore(config, Logger);
            Logger.Log("DataStore of type " + Store.GetType() + "Initialized");
        }
    }
}
