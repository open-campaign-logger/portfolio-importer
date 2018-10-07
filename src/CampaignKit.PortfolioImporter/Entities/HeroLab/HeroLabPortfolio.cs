using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
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
					// set the character name
					string name = summary.Name;

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
						Html = html,
						Name = name
					};

					Characters.Add(character);

				}
			}
		}
	}

	#endregion

}
