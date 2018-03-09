using System;
using System.Collections.Generic;
using CarParser0.DTO;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace CarParser0.SiteParser
{
    public class Auto911Parser : IAbstractSiteParser
    {
        private readonly String IE_DRIVER = @"C:\Users\Anik\Documents\Visual Studio 2017\Projects\CarParser0\CarParser0\bin\Debug\";

        private List<SiteInfo> infoList;


        public List<SiteInfo> Parse(string item)
        {
            infoList = new List<SiteInfo>();

            using (var driver = new InternetExplorerDriver(IE_DRIVER))
            {
                driver.Navigate().GoToUrl("http://911auto.com.ua/search/" + item);


                var z = driver.FindElementById("product_tbl");
                var price = z.FindElement( By.CssSelector(".hl > :last-child")).Text;

                var info = new SiteInfo();
                info.id = item;
                info.quantity = "-";
                info.site = "http://911auto.com.ua";
                info.price = price;

                infoList.Add(info);
            }

            return infoList;
        }
    }
}
