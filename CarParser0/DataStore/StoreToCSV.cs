using System;
using CarParser0.DTO;

namespace CarParser0.DataStore
{
    public class StoreToCSV : IDataStore
    {
        private String path;

        public StoreToCSV(String path)
        {
            this.path = path;
        }

        public void Save(SiteInfo info)
        {

            throw new NotImplementedException();
        }
    }
}
