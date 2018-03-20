using System;
using System.Collections.Generic;
using System.Threading;
using CarParser0.DTO;
using CarParser0.Interfaces;
using CarParser0.Logger;
using OpenQA.Selenium.IE;

namespace CarParser0.SiteParser
{
    public class AutoKlad : IAbstractSiteParser
    {
        public String url = "https://www.autoklad.ua/poisk/"; //TODO, Temporary for testing
        private InternetExplorerDriver driver;
        private ILogger Logger;

        private List<SiteInfo> infoList;

        public AutoKlad(String ieDriverFolder, ILogger Logger)
        {
            this.Logger = Logger;

            driver = new InternetExplorerDriver(ieDriverFolder);

            infoList = new List<SiteInfo>();
        }

        ~AutoKlad()
        {
            driver.Quit();
        }

        public List<SiteInfo> Parse(string item) 
        {
            TrySearchId(item);

            TryGetPrices(item);

            return infoList;
        }

        private void TrySearchId(String id)
        {
            try //TODO the try catch is useless it will not throw exception even if navigate to wrong url; but maybe after replacement of thread sleep it will be usefull
            {
                driver.Navigate().GoToUrl(url + id);

                Thread.Sleep(2000); //todo, temporary solution, just delay so site could completely loaded
            }
            catch (Exception ex)
            {
                Logger.Log("AutoKlad: Could not open site for id: " + id + ex.Message);
            }
        }

        private void TryGetPrices(String id) //TODO change logic... exception will not throw because FindElements just returns zero collection, as well remove text replacement...
        {
            try
            {
                var variants = driver.FindElementsByCssSelector("#central-column .search_element .search_price");

                foreach (var elem in variants)
                {
                    var price = elem.Text.Replace(" грн", "");

                    infoList.Add(new SiteInfo(id, price, "-", "AutoKlad"));
                }
            }
            catch (Exception ex)
            {
                Logger.Log("AutoKlad: Could not load price for id: " + id + ex.Message);
            }            
        }
    }
}
