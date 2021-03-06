﻿using System;
using System.Collections.Generic;
using CarParser0.DTO;
using CarParser0.Interfaces;
using CarParser0.ParserNS;

namespace CarParser0.SiteParser
{
    public class Auto911Parser : IAbstractSiteParser
    {
        private ParseService Service;
        private String Url;
        private ILogger Logger;

        public Auto911Parser(ParseService Service, String Url, ILogger Logger)
        {
            this.Service = Service;
            this.Url = Url;
            this.Logger = Logger;
        }

        public List<SiteInfo> Parse(string id)
        {
            List<SiteInfo> parsed = new List<SiteInfo>();

            try
            {
                Service.NavigateToSite(Url + id);

                foreach(var el in Service.GetElements("#product_tbl .hl > :last-child", id, false))
                {
                    parsed.Add(new SiteInfo(id, el.Text, "-", "911auto"));
                }

                foreach(var el in Service.GetElements("#zakaz_blk_svc tbody > tr:not(.head)", id, false))
                {
                    var qty   = Service.GetElements(el, "td:nth-child(4)", id);
                    var price = Service.GetElements(el, "td:last-child", id);

                    parsed.Add(new SiteInfo(id, price[0].Text, qty[0].Text, "911auto"));
                }
            }
            catch (Exception ex)
            {
                Logger.Log(id + " - unexpected exception. " + ex.Message);
            }

            return parsed;
        }
    }
}
