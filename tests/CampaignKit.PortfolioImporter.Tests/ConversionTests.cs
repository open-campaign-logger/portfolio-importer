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
using CampaignKit.PortfolioImporter.Entities;
using CampaignKit.PortfolioImporter.Entities.HeroLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Compression;
using System.Reflection;

namespace CampaignKit.PortfolioImporter.Tests
{
	/// <summary>
	///     Class StringExtensionsTest.
	/// </summary>
	[TestClass]
    public class ConversionTests
    {
		#region Methods

		/// <summary>
		///     Tests the dasherization of a string.
		/// </summary>
		[TestMethod]
        public void TestPortfolioFileParsing()
		{
			var assembly = typeof(ConversionTests).GetTypeInfo().Assembly;
			string[] entries = assembly.GetManifestResourceNames();

			foreach (string entry in entries)
			{
				if (entry.EndsWith(".por"))
				{
					using (var resourceStream = assembly.GetManifestResourceStream(entry))
					{
						using (ZipArchive archive = new ZipArchive(resourceStream))
						{

							HeroLabPortfolio por = new HeroLabPortfolio(archive);
							Assert.IsTrue(por.Characters.Count > 0);

						}
					}
				}
			}
		}
		
		#endregion
	}
}