using CarParser0.Logger;
using System;

namespace CarParser0Tests.SiteParser.ParserMocks
{
    public class LogMock : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
