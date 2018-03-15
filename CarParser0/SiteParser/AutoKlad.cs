using System;
using System.Collections.Generic;
using System.Threading;
using CarParser0.DTO;
using CarParser0.Logger;
using OpenQA.Selenium.IE;

namespace CarParser0.SiteParser
{
    public class AutoKlad : IAbstractSiteParser
    {
        private readonly String url = "https://www.autoklad.ua/poisk/";
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
            driver.Close();
        }

        public List<SiteInfo> Parse(string item) 
        {
            TrySearchId(item);

            TryGetPrices(item);

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
                Logger.Log("AutoKlad: Could not open site for id: " + id + ex.Message);
            }
        }

        private void TryGetPrices(String id)
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
