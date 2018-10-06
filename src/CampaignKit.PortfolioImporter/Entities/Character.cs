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


namespace CampaignKit.PortfolioImporter.Entities
{
	/// <summary>
	///     Class Character.
	/// </summary>
	public abstract class Character
    {

        #region Properties

        /// <summary>
        ///     Gets or sets the HTML.
        /// </summary>
        /// <value>The HTML.</value>
        public string Html { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the XML.
        /// </summary>
        /// <value>The XML.</value>
        public string Xml { get; set; }

		/// <summary>
		///		Gets or sets the game system
		/// </summary>
        public string Game { get; set; }

		#endregion

		#region Abstract Members

		/// <summary>
		/// Return the character formatted in the system default format.
		/// </summary>
		/// <returns></returns>
		public abstract string getDefaultFormat();

		#endregion

	}
}