using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.BrowserFactory
{
    public static class Driver
    {
        //static IWebdriver field with an annotation that specifies that it is unique for each thread
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

        }
        public static void GoTo(string url)
        {
            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }
        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("driver is null");


    }
}
