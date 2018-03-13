using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CarParser0Tests.SiteParser.ParserMocks;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            var Ids = new List<string>() { "id_1", "id_2" };
            var Parsers = new List<IAbstractSiteParser>() { new ParserMock("parser_1"), new ParserMock("parser_2") };
            var DataStore = new DataStoreMock(); //for the test expected data will be stored into DataStore.StoredData

            var parser = new Parser(Ids, Parsers, DataStore, new LogMock());

            var expected = new List<String>() {
                "id: id_1; site: parser_1; qty: 1; price: 2.2",
                "id: id_1; site: parser_1; qty: 3; price: 2.5",
                "id: id_2; site: parser_1; qty: 1; price: 2.2",
                "id: id_2; site: parser_1; qty: 3; price: 2.5",
                "id: id_1; site: parser_2; qty: 1; price: 2.2",
                "id: id_1; site: parser_2; qty: 3; price: 2.5",
                "id: id_2; site: parser_2; qty: 1; price: 2.2",
                "id: id_2; site: parser_2; qty: 3; price: 2.5"
            };

            parser.Execute();

            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], DataStore.StoredData[i]);
        }
    }
}