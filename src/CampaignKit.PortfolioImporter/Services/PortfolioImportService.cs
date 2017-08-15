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

using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.XPath;

using CampaignKit.PortfolioImporter.Entities;

namespace CampaignKit.PortfolioImporter.Services
{
    /// <summary>
    ///     Interface IPortfolioImportService
    /// </summary>
    public interface IPortfolioImportService
    {
        #region Methods

        /// <summary>
        ///     Imports the portfolio.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>IEnumerable&lt;Character&gt;.</returns>
        IEnumerable<Character> ImportPortfolio(Stream stream);

        #endregion
    }

    /// <summary>
    ///     Class DefaultPortfolioImportService.
    /// </summary>
    /// <seealso cref="IPortfolioImportService" />
    public class DefaultPortfolioImportService : IPortfolioImportService
    {
        #region Implementations

        /// <summary>
        ///     Imports the portfolio.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>IEnumerable&lt;Character&gt;.</returns>
        public IEnumerable<Character> ImportPortfolio(Stream stream)
        {
            using (var archive = new ZipArchive(stream))
            {
                var index = archive.GetEntry("index.xml");
                using (var indexStream = index.Open())
                {
                    var indexDocument = new XPathDocument(indexStream);
                    var navigator = indexDocument.CreateNavigator();
                    var characters = navigator.Select("/document/characters/character");
                    foreach (XPathNavigator character in characters)
                    {
                        var name = character.GetAttribute("name", "");
                        var text = default(string);
                        var html = default(string);
                        var xml = default(string);

                        var statblocks = character.Select("./statblocks/statblock");
                        foreach (XPathNavigator statblock in statblocks)
                        {
                            var format = statblock.GetAttribute("format", "");
                            var folder = statblock.GetAttribute("folder", "");
                            var filename = statblock.GetAttribute("filename", "");

                            var content = archive.GetEntry($"{folder}/{filename}");
                            using (var contentStream = content.Open())
                            using (var contentReader = new StreamReader(contentStream))
                            {
                                switch (format)
                                {
                                    case "text":
                                        text = contentReader.ReadToEnd();
                                        break;

                                    case "html":
                                        html = contentReader.ReadToEnd();
                                        break;

                                    case "xml":
                                        xml = contentReader.ReadToEnd();
                                        break;
                                }
                            }
                        }

                        yield return new Character { Name = name, Text = text, Html = html, Xml = xml };
                    }
                }
            }
        }

        #endregion
    }
}