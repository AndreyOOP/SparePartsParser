﻿using CarParser0.Interfaces;
using System;

namespace CarParser0Tests.SiteParser.ParserMocks
{
    public class LoggerMock : ILogger
    {
        public String Message { get; private set; }

        public void Log(string message)
        {
            Console.WriteLine(message);

            Message = message;
        }
    }
}
