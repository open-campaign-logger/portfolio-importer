using System.IO;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{
    /// <inheritdoc />
    /// <summary>
    ///     Class HeroLabCharacter.
    /// </summary>
    /// <seealso cref="T:CampaignKit.PortfolioImporter.Entities.FormattedCharacter" />
    public class HeroLabCharacter : FormattedCharacter
    {
        #region Fields

        private HeroLabCharacterRootDocument _rootDocument;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the detail document.
        /// </summary>
        /// <value>The detail document.</value>
        // ReSharper disable once UnusedMember.Global
        public CharacterDetail DetailDocument => RootDocument.Public.Character;

        /// <summary>
        ///     Gets the root document.
        /// </summary>
        /// <value>The root document.</value>
        // ReSharper disable once MemberCanBePrivate.Global
        public HeroLabCharacterRootDocument RootDocument
        {
            get
            {
                if (_rootDocument != null)
                    return _rootDocument;

                var serializer = new XmlSerializer(typeof(HeroLabCharacterRootDocument));
                using (TextReader reader = new StringReader(Xml))
                {
                    _rootDocument = (HeroLabCharacterRootDocument) serializer.Deserialize(reader);
                }

                return _rootDocument;
            }
        }

        #endregion
    }
}