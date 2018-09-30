using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    /// <summary>
    /// Character elements specific to 5e SRD 
    /// </summary>
    public partial class CharacterDetail
    {
        [XmlElement(ElementName = "typetags")]
        public Typetags Typetags { get; set; } 
        [XmlElement(ElementName = "background")]
        public Background Background { get; set; }
        [XmlElement(ElementName = "toolproficiencies")]
        public Toolproficiencies Toolproficiencies { get; set; }
        [XmlElement(ElementName = "weaponproficiencies")]
        public Weaponproficiencies Weaponproficiencies { get; set; }
        [XmlElement(ElementName = "armorproficiencies")]
        public Armorproficiencies Armorproficiencies { get; set; }
        [XmlElement(ElementName = "abilityscores")]
        public Abilityscores Abilityscores { get; set; }
        [XmlElement(ElementName = "allsaves")]
        public Allsaves Allsaves { get; set; }
        [XmlElement(ElementName = "damageresistances")]
        public Damageresistances Damageresistances { get; set; }
        [XmlElement(ElementName = "damageimmunities")]
        public Damageimmunities Damageimmunities { get; set; }
        [XmlElement(ElementName = "damagevulnerabilities")]
        public Damagevulnerabilities Damagevulnerabilities { get; set; }
        [XmlElement(ElementName = "conditionimmunities")]
        public Conditionimmunities Conditionimmunities { get; set; }
        [XmlElement(ElementName = "proficiencybonus")]
        public Proficiencybonus Proficiencybonus { get; set; }
        [XmlElement(ElementName = "racespells")]
        public Racespells Racespells { get; set; }
        
        [XmlElement(ElementName = "cantrips")]
        public Cantrips Cantrips { get; set; }
        [XmlElement(ElementName = "spellslots")]
        public Spellslots Spellslots { get; set; }

        //Not Supported
        //[XmlElement(ElementName = "itemspells")]
        //public string Itemspells { get; set; } // ToDo: Need example .por

    }


}
