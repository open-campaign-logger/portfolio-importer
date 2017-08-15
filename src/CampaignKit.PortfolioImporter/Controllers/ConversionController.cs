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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using CampaignKit.PortfolioImporter.ApiModels;
using CampaignKit.PortfolioImporter.Extensions;
using CampaignKit.PortfolioImporter.Services;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CampaignKit.PortfolioImporter.Controllers
{
    /// <summary>
    ///     Class ConversionController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class ConversionController : Controller
    {
        #region Fields

        private readonly ICharacterFormattingService _characterFormattingService;
        private readonly IPortfolioImportService _portfolioImportService;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConversionController" /> class.
        /// </summary>
        /// <param name="portfolioImportService">The portfolio import service.</param>
        /// <param name="characterFormattingService">The character formatting service.</param>
        public ConversionController(IPortfolioImportService portfolioImportService,
            ICharacterFormattingService characterFormattingService)
        {
            _portfolioImportService = portfolioImportService;
            _characterFormattingService = characterFormattingService;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     POST api/conversion endpoint
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        public JsonResult Post([FromBody] ConversionPostModel model)
        {
            var errorMessages = new List<string>();
            try
            {
                var stream = new MemoryStream(Convert.FromBase64String(model?.Portfolio));
                var characters = _portfolioImportService.ImportPortfolio(stream);

                return this.DasherizedJson(new
                {
                    Data = characters?.Select(c => new
                    {
                        Type = "characters",
                        Id = default(string),
                        Attributes = new
                        {
                            c.Name,
                            FormattedStatBlock = _characterFormattingService.Format(c).FormattedText
                        }
                    })
                });
            }
            catch (FormatException e)
            {
                errorMessages.Add("Invalid input: portfolio is not a valid base64 string.");
                errorMessages.Add($"Details: {e.Message}");
            }
            catch (Exception e)
            {
                errorMessages.Add(
                    "An unexpected error occurred, please inform the webadmin at support@campaign-logger.com.");
                errorMessages.Add($"Details: {e.Message}");
            }

            return this.DasherizedJson(new { Errors = errorMessages.Select(e => new { Message = e }) });
        }

        #endregion
    }
}