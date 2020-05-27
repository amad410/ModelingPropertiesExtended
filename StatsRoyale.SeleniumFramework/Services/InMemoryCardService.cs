using StatsRoyale.SeleniumFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Services
{
    public class InMemoryCardService : ICardService
    {
        public Card GetCardByName(string cardName)
        {
            switch (cardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();
                    break;
                case "Mirror":
                    return new MirrorCard();
                    break;
                default:
                    throw new Exception("Card is not available: " + cardName);
            }
        }
    }
}
