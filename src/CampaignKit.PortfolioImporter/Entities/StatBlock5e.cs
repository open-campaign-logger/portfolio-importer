using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    [XmlRoot(ElementName = "creature-heading")]
    public class Creatureheading
    {
        [XmlElement(ElementName = "h1")]
        public string H1 { get; set; }
        [XmlElement(ElementName = "h2")]
        public string H2 { get; set; }
    }

    [XmlRoot(ElementName = "property-line")]
    public class Propertyline
    {
        [XmlElement(ElementName = "h4")]
        public string H4 { get; set; }
        [XmlElement(ElementName = "p")]
        public string P { get; set; }
    }

    [XmlRoot(ElementName = "abilities-block")]
    public class Abilitiesblock
    {
        [XmlAttribute(AttributeName = "data-str")]
        public string Datastr { get; set; }
        [XmlAttribute(AttributeName = "data-dex")]
        public string Datadex { get; set; }
        [XmlAttribute(AttributeName = "data-con")]
        public string Datacon { get; set; }
        [XmlAttribute(AttributeName = "data-int")]
        public string Dataint { get; set; }
        [XmlAttribute(AttributeName = "data-wis")]
        public string Datawis { get; set; }
        [XmlAttribute(AttributeName = "data-cha")]
        public string Datacha { get; set; }
    }

    [XmlRoot(ElementName = "top-stats")]
    public class Topstats
    {
        [XmlElement(ElementName = "property-line")]
        public List<Propertyline> Propertyline { get; set; }
        [XmlElement(ElementName = "abilities-block")]
        public Abilitiesblock Abilitiesblock { get; set; }
    }

    [XmlRoot(ElementName = "p")]
    public class P
    {
        [XmlElement(ElementName = "i")]
        public List<string> I { get; set; }
    }

    [XmlRoot(ElementName = "property-block")]
    public class Propertyblock
    {
        [XmlElement(ElementName = "h4")]
        public string H4 { get; set; }
        [XmlElement(ElementName = "p")]
        public P P { get; set; }
    }

    /// <summary>
    /// XML Format used by https://github.com/Valloric/statblock5e
    /// </summary>
    [XmlRoot(ElementName = "stat-block")]
    public class Statblock5e
    {
        [XmlElement(ElementName = "creature-heading")]
        public Creatureheading Creatureheading { get; set; }
        [XmlElement(ElementName = "top-stats")]
        public Topstats Topstats { get; set; }
        [XmlElement(ElementName = "property-block")]
        public List<Propertyblock> Propertyblock { get; set; }
        [XmlElement(ElementName = "h3")]
        public string H3 { get; set; }

        public Statblock5e()
        {
        }

        /// <summary>
        /// This constructor will accept a HeroLabCharacter and populate elements 
        /// in the statblock accordingly.
        /// </summary>
        /// <param name="character"></param>
        public Statblock5e(HeroLabCharacter character)
        {
            this.Creatureheading = new Creatureheading();
            this.Creatureheading.H1 = character.getCharacterName();
            this.Creatureheading.H2 = character.getCharacterType() + ", " + character.getCharacterAlignment();
        }

    }

}

