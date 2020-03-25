using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    public abstract class BasePage
    {
        public IWebDriver _driver;
        public HeaderNav _HeaderNav;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _HeaderNav = new HeaderNav(_driver);

        }
    }
}
