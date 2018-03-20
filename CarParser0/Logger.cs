using CarParser0.Interfaces;
using System;
using System.IO;
using System.Text;

namespace CarParser0.Logger
{
    public class Logger : ILogger
    {
        private string logPath;
        private ITimeProvider timer;

        public Logger(string logPath, ITimeProvider timer)
        {
            this.logPath = logPath;
            this.timer = timer;
        }

        public void Log(string message)
        {
            string logMsg = timer.getCurrentTime() + message + "\r\n";

            File.AppendAllText(logPath, logMsg, Encoding.UTF8);

            Console.Write(logMsg);
        }
    }
}
