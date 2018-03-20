using OpenQA.Selenium.IE;
using System;

namespace CarParser0.ParserNS
{
    public class ParseService
    {
        InternetExplorerDriver Driver;

        public ParseService(InternetExplorerDriver Driver)
        {
            this.Driver = Driver;
        }

        public Boolean NavigateToSite(String url, Func<Boolean> isLoaded)
        {
            Driver.Navigate().GoToUrl(url);

            return isLoaded();
        }
    }
}
