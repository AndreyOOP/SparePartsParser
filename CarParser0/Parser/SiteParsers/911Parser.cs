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
        private String IeDriverFolder;
        private String Url;

        private List<SiteInfo> InfoList;
        private ILogger Logger;

        private InternetExplorerDriver Driver;


        public Auto911Parser(String Url, InternetExplorerDriver Driver, ILogger Logger)
        {
            this.Url = Url;
            this.Driver = Driver;
            this.Logger = Logger;

            InfoList = new List<SiteInfo>();
        }

        public List<SiteInfo> Parse(string id)
        {
            InfoList = new List<SiteInfo>();

            OpenSearchId(id);

            TryParseFirstTable(id);

            TryParseSecondTable(id);
            
            return InfoList;
        }

        private void OpenSearchId(String id)
        {
            Driver.Navigate().GoToUrl(Url + id);

            Thread.Sleep(2000); //todo, temporary solution, just delay so site could completely loaded

            //todo if site is not loaded properly
            //Logger.Log("911auto: Could not open site for id: " + id + ex.Message);
        }

        private void TryParseFirstTable(String id)
        {
            try
            {
                var node = Driver.FindElementById("product_tbl");

                var price = node.FindElement(By.CssSelector(".hl > :last-child"));

                InfoList.Add(new SiteInfo(id, price.Text, "-", "911auto"));
            }
            catch (Exception)//or in case of error add object
            {
                Logger.Log("911auto: Could not get price for id: " + id + " from first table");
            }
        }

        private void TryParseSecondTable(String id)
        {
            try
            {
                var table = Driver.FindElementById("zakaz_blk_svc");
                var rows = table.FindElements(By.CssSelector("tbody > tr:not(.head)"));

                for (int i = 0; i < rows.Count; i++)
                {
                    var qty = rows[i].FindElement(By.CssSelector("td:nth-child(4)")).Text;
                    var price = rows[i].FindElement(By.CssSelector("td:last-child")).Text;

                    InfoList.Add(new SiteInfo(id, price, qty, "911auto"));
                }
            }
            catch (Exception)
            {
                Logger.Log("911auto: Could not get prices for id: " + id + " in second table");//or just throw exception here so could define more tests ?
            }
        }
    }
}
