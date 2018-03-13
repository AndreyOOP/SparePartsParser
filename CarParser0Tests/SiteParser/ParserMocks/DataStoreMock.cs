using CarParser0.DataStore;
using System;
using CarParser0.DTO;
using System.Collections.Generic;

namespace CarParser0Tests.SiteParser.ParserMocks
{
    class DataStoreMock : IDataStore
    {
        public List<String> StoredData { get; } = new List<String>();

        public void Save(SiteInfo info)
        {
            StoredData.Add(info.ToString());

            Console.WriteLine("Store: " + info);
        }
    }
}
