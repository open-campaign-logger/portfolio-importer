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
	///     Class FormattedCharacter.
	/// </summary>
	/// <seealso cref="Character" />
	public class FormattedCharacter : Character
    {
		
		#region Properties

		/// <summary>
		///     Gets or sets the formatted text.
		/// </summary>
		/// <value>The formatted text.</value>
		public string FormattedText { get; set; }

		public override string getCompactStatBlockFormat()
		{
			throw new System.NotImplementedException();
		}

		public override string getDefaultFormat()
		{
			throw new System.NotImplementedException();
		}

		public override string getStatBlockFormat()
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}