using CarParser0.SiteParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SiteInfo info = new SiteInfo();

            info.id     = item;
            info.site   = name ?? "mock";
            info.quantity = "1";
            info.price  = "2.2";

            List<SiteInfo> list = new List<SiteInfo>();
            list.Add(info);

            return list;
        }
    }
}
