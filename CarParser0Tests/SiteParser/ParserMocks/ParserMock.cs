using CarParser0.SiteParser;
using System;
using System.Collections.Generic;
using CarParser0.DTO;

namespace CarParser0Tests.SiteParser.ParserMocks
{
    public class ParserMock : IAbstractSiteParser
    {
        String name;

        public ParserMock(String name)
        {
            this.name = name;
        }

        public List<SiteInfo> Parse(string item)
        {
            SiteInfo info1 = new SiteInfo(item, "2.2", "1", name);
            SiteInfo info2 = new SiteInfo(item, "2.5", "3", name);

            List<SiteInfo> list = new List<SiteInfo>();
            list.Add(info1);
            list.Add(info2);

            return list;
        }
    }
}
