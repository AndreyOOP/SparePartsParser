using System;
using System.IO;
using System.Text;

namespace CarParser0.Logger
{
    public class LoggerToTextFile : ILogger
    {
        private string logPath;
        private ITimeProvider timer;

        public LoggerToTextFile(string logPath, ITimeProvider timer)
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
