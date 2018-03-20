using CarParser0.DTO;
using CarParser0.Interfaces;
using CarParser0.SiteParser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CarParser0.ParserNS.SiteParsers
{
    public class AutoKladService : IAbstractSiteParser
    {
        static ParseService Service;
        String Url;
        static ILogger Logger;

        public AutoKladService(ParseService Service, String Url, ILogger Logger)
        {
            AutoKladService.Service = Service;
            this.Url = Url;
            AutoKladService.Logger = Logger;
        }

        public List<SiteInfo> Parse(string item)
        {
            List<SiteInfo> parsed = new List<SiteInfo>();

            try
            {
                Service.NavigateToSite(Url + item, IsLoad, OnError);

                var elems = Service.GetElements("#central-column .search_element a", OnError);

                foreach(var link in ToList(elems))
                {
                    Service.NavigateToSite(link, IsLoad, OnError);

                    var pr = Service.GetElements("#product-top-left .plitka_price b", OnError);

                    foreach(var p in pr)
                    {
                        parsed.Add(new SiteInfo(item, p.Text, "-", "AutoKlad"));
                    }
                }
            }
            catch (Exception)
            {
            }

            return parsed;
        }


        private Func<Boolean> IsLoad = () =>
        {
            return Service.GetElements("#ak_rev") != null;
        };

        private Action<String> OnError = (str) =>
        {
            Logger.Log("Error: " + str);
            throw new Exception();
        };

        private List<String> ToList(IReadOnlyCollection<IWebElement> Elems)
        {
            List<String> Converted = new List<String>();

            foreach (var webEl in Elems)
            {
                Converted.Add(webEl.GetAttribute("href"));
            }

            return Converted;
        }
    }
}
