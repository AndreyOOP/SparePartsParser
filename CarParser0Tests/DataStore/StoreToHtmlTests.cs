using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParser0.DTO;

namespace CarParser0.DataStore.Tests
{
    [TestClass()]
    public class StoreToHtmlTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            var store = new StoreToHtml("store1.html");
            var Info = new SiteInfo("MD51", "123.4", "4", "some site");
            var Info2 = new SiteInfo("MD2", "123.4", "4", "some site");

            store.Save(Info);
            store.Save(Info);
            store.Save(Info2);
        }
    }
}