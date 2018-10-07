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

namespace CampaignKit.PortfolioImporter.Entities
{
    /// <inheritdoc />
    /// <summary>
    ///     Class FormattedCharacter.
    /// </summary>
    /// <seealso cref="T:CampaignKit.PortfolioImporter.Entities.Character" />
    public class FormattedCharacter : Character
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the formatted text.
        /// </summary>
        /// <value>The formatted text.</value>
        public string FormattedText { get; set; }

        #endregion

        #region Methods

        #region Formatting Code

        /// <inheritdoc />
        /// <summary>
        ///     Return the character formatted in the system default format.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetDefaultFormat()
        {
            string[] ignoreList =
                { "<html", "<head", "<meta", "</head", "<body", "</body", "</html", "<p>Hero Lab", "System Reference Document", "Pathfinder®" };
            var sr = new StringReader(Html);
            var sb = new StringBuilder();

            while (true)
            {
                var nextLine = sr.ReadLine();

                if (nextLine != null)
                {
                    var ignoreLine = ignoreList.Any(s => nextLine.Contains(s));
                    if (ignoreLine)
                        continue;

                    nextLine = nextLine.Replace("&nbsp;", "\t");
                    nextLine = nextLine.Replace("<b><i>", "{bi|");
                    nextLine = nextLine.Replace("<b>", "{b|");
                    nextLine = nextLine.Replace("<i>", "{i|");
                    nextLine = nextLine.Replace("<sup>", "{/|");
                    nextLine = nextLine.Replace("<br/>", "");
                    nextLine = nextLine.Replace("<hr/>", "---\r\n");
                    nextLine = nextLine.Replace("</b></i>", "}");
                    nextLine = nextLine.Replace("</b>", "}");
                    nextLine = nextLine.Replace("</i>", "}");
                    nextLine = nextLine.Replace("</sup>", "}");

                    if (!string.IsNullOrWhiteSpace(nextLine))
                        sb.AppendLine(nextLine);
                }
                else
                {
                    break;
                }
            }

            return sb.ToString();
        }

        #endregion

        #endregion
    }
}