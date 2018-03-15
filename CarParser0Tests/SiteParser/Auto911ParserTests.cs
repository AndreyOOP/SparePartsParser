using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CarParser0.DTO;
using CarParser0Tests.SiteParser.ParserMocks;
using System;
using System.Reflection;
using System.IO;

namespace CarParser0.SiteParser.Tests
{
    [TestClass()] //todo how to correctly test it ?
    public class Auto911ParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            Auto911Parser parser = new Auto911Parser("SiteParser/IE Driver/", new LogMock());

            List<SiteInfo> actual = parser.Parse("MD619865");
            parser.Parse("MD619864");

            Assert.AreEqual("id: MD619865; site: 911auto; qty: -; price: 835", actual[0].ToString());
        }

        [TestMethod(), Ignore()]
        public void ParseTestBS()
        {
            Auto911Parser parser = new Auto911Parser("SiteParser/IE Driver/", new LogMock());

            SetField(parser, "url", "http://localhost:3000/");


            List<SiteInfo> actual = parser.Parse("");

            Assert.AreEqual("id: MD619865; site: 911auto; qty: -; price: 822", actual[0].ToString());
        }

        private void SetField(Object obj, String fieldName, Object fieldValue)
        {
            var fields = obj.GetType().GetRuntimeFields();
            var en = fields.GetEnumerator();

            while (en.MoveNext())
            {
                var field = en.Current;

                if(field.Name == fieldName)
                {
                    field.SetValue(obj, fieldValue);
                    return;
                }
            }
        }
    }
}