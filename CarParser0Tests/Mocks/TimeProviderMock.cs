﻿using CarParser0.Logger;

namespace CarParser0Tests.Logger
{
    public class TimeProviderMock : ITimeProvider
    {
        public string getCurrentTime()
        {
            return "28.02.2018|19:51:36|";
        }
    }
}
