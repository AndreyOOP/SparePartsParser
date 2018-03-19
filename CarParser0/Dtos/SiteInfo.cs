using System;

namespace CarParser0.DTO
{
    public class SiteInfo
    {
        public String id { get; }
        public String price { get; }
        public String quantity { get; }
        public String site { get; }

        public SiteInfo(String id, String price, String quantity, String site)
        {
            this.id = id;
            this.price = price;
            this.quantity = quantity;
            this.site = site;
        }

        public override string ToString()
        {
            return String.Format("id: {0}; site: {1}; qty: {2}; price: {3}", id, site, quantity, price);
        }
    }
}
