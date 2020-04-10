using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsRoyale.SeleniumFramework.Models
{
    /// <summary>
    /// This is the base card model class containing base property values that can be overridden by
    /// classes that inherit from this class. 
    /// </summary>
    public class Card
    {
        public virtual string Name { get; set; } = "Mirror";
        public virtual int Cost { get; set; } = 1;
        public virtual string RarityStatus { get; set; } = "Epic";

        public virtual string Category { get; set; } = "Spell";

        public virtual string Arena { get; set; } = "Arena 12";
    }
}
