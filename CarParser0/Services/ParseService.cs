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
    }
}

//public List<T> GetElements<T>(String cssSelector, Boolean handleError = true)
//{
//    IReadOnlyCollection<T> elements = (IReadOnlyCollection<T>)Driver.FindElementsByCssSelector(cssSelector);

//    if (handleError && elements.Count == 0)
//    {
//        OnError();
//    }

//    List<T> result = new List<T>();

//    result.AddRange(elements);

//    return result;
//}


//public void NavigateToSite(String url, Func<Boolean> isLoaded, Action<String> IsNotLoaded)
//{
//    Driver.Navigate().GoToUrl(url);

//    if(!isLoaded())
//    {
//        IsNotLoaded(url);

//        //throw new Exception();
//    }
//}