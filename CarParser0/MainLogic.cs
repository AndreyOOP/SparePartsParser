using CarParser0.ConfigNS;
using CarParser0.Logger;
using System;

namespace CarParser0
{
    class MainLogic
    {
        private static ILogger Logger;

        static void Main(string[] args)
        {
            String ConfigPath = "config.xml";

            //Config config = new Config(ConfigPath);

            Initialization(new Config(ConfigPath));

            Logger.Log("Test Msg 1");
            Logger.Log("Test Msg 2");
            Logger.Log("Test Msg 3");

            Console.ReadLine();
            
        }

        static void Initialization(Config config)
        {
            if(config.LogType == "txt")
            {
                Logger = new LoggerToTextFile(config.LogPath, new TimeProvider());
            }
            else if (config.LogType == "excel")
            {
                Logger = new LoggerToExcel(config.LogPath, new TimeProvider());
            }

            Logger.Log("Initialized");
        }
    }
}
