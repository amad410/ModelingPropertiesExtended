using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    public class CardsPage : BasePage
    {
        public CardsPageMap _CardsPageMap;
        IWebDriver _driver;
        public CardsPage(IWebDriver driver): base(driver)
        {
            _driver = driver;
            _CardsPageMap = new CardsPageMap(_driver);
        }
        public IWebElement GetCardByCardName(string name)
        {
            if (name.Contains(" "))
            {
                name = name.Replace(" ", "+");
            }
            return _CardsPageMap.Card(name);
        }
        public CardsPage GoTo()
        {
            _HeaderNav.GoToCardsPage();
            return this;
           
        }
    }
    public class CardsPageMap
    {

        IWebDriver _driver;

        public CardsPageMap(IWebDriver driver) 
        {
            _driver = driver;

        }
       

        public IWebElement Card(string name)=> _driver.FindElement(By.CssSelector($"a[href='https://statsroyale.com/card/{name}']"));
       

    }
}
