using OpenQA.Selenium;
using StatsRoyale.SeleniumFramework.BrowserFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    /// <summary>
    /// This is the card page containing methods to retrieve a specific card. As you may recall,
    /// the card page in the StatsRoyale website contains properties/elements/controls [cards] and at least
    /// one action/event that can be done on that page [getting cards by a specific name to click on].
    /// </summary>
    public class CardsPage : BasePage
    {
        public CardsPageMap _CardsPageMap;
       
        public CardsPage(): base()
        {
            
            _CardsPageMap = new CardsPageMap();
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

       

        public CardsPageMap() 
        {
            

        }
       

        public IWebElement Card(string name)=> Driver.FindElement(By.CssSelector($"a[href='https://statsroyale.com/card/{name}']"));
       

    }
}
