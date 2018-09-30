using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    [XmlRoot(ElementName = "creature-heading")]
    public class Creatureheading
    {
        public Creatureheading()
        {
        }

        public Creatureheading(string name, List<string> types, string align)
        {

            H1 = name;
            H2 =  string.Join(" ", types.ToArray()) + ", " + align;

        }

        [XmlElement(ElementName = "h1")]
        public string H1 { get; set; }
        [XmlElement(ElementName = "h2")]
        public string H2 { get; set; }
    }

    [XmlRoot(ElementName = "property-line")]
    public class Propertyline
    {
        public Propertyline()
        {
        }

        public Propertyline(string title, string description)
        {
            H4 = title;
            P = description;
        }

        [XmlElement(ElementName = "h4")]
        public string H4 { get; set; }
        [XmlElement(ElementName = "p")]
        public string P { get; set; }
    }

    [XmlRoot(ElementName = "abilities-block")]
    public class Abilitiesblock
    {
        public Abilitiesblock()
        {
        }

        public Abilitiesblock(string strength, string strengthBonus,
            string dexterity, string dexterityBonus,
            string constitution, string constitutionBonus,
            string intelligence, string intelligenceBonus,
            string wisdom, string wisdomBonus,
            string charisma, string charismaBonus)
        {
            Datastr = strength + " (" + strengthBonus + ")";
            Datadex = dexterity + " (" + dexterityBonus + ")";
            Datacon = constitution + " (" + constitutionBonus + ")";
            Dataint = intelligence + " (" + intelligenceBonus + ")";
            Datawis = wisdom + " (" + wisdomBonus + ")";
            Datacha = charisma + " (" + charismaBonus + ")";
        }

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
        public Topstats()
        {
        }

        public Topstats(string ac, string hp, string speed)
        {
            this.Propertyline = new List<Propertyline>();
            this.Propertyline.Add(new Propertyline("Armor Class", ac));
            this.Propertyline.Add(new Propertyline("Hit Points", ac));
            this.Propertyline.Add(new Propertyline("Speed", ac));
            this.Abilitiesblock = new Abilitiesblock();
        }

        [XmlElement(ElementName = "property-line")]
        public List<Propertyline> Propertyline { get; set; }
        [XmlElement(ElementName = "abilities-block")]
        public Abilitiesblock Abilitiesblock { get; set; }
    }
    
    [XmlRoot(ElementName = "property-block")]
    public class Propertyblock
    {
        public Propertyblock()
        {
        }

        public Propertyblock(string title, string description)
        {
            H4 = title;
            P = description;
        }

        [XmlElement(ElementName = "h4")]
        public string H4 { get; set; }
        [XmlElement(ElementName = "p")]
        public string P { get; set; }
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
            string val;

            // Creature Heading
            this.Creatureheading 
                = new Creatureheading(character.getCharacterName(),
                    character.getCharacterType(),
                    character.getCharacterAlignment());

            // Top Stats
            this.Topstats 
                = new Topstats(character.getArmorClass(), 
                    character.getHitPoints() + " (" + character.getHitDice() + ")",
                    character.getAlignment());

            // Abilities
            this.Topstats.Abilitiesblock
                = new Abilitiesblock(character.getSTR(), character.getSTRBonus(),
                    character.getDEX(), character.getDEXBonus(),
                    character.getCON(), character.getCONBonus(),
                    character.getINT(), character.getINTBonus(),
                    character.getWIS(), character.getWISBonus(),
                    character.getCHA(), character.getCHABonus());
            
            // Immunities
            val = string.Join(", ", character.getImmunities().ToArray()).Trim();
            if (!string.IsNullOrEmpty(val)) { this.Topstats.Propertyline.Add(new Propertyline("Immunities", val)); }

            // Resistances
            val = string.Join(", ", character.getResistances().ToArray()).Trim();
            if (!string.IsNullOrEmpty(val)) { this.Topstats.Propertyline.Add(new Propertyline("Resistances", val)); }

            // Weaknesses
            val = string.Join(", ", character.getWeaknesses().ToArray()).Trim();
            if (!string.IsNullOrEmpty(val)) { this.Topstats.Propertyline.Add(new Propertyline("Weaknesses", val)); }

            // Saves
            List<string> saves = new List<string>();
            foreach (string key in character.getSaves().Keys)
            {
                character.getSaves().TryGetValue(key, out val);
                saves.Add(key + " (" + val + ")");
            }
            val = string.Join(" ", saves.ToArray()).Trim();
            if (!string.IsNullOrEmpty(val)) { this.Topstats.Propertyline.Add(new Propertyline("Saves", val)); }
            
            // Senses
            val = string.Join(", ", character.getSenses().ToArray()).Trim();
            if (!string.IsNullOrEmpty(val)) { this.Topstats.Propertyline.Add(new Propertyline("Senses", val)); }

            // Languages
            val = string.Join(", ", character.getLanguages().ToArray());
            if (!string.IsNullOrEmpty(val)) { this.Topstats.Propertyline.Add(new Propertyline("Languages", val));}

            // Challenge Rating
            if (!string.IsNullOrEmpty(character.getCR()))
            {
                this.Topstats.Propertyline.Add(new Propertyline("Challenge", character.getCR() + "(" + character.getXPAward() + ")"));
            }            

            // Actions
            this.H3 = "Actions";
            this.Propertyblock = new List<Propertyblock>();

            // Special
            foreach (string key in character.getSpecial().Keys)
            {
                character.getSpecial().TryGetValue(key, out val);                
                this.Propertyblock.Add(new Propertyblock(key, val));
            }

            // Weapons
            
            foreach (Weapon wp in character.getWeapons())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(wp.Name);
                sb.Append(": ");
                sb.Append(wp.Attack);
                sb.Append(" to hit, Hit: ");
                sb.Append(wp.Damage);

                this.Propertyblock.Add(new Propertyblock(wp.Name, sb.ToString()));

            }
                        
        }

    }

}

