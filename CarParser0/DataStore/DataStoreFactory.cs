using CarParser0.ConfigNS;

namespace CarParser0.DataStore
{
    public class DataStoreFactory //todo...
    {
        public static IDataStore CreateDataStore(Config config)
        {
            return new StoreToCSV("");
        }
    }
}
