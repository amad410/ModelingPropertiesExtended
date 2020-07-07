using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StatsRoyale.SeleniumFramework.BrowserFactory;
using StatsRoyale.SeleniumFramework.Models;
using StatsRoyale.SeleniumFramework.Pages;
using StatsRoyale.SeleniumFramework.Services;
using Assert = NUnit.Framework.Assert;

namespace StatsRoyale.SeleniumTests
{
    [TestFixture]
    public class CardsTests
    {
        //this is a global variable in which all test methods in this class can use.
        //IWebDriver driver;
        static string[] cardNames = { "Ice Spirit", "Mirror" };
        [TestMethod]
        public void AssertIceSpiritCardIsOnCardPage()
        {
            //use our Page Map Pattern Classes
            //CardsPage _cardsPage = new CardsPage(Driver.Current);
            //_cardsPage.GoTo();
            Pages.Cards.GoTo();
            //var card = _cardsPage.GetCardByCardName("Ice Spirit");
            var card = Pages.Cards.GetCardByCardName("Ice Spirit");
            Assert.IsTrue(card.Displayed);
        }

        /// <summary>
        /// AS you can see here, I have 4 assertions.  That is a valid strategy for the testing of this
        /// card only. 
        /// </summary>
        [TestMethod]
        public void AssertIceSpiritCardStatsOnDetailsPage()
        {
            //CardsPage _cardsPage = new CardsPage(Driver.Current);
            //_cardsPage.GoTo();
            Pages.Cards.GoTo();
            //_cardsPage.GetCardByCardName("Ice Spirit").Click();
            Pages.Cards.GetCardByCardName("Ice Spirit").Click();
            //CardDetailsPage _cardDetailsPage = new CardDetailsPage();

            //Assert.AreEqual("Troop", _cardDetailsPage.GetCardCategory());
            //Assert.AreEqual("Arena 8", _cardDetailsPage.GetCardArena());
            //Assert.AreEqual("Ice Spirit", _cardDetailsPage._Map.CardName.Text);
            //Assert.AreEqual("Common", _cardDetailsPage._Map.CardRarityStatus.Text);

            Assert.AreEqual("Troop", Pages.CardDetails.GetCardCategory());
            Assert.AreEqual("Arena 8", Pages.CardDetails.GetCardArena());
            Assert.AreEqual("Ice Spirit", Pages.CardDetails._Map.CardName.Text);
            Assert.AreEqual("Common", Pages.CardDetails._Map.CardRarityStatus.Text);

        }
        /// <summary>
        /// AS you can see in the above scenario, we had 4 assertions.  That is a valid strategy for the testing of this
        /// card only. However, we are working with different cards that have different properties. So we made a 3rd test
        /// that will utilize models and services to handle different types of test data properties.
        /// </summary>
        /// 
       




        [TestMethod]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        //[TestCase("Mirror")]
        //[TestCase("Ice Spirit")]
        public void AssertDifferentCardStatsOnDetailsPage(string cardName)
        {
            //CardsPage _cardsPage = new CardsPage(Driver.Current);
            // _cardsPage.GoTo();
            Pages.Cards.GoTo();
            Thread.Sleep(TimeSpan.FromSeconds(20));
            // _cardsPage.GetCardByCardName(cardName).Click();
            Pages.Cards.GetCardByCardName(cardName).Click();
            //CardDetailsPage _cardDetailsPage = new CardDetailsPage(Driver.Current);
            var cardOnPage = Pages.CardDetails.GetBaseCard();

            //var cardOnPage = _cardDetailsPage.GetBaseCard();
            //var mirror = new MirrorCard();
            var targetedCardModel = new InMemoryCardService().GetCardByName(cardName);


            Assert.AreEqual(targetedCardModel.Category, cardOnPage.Category);
            Assert.AreEqual(targetedCardModel.Arena, cardOnPage.Arena);
            Assert.AreEqual(targetedCardModel.Name, cardOnPage.Name);
            Assert.AreEqual(targetedCardModel.RarityStatus, cardOnPage.RarityStatus);
        }

        [SetUp]
        public void Setup()
        {
            //Created a chrome driver and launches chrome
            //driver = new ChromeDriver();
            Driver.Init();
            Pages.Init();
            //This will expand the chrome window
            //driver.Manage().Window.Maximize();
            //Navigate to the website
            //driver.Navigate().GoToUrl("https://statsroyale.com/");
            //Driver.Current.Url = "https://statsroyale.com/";
            Driver.GoTo("https://statsroyale.com/");
        }

        [TearDown]
        public void Teardown()
        {
            //Close all chrome tabs
            // driver.Quit();
            Driver.Current.Quit();
        }
        
    }
}
