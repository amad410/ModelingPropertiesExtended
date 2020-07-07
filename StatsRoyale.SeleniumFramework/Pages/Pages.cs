using StatsRoyale.SeleniumFramework.BrowserFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Pages
{
    public class Pages
    {
        [ThreadStatic]
        public static CardsPage Cards;
        [ThreadStatic]
        public static CardDetailsPage CardDetails;

        public static void Init()
        {
            Cards = new CardsPage();
            CardDetails = new CardDetailsPage();
        }

    }
}
