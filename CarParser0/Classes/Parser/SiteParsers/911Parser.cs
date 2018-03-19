using System;
using System.Collections.Generic;
using CarParser0.DTO;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using CarParser0.Logger;
using System.IO;
using System.Threading;
using CarParser0.Interfaces;

namespace CarParser0.SiteParser
{
    public class Auto911Parser : IAbstractSiteParser
    {
        private String ieDriverFolder;
        public String url = "http://911auto.com.ua/search/"; //TODO temporary solution

        private List<SiteInfo> infoList;
        private ILogger Logger;

        private InternetExplorerDriver driver;


        public Auto911Parser(String ieDriverFolder, ILogger Logger)
        {
            this.ieDriverFolder = ieDriverFolder;
            this.Logger = Logger;

            infoList = new List<SiteInfo>();
            driver = new InternetExplorerDriver(ieDriverFolder);
        }

        ~Auto911Parser()
        {
            driver.Quit();
        }

        public List<SiteInfo> Parse(string id)
        {
            infoList = new List<SiteInfo>();

            TrySearchId(id);

            TryParseFirstTable(id);

            TryParseSecondTable(id);
            
            return infoList;
        }

        private void TrySearchId(String id)
        {
            try
            {
                driver.Navigate().GoToUrl(url + id);

                Thread.Sleep(2000); //todo, temporary solution, just delay so site could completely loaded
            }
            catch (Exception ex)
            {
                Logger.Log("911auto: Could not open site for id: " + id + ex.Message);
            }
        }

        private void TryParseFirstTable(String id)
        {
            try
            {
                var node  = driver.FindElementById("product_tbl");

                var price = node.FindElement(By.CssSelector(".hl > :last-child")).Text;

                infoList.Add(new SiteInfo(id, price, "-", "911auto"));
            }
            catch (Exception ex)
            {
                Logger.Log("911auto: Could not get price for id: " + id + ex.Message);
            }
        }

        private void TryParseSecondTable(String id)
        {
            try
            {
                var table = driver.FindElementById("zakaz_blk_svc");
                var rows  = table.FindElements(By.CssSelector("tbody > tr:not(.head)"));

                for (int i = 0; i < rows.Count; i++)
                {
                    var qty   = rows[i].FindElement(By.CssSelector("td:nth-child(4)")).Text;
                    var price = rows[i].FindElement(By.CssSelector("td:last-child")).Text;

                    infoList.Add(new SiteInfo(id, price, qty, "911auto"));
                }
            }
            catch (Exception ex)
            {
                Logger.Log("911auto: Could not get price for id: " + id + ex.Message);
            }
        }
    }
}
