using CarParser0.ConfigF.enums;
using CarParser0.ConfigNS;
using System;

namespace CarParser0.Logger
{
    public class LoggerFactory
    {
        public static ILogger Instantiate(Config config)
        {
            if (config.LogType == LoggerType.TXT)
            {
                return new LoggerToTextFile(config.LogPath, new TimeProvider());
            }

            if (config.LogType == LoggerType.EXCEL)
            {
                return new LoggerToExcel(config.LogPath, new TimeProvider());
            }

            throw new Exception("Unknown Logger Type");
        }
    }
}
