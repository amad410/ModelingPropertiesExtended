using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    /// <summary>
    /// The base page class contains the common things and actions that can be done on a webpage:
    ///  * navigating forward
    ///  * navigating backward
    ///  * getting the title
    ///  * Sending Keys (entering text) on an element
    ///  * clicking an element
    ///  * common navigation
    ///  * etc. 
    ///  Not everything is modeled here. However, we have chosen to ensure we have access to the header navigational class
    ///  which takes care of my interaction with the navigational header on the page. 
    /// </summary>
    public abstract class BasePage
    {
        public IWebDriver _driver;
        public HeaderNav _HeaderNav;

        public BasePage()
        {
            
            _HeaderNav = new HeaderNav();

        }
    }
}
