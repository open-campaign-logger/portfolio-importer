using System.IO;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{

	public class HeroLabCharacter : FormattedCharacter
	{

		#region Character Properties

		private HeroLabCharacterRootDocument _rootDocument;

		public HeroLabCharacterRootDocument RootDocument
		{
			get
			{
				if (_rootDocument == null)
				{
					XmlSerializer serializer = new XmlSerializer(typeof(HeroLabCharacterRootDocument));
					using (TextReader reader = new StringReader(Xml))
					{
						_rootDocument = (HeroLabCharacterRootDocument)serializer.Deserialize(reader);
					}
				}
				return _rootDocument;
			}
		}

		public CharacterDetail DetailDocument
		{
			get
			{
				return RootDocument.Public.Character;
			}
		}

		#endregion

	}

}
