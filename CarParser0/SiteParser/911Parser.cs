using System;
using System.Collections.Generic;
using CarParser0.DTO;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using CarParser0.Logger;
using System.IO;

namespace CarParser0.SiteParser
{
    public class Auto911Parser : IAbstractSiteParser
    {
        private String ieDriverFolder;
        private readonly String url = "http://911auto.com.ua/search/";

        private List<SiteInfo> infoList;
        private ILogger Logger;


        public Auto911Parser(String ieDriverFolder, ILogger Logger)
        {
            this.ieDriverFolder = ieDriverFolder;
            this.Logger = Logger;
        }

        public List<SiteInfo> Parse(string id)
        {
            infoList = new List<SiteInfo>();

            using (var driver = new InternetExplorerDriver(ieDriverFolder))
            {
                try
                {
                    driver.Navigate().GoToUrl(url + id);
                }
                catch (Exception ex)
                {
                    Logger.Log("911auto: Could not open site for id: " + id + ex.Message);
                }

                String price;
                try
                {
                    var node = driver.FindElementById("product_tbl");
                    price = node.FindElement(By.CssSelector(".hl > :last-child")).Text;

                    infoList.Add(new SiteInfo(id, price, "-", "911auto"));
                }
                catch (Exception ex)
                {
                    Logger.Log("911auto: Could not get price for id: " + id + ex.Message);
                }
            }

            return infoList;
        }
    }
}
