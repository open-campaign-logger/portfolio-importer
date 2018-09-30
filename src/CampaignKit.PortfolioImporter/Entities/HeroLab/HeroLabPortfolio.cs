using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
	#region Class Structures for XML

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
    public class HeroLabPortfolioRootDocument
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

	#endregion

	#region HeroLab Portfolio Class

	public class HeroLabPortfolio : Portfolio
	{

		public HeroLabPortfolioRootDocument rootDocument { get; set; }

		public HeroLabPortfolio(ZipArchive porFile)
		{
			// Retrieve the entry for the main portfolio index
			ZipArchiveEntry indexFile = porFile.GetEntry("index.xml");

			// Initialize the list of deserialized characters
			Characters = new List<Character>();

			// Open the main portfolio index for reading
			using (Stream indexStream = indexFile.Open())
			{
				// Deserialize the portfolio root document
				XmlSerializer serializer = new XmlSerializer(typeof(HeroLabPortfolioRootDocument));
				rootDocument = (HeroLabPortfolioRootDocument)serializer.Deserialize(indexStream);

				// Process each of the character summaries found in the portfolio
				foreach (CharacterSummary summary in rootDocument.CharacterSummaries.CharacterSummary)
				{

					string text = string.Empty;
					string xml = string.Empty;
					string html = string.Empty;
					string fileContents = string.Empty;

					// Cycle through the statbock and retrieve the text, html and html data.
					foreach (Statblock statblock in summary.Statblocks.Statblock)
					{

						// Load the file referenced in the statblock
						ZipArchiveEntry entry = porFile.GetEntry(statblock.Folder + "/" + statblock.Filename);
						using (StreamReader entryReader = new StreamReader(entry.Open()))
						{
							fileContents = entryReader.ReadToEnd();
						}

						// Update the character object
						switch (statblock.Format)
						{
							case "text":
								text = fileContents;
								break;
							case "xml":
								xml = fileContents;
								break;
							case "html":
								html = fileContents;
								break;
						}

					};

					HeroLabCharacter character = new HeroLabCharacter()
					{
						Game = rootDocument.Game.Name,
						Text = text,
						Xml = xml,
						Html = html
					};
					Characters.Add(character);

				}
			}
		}
	}

	#endregion

}
