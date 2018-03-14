using System;
using System.Collections.Generic;
using CarParser0.DTO;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using CarParser0.Logger;
using System.IO;
using System.Threading;

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

                    Thread.Sleep(2000); //todo, temporary solution, just delay so site could completely loaded
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

                //todo refactor
                try
                {
                    var nodeR = driver.FindElementById("zakaz_blk_svc");
                    var elems = nodeR.FindElements(By.CssSelector("tbody > tr:not(.head)"));

                    for(int i=0; i<elems.Count; i++)
                    {
                        var qt = elems[i].FindElement( By.CssSelector("td:nth-child(4)") ).Text;
                        var pr = elems[i].FindElement( By.CssSelector("td:last-child") ).Text;

                        infoList.Add(new SiteInfo(id, pr, qt, "911auto"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log("911auto: Could not get price for id: " + id + ex.Message);
                }

                driver.Close();
            }

            return infoList;
        }
    }
}
