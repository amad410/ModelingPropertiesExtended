using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Models
{
    public class IceSpiritCard : Card
    {
        public override string Name { get; set; } = "Ice Spirit";
        public override int Cost { get; set; } = 1;
        public override string RarityStatus { get; set; } = "Common";

        public override string Category { get; set; } = "Troop";

        public override string Arena { get; set; } = "Arena 8";
    }
}
