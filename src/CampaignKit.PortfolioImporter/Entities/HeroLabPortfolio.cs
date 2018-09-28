using System.Collections.Generic;
using System.Xml.Serialization;


namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    [XmlRoot(ElementName = "game")]
    public class Game
    {
        [XmlElement(ElementName = "gameinfo")]
        public string Gameinfo { get; set; }
        [XmlElement(ElementName = "version")]
        public Version Version { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "folder")]
        public string Folder { get; set; }
        [XmlAttribute(AttributeName = "publisher")]
        public string Publisher { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "handler")]
    public class Handler
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "folder")]
        public string Folder { get; set; }
    }

    [XmlRoot(ElementName = "handlers")]
    public class Handlers
    {
        [XmlElement(ElementName = "handler")]
        public Handler Handler { get; set; }
    }

    [XmlRoot(ElementName = "statblock")]
    public class Statblock
    {
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
        [XmlAttribute(AttributeName = "folder")]
        public string Folder { get; set; }
        [XmlAttribute(AttributeName = "filename")]
        public string Filename { get; set; }
    }

    [XmlRoot(ElementName = "statblocks")]
    public class Statblocks
    {
        [XmlElement(ElementName = "statblock")]
        public List<Statblock> Statblock { get; set; }
    }

    [XmlRoot(ElementName = "character")]
    public class CharacterSummary
    {
        [XmlElement(ElementName = "statblocks")]
        public Statblocks Statblocks { get; set; }
        [XmlElement(ElementName = "images")]
        public Images Images { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "summary")]
        public string Summary { get; set; }
        [XmlAttribute(AttributeName = "isally")]
        public string Isally { get; set; }
        [XmlAttribute(AttributeName = "allegianceid")]
        public string Allegianceid { get; set; }
        [XmlAttribute(AttributeName = "allegiancename")]
        public string Allegiancename { get; set; }
        [XmlAttribute(AttributeName = "playername")]
        public string Playername { get; set; }
        [XmlAttribute(AttributeName = "herolableadindex")]
        public string Herolableadindex { get; set; }
        [XmlAttribute(AttributeName = "characterindex")]
        public string Characterindex { get; set; }
    }

    [XmlRoot(ElementName = "characters")]
    public class CharacterSummaries
    {
        [XmlElement(ElementName = "character")]
        public List<CharacterSummary> CharacterSummary { get; set; }
    }

    [XmlRoot(ElementName = "document")]
    public class HeroLabPortfolio
    {
        [XmlElement(ElementName = "game")]
        public Game Game { get; set; }
        [XmlElement(ElementName = "program")]
        public Program Program { get; set; }
        [XmlElement(ElementName = "handlers")]
        public Handlers Handlers { get; set; }
        [XmlElement(ElementName = "characters")]
        public CharacterSummaries CharacterSummaries { get; set; }
        [XmlAttribute(AttributeName = "signature")]
        public string Signature { get; set; }
    }

}
