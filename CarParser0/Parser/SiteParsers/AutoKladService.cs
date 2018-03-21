using CarParser0.DTO;
using CarParser0.Interfaces;
using CarParser0.SiteParser;
using System;
using System.Collections.Generic;

namespace CarParser0.ParserNS.SiteParsers
{
    public class AutoKladService : IAbstractSiteParser
    {
        ParseService Service;
        String Url;
        ILogger Logger;

        public AutoKladService(ParseService Service, String Url, ILogger Logger)
        {
            this.Service = Service;
            this.Url     = Url;
            this.Logger  = Logger;
        }

        public List<SiteInfo> Parse(string item)
        {
            List<String> links = new List<String>();
            List<SiteInfo> parsed = new List<SiteInfo>();

            try
            {
                Service.NavigateToSite(Url + item);

                foreach (var linkElem in Service.GetElements("#central-column .search_element a", item))
                {
                    links.Add(linkElem.GetAttribute("href"));
                }

                foreach (var link in links)
                {
                    Service.NavigateToSite(link);

                    foreach(var elem in Service.GetElements("#product-top-left .plitka_price b", item))
                    {
                        parsed.Add(new SiteInfo(item, elem.Text, "-", "AutoKlad"));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(item + " - unexpected exception. " + ex.Message);
            }

            return parsed;
        }
    }
}
