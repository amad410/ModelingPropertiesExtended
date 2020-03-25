using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StatsRoyale.SeleniumFramework.Models;
using StatsRoyale.SeleniumFramework.Pages;

namespace StatsRoyale.SeleniumTests
{
    [TestClass]
    public class CardsTests
    {
        //this is a global variable in which all test methods in this class can use.
        IWebDriver driver;
        [TestMethod]
        public void AssertIceSpiritCardIsOnCardPage()
        {
            //use our Page Map Pattern Classes
            CardsPage _cardsPage = new CardsPage(driver);
            _cardsPage.GoTo();
            var card = _cardsPage.GetCardByCardName("Ice Spirit");
            Assert.IsTrue(card.Displayed);
        }

        /// <summary>
        /// AS you can see here, I have 4 assertions.  That is a valid strategy for the testing of this
        /// card only. 
        /// </summary>
        [TestMethod]
        public void AssertIceSpiritCardStatsOnDetailsPage()
        {
            CardsPage _cardsPage = new CardsPage(driver);
            _cardsPage.GoTo();
            _cardsPage.GetCardByCardName("Ice Spirit").Click();
            CardDetailsPage _cardDetailsPage = new CardDetailsPage(driver);

            Assert.AreEqual("Troop", _cardDetailsPage.GetCardCategory());
            Assert.AreEqual("Arena 8", _cardDetailsPage.GetCardArena());
            Assert.AreEqual("Ice Spirit", _cardDetailsPage._Map.CardName.Text);
            Assert.AreEqual("Common", _cardDetailsPage._Map.CardRarityStatus.Text);

        }
        /// <summary>
        /// AS you can see in the above scenario, we had 4 assertions.  That is a valid strategy for the testing of this
        /// card only. However, we are working with different cards that have different properties. So we made a 3rd test
        /// that will utilize models and services to handle different types of test data properties.
        /// </summary>
        [TestMethod]
        public void AssertMirrorCardStatsOnDetailsPage()
        {
            CardsPage _cardsPage = new CardsPage(driver);
            _cardsPage.GoTo();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _cardsPage.GetCardByCardName("Mirror").Click();
            CardDetailsPage _cardDetailsPage = new CardDetailsPage(driver);

            var card = _cardDetailsPage.GetBaseCard();
            var mirror = new MirrorCard();

            Assert.AreEqual(mirror.Category, card.Category);
            Assert.AreEqual(mirror.Arena, card.Arena);
            Assert.AreEqual(mirror.Name, card.Name);
            Assert.AreEqual(mirror.RarityStatus, card.RarityStatus);
        }

        [TestInitialize]
        public void Setup()
        {
            //Created a chrome driver and launches chrome
            driver = new ChromeDriver();
            //This will expand the chrome window
            driver.Manage().Window.Maximize();
            //Navigate to the website
            driver.Navigate().GoToUrl("https://statsroyale.com/");
        }

        [TestCleanup]
        public void Teardown()
        {
            //Close all chrome tabs
            driver.Quit();
        }
        
    }
}
