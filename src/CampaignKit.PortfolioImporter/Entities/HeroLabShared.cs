using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{

    #region Main XML Document Classes

        [XmlRoot(ElementName = "document")]
        public class Document
        {
            [XmlElement(ElementName = "public")]
            public Public Public { get; set; }
        }

        [XmlRoot(ElementName = "public")]
        public class Public
        {
            [XmlElement(ElementName = "program")]
            public Program Program { get; set; }
            [XmlElement(ElementName = "localization")]
            public Localization Localization { get; set; }
            [XmlElement(ElementName = "character")]
            public HeroLabCharacter Character { get; set; }
        }

        [XmlRoot(ElementName = "version")]
        public class Version
        {
            [XmlAttribute(AttributeName = "version")]
            public string _version { get; set; }
            [XmlAttribute(AttributeName = "primary")]
            public string Primary { get; set; }
            [XmlAttribute(AttributeName = "secondary")]
            public string Secondary { get; set; }
            [XmlAttribute(AttributeName = "tertiary")]
            public string Tertiary { get; set; }
            [XmlAttribute(AttributeName = "build")]
            public string Build { get; set; }
        }

        [XmlRoot(ElementName = "program")]
        public class Program
        {
            [XmlElement(ElementName = "programinfo")]
            public string Programinfo { get; set; }
            [XmlElement(ElementName = "version")]
            public Version Version { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "url")]
            public string Url { get; set; }
        }
    
        [XmlRoot(ElementName = "localization")]
        public class Localization
        {
            [XmlAttribute(AttributeName = "language")]
            public string Language { get; set; }
            [XmlAttribute(AttributeName = "units")]
            public string Units { get; set; }
        }
    
        [XmlRoot(ElementName = "bookinfo")]
        public class Bookinfo
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "validation")]
        public class Validation
        {
            [XmlElement(ElementName = "report")]
            public string Report { get; set; }
        }

        [XmlRoot(ElementName = "settings")]
        public class Settings
        {
            [XmlAttribute(AttributeName = "summary")]
            public string Summary { get; set; }
        }



    #endregion

    #region Base Types

        [XmlRoot(ElementName = "type")]
        public class Type
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "active")]
            public string Active { get; set; }
        }

        [XmlRoot(ElementName = "types")]
        public class Types
        {
            [XmlElement(ElementName = "type")]
            public List<Type> Type { get; set; }
        }

        [XmlRoot(ElementName = "subtype")]
        public class Subtype
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "subtypes")]
        public class Subtypes
        {
            [XmlElement(ElementName = "subtype")]
            public List<Subtype> Subtype { get; set; }
        }
    
        [XmlRoot(ElementName = "typetag")]
        public class Typetag
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "typetags")]
        public class Typetags
        {
            [XmlElement(ElementName = "typetag")]
            public Typetag Typetag { get; set; }
        }

        [XmlRoot(ElementName = "language")]
        public class Language
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "useradded")]
            public string Useradded { get; set; }
        }

        [XmlRoot(ElementName = "languages")]
        public class Languages
        {
            [XmlElement(ElementName = "language")]
            public List<Language> Language { get; set; }
            [XmlElement(ElementName = "special")]
            public Special Special { get; set; }
        }

        [XmlRoot(ElementName = "image")]
        public class Image
        {
            [XmlAttribute(AttributeName = "filename")]
            public string Filename { get; set; }
            [XmlAttribute(AttributeName = "folder")]
            public string Foldere { get; set; }
        }

        [XmlRoot(ElementName = "images")]
        public class Images
        {
            [XmlElement(ElementName = "image")]
            public List<Image> Image { get; set; }
        }
    
        [XmlRoot(ElementName = "special")]
        public class Special
        {
            [XmlElement(ElementName = "description")]
            public string Description { get; set; }
            [XmlElement(ElementName = "specsource")]
            public string Specsource { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "shortname")]
            public string Shortname { get; set; }
            [XmlAttribute(AttributeName = "sourcetext")]
            public string Sourcetext { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }

        [XmlRoot(ElementName = "otherspecials")]
        public class Otherspecials
        {
            [XmlElement(ElementName = "special")]
            public List<Special> Special { get; set; }
        }

        [XmlRoot(ElementName = "senses")]
        public class Senses
        {
            [XmlElement(ElementName = "special")]
            public List<Special> Special { get; set; }
        }

        [XmlRoot(ElementName = "auras")]
        public class Auras
        {
            [XmlElement(ElementName = "special")]
            public List<Special> Special { get; set; }
        }

        [XmlRoot(ElementName = "faction")]
        public class Faction
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "renown")]
            public string Renown { get; set; }
        }

        [XmlRoot(ElementName = "factions")]
        public class Factions
        {
            [XmlElement(ElementName = "faction")]
            public List<Faction> Faction { get; set; }
        }

        [XmlRoot(ElementName = "situationalmodifier")]
        public class Situationalmodifier
        {
            [XmlAttribute(AttributeName = "text")]
            public string Text { get; set; }
            [XmlAttribute(AttributeName = "source")]
            public string Source { get; set; }
        }

        [XmlRoot(ElementName = "situationalmodifiers")]
        public class Situationalmodifiers
        {
            [XmlAttribute(AttributeName = "text")]
            public string Text { get; set; }
            [XmlElement(ElementName = "situationalmodifier")]
            public Situationalmodifier Situationalmodifier { get; set; }
        }

        [XmlRoot(ElementName = "weight")]
        public class Weight
        {
            [XmlAttribute(AttributeName = "text")]
            public string Text { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "cost")]
        public class Cost
        {
            [XmlAttribute(AttributeName = "text")]
            public string Text { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "geartype")]
        public class Geartype
        {
            [XmlAttribute(AttributeName = "text")]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "rarity")]
        public class Rarity
        {
            [XmlAttribute(AttributeName = "text")]
            public string Text { get; set; }
        }

    #endregion

    #region Attributes/Abilities
    
    [XmlRoot(ElementName = "attrvalue")]
    public class Attrvalue
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }
    }

    [XmlRoot(ElementName = "attrbonus")]
    public class Attrbonus
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }
    }


    [XmlRoot(ElementName = "attribute")]
    public class Attribute
    {
        [XmlElement(ElementName = "attrvalue")]
        public Attrvalue Attrvalue { get; set; }
        [XmlElement(ElementName = "attrbonus")]
        public Attrbonus Attrbonus { get; set; }
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "attributes")]
    public class Attributes
    {
        [XmlElement(ElementName = "attribute")]
        public List<Attribute> Attribute { get; set; }
    }
    
    [XmlRoot(ElementName = "abilvalue")]
    public class Abilvalue
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }
    }

    [XmlRoot(ElementName = "abilbonus")]
    public class Abilbonus
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }
    }

    [XmlRoot(ElementName = "abilityscore")]
    public class Abilityscore
    {
        [XmlElement(ElementName = "abilvalue")]
        public Abilvalue Abilvalue { get; set; }
        [XmlElement(ElementName = "abilbonus")]
        public Abilbonus Abilbonus { get; set; }
        [XmlElement(ElementName = "savingthrow")]
        public Savingthrow Savingthrow { get; set; }
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "abilityscores")]
    public class Abilityscores
    {
        [XmlElement(ElementName = "abilityscore")]
        public List<Abilityscore> Abilityscore { get; set; }
    }



    #endregion

    #region Race

    [XmlRoot(ElementName = "race")]
    public class Race
    {
        [XmlAttribute(AttributeName = "racetext")]
        public string Racetext { get; set; }
        [XmlAttribute(AttributeName = "displayname")]
        public string Displayname { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ethnicity")]
        public string Ethnicity { get; set; }
    }

    [XmlRoot(ElementName = "subrace")]
    public class Subrace
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    #endregion

    #region Alignment

    [XmlRoot(ElementName = "alignment")]
    public class Alignment
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "abbreviation")]
        public string Abbreviation { get; set; }
    }

    #endregion

    #region Character Options

    [XmlRoot(ElementName = "templates")]
    public class Templates
    {
        [XmlAttribute(AttributeName = "summary")]
        public string Summary { get; set; }
    }

    #endregion

    #region Characteristics

    [XmlRoot(ElementName = "space")]
    public class Space
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "reach")]
    public class Reach
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "size")]
    public class Size
    {
        [XmlElement(ElementName = "space")]
        public Space Space { get; set; }
        [XmlElement(ElementName = "reach")]
        public Reach Reach { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "deity")]
    public class Deity
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "charheight")]
    public class Charheight
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "charweight")]
    public class Charweight
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "personal")]
    public class Personal
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "charheight")]
        public Charheight Charheight { get; set; }
        [XmlElement(ElementName = "charweight")]
        public Charweight Charweight { get; set; }
        [XmlAttribute(AttributeName = "gender")]
        public string Gender { get; set; }
        [XmlAttribute(AttributeName = "age")]
        public string Age { get; set; }
        [XmlAttribute(AttributeName = "hair")]
        public string Hair { get; set; }
        [XmlAttribute(AttributeName = "eyes")]
        public string Eyes { get; set; }
        [XmlAttribute(AttributeName = "skin")]
        public string Skin { get; set; }
    }

    #endregion

    #region NPC Info

    [XmlRoot(ElementName = "challengerating")]
    public class Challengerating
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "xpaward")]
    public class Xpaward
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "npcinfo")]
    public class Npcinfo
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ecology")]
    public class Ecology
    {
        [XmlElement(ElementName = "npcinfo")]
        public List<Npcinfo> Npcinfo { get; set; }
    }

    [XmlRoot(ElementName = "npc")]
    public class Npc
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "basics")]
        public string Basics { get; set; }
        [XmlElement(ElementName = "tactics")]
        public string Tactics { get; set; }
        [XmlElement(ElementName = "ecology")]
        public Ecology Ecology { get; set; }
        [XmlElement(ElementName = "additional")]
        public string Additional { get; set; }
    }

    #endregion

    #region Background

    [XmlRoot(ElementName = "backgroundtrait")]
    public class Backgroundtrait
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "background")]
    public class Background
    {
        [XmlElement(ElementName = "backgroundtrait")]
        public List<Backgroundtrait> Backgroundtrait { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    #endregion

    #region Journal

    [XmlRoot(ElementName = "xp")]
    public class Xp
    {
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
    }

    [XmlRoot(ElementName = "coins")]
    public class Coins
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "abbreviation")]
        public string Abbreviation { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
    }

    [XmlRoot(ElementName = "money")]
    public class Money
    {
        [XmlElement(ElementName = "coins")]
        public List<Coins> Coins { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "valuables")]
        public string Valuables { get; set; }
        [XmlAttribute(AttributeName = "pp")]
        public string Pp { get; set; }
        [XmlAttribute(AttributeName = "gp")]
        public string Gp { get; set; }
        [XmlAttribute(AttributeName = "sp")]
        public string Sp { get; set; }
        [XmlAttribute(AttributeName = "cp")]
        public string Cp { get; set; }
        [XmlAttribute(AttributeName = "cn1")]
        public string Cn1 { get; set; }
        [XmlAttribute(AttributeName = "cn2")]
        public string Cn2 { get; set; }
        [XmlAttribute(AttributeName = "cn3")]
        public string Cn3 { get; set; }
        [XmlAttribute(AttributeName = "cn4")]
        public string Cn4 { get; set; }
    }
    
    [XmlRoot(ElementName = "journal")]
    public class Journal
    {
        [XmlElement(ElementName = "coins")]
        public List<Coins> Coins { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "gamedate")]
        public string Gamedate { get; set; }
        [XmlAttribute(AttributeName = "realdate")]
        public string Realdate { get; set; }
        [XmlAttribute(AttributeName = "xp")]
        public string Xp { get; set; }
        [XmlAttribute(AttributeName = "pp")]
        public string Pp { get; set; }
        [XmlAttribute(AttributeName = "gp")]
        public string Gp { get; set; }
        [XmlAttribute(AttributeName = "sp")]
        public string Sp { get; set; }
        [XmlAttribute(AttributeName = "cp")]
        public string Cp { get; set; }
        [XmlAttribute(AttributeName = "cn1")]
        public string Cn1 { get; set; }
        [XmlAttribute(AttributeName = "cn2")]
        public string Cn2 { get; set; }
        [XmlAttribute(AttributeName = "cn3")]
        public string Cn3 { get; set; }
        [XmlAttribute(AttributeName = "cn4")]
        public string Cn4 { get; set; }
        [XmlAttribute(AttributeName = "prestigeaward")]
        public string Prestigeaward { get; set; }
        [XmlAttribute(AttributeName = "prestigespend")]
        public string Prestigespend { get; set; }
    }

    [XmlRoot(ElementName = "journals")]
    public class Journals
    {
        [XmlElement(ElementName = "journal")]
        public List<Journal> Journal { get; set; }
    }

    [XmlRoot(ElementName = "heropoints")]
    public class Heropoints
    {
        [XmlAttribute(AttributeName = "enabled")]
        public string Enabled { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
    }

    #endregion

    #region Class
    
    [XmlRoot(ElementName = "classhitdice")]
    public class Classhitdice
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
        [XmlAttribute(AttributeName = "sides")]
        public string Sides { get; set; }
    }

    [XmlRoot(ElementName = "class")]
    public class Class
    {
        [XmlElement(ElementName = "classhitdice")]
        public Classhitdice Classhitdice { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }
        [XmlAttribute(AttributeName = "spells")]
        public string Spells { get; set; }
        [XmlAttribute(AttributeName = "casterlevel")]
        public string Casterlevel { get; set; }
        [XmlAttribute(AttributeName = "spellattack")]
        public string Spellattack { get; set; }
        [XmlAttribute(AttributeName = "spellsavedc")]
        public string Spellsavedc { get; set; }
        [XmlAttribute(AttributeName = "castersource")]
        public string Castersource { get; set; }
        [XmlAttribute(AttributeName = "spellability")]
        public string Spellability { get; set; }
        [XmlAttribute(AttributeName = "casterlevelprogression")]
        public string Casterlevelprogression { get; set; }
    }
    
    [XmlRoot(ElementName = "classes")]
    public class Classes
    {
        [XmlElement(ElementName = "class")]
        public List<Class> Class { get; set; }
        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }
        [XmlAttribute(AttributeName = "summary")]
        public string Summary { get; set; }
        [XmlAttribute(AttributeName = "summaryabbr")]
        public string Summaryabbr { get; set; }
    }

    [XmlRoot(ElementName = "favoredclass")]
    public class Favoredclass
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "favoredclasses")]
    public class Favoredclasses
    {
        [XmlElement(ElementName = "favoredclass")]
        public Favoredclass Favoredclass { get; set; }
    }

    #endregion

    #region Skills, Proficiencies, Feats and Traits
    [XmlRoot(ElementName = "skillabilities")]
    public class Skillabilities
    {
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }

    [XmlRoot(ElementName = "trait")]
    public class Trait
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "traitcategory")]
        public string Traitcategory { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "categorytext")]
        public string Categorytext { get; set; }
    }

    [XmlRoot(ElementName = "traits")]
    public class Traits
    {
        [XmlElement(ElementName = "trait")]
        public List<Trait> Trait { get; set; }
    }

    [XmlRoot(ElementName = "proficiencybonus")]
    public class Proficiencybonus
    {
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
    }

    [XmlRoot(ElementName = "toolproficiencies")]
    public class Toolproficiencies
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "weaponproficiencies")]
    public class Weaponproficiencies
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "armorproficiencies")]
    public class Armorproficiencies
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "skill")]
    public class Skill
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ranks")]
        public string Ranks { get; set; }
        [XmlAttribute(AttributeName = "attrbonus")]
        public string Attrbonus { get; set; }
        [XmlAttribute(AttributeName = "attrname")]
        public string Attrname { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "armorcheck")]
        public string Armorcheck { get; set; }
        [XmlAttribute(AttributeName = "classskill")]
        public string Classskill { get; set; }
        [XmlAttribute(AttributeName = "tools")]
        public string Tools { get; set; }
        [XmlAttribute(AttributeName = "trainedonly")]
        public string Trainedonly { get; set; }
        [XmlAttribute(AttributeName = "usable")]
        public string Usable { get; set; }
        [XmlAttribute(AttributeName = "abilbonus")]
        public string Abilbonus { get; set; }
        [XmlAttribute(AttributeName = "abilabbreviation")]
        public string Abilabbreviation { get; set; }
        [XmlAttribute(AttributeName = "passive")]
        public string Passive { get; set; }
        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }
        [XmlAttribute(AttributeName = "isprofdoubled")]
        public string Isprofdoubled { get; set; }
        [XmlAttribute(AttributeName = "showpassive")]
        public string Showpassive { get; set; }
    }

    [XmlRoot(ElementName = "skills")]
    public class Skills
    {
        [XmlElement(ElementName = "skill")]
        public List<Skill> Skill { get; set; }
    }

    [XmlRoot(ElementName = "feat")]
    public class Feat
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "featcategory")]
        public string Featcategory { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "categorytext")]
        public string Categorytext { get; set; }
        [XmlAttribute(AttributeName = "profgroup")]
        public string Profgroup { get; set; }
        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }
    }

    [XmlRoot(ElementName = "feats")]
    public class Feats
    {
        [XmlElement(ElementName = "feat")]
        public List<Feat> Feat { get; set; }
    }

    #endregion

    #region Saves

    [XmlRoot(ElementName = "save")]
    public class Save
    {
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "abbr")]
        public string Abbr { get; set; }
        [XmlAttribute(AttributeName = "save")]
        public string _save { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "fromattr")]
        public string Fromattr { get; set; }
        [XmlAttribute(AttributeName = "fromresist")]
        public string Fromresist { get; set; }
        [XmlAttribute(AttributeName = "frommisc")]
        public string Frommisc { get; set; }
    }


    [XmlRoot(ElementName = "allsaves")]
    public class Allsaves
    {
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "save")]
        public string Save { get; set; }
        [XmlAttribute(AttributeName = "base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "fromresist")]
        public string Fromresist { get; set; }
        [XmlAttribute(AttributeName = "frommisc")]
        public string Frommisc { get; set; }
    }
    
    [XmlRoot(ElementName = "saves")]
    public class Saves
    {
        [XmlElement(ElementName = "save")]
        public List<Save> Save { get; set; }
        [XmlElement(ElementName = "allsaves")]
        public Allsaves Allsaves { get; set; }
    }

    [XmlRoot(ElementName = "savingthrow")]
    public class Savingthrow
    {
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }
    }

    #endregion

    #region Defenses

    [XmlRoot(ElementName = "damageresistances")]
    public class Damageresistances
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "damageimmunities")]
    public class Damageimmunities
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "damagevulnerabilities")]
    public class Damagevulnerabilities
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "conditionimmunities")]
    public class Conditionimmunities
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "damagereduction")]
    public class Damagereduction
    {
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }

    [XmlRoot(ElementName = "immunities")]
    public class Immunities
    {
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }

    [XmlRoot(ElementName = "resistances")]
    public class Resistances
    {
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }

    [XmlRoot(ElementName = "weaknesses")]
    public class Weaknesses
    {
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }

    [XmlRoot(ElementName = "armorclass")]
    public class Armorclass
    {
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "ac")]
        public string Ac { get; set; }
        [XmlAttribute(AttributeName = "touch")]
        public string Touch { get; set; }
        [XmlAttribute(AttributeName = "flatfooted")]
        public string Flatfooted { get; set; }
        [XmlAttribute(AttributeName = "fromarmor")]
        public string Fromarmor { get; set; }
        [XmlAttribute(AttributeName = "fromshield")]
        public string Fromshield { get; set; }
        [XmlAttribute(AttributeName = "fromdexterity")]
        public string Fromdexterity { get; set; }
        [XmlAttribute(AttributeName = "fromwisdom")]
        public string Fromwisdom { get; set; }
        [XmlAttribute(AttributeName = "fromcharisma")]
        public string Fromcharisma { get; set; }
        [XmlAttribute(AttributeName = "fromsize")]
        public string Fromsize { get; set; }
        [XmlAttribute(AttributeName = "fromnatural")]
        public string Fromnatural { get; set; }
        [XmlAttribute(AttributeName = "fromdeflect")]
        public string Fromdeflect { get; set; }
        [XmlAttribute(AttributeName = "fromdodge")]
        public string Fromdodge { get; set; }
        [XmlAttribute(AttributeName = "frommisc")]
        public string Frommisc { get; set; }
        [XmlAttribute(AttributeName = "unarmored")]
        public string Unarmored { get; set; }
        [XmlAttribute(AttributeName = "maxdexbonus")]
        public string Maxdexbonus { get; set; }
    }

    [XmlRoot(ElementName = "penalty")]
    public class Penalty
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "penalties")]
    public class Penalties
    {
        [XmlElement(ElementName = "penalty")]
        public List<Penalty> Penalty { get; set; }
    }

    [XmlRoot(ElementName = "armor")]
    public class Armor
    {
        [XmlElement(ElementName = "weight")]
        public Weight Weight { get; set; }
        [XmlElement(ElementName = "cost")]
        public Cost Cost { get; set; }
        [XmlElement(ElementName = "geartype")]
        public Geartype Geartype { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ac")]
        public string Ac { get; set; }
        [XmlAttribute(AttributeName = "equipped")]
        public string Equipped { get; set; }
        [XmlAttribute(AttributeName = "natural")]
        public string Natural { get; set; }
        [XmlAttribute(AttributeName = "stealth")]
        public string Stealth { get; set; }
        [XmlAttribute(AttributeName = "maxdex")]
        public string Maxdex { get; set; }
        [XmlAttribute(AttributeName = "strengthrequired")]
        public string Strengthrequired { get; set; }
        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }
        [XmlElement(ElementName = "itemslot")]
        public string Itemslot { get; set; }
    }

    [XmlRoot(ElementName = "defenses")]
    public class Defenses
    {
        [XmlElement(ElementName = "armor")]
        public List<Armor> Armor { get; set; }
    }

    [XmlRoot(ElementName = "defensive")]
    public class Defensive
    {
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }
    
    #endregion

    #region Speed, Movement and Initiative
    
    [XmlRoot(ElementName = "initiative")]
    public class Initiative
    {
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "abiltext")]
        public string Abiltext { get; set; }
        [XmlAttribute(AttributeName = "misctext")]
        public string Misctext { get; set; }
        [XmlAttribute(AttributeName = "abilname")]
        public string Abilname { get; set; }
        [XmlAttribute(AttributeName = "attrtext")]
        public string Attrtext { get; set; }
        [XmlAttribute(AttributeName = "attrname")]
        public string Attrname { get; set; }
    }
    
    [XmlRoot(ElementName = "speed")]
    public class Speed
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "basespeed")]
    public class Basespeed
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "movement")]
    public class Movement
    {
        [XmlElement(ElementName = "speed")]
        public Speed Speed { get; set; }
        [XmlElement(ElementName = "basespeed")]
        public Basespeed Basespeed { get; set; }
    }

    [XmlRoot(ElementName = "encumbrance")]
    public class Encumbrance
    {
        [XmlAttribute(AttributeName = "carried")]
        public string Carried { get; set; }
        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }
        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }
        [XmlAttribute(AttributeName = "encumstr")]
        public string Encumstr { get; set; }
        [XmlAttribute(AttributeName = "light")]
        public string Light { get; set; }
        [XmlAttribute(AttributeName = "medium")]
        public string Medium { get; set; }
        [XmlAttribute(AttributeName = "heavy")]
        public string Heavy { get; set; }
    }


    [XmlRoot(ElementName = "maneuvertype")]
    public class Maneuvertype
    {
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "bonus")]
        public string Bonus { get; set; }
        [XmlAttribute(AttributeName = "cmb")]
        public string Cmb { get; set; }
        [XmlAttribute(AttributeName = "cmd")]
        public string Cmd { get; set; }
    }

    [XmlRoot(ElementName = "maneuvers")]
    public class Maneuvers
    {
        [XmlElement(ElementName = "situationalmodifiers")]
        public Situationalmodifiers Situationalmodifiers { get; set; }
        [XmlElement(ElementName = "maneuvertype")]
        public List<Maneuvertype> Maneuvertype { get; set; }
        [XmlAttribute(AttributeName = "cmb")]
        public string Cmb { get; set; }
        [XmlAttribute(AttributeName = "cmd")]
        public string Cmd { get; set; }
        [XmlAttribute(AttributeName = "cmdflatfooted")]
        public string Cmdflatfooted { get; set; }
    }

    #endregion

    #region Weapons

    [XmlRoot(ElementName = "magicbonus")]
    public class Magicbonus
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }


    [XmlRoot(ElementName = "weapon")]
    public class Weapon
    {
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
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "categorytext")]
        public string Categorytext { get; set; }
        [XmlAttribute(AttributeName = "typetext")]
        public string Typetext { get; set; }
        [XmlAttribute(AttributeName = "attack")]
        public string Attack { get; set; }
        [XmlAttribute(AttributeName = "damage")]
        public string Damage { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }
        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }
        [XmlElement(ElementName = "rangedattack")]
        public Rangedattack Rangedattack { get; set; }
        [XmlElement(ElementName = "itempower")]
        public Itempower Itempower { get; set; }
        [XmlAttribute(AttributeName = "crit")]
        public string Crit { get; set; }
    }

    [XmlRoot(ElementName = "melee")]
    public class Melee
    {
        [XmlElement(ElementName = "weapon")]
        public List<Weapon> Weapon { get; set; }
    }

    [XmlRoot(ElementName = "rangedattack")]
    public class Rangedattack
    {
        [XmlAttribute(AttributeName = "attack")]
        public string Attack { get; set; }
        [XmlAttribute(AttributeName = "range")]
        public string Range { get; set; }
        [XmlAttribute(AttributeName = "rangeinctext")]
        public string Rangeinctext { get; set; }
        [XmlAttribute(AttributeName = "rangeincvalue")]
        public string Rangeincvalue { get; set; }
 
    }

    [XmlRoot(ElementName = "ranged")]
    public class Ranged
    {
        [XmlElement(ElementName = "weapon")]
        public List<Weapon> Weapon { get; set; }
    }


    [XmlRoot(ElementName = "attack")]
    public class Attack
    {
        [XmlAttribute(AttributeName = "attackbonus")]
        public string Attackbonus { get; set; }
        [XmlAttribute(AttributeName = "meleeattack")]
        public string Meleeattack { get; set; }
        [XmlAttribute(AttributeName = "rangedattack")]
        public string Rangedattack { get; set; }
        [XmlAttribute(AttributeName = "baseattack")]
        public string Baseattack { get; set; }
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }

    #endregion

    #region Magic
    
    [XmlRoot(ElementName = "spell")]
    public class Spell
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "spellcomp")]
        public List<string> Spellcomp { get; set; }
        [XmlElement(ElementName = "spellschool")]
        public string Spellschool { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "level")]
        public string Level { get; set; }
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "casttime")]
        public string Casttime { get; set; }
        [XmlAttribute(AttributeName = "range")]
        public string Range { get; set; }
        [XmlAttribute(AttributeName = "target")]
        public string Target { get; set; }
        [XmlAttribute(AttributeName = "area")]
        public string Area { get; set; }
        [XmlAttribute(AttributeName = "effect")]
        public string Effect { get; set; }
        [XmlAttribute(AttributeName = "duration")]
        public string Duration { get; set; }
        [XmlAttribute(AttributeName = "save")]
        public string Save { get; set; }
        [XmlAttribute(AttributeName = "resist")]
        public string Resist { get; set; }
        [XmlAttribute(AttributeName = "dc")]
        public string Dc { get; set; }
        [XmlAttribute(AttributeName = "subschooltext")]
        public string Subschooltext { get; set; }
        [XmlAttribute(AttributeName = "descriptortext")]
        public string Descriptortext { get; set; }
        [XmlAttribute(AttributeName = "savetext")]
        public string Savetext { get; set; }
        [XmlAttribute(AttributeName = "resisttext")]
        public string Resisttext { get; set; }
        [XmlAttribute(AttributeName = "castsleft")]
        public string Castsleft { get; set; }
        [XmlAttribute(AttributeName = "casterlevel")]
        public string Casterlevel { get; set; }
        [XmlAttribute(AttributeName = "componenttext")]
        public string Componenttext { get; set; }
        [XmlAttribute(AttributeName = "schooltext")]
        public string Schooltext { get; set; }
        [XmlAttribute(AttributeName = "unlimited")]
        public string Unlimited { get; set; }
        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }
        [XmlElement(ElementName = "spellsubschool")]
        public string Spellsubschool { get; set; }
        [XmlElement(ElementName = "spelldescript")]
        public List<string> Spelldescript { get; set; }
    }

    [XmlRoot(ElementName = "cantrips")]
    public class Cantrips
    {
        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }
    }

    [XmlRoot(ElementName = "spellsknown")]
    public class Spellsknown
    {
        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }
    }

    [XmlRoot(ElementName = "spellsmemorized")]
    public class Spellsmemorized
    {
        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }
    }

    [XmlRoot(ElementName = "spellbook")]
    public class Spellbook
    {
        [XmlElement(ElementName = "spell")]
        public List<Spell> Spell { get; set; }
    }

    [XmlRoot(ElementName = "spellclass")]
    public class Spellclass
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "spells")]
        public string Spells { get; set; }
        [XmlAttribute(AttributeName = "maxspelllevel")]
        public string Maxspelllevel { get; set; }
        [XmlAttribute(AttributeName = "cantripcount")]
        public string Cantripcount { get; set; }
        [XmlAttribute(AttributeName = "spellcount")]
        public string Spellcount { get; set; }
    }

    [XmlRoot(ElementName = "spellclasses")]
    public class Spellclasses
    {
        [XmlElement(ElementName = "spellclass")]
        public List<Spellclass> Spellclass { get; set; }
    }

    [XmlRoot(ElementName = "spellslot")]
    public class Spellslot
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
        [XmlAttribute(AttributeName = "used")]
        public string Used { get; set; }
    }

    [XmlRoot(ElementName = "spellslots")]
    public class Spellslots
    {
        [XmlElement(ElementName = "spellslot")]
        public List<Spellslot> Spellslot { get; set; }
    }

    [XmlRoot(ElementName = "spelllike")]
    public class Spelllike
    {
        [XmlElement(ElementName = "special")]
        public List<Special> Special { get; set; }
    }

    [XmlRoot(ElementName = "racespells")]
    public class Racespells
    {
        [XmlElement(ElementName = "spellability")]
        public List<Spell> Spell { get; set; }
    }

    #endregion

    #region Items

    [XmlRoot(ElementName = "itempower")]
    public class Itempower
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "pricebonusvalue")]
        public string Pricebonusvalue { get; set; }
        [XmlAttribute(AttributeName = "pricebonustext")]
        public string Pricebonustext { get; set; }
        [XmlAttribute(AttributeName = "pricecashvalue")]
        public string Pricecashvalue { get; set; }
        [XmlAttribute(AttributeName = "pricecashtext")]
        public string Pricecashtext { get; set; }
    }
 
    [XmlRoot(ElementName = "item")]
    public class Item
    {
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
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }
        [XmlAttribute(AttributeName = "isproficient")]
        public string Isproficient { get; set; }
        [XmlAttribute(AttributeName = "isattuned")]
        public string Isattuned { get; set; }
        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }
        [XmlElement(ElementName = "itempower")]
        public Itempower Itempower { get; set; }
        [XmlElement(ElementName = "itemslot")]
        public string Itemslot { get; set; }
    }

    [XmlRoot(ElementName = "magicitems")]
    public class Magicitems
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "gear")]
    public class Gear
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "trackedresource")]
    public class Trackedresource
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "used")]
        public string Used { get; set; }
        [XmlAttribute(AttributeName = "left")]
        public string Left { get; set; }
        [XmlAttribute(AttributeName = "min")]
        public string Min { get; set; }
        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }
    }

    [XmlRoot(ElementName = "trackedresources")]
    public class Trackedresources
    {
        [XmlElement(ElementName = "trackedresource")]
        public List<Trackedresource> Trackedresource { get; set; }
    }

    #endregion

    #region Health

    [XmlRoot(ElementName = "hitdice")]
    public class Hitdice
    {
        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "count")]
        public string Count { get; set; }
        [XmlAttribute(AttributeName = "dietype")]
        public string Dietype { get; set; }
    }

    [XmlRoot(ElementName = "health")]
    public class Health
    {
        [XmlElement(ElementName = "special")]
        public Special Special { get; set; }
        [XmlElement(ElementName = "hitdice")]
        public List<Hitdice> Hitdice { get; set; }
        [XmlAttribute(AttributeName = "hitdice")]
        public string _Hitdice { get; set; }
        [XmlAttribute(AttributeName = "hitpoints")]
        public string Hitpoints { get; set; }
        [XmlAttribute(AttributeName = "damage")]
        public string Damage { get; set; }
        [XmlAttribute(AttributeName = "nonlethal")]
        public string Nonlethal { get; set; }
        [XmlAttribute(AttributeName = "currenthp")]
        public string Currenthp { get; set; }
    }
    
    #endregion

    #region Minions

    [XmlRoot(ElementName = "minions")]
    public class Minions
    {
        [XmlElement(ElementName = "character")]
        public List<HeroLabCharacter> Character { get; set; }
    }
    
    [XmlRoot(ElementName = "animaltrick")]
    public class Animaltrick
    {
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "useradded")]
        public string Useradded { get; set; }
    }

    [XmlRoot(ElementName = "animaltricks")]
    public class Animaltricks
    {
        [XmlElement(ElementName = "animaltrick")]
        public List<Animaltrick> Animaltrick { get; set; }
    }

    #endregion

    #region Character Common Class

    [XmlRoot(ElementName = "character")]
    public partial class HeroLabCharacter
    {
        [XmlElement(ElementName = "race")]
        public Race Race { get; set; }
        [XmlElement(ElementName = "alignment")]
        public Alignment Alignment { get; set; }
        [XmlElement(ElementName = "templates")]
        public Templates Templates { get; set; }
        [XmlElement(ElementName = "size")]
        public Size Size { get; set; }
        [XmlElement(ElementName = "deity")]
        public Deity Deity { get; set; }
        [XmlElement(ElementName = "challengerating")]
        public Challengerating Challengerating { get; set; }
        [XmlElement(ElementName = "xpaward")]
        public Xpaward Xpaward { get; set; }
        [XmlElement(ElementName = "classes")]
        public Classes Classes { get; set; }
        [XmlElement(ElementName = "factions")]
        public Factions Factions { get; set; }
        [XmlElement(ElementName = "types")]
        public Types Types { get; set; }
        [XmlElement(ElementName = "senses")]
        public Senses Senses { get; set; }
        [XmlElement(ElementName = "auras")]
        public Auras Auras { get; set; }
        [XmlElement(ElementName = "health")]
        public Health Health { get; set; }
        [XmlElement(ElementName = "xp")]
        public Xp Xp { get; set; }
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
        [XmlElement(ElementName = "initiative")]
        public Initiative Initiative { get; set; }
        [XmlElement(ElementName = "movement")]
        public Movement Movement { get; set; }
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
        [XmlElement(ElementName = "melee")]
        public Melee Melee { get; set; }
        [XmlElement(ElementName = "ranged")]
        public Ranged Ranged { get; set; }
        [XmlElement(ElementName = "defenses")]
        public Defenses Defenses { get; set; }
        [XmlElement(ElementName = "magicitems")]
        public Magicitems Magicitems { get; set; }
        [XmlElement(ElementName = "gear")]
        public Gear Gear { get; set; }
        [XmlElement(ElementName = "spelllike")]
        public Spelllike Spelllike { get; set; }
        [XmlElement(ElementName = "trackedresources")]
        public Trackedresources Trackedresources { get; set; }
        [XmlElement(ElementName = "otherspecials")]
        public Otherspecials Otherspecials { get; set; }
        [XmlElement(ElementName = "spellsknown")]
        public Spellsknown Spellsknown { get; set; }
        [XmlElement(ElementName = "spellsmemorized")]
        public Spellsmemorized Spellsmemorized { get; set; }
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
        [XmlAttribute(AttributeName = "active")]
        public string Active { get; set; }
        [XmlAttribute(AttributeName = "characterindex")]
        public string Characterindex { get; set; }
        [XmlAttribute(AttributeName = "nature")]
        public string Nature { get; set; }
        [XmlAttribute(AttributeName = "role")]
        public string Role { get; set; }
        [XmlAttribute(AttributeName = "relationship")]
        public string Relationship { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "playername")]
        public string Playername { get; set; }

        public string getCharacterName()
        {
            StringBuilder sb = new StringBuilder();
            if (Name != null) { sb.Append(Name); }
            return sb.ToString().Trim();
        }

        public List<string> getCharacterType()
        {
            List<string> result = new List<string>();
            if ((Types != null) && (Types.Type != null) && (Types.Type.Count > 0))
            {
                foreach (Type typ in Types.Type)
                {
                    result.Add(typ.Name);
                }
            }
            return result;
        }

        public string getCharacterAlignment()
        {
            StringBuilder sb = new StringBuilder();
            if (Alignment != null) { sb.Append(Alignment.Name);}
            return sb.ToString().Trim();
        }

        public string getArmorClass()
        {
            StringBuilder sb = new StringBuilder();
            if (Armorclass != null) { sb.Append(Armorclass.Ac);}
            return sb.ToString().Trim();
        }

        public string getHitPoints()
        {
            StringBuilder sb = new StringBuilder();
            if (Health != null) { sb.Append(Health.Hitpoints);}
            return sb.ToString().Trim();
        }

        public string getHitDice()
        {
            StringBuilder sb = new StringBuilder();
            if (Health != null){ sb.Append(Health._Hitdice); }
            return sb.ToString().Trim();
        }

        public string getSpeed()
        {
            StringBuilder sb = new StringBuilder();
            if (Movement != null) { sb.Append(Movement.Speed); }
            return sb.ToString().Trim();
        }

        public bool is5e()
        {
            return Abilityscores != null && Abilityscores.Abilityscore != null && Abilityscores.Abilityscore.Count > 0;
        }

        public bool isPathfinder()
        {
            return !is5e();
        }

        private string getAbilityScore(string ability)
        {
            StringBuilder sb = new StringBuilder();
            if (is5e())
            {
                if (Abilityscores != null && Abilityscores.Abilityscore != null && Abilityscores.Abilityscore.Count > 0)
                {
                    foreach (Abilityscore ab in Abilityscores.Abilityscore)
                    {
                        if (ab.Name.Equals(ability)){ sb.Append(ab.Abilvalue.Text); }
                    }
                }
            }
            else
            {
                if (Attributes != null && Attributes.Attribute != null && Attributes.Attribute.Count > 0)
                {
                    foreach (Attribute ab in Attributes.Attribute)
                    {
                        if (ab.Name.Equals(ability)) { sb.Append(ab.Attrvalue.Text); }
                    }
                }
            }
            return sb.ToString().Trim();
        }

        private string getAbilityBonus(string ability)
        {
            StringBuilder sb = new StringBuilder();
            if (is5e())
            {
                foreach (Abilityscore ab in Abilityscores.Abilityscore)
                {
                    if (ab.Name.Equals(ability)) { sb.Append(ab.Abilbonus.Text); }
                }
            }
            else
            {
                foreach (Attribute ab in Attributes.Attribute)
                {
                    if (ab.Name.Equals(ability)) { sb.Append(ab.Attrbonus.Text); }
                }
            }
            return sb.ToString().Trim();
        }

        public string getSTR()
        {
            return getAbilityScore("Strength");
        }

        public string getDEX()
        {
            return getAbilityScore("Dexterity");
        }

        public string getCON()
        {
            return getAbilityScore("Constitution");
        }

        public string getINT()
        {
            return getAbilityScore("Intelligence");
        }

        public string getWIS()
        {
            return getAbilityScore("Wisdom");
        }

        public string getCHA()
        {
            return getAbilityScore("Charisma");
        }

        public string getSTRBonus()
        {
            return getAbilityBonus("Strength");
        }

        public string getDEXBonus()
        {
            return getAbilityBonus("Dexterity");
        }

        public string getCONBonus()
        {
            return getAbilityBonus("Constitution");
        }

        public string getINTBonus()
        {
            return getAbilityBonus("Intelligence");
        }

        public string getWISBonus()
        {
            return getAbilityBonus("Wisdom");
        }

        public string getCHABonus()
        {
            return getAbilityBonus("Charisma");
        }

        public List<string> getImmunities()
        {
            List<string> result = new List<string>();
            if (is5e())
            {
                if (Damageimmunities != null) {
                    string[] arr = Damageimmunities.Text.Split(',');
                    result.AddRange(arr.ToList<string>());
                }
                if (Conditionimmunities != null) {
                    string[] arr = Conditionimmunities.Text.Split(',');
                    result.AddRange(arr.ToList<string>());
                }
            }
            else
            {
                if (Immunities != null && Immunities.Special != null && Immunities.Special.Count > 0)
                {
                    foreach (Special sp in Immunities.Special)
                    {
                        result.Add(sp.Shortname);
                    }
                }
            }
            return result;
        }

        public List<string> getResistances()
        {
            List<string> result = new List<string>();
            if (is5e())
            {
                if (Damageresistances != null) {
                    string[] arr = Damageresistances.Text.Split(',');
                    result.AddRange(arr.ToList<string>());
                };
            }
            else
            {
                if (Damagereduction != null && Damagereduction.Special != null && Damagereduction.Special.Count > 0)
                {
                    foreach (Special sp in Damagereduction.Special)
                    {
                        result.Add(sp.Shortname);
                    }
                }
                if (Resistances != null && Resistances.Special != null && Resistances.Special.Count > 0)
                {
                    foreach (Special sp in Resistances.Special)
                    {
                        result.Add(sp.Shortname);
                    }
                }
            }
            return result;
        }

        public List<string> getWeaknesses()
        {
            List<string> result = new List<string>();
            if (is5e())
            {
                if (Damagevulnerabilities != null) {
                    string[] arr = Damageresistances.Text.Split(',');
                    result.AddRange(arr.ToList<string>());
                }
            }
            else
            {
                if (Weaknesses != null && Weaknesses.Special != null && Weaknesses.Special.Count > 0)
                {
                    foreach (Special sp in Weaknesses.Special)
                    {
                        result.Add(sp.Shortname);
                    }
                }
            }
            return result;
        }

        public List<string> getSenses()
        {
            List<string> result = new List<string>();
            if (Senses != null && Senses.Special != null && Senses.Special.Count > 0)
            {
                foreach (Special sp in Senses.Special)
                {
                    result.Add(sp.Name);
                }
            }
            return result;
        }

        public List<string> getAuras()
        {
            List<string> result = new List<string>();
            if (Auras != null && Auras.Special != null && Auras.Special.Count > 0)
            {
                foreach (Special sp in Auras.Special)
                {
                    result.Add(sp.Name);
                }
            }
            return result;
        }

        public List<string> getLanguages()
        {
            List<string> result = new List<string>();
            if (Languages != null && Languages.Language != null && Languages.Language.Count > 0)
            {
                foreach (Language ln in Languages.Language)
                {
                    result.Add(ln.Name);
                }
            }
            return result;
        }

        public string getCR()
        {
            StringBuilder sb = new StringBuilder();
            if (Challengerating != null) { sb.Append(Challengerating.Value); }
            return sb.ToString();
        }

        public string getXPAward()
        {
            StringBuilder sb = new StringBuilder();
            if (Xpaward != null) { sb.Append(Xpaward.Value); }
            return sb.ToString();
        }

        
        public Dictionary<string, string> getSpecial()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (Otherspecials != null && Otherspecials.Special != null && Otherspecials.Special.Count > 0)
            {
                foreach (Special sp in Otherspecials.Special)
                {
                    result.Add(sp.Shortname, sp.Description);
                }
            }
            if (Attack != null && Attack.Special != null && Attack.Special.Count > 0)
            {
                foreach (Special sp in Otherspecials.Special)
                {
                    result.Add(sp.Shortname, sp.Description);
                }
            }
            if (Spelllike != null && Spelllike.Special != null && Spelllike.Special.Count > 0)
            {
                foreach (Special sp in Otherspecials.Special)
                {
                    result.Add(sp.Shortname, sp.Description);
                }
            }
            
            return result;
        }

        public Dictionary<string, string> getFeats()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (Feats != null && Feats.Feat != null && Feats.Feat.Count > 0)
            {
                foreach (Feat sp in Feats.Feat)
                {
                    result.Add(sp.Name, sp.Description);
                }
            }
            return result;
        }

        public Dictionary<string, string> getTraits()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (Traits != null && Traits.Trait != null && Traits.Trait.Count > 0)
            {
                foreach (Trait sp in Traits.Trait)
                {
                    result.Add(sp.Name, sp.Description);
                }
            }
            return result;
        }

        public Dictionary<string, string> getSkills()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (Skills != null && Skills.Skill != null && Skills.Skill.Count > 0)
            {
                foreach (Skill sp in Skills.Skill)
                {
                    string bonus;
                    if (is5e())
                    {
                        bonus = sp.Abilbonus;
                    }
                    else
                    {
                        bonus = sp.Attrbonus;
                    }
                    if (sp.Isproficient.Equals("yes") || !sp.Ranks.Equals("0"))
                    {
                        result.Add(sp.Name, bonus);
                    }
                }
            }
            return result;
        }

        public Dictionary<string, string> getSaves()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (is5e())
            {
                if (Abilityscores != null && Abilityscores.Abilityscore != null && Abilityscores.Abilityscore.Count > 0)
                {
                    foreach (Abilityscore ab in Abilityscores.Abilityscore)
                    {
                        if (ab.Savingthrow.Isproficient.Equals("yes"))
                        {
                            result.Add(ab.Name, ab.Savingthrow.Text);
                        }
                    }
                }
            }
            else
            {
                if (Saves != null && Saves.Save != null && Saves.Save.Count > 0)
                {
                    foreach (Save sv in Saves.Save)
                    {
                        result.Add(sv.Name, sv._save);
                    }
                }
            }
            return result;
        }

        public List<Weapon> getWeapons()
        {
            List<Weapon> result = new List<Weapon>();
            if (Melee != null && Melee.Weapon != null && Melee.Weapon.Count > 0)
            {
                result.AddRange(Melee.Weapon);
            }
            if (Ranged != null && Ranged.Weapon != null && Ranged.Weapon.Count > 0)
            {
                result.AddRange(Ranged.Weapon);
            }
            return result;
        }

        public List<Spell> getSpells()
        {
            List<Spell> result = new List<Spell>();
            if (Spellsknown != null && Spellsknown.Spell != null && Spellsknown.Spell.Count > 0)
            {
                result.AddRange(Spellsknown.Spell);
            }
            if (Racespells != null && Racespells.Spell != null && Racespells.Spell.Count > 0)
            {
                result.AddRange(Racespells.Spell);
            }
            return result;
        }
    }

    #endregion

}
