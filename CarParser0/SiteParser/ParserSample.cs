using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

namespace CarParser0.SiteParser
{
    public class ParserSample
    {
        public void Parse()
        {
            using (var driver = new InternetExplorerDriver(@"C:\\Users\\Anik\\Documents\\Visual Studio 2017\\Projects\\CarParser0\\CarParser0\\bin\\Debug\\"))
            {
                                
                driver.Navigate().GoToUrl("http://911auto.com.ua/search/MD619866");

                var z = driver.FindElementById("b1");

                Console.WriteLine(z.Text);
            }
        }
    }
}
