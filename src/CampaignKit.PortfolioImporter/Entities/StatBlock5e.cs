using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

namespace CampaignKit.PortfolioImporter.Entities
{
    /// <summary>
    ///     Class Creatureheading.
    /// </summary>
    [XmlRoot(ElementName = "creature-heading")]
    public class Creatureheading
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Creatureheading" /> class.
        /// </summary>
        public Creatureheading()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Creatureheading" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="types">The types.</param>
        /// <param name="align">The align.</param>
        public Creatureheading(string name, List<string> types, string align)
        {
            H1 = name;
            H2 = string.Join(" ", types.ToArray()) + ", " + align;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the h1.
        /// </summary>
        /// <value>The h1.</value>
        [XmlElement(ElementName = "h1")]
        public string H1 { get; set; }

        /// <summary>
        ///     Gets or sets the h2.
        /// </summary>
        /// <value>The h2.</value>
        [XmlElement(ElementName = "h2")]
        public string H2 { get; set; }

        #endregion
    }

    /// <summary>
    ///     Class Propertyline.
    /// </summary>
    [XmlRoot(ElementName = "property-line")]
    public class Propertyline
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Propertyline" /> class.
        /// </summary>
        public Propertyline()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Propertyline" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        public Propertyline(string title, string description)
        {
            H4 = title;
            P = description;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the h4.
        /// </summary>
        /// <value>The h4.</value>
        [XmlElement(ElementName = "h4")]
        public string H4 { get; set; }

        /// <summary>
        ///     Gets or sets the p.
        /// </summary>
        /// <value>The p.</value>
        [XmlElement(ElementName = "p")]
        public string P { get; set; }

        #endregion
    }

    /// <summary>
    ///     Class Abilitiesblock.
    /// </summary>
    [XmlRoot(ElementName = "abilities-block")]
    public class Abilitiesblock
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Abilitiesblock" /> class.
        /// </summary>
        public Abilitiesblock()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Abilitiesblock" /> class.
        /// </summary>
        /// <param name="strength">The strength.</param>
        /// <param name="strengthBonus">The strength bonus.</param>
        /// <param name="dexterity">The dexterity.</param>
        /// <param name="dexterityBonus">The dexterity bonus.</param>
        /// <param name="constitution">The constitution.</param>
        /// <param name="constitutionBonus">The constitution bonus.</param>
        /// <param name="intelligence">The intelligence.</param>
        /// <param name="intelligenceBonus">The intelligence bonus.</param>
        /// <param name="wisdom">The wisdom.</param>
        /// <param name="wisdomBonus">The wisdom bonus.</param>
        /// <param name="charisma">The charisma.</param>
        /// <param name="charismaBonus">The charisma bonus.</param>
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

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the datacha.
        /// </summary>
        /// <value>The datacha.</value>
        [XmlAttribute(AttributeName = "data-cha")]
        public string Datacha { get; set; }

        /// <summary>
        ///     Gets or sets the datacon.
        /// </summary>
        /// <value>The datacon.</value>
        [XmlAttribute(AttributeName = "data-con")]
        public string Datacon { get; set; }

        /// <summary>
        ///     Gets or sets the datadex.
        /// </summary>
        /// <value>The datadex.</value>
        [XmlAttribute(AttributeName = "data-dex")]
        public string Datadex { get; set; }

        /// <summary>
        ///     Gets or sets the dataint.
        /// </summary>
        /// <value>The dataint.</value>
        [XmlAttribute(AttributeName = "data-int")]
        public string Dataint { get; set; }

        /// <summary>
        ///     Gets or sets the datastr.
        /// </summary>
        /// <value>The datastr.</value>
        [XmlAttribute(AttributeName = "data-str")]
        public string Datastr { get; set; }

        /// <summary>
        ///     Gets or sets the datawis.
        /// </summary>
        /// <value>The datawis.</value>
        [XmlAttribute(AttributeName = "data-wis")]
        public string Datawis { get; set; }

        #endregion
    }

    /// <summary>
    ///     Class Topstats.
    /// </summary>
    [XmlRoot(ElementName = "top-stats")]
    public class Topstats
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Topstats" /> class.
        /// </summary>
        public Topstats()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Topstats" /> class.
        /// </summary>
        /// <param name="ac">The ac.</param>
        /// <param name="hp">The hp.</param>
        /// <param name="speed">The speed.</param>
        public Topstats(string ac, string hp, string speed)
        {
            Propertyline = new List<Propertyline>
            {
                new Propertyline("Armor Class", ac),
                new Propertyline("Hit Points", hp),
                new Propertyline("Speed", speed)
            };
            Abilitiesblock = new Abilitiesblock();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the propertyline.
        /// </summary>
        /// <value>The propertyline.</value>
        [XmlElement(ElementName = "property-line")]
        public List<Propertyline> Propertyline { get; set; }

        /// <summary>
        ///     Gets or sets the abilitiesblock.
        /// </summary>
        /// <value>The abilitiesblock.</value>
        [XmlElement(ElementName = "abilities-block")]
        public Abilitiesblock Abilitiesblock { get; set; }

        #endregion
    }

    /// <summary>
    ///     Class Propertyblock.
    /// </summary>
    [XmlRoot(ElementName = "property-block")]
    public class Propertyblock
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Propertyblock" /> class.
        /// </summary>
        public Propertyblock()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Propertyblock" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        public Propertyblock(string title, string description)
        {
            H4 = title;
            P = description;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the h4.
        /// </summary>
        /// <value>The h4.</value>
        [XmlElement(ElementName = "h4")]
        public string H4 { get; set; }

        /// <summary>
        ///     Gets or sets the p.
        /// </summary>
        /// <value>The p.</value>
        [XmlElement(ElementName = "p")]
        public string P { get; set; }

        #endregion
    }

    /// <summary>
    ///     XML Format used by https://github.com/Valloric/statblock5e
    /// </summary>
    [XmlRoot(ElementName = "stat-block")]
    public class Statblock5e
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the creatureheading.
        /// </summary>
        /// <value>The creatureheading.</value>
        [XmlElement(ElementName = "creature-heading")]
        public Creatureheading Creatureheading { get; set; }

        /// <summary>
        ///     Gets or sets the topstats.
        /// </summary>
        /// <value>The topstats.</value>
        [XmlElement(ElementName = "top-stats")]
        public Topstats Topstats { get; set; }

        /// <summary>
        ///     Gets or sets the propertyblock.
        /// </summary>
        /// <value>The propertyblock.</value>
        [XmlElement(ElementName = "property-block")]
        public List<Propertyblock> Propertyblock { get; set; }

        /// <summary>
        ///     Gets or sets the h3.
        /// </summary>
        /// <value>The h3.</value>
        [XmlElement(ElementName = "h3")]
        public string H3 { get; set; }

        #endregion
    }
}