using System;

namespace CarParser0.DTO
{
    public class SiteInfo
    {
        public String id { get; set; }
        public String price { get; set; }
        public String quantity { get; set; }
        public String site { get; set; }

        public override string ToString()
        {
            return String.Format("id: {0}; site: {1}; qty: {2}; price: {3}", id, site, quantity, price);
        }
    }
}
