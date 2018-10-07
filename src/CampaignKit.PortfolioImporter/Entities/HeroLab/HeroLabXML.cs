using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    #region Portfolio Related Classes

    [XmlRoot(ElementName = "game")]
    public class Game
    {
        #region Properties

        [XmlAttribute(AttributeName = "folder")]
        public string Folder { get; set; }

        [XmlElement(ElementName = "gameinfo")]
        public string Gameinfo { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "publisher")]
        public string Publisher { get; set; }

        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "version")]
        public Version Version { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "handler")]
    public class Handler
    {
        #region Properties

        [XmlAttribute(AttributeName = "folder")]
        public string Folder { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "handlers")]
    public class Handlers
    {
        #region Properties

        [XmlElement(ElementName = "handler")]
        public Handler Handler { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "statblock")]
    public class Statblock
    {
        #region Properties

        [XmlAttribute(AttributeName = "filename")]
        public string Filename { get; set; }

        [XmlAttribute(AttributeName = "folder")]
        public string Folder { get; set; }

        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "statblocks")]
    public class Statblocks
    {
        #region Properties

        [XmlElement(ElementName = "statblock")]
        public List<Statblock> Statblock { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "character")]
    public class CharacterSummary
    {
        #region Properties

        [XmlAttribute(AttributeName = "allegianceid")]
        public string Allegianceid { get; set; }

        [XmlAttribute(AttributeName = "allegiancename")]
        public string Allegiancename { get; set; }

        [XmlAttribute(AttributeName = "characterindex")]
        public string Characterindex { get; set; }

        [XmlAttribute(AttributeName = "herolableadindex")]
        public string Herolableadindex { get; set; }

        [XmlElement(ElementName = "statblocks")]
        public Statblocks Statblocks { get; set; }

        [XmlElement(ElementName = "images")]
        public Images Images { get; set; }

        [XmlAttribute(AttributeName = "isally")]
        public string Isally { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "playername")]
        public string Playername { get; set; }

        [XmlAttribute(AttributeName = "summary")]
        public string Summary { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "characters")]
    public class CharacterSummaries
    {
        #region Properties

        [XmlElement(ElementName = "character")]
        public List<CharacterSummary> CharacterSummary { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "document")]
    public class HeroLabPortfolioRootDocument
    {
        #region Properties

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

        #endregion
    }

    #endregion

    #region Character Related Classes

    #region Basic Document Classes

    [XmlRoot(ElementName = "document")]
    public class HeroLabCharacterRootDocument
    {
        #region Properties

        [XmlElement(ElementName = "public")]
        public Public Public { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "public")]
    public class Public
    {
        #region Properties

        [XmlElement(ElementName = "program")]
        public Program Program { get; set; }

        [XmlElement(ElementName = "localization")]
        public Localization Localization { get; set; }

        [XmlElement(ElementName = "character")]
        public CharacterDetail Character { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "version")]
    public class Version
    {
        #region Properties

        [XmlAttribute(AttributeName = "version")]
        public string _version { get; set; }

        [XmlAttribute(AttributeName = "build")]
        public string Build { get; set; }

        [XmlAttribute(AttributeName = "primary")]
        public string Primary { get; set; }

        [XmlAttribute(AttributeName = "secondary")]
        public string Secondary { get; set; }

        [XmlAttribute(AttributeName = "tertiary")]
        public string Tertiary { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "program")]
    public class Program
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "programinfo")]
        public string Programinfo { get; set; }

        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "version")]
        public Version Version { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "localization")]
    public class Localization
    {
        #region Properties

        [XmlAttribute(AttributeName = "language")]
        public string Language { get; set; }

        [XmlAttribute(AttributeName = "units")]
        public string Units { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "bookinfo")]
    public class Bookinfo
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "validation")]
    public class Validation
    {
        #region Properties

        [XmlElement(ElementName = "report")]
        public string Report { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "settings")]
    public class Settings
    {
        #region Properties

        [XmlAttribute(AttributeName = "summary")]
        public string Summary { get; set; }

        #endregion
    }

    #endregion

    #region Base Types

    [XmlRoot(ElementName = "type")]
    public class Type
    {
        #region Properties

        [XmlAttribute(AttributeName = "active")]
        public string Active { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "types")]
    public class Types
    {
        #region Properties

        [XmlElement(ElementName = "type")]
        public List<Type> Type { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "subtype")]
    public class Subtype
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "subtypes")]
    public class Subtypes
    {
        #region Properties

        [XmlElement(ElementName = "subtype")]
        public List<Subtype> Subtype { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "typetag")]
    public class Typetag
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "typetags")]
    public class Typetags
    {
        #region Properties

        [XmlElement(ElementName = "typetag")]
        public Typetag Typetag { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "language")]
    public class Language
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "languages")]
    public class Languages
    {
        #region Properties

        [XmlElement(ElementName = "language")]
        public List<Language> Language { get; set; }

        [XmlElement(ElementName = "special")]
        public Special Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "image")]
    public class Image
    {
        #region Properties

        [XmlAttribute(AttributeName = "filename")]
        public string Filename { get; set; }

        [XmlAttribute(AttributeName = "folder")]
        public string Foldere { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "images")]
    public class Images
    {
        #region Properties

        [XmlElement(ElementName = "image")]
        public List<Image> Image { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "special")]
    public class Special
    {
        #region Properties

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "shortname")]
        public string Shortname { get; set; }

        [XmlAttribute(AttributeName = "sourcetext")]
        public string Sourcetext { get; set; }

        [XmlElement(ElementName = "specsource")]
        public string Specsource { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "otherspecials")]
    public class Otherspecials
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "senses")]
    public class Senses
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "auras")]
    public class Auras
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "faction")]
    public class Faction
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "renown")]
        public string Renown { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "factions")]
    public class Factions
    {
        #region Properties

        [XmlElement(ElementName = "faction")]
        public List<Faction> Faction { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "situationalmodifier")]
    public class Situationalmodifier
    {
        #region Properties

        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "situationalmodifiers")]
    public class Situationalmodifiers
    {
        #region Properties

        [XmlElement(ElementName = "situationalmodifier")]
        public Situationalmodifier Situationalmodifier { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "weight")]
    public class Weight
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "cost")]
    public class Cost
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "geartype")]
    public class Geartype
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "rarity")]
    public class Rarity
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    #endregion

    #region Attributes/Abilities

    [XmlRoot(ElementName = "attrvalue")]
    public class Attrvalue
    {
        #region Properties

        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }

        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "attrbonus")]
    public class Attrbonus
    {
        #region Properties

        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }

        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "attribute")]
    public class Attribute
    {
        #region Properties

        [XmlElement(ElementName = "attrvalue")]
        public Attrvalue Attrvalue { get; set; }

        [XmlElement(ElementName = "attrbonus")]
        public Attrbonus Attrbonus { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "attributes")]
    public class Attributes
    {
        #region Properties

        [XmlElement(ElementName = "attribute")]
        public List<Attribute> Attribute { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "abilvalue")]
    public class Abilvalue
    {
        #region Properties

        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }

        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "abilbonus")]
    public class Abilbonus
    {
        #region Properties

        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }

        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "abilityscore")]
    public class Abilityscore
    {
        #region Properties

        [XmlElement(ElementName = "abilvalue")]
        public Abilvalue Abilvalue { get; set; }

        [XmlElement(ElementName = "abilbonus")]
        public Abilbonus Abilbonus { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "savingthrow")]
        public Savingthrow Savingthrow { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "abilityscores")]
    public class Abilityscores
    {
        #region Properties

        [XmlElement(ElementName = "abilityscore")]
        public List<Abilityscore> Abilityscore { get; set; }

        #endregion
    }

    #endregion

    #region Race

    [XmlRoot(ElementName = "race")]
    public class Race
    {
        #region Properties

        [XmlAttribute(AttributeName = "displayname")]
        public string Displayname { get; set; }

        [XmlAttribute(AttributeName = "ethnicity")]
        public string Ethnicity { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "racetext")]
        public string Racetext { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "subrace")]
    public class Subrace
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    #endregion

    #region Alignment

    [XmlRoot(ElementName = "alignment")]
    public class Alignment
    {
        #region Properties

        [XmlAttribute(AttributeName = "abbreviation")]
        public string Abbreviation { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    #endregion

    #region Character Options

    [XmlRoot(ElementName = "templates")]
    public class Templates
    {
        #region Properties

        [XmlAttribute(AttributeName = "summary")]
        public string Summary { get; set; }

        #endregion
    }

    #endregion

    #region Characteristics

    [XmlRoot(ElementName = "space")]
    public class Space
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "reach")]
    public class Reach
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "size")]
    public class Size
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "space")]
        public Space Space { get; set; }

        [XmlElement(ElementName = "reach")]
        public Reach Reach { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "deity")]
    public class Deity
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "charheight")]
    public class Charheight
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "charweight")]
    public class Charweight
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "personal")]
    public class Personal
    {
        #region Properties

        [XmlAttribute(AttributeName = "age")]
        public string Age { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "charheight")]
        public Charheight Charheight { get; set; }

        [XmlElement(ElementName = "charweight")]
        public Charweight Charweight { get; set; }

        [XmlAttribute(AttributeName = "eyes")]
        public string Eyes { get; set; }

        [XmlAttribute(AttributeName = "gender")]
        public string Gender { get; set; }

        [XmlAttribute(AttributeName = "hair")]
        public string Hair { get; set; }

        [XmlAttribute(AttributeName = "skin")]
        public string Skin { get; set; }

        #endregion
    }

    #endregion

    #region NPC Info

    [XmlRoot(ElementName = "challengerating")]
    public class Challengerating
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "xpaward")]
    public class Xpaward
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "npcinfo")]
    public class Npcinfo
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlText]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "ecology")]
    public class Ecology
    {
        #region Properties

        [XmlElement(ElementName = "npcinfo")]
        public List<Npcinfo> Npcinfo { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "npc")]
    public class Npc
    {
        #region Properties

        [XmlElement(ElementName = "basics")]
        public string Basics { get; set; }

        [XmlElement(ElementName = "tactics")]
        public string Tactics { get; set; }

        [XmlElement(ElementName = "ecology")]
        public Ecology Ecology { get; set; }

        [XmlElement(ElementName = "additional")]
        public string Additional { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        #endregion
    }

    #endregion

    #region Background

    [XmlRoot(ElementName = "backgroundtrait")]
    public class Backgroundtrait
    {
        #region Properties

        [XmlText]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "background")]
    public class Background
    {
        #region Properties

        [XmlElement(ElementName = "backgroundtrait")]
        public List<Backgroundtrait> Backgroundtrait { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    #endregion

    #region Journal

    [XmlRoot(ElementName = "xp")]
    public class Xp
    {
        #region Properties

        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "coins")]
    public class Coins
    {
        #region Properties

        [XmlAttribute(AttributeName = "abbreviation")]
        public string Abbreviation { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "money")]
    public class Money
    {
        #region Properties

        [XmlAttribute(AttributeName = "cn1")]
        public string Cn1 { get; set; }

        [XmlAttribute(AttributeName = "cn2")]
        public string Cn2 { get; set; }

        [XmlAttribute(AttributeName = "cn3")]
        public string Cn3 { get; set; }

        [XmlAttribute(AttributeName = "cn4")]
        public string Cn4 { get; set; }

        [XmlElement(ElementName = "coins")]
        public List<Coins> Coins { get; set; }

        [XmlAttribute(AttributeName = "cp")]
        public string Cp { get; set; }

        [XmlAttribute(AttributeName = "gp")]
        public string Gp { get; set; }

        [XmlAttribute(AttributeName = "pp")]
        public string Pp { get; set; }

        [XmlAttribute(AttributeName = "sp")]
        public string Sp { get; set; }

        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }

        [XmlAttribute(AttributeName = "valuables")]
        public string Valuables { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "journal")]
    public class Journal
    {
        #region Properties

        [XmlAttribute(AttributeName = "cn1")]
        public string Cn1 { get; set; }

        [XmlAttribute(AttributeName = "cn2")]
        public string Cn2 { get; set; }

        [XmlAttribute(AttributeName = "cn3")]
        public string Cn3 { get; set; }

        [XmlAttribute(AttributeName = "cn4")]
        public string Cn4 { get; set; }

        [XmlElement(ElementName = "coins")]
        public List<Coins> Coins { get; set; }

        [XmlAttribute(AttributeName = "cp")]
        public string Cp { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "gamedate")]
        public string Gamedate { get; set; }

        [XmlAttribute(AttributeName = "gp")]
        public string Gp { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "pp")]
        public string Pp { get; set; }

        [XmlAttribute(AttributeName = "prestigeaward")]
        public string Prestigeaward { get; set; }

        [XmlAttribute(AttributeName = "prestigespend")]
        public string Prestigespend { get; set; }

        [XmlAttribute(AttributeName = "realdate")]
        public string Realdate { get; set; }

        [XmlAttribute(AttributeName = "sp")]
        public string Sp { get; set; }

        [XmlAttribute(AttributeName = "xp")]
        public string Xp { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "journals")]
    public class Journals
    {
        #region Properties

        [XmlElement(ElementName = "journal")]
        public List<Journal> Journal { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "heropoints")]
    public class Heropoints
    {
        #region Properties

        [XmlAttribute(AttributeName = "enabled")]
        public string Enabled { get; set; }

        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }

        #endregion
    }

    #endregion

    #region Class

    [XmlRoot(ElementName = "classhitdice")]
    public class Classhitdice
    {
        #region Properties

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlAttribute(AttributeName = "sides")]
        public string Sides { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "class")]
    public class Class
    {
        #region Properties

        [XmlAttribute(AttributeName = "casterlevel")]
        public string Casterlevel { get; set; }

        [XmlAttribute(AttributeName = "casterlevelprogression")]
        public string Casterlevelprogression { get; set; }

        [XmlAttribute(AttributeName = "castersource")]
        public string Castersource { get; set; }

        [XmlElement(ElementName = "classhitdice")]
        public Classhitdice Classhitdice { get; set; }

        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "spellability")]
        public string Spellability { get; set; }

        [XmlAttribute(AttributeName = "spellattack")]
        public string Spellattack { get; set; }

        [XmlAttribute(AttributeName = "spells")]
        public string Spells { get; set; }

        [XmlAttribute(AttributeName = "spellsavedc")]
        public string Spellsavedc { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "classes")]
    public class Classes
    {
        #region Properties

        [XmlElement(ElementName = "class")]
        public List<Class> Class { get; set; }

        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }

        [XmlAttribute(AttributeName = "summary")]
        public string Summary { get; set; }

        [XmlAttribute(AttributeName = "summaryabbr")]
        public string Summaryabbr { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "favoredclass")]
    public class Favoredclass
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "favoredclasses")]
    public class Favoredclasses
    {
        #region Properties

        [XmlElement(ElementName = "favoredclass")]
        public Favoredclass Favoredclass { get; set; }

        #endregion
    }

    #endregion

    #region Skills, Proficiencies, Feats and Traits

    [XmlRoot(ElementName = "skillabilities")]
    public class Skillabilities
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "trait")]
    public class Trait
    {
        #region Properties

        [XmlAttribute(AttributeName = "categorytext")]
        public string Categorytext { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "traitcategory")]
        public string Traitcategory { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "traits")]
    public class Traits
    {
        #region Properties

        [XmlElement(ElementName = "trait")]
        public List<Trait> Trait { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "proficiencybonus")]
    public class Proficiencybonus
    {
        #region Properties

        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "toolproficiencies")]
    public class Toolproficiencies
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "weaponproficiencies")]
    public class Weaponproficiencies
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "armorproficiencies")]
    public class Armorproficiencies
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "skill")]
    public class Skill
    {
        #region Properties

        [XmlAttribute(AttributeName = "abilabbreviation")]
        public string Abilabbreviation { get; set; }

        [XmlAttribute(AttributeName = "abilbonus")]
        public string Abilbonus { get; set; }

        [XmlAttribute(AttributeName = "armorcheck")]
        public string Armorcheck { get; set; }

        [XmlAttribute(AttributeName = "attrbonus")]
        public string Attrbonus { get; set; }

        [XmlAttribute(AttributeName = "attrname")]
        public string Attrname { get; set; }

        [XmlAttribute(AttributeName = "classskill")]
        public string Classskill { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "isprofdoubled")]
        public string Isprofdoubled { get; set; }

        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "passive")]
        public string Passive { get; set; }

        [XmlAttribute(AttributeName = "ranks")]
        public string Ranks { get; set; }

        [XmlAttribute(AttributeName = "showpassive")]
        public string Showpassive { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        [XmlAttribute(AttributeName = "tools")]
        public string Tools { get; set; }

        [XmlAttribute(AttributeName = "trainedonly")]
        public string Trainedonly { get; set; }

        [XmlAttribute(AttributeName = "usable")]
        public string Usable { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "skills")]
    public class Skills
    {
        #region Properties

        [XmlElement(ElementName = "skill")]
        public List<Skill> Skill { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "feat")]
    public class Feat
    {
        #region Properties

        [XmlAttribute(AttributeName = "categorytext")]
        public string Categorytext { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "featcategory")]
        public string Featcategory { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "profgroup")]
        public string Profgroup { get; set; }

        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "feats")]
    public class Feats
    {
        #region Properties

        [XmlElement(ElementName = "feat")]
        public List<Feat> Feat { get; set; }

        #endregion
    }

    #endregion

    #region Saves

    [XmlRoot(ElementName = "save")]
    public class Save
    {
        #region Properties

        [XmlAttribute(AttributeName = "save")]
        public string _save { get; set; }

        [XmlAttribute(AttributeName = "abbr")]
        public string Abbr { get; set; }

        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }

        [XmlAttribute(AttributeName = "fromattr")]
        public string Fromattr { get; set; }

        [XmlAttribute(AttributeName = "frommisc")]
        public string Frommisc { get; set; }

        [XmlAttribute(AttributeName = "fromresist")]
        public string Fromresist { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "allsaves")]
    public class Allsaves
    {
        #region Properties

        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }

        [XmlAttribute(AttributeName = "frommisc")]
        public string Frommisc { get; set; }

        [XmlAttribute(AttributeName = "fromresist")]
        public string Fromresist { get; set; }

        [XmlAttribute(AttributeName = "save")]
        public string Save { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public List<Situationalmodifiers> Situationalmodifiers { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "saves")]
    public class Saves
    {
        #region Properties

        [XmlElement(ElementName = "save")]
        public List<Save> Save { get; set; }

        [XmlElement(ElementName = "allsaves")]
        public Allsaves Allsaves { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "savingthrow")]
    public class Savingthrow
    {
        #region Properties

        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    #endregion

    #region Defenses

    [XmlRoot(ElementName = "damageresistances")]
    public class Damageresistances
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "damageimmunities")]
    public class Damageimmunities
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "damagevulnerabilities")]
    public class Damagevulnerabilities
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "conditionimmunities")]
    public class Conditionimmunities
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "damagereduction")]
    public class Damagereduction
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "immunities")]
    public class Immunities
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "resistances")]
    public class Resistances
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "weaknesses")]
    public class Weaknesses
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "armorclass")]
    public class Armorclass
    {
        #region Properties

        [XmlAttribute(AttributeName = "ac")]
        public string Ac { get; set; }

        [XmlAttribute(AttributeName = "flatfooted")]
        public string Flatfooted { get; set; }

        [XmlAttribute(AttributeName = "fromarmor")]
        public string Fromarmor { get; set; }

        [XmlAttribute(AttributeName = "fromcharisma")]
        public string Fromcharisma { get; set; }

        [XmlAttribute(AttributeName = "fromdeflect")]
        public string Fromdeflect { get; set; }

        [XmlAttribute(AttributeName = "fromdexterity")]
        public string Fromdexterity { get; set; }

        [XmlAttribute(AttributeName = "fromdodge")]
        public string Fromdodge { get; set; }

        [XmlAttribute(AttributeName = "frommisc")]
        public string Frommisc { get; set; }

        [XmlAttribute(AttributeName = "fromnatural")]
        public string Fromnatural { get; set; }

        [XmlAttribute(AttributeName = "fromshield")]
        public string Fromshield { get; set; }

        [XmlAttribute(AttributeName = "fromsize")]
        public string Fromsize { get; set; }

        [XmlAttribute(AttributeName = "fromwisdom")]
        public string Fromwisdom { get; set; }

        [XmlAttribute(AttributeName = "maxdexbonus")]
        public string Maxdexbonus { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        [XmlAttribute(AttributeName = "touch")]
        public string Touch { get; set; }

        [XmlAttribute(AttributeName = "unarmored")]
        public string Unarmored { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "penalty")]
    public class Penalty
    {
        #region Properties

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "penalties")]
    public class Penalties
    {
        #region Properties

        [XmlElement(ElementName = "penalty")]
        public List<Penalty> Penalty { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "armor")]
    public class Armor
    {
        #region Properties

        [XmlAttribute(AttributeName = "ac")]
        public string Ac { get; set; }

        [XmlElement(ElementName = "weight")]
        public Weight Weight { get; set; }

        [XmlElement(ElementName = "cost")]
        public Cost Cost { get; set; }

        [XmlElement(ElementName = "geartype")]
        public Geartype Geartype { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "equipped")]
        public string Equipped { get; set; }

        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }

        [XmlElement(ElementName = "itemslot")]
        public string Itemslot { get; set; }

        [XmlAttribute(AttributeName = "maxdex")]
        public string Maxdex { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "natural")]
        public string Natural { get; set; }

        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }

        [XmlAttribute(AttributeName = "stealth")]
        public string Stealth { get; set; }

        [XmlAttribute(AttributeName = "strengthrequired")]
        public string Strengthrequired { get; set; }

        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "defenses")]
    public class Defenses
    {
        #region Properties

        [XmlElement(ElementName = "armor")]
        public List<Armor> Armor { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "defensive")]
    public class Defensive
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    #endregion

    #region Speed, Movement and Initiative

    [XmlRoot(ElementName = "initiative")]
    public class Initiative
    {
        #region Properties

        [XmlAttribute(AttributeName = "abilname")]
        public string Abilname { get; set; }

        [XmlAttribute(AttributeName = "abiltext")]
        public string Abiltext { get; set; }

        [XmlAttribute(AttributeName = "attrname")]
        public string Attrname { get; set; }

        [XmlAttribute(AttributeName = "attrtext")]
        public string Attrtext { get; set; }

        [XmlAttribute(AttributeName = "misctext")]
        public string Misctext { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "speed")]
    public class Speed
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "basespeed")]
    public class Basespeed
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "movement")]
    public class Movement
    {
        #region Properties

        [XmlElement(ElementName = "speed")]
        public Speed Speed { get; set; }

        [XmlElement(ElementName = "basespeed")]
        public Basespeed Basespeed { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "encumbrance")]
    public class Encumbrance
    {
        #region Properties

        [XmlAttribute(AttributeName = "carried")]
        public string Carried { get; set; }

        [XmlAttribute(AttributeName = "encumstr")]
        public string Encumstr { get; set; }

        [XmlAttribute(AttributeName = "heavy")]
        public string Heavy { get; set; }

        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }

        [XmlAttribute(AttributeName = "light")]
        public string Light { get; set; }

        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }

        [XmlAttribute(AttributeName = "medium")]
        public string Medium { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "maneuvertype")]
    public class Maneuvertype
    {
        #region Properties

        [XmlAttribute(AttributeName = "bonus")]
        public string Bonus { get; set; }

        [XmlAttribute(AttributeName = "cmb")]
        public string Cmb { get; set; }

        [XmlAttribute(AttributeName = "cmd")]
        public string Cmd { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "maneuvers")]
    public class Maneuvers
    {
        #region Properties

        [XmlAttribute(AttributeName = "cmb")]
        public string Cmb { get; set; }

        [XmlAttribute(AttributeName = "cmd")]
        public string Cmd { get; set; }

        [XmlAttribute(AttributeName = "cmdflatfooted")]
        public string Cmdflatfooted { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        [XmlElement(ElementName = "maneuvertype")]
        public List<Maneuvertype> Maneuvertype { get; set; }

        #endregion
    }

    #endregion

    #region Weapons

    [XmlRoot(ElementName = "magicbonus")]
    public class Magicbonus
    {
        #region Properties

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "weapon")]
    public class Weapon
    {
        #region Properties

        [XmlAttribute(AttributeName = "attack")]
        public string Attack { get; set; }

        [XmlAttribute(AttributeName = "categorytext")]
        public string Categorytext { get; set; }

        [XmlElement(ElementName = "magicbonus")]
        public Magicbonus Magicbonus { get; set; }

        [XmlElement(ElementName = "weight")]
        public Weight Weight { get; set; }

        [XmlElement(ElementName = "cost")]
        public Cost Cost { get; set; }

        [XmlAttribute(AttributeName = "crit")]
        public string Crit { get; set; }

        [XmlAttribute(AttributeName = "damage")]
        public string Damage { get; set; }

        [XmlElement(ElementName = "geartype")]
        public Geartype Geartype { get; set; }

        [XmlElement(ElementName = "rarity")]
        public Rarity Rarity { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }

        [XmlElement(ElementName = "wepcategory")]
        public string Wepcategory { get; set; }

        [XmlElement(ElementName = "weptype")]
        public string Weptype { get; set; }

        [XmlElement(ElementName = "wepproperty")]
        public List<string> Wepproperty { get; set; }

        [XmlElement(ElementName = "wepproficiency")]
        public string Wepproficiency { get; set; }

        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }

        [XmlElement(ElementName = "rangedattack")]
        public Rangedattack Rangedattack { get; set; }

        [XmlElement(ElementName = "itempower")]
        public Itempower Itempower { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }

        [XmlAttribute(AttributeName = "typetext")]
        public string Typetext { get; set; }

        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "melee")]
    public class Melee
    {
        #region Properties

        [XmlElement(ElementName = "weapon")]
        public List<Weapon> Weapon { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "rangedattack")]
    public class Rangedattack
    {
        #region Properties

        [XmlAttribute(AttributeName = "attack")]
        public string Attack { get; set; }

        [XmlAttribute(AttributeName = "range")]
        public string Range { get; set; }

        [XmlAttribute(AttributeName = "rangeinctext")]
        public string Rangeinctext { get; set; }

        [XmlAttribute(AttributeName = "rangeincvalue")]
        public string Rangeincvalue { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "ranged")]
    public class Ranged
    {
        #region Properties

        [XmlElement(ElementName = "weapon")]
        public List<Weapon> Weapon { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "attack")]
    public class Attack
    {
        #region Properties

        [XmlAttribute(AttributeName = "attackbonus")]
        public string Attackbonus { get; set; }

        [XmlAttribute(AttributeName = "baseattack")]
        public string Baseattack { get; set; }

        [XmlAttribute(AttributeName = "meleeattack")]
        public string Meleeattack { get; set; }

        [XmlAttribute(AttributeName = "rangedattack")]
        public string Rangedattack { get; set; }

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    #endregion

    #region Magic

    [XmlRoot(ElementName = "spell")]
    public class Spell
    {
        #region Properties

        [XmlAttribute(AttributeName = "area")]
        public string Area { get; set; }

        [XmlAttribute(AttributeName = "casterlevel")]
        public string Casterlevel { get; set; }

        [XmlAttribute(AttributeName = "castsleft")]
        public string Castsleft { get; set; }

        [XmlAttribute(AttributeName = "casttime")]
        public string Casttime { get; set; }

        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }

        [XmlAttribute(AttributeName = "componenttext")]
        public string Componenttext { get; set; }

        [XmlAttribute(AttributeName = "dc")]
        public string Dc { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "descriptortext")]
        public string Descriptortext { get; set; }

        [XmlAttribute(AttributeName = "duration")]
        public string Duration { get; set; }

        [XmlAttribute(AttributeName = "effect")]
        public string Effect { get; set; }

        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "range")]
        public string Range { get; set; }

        [XmlAttribute(AttributeName = "resist")]
        public string Resist { get; set; }

        [XmlAttribute(AttributeName = "resisttext")]
        public string Resisttext { get; set; }

        [XmlAttribute(AttributeName = "save")]
        public string Save { get; set; }

        [XmlAttribute(AttributeName = "savetext")]
        public string Savetext { get; set; }

        [XmlAttribute(AttributeName = "schooltext")]
        public string Schooltext { get; set; }

        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }

        [XmlElement(ElementName = "spellcomp")]
        public List<string> Spellcomp { get; set; }

        [XmlElement(ElementName = "spellschool")]
        public string Spellschool { get; set; }

        [XmlElement(ElementName = "spellsubschool")]
        public string Spellsubschool { get; set; }

        [XmlElement(ElementName = "spelldescript")]
        public List<string> Spelldescript { get; set; }

        [XmlAttribute(AttributeName = "subschooltext")]
        public string Subschooltext { get; set; }

        [XmlAttribute(AttributeName = "target")]
        public string Target { get; set; }

        [XmlAttribute(AttributeName = "unlimited")]
        public string Unlimited { get; set; }

        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "cantrips")]
    public class Cantrips
    {
        #region Properties

        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spellsknown")]
    public class Spellsknown
    {
        #region Properties

        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spellsmemorized")]
    public class Spellsmemorized
    {
        #region Properties

        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spellbook")]
    public class Spellbook
    {
        #region Properties

        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spellclass")]
    public class Spellclass
    {
        #region Properties

        [XmlAttribute(AttributeName = "cantripcount")]
        public string Cantripcount { get; set; }

        [XmlAttribute(AttributeName = "maxspelllevel")]
        public string Maxspelllevel { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "spellcount")]
        public string Spellcount { get; set; }

        [XmlAttribute(AttributeName = "spells")]
        public string Spells { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spellclasses")]
    public class Spellclasses
    {
        #region Properties

        [XmlElement(ElementName = "spellclass")]
        public List<Spellclass> Spellclass { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spellslot")]
    public class Spellslot
    {
        #region Properties

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "used")]
        public string Used { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spellslots")]
    public class Spellslots
    {
        #region Properties

        [XmlElement(ElementName = "spellslot")]
        public List<Spellslot> Spellslot { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "spelllike")]
    public class Spelllike
    {
        #region Properties

        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "racespells")]
    public class Racespells
    {
        #region Properties

        [XmlElement(ElementName = "spellability")]
        public List<Spell> Spell { get; set; }

        #endregion
    }

    #endregion

    #region Items

    [XmlRoot(ElementName = "itempower")]
    public class Itempower
    {
        #region Properties

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "pricebonustext")]
        public string Pricebonustext { get; set; }

        [XmlAttribute(AttributeName = "pricebonusvalue")]
        public string Pricebonusvalue { get; set; }

        [XmlAttribute(AttributeName = "pricecashtext")]
        public string Pricecashtext { get; set; }

        [XmlAttribute(AttributeName = "pricecashvalue")]
        public string Pricecashvalue { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        #region Properties

        [XmlElement(ElementName = "magicbonus")]
        public Magicbonus Magicbonus { get; set; }

        [XmlElement(ElementName = "weight")]
        public Weight Weight { get; set; }

        [XmlElement(ElementName = "cost")]
        public Cost Cost { get; set; }

        [XmlElement(ElementName = "geartype")]
        public Geartype Geartype { get; set; }

        [XmlElement(ElementName = "rarity")]
        public Rarity Rarity { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "isattuned")]
        public string Isattuned { get; set; }

        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }

        [XmlElement(ElementName = "itempower")]
        public Itempower Itempower { get; set; }

        [XmlElement(ElementName = "itemslot")]
        public string Itemslot { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }

        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "magicitems")]
    public class Magicitems
    {
        #region Properties

        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "gear")]
    public class Gear
    {
        #region Properties

        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "trackedresource")]
    public class Trackedresource
    {
        #region Properties

        [XmlAttribute(AttributeName = "left")]
        public string Left { get; set; }

        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }

        [XmlAttribute(AttributeName = "min")]
        public string Min { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "used")]
        public string Used { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "trackedresources")]
    public class Trackedresources
    {
        #region Properties

        [XmlElement(ElementName = "trackedresource")]
        public List<Trackedresource> Trackedresource { get; set; }

        #endregion
    }

    #endregion

    #region Health

    [XmlRoot(ElementName = "hitdice")]
    public class Hitdice
    {
        #region Properties

        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }

        [XmlAttribute(AttributeName = "dietype")]
        public string Dietype { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "health")]
    public class Health
    {
        #region Properties

        [XmlAttribute(AttributeName = "hitdice")]
        public string _Hitdice { get; set; }

        [XmlAttribute(AttributeName = "currenthp")]
        public string Currenthp { get; set; }

        [XmlAttribute(AttributeName = "damage")]
        public string Damage { get; set; }

        [XmlElement(ElementName = "special")]
        public Special Special { get; set; }

        [XmlElement(ElementName = "hitdice")]
        public List<Hitdice> Hitdice { get; set; }

        [XmlAttribute(AttributeName = "hitpoints")]
        public string Hitpoints { get; set; }

        [XmlAttribute(AttributeName = "nonlethal")]
        public string Nonlethal { get; set; }

        #endregion
    }

    #endregion

    #region Minions

    [XmlRoot(ElementName = "minions")]
    public class Minions
    {
        #region Properties

        [XmlElement(ElementName = "character")]
        public List<CharacterDetail> Character { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "animaltrick")]
    public class Animaltrick
    {
        #region Properties

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }

        #endregion
    }

    [XmlRoot(ElementName = "animaltricks")]
    public class Animaltricks
    {
        #region Properties

        [XmlElement(ElementName = "animaltrick")]
        public List<Animaltrick> Animaltrick { get; set; }

        #endregion
    }

    #endregion

    #region Character Detail

    [XmlRoot(ElementName = "character")]
    public partial class CharacterDetail
    {
        #region Properties

        [XmlAttribute(AttributeName = "active")]
        public string Active { get; set; }

        [XmlElement(ElementName = "race")]
        public Race Race { get; set; }

        [XmlElement(ElementName = "alignment")]
        public Alignment Alignment { get; set; }

        [XmlElement(ElementName = "money")]
        public Money Money { get; set; }

        [XmlElement(ElementName = "personal")]
        public Personal Personal { get; set; }

        [XmlElement(ElementName = "languages")]
        public Languages Languages { get; set; }

        [XmlElement(ElementName = "defensive")]
        public Defensive Defensive { get; set; }

        [XmlElement(ElementName = "armorclass")]
        public Armorclass Armorclass { get; set; }

        [XmlElement(ElementName = "encumbrance")]
        public Encumbrance Encumbrance { get; set; }

        [XmlElement(ElementName = "skills")]
        public Skills Skills { get; set; }

        [XmlElement(ElementName = "skillabilities")]
        public Skillabilities Skillabilities { get; set; }

        [XmlElement(ElementName = "feats")]
        public Feats Feats { get; set; }

        [XmlElement(ElementName = "attack")]
        public Attack Attack { get; set; }

        [XmlElement(ElementName = "factions")]
        public Factions Factions { get; set; }

        [XmlElement(ElementName = "types")]
        public Types Types { get; set; }

        [XmlElement(ElementName = "senses")]
        public Senses Senses { get; set; }

        [XmlElement(ElementName = "auras")]
        public Auras Auras { get; set; }

        [XmlElement(ElementName = "templates")]
        public Templates Templates { get; set; }

        [XmlElement(ElementName = "size")]
        public Size Size { get; set; }

        [XmlElement(ElementName = "deity")]
        public Deity Deity { get; set; }

        [XmlElement(ElementName = "challengerating")]
        public Challengerating Challengerating { get; set; }

        [XmlAttribute(AttributeName = "characterindex")]
        public string Characterindex { get; set; }

        [XmlElement(ElementName = "xpaward")]
        public Xpaward Xpaward { get; set; }

        [XmlElement(ElementName = "classes")]
        public Classes Classes { get; set; }

        [XmlElement(ElementName = "melee")]
        public Melee Melee { get; set; }

        [XmlElement(ElementName = "ranged")]
        public Ranged Ranged { get; set; }

        [XmlElement(ElementName = "defenses")]
        public Defenses Defenses { get; set; }

        [XmlElement(ElementName = "initiative")]
        public Initiative Initiative { get; set; }

        [XmlElement(ElementName = "movement")]
        public Movement Movement { get; set; }

        [XmlElement(ElementName = "magicitems")]
        public Magicitems Magicitems { get; set; }

        [XmlElement(ElementName = "gear")]
        public Gear Gear { get; set; }

        [XmlElement(ElementName = "health")]
        public Health Health { get; set; }

        [XmlElement(ElementName = "spellbook")]
        public Spellbook Spellbook { get; set; }

        [XmlElement(ElementName = "spellclasses")]
        public Spellclasses Spellclasses { get; set; }

        [XmlElement(ElementName = "journals")]
        public Journals Journals { get; set; }

        [XmlElement(ElementName = "images")]
        public Images Images { get; set; }

        [XmlElement(ElementName = "validation")]
        public Validation Validation { get; set; }

        [XmlElement(ElementName = "settings")]
        public Settings Settings { get; set; }

        [XmlElement(ElementName = "npc")]
        public Npc Npc { get; set; }

        [XmlElement(ElementName = "minions")]
        public Minions Minions { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "nature")]
        public string Nature { get; set; }

        [XmlElement(ElementName = "spelllike")]
        public Spelllike Spelllike { get; set; }

        [XmlElement(ElementName = "trackedresources")]
        public Trackedresources Trackedresources { get; set; }

        [XmlElement(ElementName = "otherspecials")]
        public Otherspecials Otherspecials { get; set; }

        [XmlAttribute(AttributeName = "playername")]
        public string Playername { get; set; }

        [XmlAttribute(AttributeName = "relationship")]
        public string Relationship { get; set; }

        [XmlAttribute(AttributeName = "role")]
        public string Role { get; set; }

        [XmlElement(ElementName = "xp")]
        public Xp Xp { get; set; }

        [XmlElement(ElementName = "spellsknown")]
        public Spellsknown Spellsknown { get; set; }

        [XmlElement(ElementName = "spellsmemorized")]
        public Spellsmemorized Spellsmemorized { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        #endregion
    }

    #endregion

    #endregion

    #region 5e Specific

    /// <summary>
    ///     Character elements specific to 5e SRD
    /// </summary>
    public partial class CharacterDetail
    {
        #region Properties

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

        [XmlElement(ElementName = "typetags")]
        public Typetags Typetags { get; set; }

        [XmlElement(ElementName = "background")]
        public Background Background { get; set; }

        [XmlElement(ElementName = "proficiencybonus")]
        public Proficiencybonus Proficiencybonus { get; set; }

        [XmlElement(ElementName = "racespells")]
        public Racespells Racespells { get; set; }

        [XmlElement(ElementName = "cantrips")]
        public Cantrips Cantrips { get; set; }

        [XmlElement(ElementName = "damageimmunities")]
        public Damageimmunities Damageimmunities { get; set; }

        [XmlElement(ElementName = "damagevulnerabilities")]
        public Damagevulnerabilities Damagevulnerabilities { get; set; }

        [XmlElement(ElementName = "conditionimmunities")]
        public Conditionimmunities Conditionimmunities { get; set; }

        [XmlElement(ElementName = "damageresistances")]
        public Damageresistances Damageresistances { get; set; }

        [XmlElement(ElementName = "spellslots")]
        public Spellslots Spellslots { get; set; }

        #endregion

        //Not Supported
        //[XmlElement(ElementName = "itemspells")]
        //public string Itemspells { get; set; } // ToDo: Need example .por
    }

    #endregion

    #region Pathfinder Specific

    /// <summary>
    ///     Character elements specific to Pathfinder
    /// </summary>
    public partial class CharacterDetail
    {
        #region Properties

        [XmlElement(ElementName = "maneuvers")]
        public Maneuvers Maneuvers { get; set; }

        [XmlElement(ElementName = "traits")]
        public Traits Traits { get; set; }

        [XmlElement(ElementName = "animaltricks")]
        public Animaltricks Animaltricks { get; set; }

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

        #endregion

        // Not Supported
        //[XmlElement(ElementName = "flaws")]
        //public string Flaws { get; set; }
        //[XmlElement(ElementName = "skilltricks")]
        //public string Skilltricks { get; set; }
    }

    #endregion
}