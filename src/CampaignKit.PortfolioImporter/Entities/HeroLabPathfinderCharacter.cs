using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    /// <summary>
    /// Character elements specific to Pathfinder
    /// </summary>
    public partial class HeroLabCharacter
    {
        [XmlElement(ElementName = "bookinfo")]
        public Bookinfo Bookinfo { get; set; }
        [XmlElement(ElementName = "subtypes")]
        public Subtypes Subtypes { get; set; }
        [XmlElement(ElementName = "heropoints")]
        public Heropoints Heropoints { get; set; }
        [XmlElement(ElementName = "favoredclasses")]
        public Favoredclasses Favoredclasses { get; set; }
        [XmlElement(ElementName = "attributes")]
        public Attributes Attributes { get; set; }
        [XmlElement(ElementName = "saves")]
        public Saves Saves { get; set; }
        [XmlElement(ElementName = "damagereduction")]
        public Damagereduction Damagereduction { get; set; }
        [XmlElement(ElementName = "immunities")]
        public Immunities Immunities { get; set; }
        [XmlElement(ElementName = "resistances")]
        public Resistances Resistances { get; set; }
        [XmlElement(ElementName = "weaknesses")]
        public Weaknesses Weaknesses { get; set; }
        [XmlElement(ElementName = "penalties")]
        public Penalties Penalties { get; set; }
        [XmlElement(ElementName = "maneuvers")]
        public Maneuvers Maneuvers { get; set; }
        
        [XmlElement(ElementName = "traits")]
        public Traits Traits { get; set; }
        [XmlElement(ElementName = "animaltricks")]
        public Animaltricks Animaltricks { get; set; }

        // Not Supported
        //[XmlElement(ElementName = "flaws")]
        //public string Flaws { get; set; }
        //[XmlElement(ElementName = "skilltricks")]
        //public string Skilltricks { get; set; }


    }


}
