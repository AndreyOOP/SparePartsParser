using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

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

        public void NavigateToSite(String url, Func<Boolean> isLoaded, Action<String> IsNotLoaded)
        {
            Driver.Navigate().GoToUrl(url);

            if(!isLoaded())
            {
                IsNotLoaded(url);

                //throw new Exception();
            }
        }

        public IReadOnlyCollection<IWebElement> GetElements(String cssSelector, Action<String> OnNotFound)
        {
            var elements = Driver.FindElementsByCssSelector(cssSelector);
            
            if(elements.Count == 0)
            {
                OnNotFound(cssSelector);
                //throw new Exception();
            }

            return elements;
        }

        public IReadOnlyCollection<IWebElement> GetElements(String cssSelector)
        {
            return Driver.FindElementsByCssSelector(cssSelector);
        }

        //get element -> onsuccess, on error
        //get element -> onsuccess - return, on error lambada

        //parse element -> onsuccess text, on error lambada
    }
}
