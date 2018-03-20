using CarParser0.DTO;
using System;
using System.Collections.Generic;

namespace CarParser0.SiteParser
{
    public interface IAbstractSiteParser
    {
        List<SiteInfo> Parse(String item);
    }
}
