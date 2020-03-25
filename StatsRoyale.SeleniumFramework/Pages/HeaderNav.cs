using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    public class HeaderNav
    {
        readonly HeaderNavMap Map;

        public HeaderNav(IWebDriver driver)
        {
            Map = new HeaderNavMap(driver);
        }

        public void GoToCardsPage()
        {
            Map.CardsMenu.Click();
        }
       
    }
    public class HeaderNavMap
    {
        IWebDriver _driver;

        public HeaderNavMap(IWebDriver driver)
        {
            _driver = driver;
        }


        public IWebElement CardsMenu
        {
            get
            {
                return _driver.FindElement(By.CssSelector("a[href='/cards']"));
            }
        }
    }
}
