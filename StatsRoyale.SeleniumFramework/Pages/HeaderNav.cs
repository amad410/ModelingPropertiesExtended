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
    /// This is the header navigation class. It is not a page class object per say.  However, it is a common
    /// theme throughout multiple pages that we navigate to. Wherever we go, the majority of the pages will have
    /// a navigational header. We should have access to this navigational header on each page or within each page object. 
    /// Since that is the truth, we need to model this header navigation and make it a part of the base page class that all 
    /// classes will inherit from. 
    /// </summary>
    public class HeaderNav
    {
        readonly HeaderNavMap Map;

        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

        public void GoToCardsPage()
        {
            Map.CardsMenu.Click();
        }
       
    }
    public class HeaderNavMap
    {
        

        public HeaderNavMap()
        {
            
        }


        public IWebElement CardsMenu
        {
            get
            {
                return Driver.FindElement(By.CssSelector("a[href='/cards']"));
            }
        }
    }
}
