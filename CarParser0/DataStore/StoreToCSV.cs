using System;
using CarParser0.DTO;
using System.IO;

namespace CarParser0.DataStore
{
    public class StoreToCSV : IDataStore
    {
        private String path;

        public StoreToCSV(String path)
        {
            this.path = path;

            File.AppendAllText(path, "\r\nid; site; qty; price\r\n");
        }

        public void Save(SiteInfo info)
        {
            var newLine = String.Format("{0}; {1}; {2}; {3}\r\n", info.id, info.site, info.quantity, info.price);

            File.AppendAllText(path, newLine);
        }
    }
}
