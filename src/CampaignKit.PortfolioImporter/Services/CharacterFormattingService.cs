﻿// Copyright 2017 Jochen Linnemann
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

using CampaignKit.PortfolioImporter.Entities;

namespace CampaignKit.PortfolioImporter.Services
{
    #region Options

    /// <summary>
    ///     Used to specify which character formatting option to use.
    /// </summary>
    public enum FormatOptions
    {
        Default,
        StatBlock,
        StatBlockCompact,
        Text,
        Html,
        Xml
    }

    #endregion

    /// <summary>
    ///     Interface ICharacterFormattingService
    /// </summary>
    public interface ICharacterFormattingService
    {
        #region Methods

        /// <summary>
        /// Formats the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="options">The options.</param>
        /// <returns>FormattedCharacter.</returns>
        FormattedCharacter Format(Character character, FormatOptions options = FormatOptions.Default);

        #endregion
    }

    /// <inheritdoc />
    /// <summary>
    ///     Class DefaultCharacterFormattingService.
    /// </summary>
    /// <seealso cref="T:CampaignKit.PortfolioImporter.Services.ICharacterFormattingService" />
    public class DefaultCharacterFormattingService : ICharacterFormattingService
    {
        #region Implementations

        /// <summary>
        /// Formats the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="options">The options.</param>
        /// <returns>FormattedCharacter.</returns>
        /// <inheritdoc />
        public FormattedCharacter Format(Character character, FormatOptions options = FormatOptions.Default)
        {
            if (character == null) return null;

            var formattedCharacter = new FormattedCharacter
            {
                Name = character.Name,
                Html = character.Html,
                Text = character.Text,
                Xml = character.Xml
            };

            switch (options)
            {
                case FormatOptions.Text:
                    formattedCharacter.FormattedText = character.Text;
                    break;
                case FormatOptions.Html:
                    formattedCharacter.FormattedText = character.Html;
                    break;
                case FormatOptions.Xml:
                    formattedCharacter.FormattedText = character.Xml;
                    break;
                default:
                    formattedCharacter.FormattedText = character.GetDefaultFormat();
                    break;
            }

            return formattedCharacter;
        }

        #endregion
    }
}