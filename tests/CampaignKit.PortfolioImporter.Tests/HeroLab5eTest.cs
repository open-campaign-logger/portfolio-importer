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

using CampaignKit.PortfolioImporter.Entities.HeroLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Tests
{
	/// <summary>
	///     Class StringExtensionsTest.
	/// </summary>
	[TestClass]
    public class HeroLab5eTest
    {
		#region Methods

		/// <summary>
		///     Tests the dasherization of a string.
		/// </summary>
		[TestMethod]
        public void TestPORFileParsing()
		{

			string dataDir = "C:\\Users\\Cory\\source\\repos\\portfolio-importer\\data\\HeroLab5e";
			string[] testFiles = Directory.GetFiles(dataDir);
			NewMethod(testFiles);
		}

		private static void NewMethod(string[] testFiles)
		{
			foreach (string testFile in testFiles)
			{
				if (!testFile.EndsWith(".por"))
				{
					continue;
				}
				using (ZipArchive archive = ZipFile.OpenRead(testFile))
				{

					ZipArchiveEntry indexFile = archive.GetEntry("index.xml");
					List<ZipArchiveEntry> characters = new List<ZipArchiveEntry>();

					using (Stream indexStream = indexFile.Open())
					{

						HeroLabPortfolio por;

						XmlSerializer serializer = new XmlSerializer(typeof(HeroLabPortfolio));

						por = (HeroLabPortfolio)serializer.Deserialize(indexStream);

						foreach (CharacterSummary summary in por.CharacterSummaries.CharacterSummary)
						{

							foreach (Statblock block in summary.Statblocks.Statblock)
							{
								if (block.Format.Equals("xml"))
								{

									characters.Add(archive.GetEntry(block.Folder + "/" + block.Filename));
								}

							}

						}
					}

					foreach (ZipArchiveEntry character in characters)
					{

						using (Stream indexStream = character.Open())
						{

							Document hero;

							XmlSerializer serializer = new XmlSerializer(typeof(Document));

							System.Console.Out.WriteLine("Processing Entry: {0}/{1}", testFile, character.FullName);

							hero = (Document)serializer.Deserialize(indexStream);

							System.Console.Out.WriteLine("Processed Character: {0}", hero.Public.Character.Name);

							Statblock5e statblock = new Statblock5e(hero.Public.Character);

							serializer = new XmlSerializer(typeof(Statblock5e));
							StringWriter sw = new StringWriter();
							XmlTextWriter tw = new XmlTextWriter(sw);
							serializer.Serialize(tw, statblock);

							System.Console.Out.Write(sw.ToString());

						}
					}
				}
			}
		}

		#endregion
	}
}