using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    #region HeroLab Portfolio Class

    /// <inheritdoc />
    /// <summary>
    ///     Class HeroLabPortfolio.
    /// </summary>
    /// <seealso cref="T:CampaignKit.PortfolioImporter.Entities.Portfolio" />
    public class HeroLabPortfolio : Portfolio
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HeroLabPortfolio" /> class.
        /// </summary>
        /// <param name="porFile">The por file.</param>
        public HeroLabPortfolio(ZipArchive porFile)
        {
            // Retrieve the entry for the main portfolio index
            var indexFile = porFile.GetEntry("index.xml");

            // Initialize the list of deserialized characters
            Characters = new List<Character>();

            if (indexFile == null)
                return;

            // Open the main portfolio index for reading
            using (var indexStream = indexFile.Open())
            {
                // Deserialize the portfolio root document
                var serializer = new XmlSerializer(typeof(HeroLabPortfolioRootDocument));
                RootDocument = (HeroLabPortfolioRootDocument) serializer.Deserialize(indexStream);

                // Process each of the character summaries found in the portfolio
                foreach (var summary in RootDocument.CharacterSummaries.CharacterSummary)
                {
                    // set the character name
                    var name = summary.Name;

                    var text = string.Empty;
                    var xml = string.Empty;
                    var html = string.Empty;

                    // Cycle through the statbock and retrieve the text, html and html data.
                    foreach (var statblock in summary.Statblocks.Statblock)
                    {
                        // Load the file referenced in the statblock
                        var entry = porFile.GetEntry(statblock.Folder + "/" + statblock.Filename);
                        var fileContents = string.Empty;
                        if (entry != null)
                            using (var entryReader = new StreamReader(entry.Open()))
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
                    }

                    var character = new HeroLabCharacter
                    {
                        Game = RootDocument.Game.Name,
                        Text = text,
                        Xml = xml,
                        Html = html,
                        Name = name
                    };

                    Characters.Add(character);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the root document.
        /// </summary>
        /// <value>The root document.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        public HeroLabPortfolioRootDocument RootDocument { get; set; }

        #endregion
    }

    #endregion
}