using StatsRoyale.SeleniumFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Services
{
    public interface ICardService
    {
        Card GetCardByName(string cardName);
    }
}
