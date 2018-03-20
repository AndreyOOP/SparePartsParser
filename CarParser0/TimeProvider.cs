using System;

namespace CarParser0.Logger
{
    public class TimeProvider : ITimeProvider
    {
        public string getCurrentTime()
        {
            return DateTime.Now.ToString("dd.MM.yyyy|hh:mm:ss|");
        }
    }
}
