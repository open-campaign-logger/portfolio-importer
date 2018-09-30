// Copyright 2017 Jochen Linnemann
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using System.Linq;
using System.Text;
using System.Xml.XPath;

using CampaignKit.PortfolioImporter.Entities;
using CampaignKit.PortfolioImporter.Entities.HeroLab;
using CampaignKit.PortfolioImporter.Extensions;

namespace CampaignKit.PortfolioImporter.Services
{

	#region Options

	/// <summary>
	/// Used to specify which character formatting option to use.
	/// </summary>
	public enum FormatOptions
	{
		Default,
		StatBlock,
		StatBlockCompact,
		Text,
		HTML,
		XML
	}

	#endregion

	/// <summary>
	///     Interface ICharacterFormattingService
	/// </summary>
	public interface ICharacterFormattingService
    {

		#region Methods

		/// <summary>
		///     Formats the specified character.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>FormattedCharacter.</returns>
		FormattedCharacter Format(Character character, FormatOptions options = FormatOptions.Default);

        #endregion
    }

    /// <summary>
    ///     Class DefaultCharacterFormattingService.
    /// </summary>
    /// <seealso cref="ICharacterFormattingService" />
    public class DefaultCharacterFormattingService : ICharacterFormattingService
    {
		#region Implementations

		/// <summary>
		///     Formats the specified character.
		/// </summary>
		/// <param name="character">The character.</param>
		/// <returns>FormattedCharacter.</returns>
		public FormattedCharacter Format(Character character, FormatOptions option = FormatOptions.Default)
		{
			if (character == null) return null;

			FormattedCharacter formattedCharacter = new FormattedCharacter()
			{
				Name = character.Name,
				Html = character.Html,
				Text = character.Text,
				Xml = character.Xml
			};

            switch (option)
            {
                case FormatOptions.StatBlock:
					formattedCharacter.FormattedText = character.getStatBlockFormat();
					break;
				case FormatOptions.StatBlockCompact:
					formattedCharacter.FormattedText =  character.getCompactStatBlockFormat();
					break;
				case FormatOptions.Text:
					formattedCharacter.FormattedText = character.Text;
					break;
				case FormatOptions.HTML:
					formattedCharacter.FormattedText = character.Html;
					break;
				case FormatOptions.XML:
					formattedCharacter.FormattedText =  character.Xml;
					break;
				default:
					formattedCharacter.FormattedText = character.getDefaultFormat();
					break;
            }

			return formattedCharacter;

        }

        #endregion

    }
}