using CarParser0.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParser0.SiteParser
{
    public interface IAbstractSiteParser
    {
        List<SiteInfo> Parse(String item);
    }
}
