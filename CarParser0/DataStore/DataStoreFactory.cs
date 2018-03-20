using CarParser0.ConfigF.enums;
using CarParser0.ConfigNS;
using CarParser0.Interfaces;
using System;

namespace CarParser0.DataStore
{
    public class DataStoreFactory
    {
        public static IDataStore CreateDataStore(Configuration config, ILogger Logger)
        {
            IDataStore DataStore;

            switch (config.StoreType)
            {
                case DataStoreType.CSV:
                    {
                        DataStore = new StoreToCSV(config.StorePath);

                        Logger.Log("Data Store object StoreToCSV initialized");

                        return DataStore;
                    }

                case DataStoreType.EXCEL:
                    throw new NotImplementedException("Data store type " + config.StoreType + " is not implemented yet");

                case DataStoreType.HTML:
                    {
                        DataStore = new StoreToHtml(config.StorePath);

                        Logger.Log("Data Store object StoreToCSV initialized");

                        return DataStore;
                    }

                case DataStoreType.SQL:
                    throw new NotImplementedException("Data store type " + config.StoreType + " is not implemented yet");
            }

            throw new Exception("Unknown Data store type " + config.StoreType);
        }
    }
}
