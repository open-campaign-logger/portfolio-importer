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

using CampaignKit.PortfolioImporter.Entities;
using CampaignKit.PortfolioImporter.Entities.HeroLab;

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

        /// <inheritdoc />
        /// <summary>
        ///     Imports the portfolio.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>IEnumerable&lt;Character&gt;.</returns>
        public IEnumerable<Character> ImportPortfolio(Stream stream)
        {
            using (var archive = new ZipArchive(stream))
            {
                var por = new HeroLabPortfolio(archive);
                return por.Characters;
            }
        }

        #endregion
    }
}