using OpenQA.Selenium;
using StatsRoyale.SeleniumFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    public class CardDetailsPage : BasePage
    {
        public IWebDriver _driver;
        public CardDetailsPageMap _Map;
        public CardDetailsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _Map = new CardDetailsPageMap(_driver);
        }

        public IWebElement GetCardRarity()
        {
            return _Map.CardRarity;
        }
        public string GetCardCategory()
        {
            var category = GetCardRarity().Text.Split(',')[0];
            return category;
        }
        public string GetCardArena()
        {
            var arena = GetCardRarity().Text.Split(',')[1];
            return arena;
        }
        public Card GetBaseCard()
        {
            return new Card
            {
                Name = _Map.CardName.Text,
                RarityStatus = _Map.CardRarityStatus.Text,
                Category = _Map.CardRarity.Text.Split(',')[0],
                Arena = _Map.CardRarity.Text.Split(',')[1].Trim()
            };

        }
    }
    public class CardDetailsPageMap
    {
        public IWebDriver _driver;
        public CardDetailsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardRarity => _driver.FindElement(By.CssSelector("div[class='card__rarity']"));

        public IWebElement CardName => _driver.FindElement(By.CssSelector(".ui__headerMedium.card__cardName"));
        public IWebElement CardRarityStatus => _driver.FindElement(By.CssSelector(".card__rarityCaption div.card__count"));
    }
}
