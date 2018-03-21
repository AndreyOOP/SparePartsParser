using CarParser0.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace CarParser0.ParserNS
{
    public class ParseService
    {
        InternetExplorerDriver Driver;
        ILogger Logger;

        public ParseService(InternetExplorerDriver Driver, ILogger Logger)
        {
            this.Driver = Driver;
            this.Logger = Logger;
        }

        public void NavigateToSite(String url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void OnNotFound(String cssSelector, String id)
        {
            String msg = String.Format("{0} - Not Found, query - {1}", id, cssSelector);

            Logger.Log(msg);
        }

        public IReadOnlyCollection<IWebElement> GetElements(String cssSelector, String id = "", Boolean handleNotFound = true)
        {
            IReadOnlyCollection<IWebElement> elements = Driver.FindElementsByCssSelector(cssSelector);
            
            if(handleNotFound && elements.Count == 0)
            {
                OnNotFound(cssSelector, id);
            }

            return elements;
        }

        public List<IWebElement> GetElements(IWebElement Source, String cssSelector, String id = "", Boolean handleNotFound = true)
        {
            var elements = Source.FindElements(By.CssSelector(cssSelector));

            if (handleNotFound && elements.Count == 0)
            {
                OnNotFound(cssSelector, id);
            }

            List<IWebElement> list = new List<IWebElement>();

            list.AddRange(elements);

            return list;
        }
    }
}