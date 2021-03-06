﻿// Copyright 2017,2020 Jochen Linnemann
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

using System.Linq;
using CampaignKit.PortfolioImporter.Services;
using CampaignKit.PortfolioImporter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CampaignKit.PortfolioImporter.Controllers
{
    /// <inheritdoc />
    /// <summary>
    ///     Class HomeController.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Mvc.Controller" />
    [Route("")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="portfolioImportService">The portfolio import service.</param>
        /// <param name="characterFormattingService">The character formatting service.</param>
        public HomeController(IPortfolioImportService portfolioImportService,
            ICharacterFormattingService characterFormattingService)
        {
            _portfolioImportService = portfolioImportService;
            _characterFormattingService = characterFormattingService;
        }

        #endregion

        #region Fields

        private readonly ICharacterFormattingService _characterFormattingService;

        private readonly IPortfolioImportService _portfolioImportService;

        #endregion

        #region Methods

        /// <summary>
        ///     GET Home/Import endpoint
        ///     - displays the file upload view
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet("Import")]
        public ActionResult Import()
        {
            var model = new ImportViewModel();
            return View(model);
        }

        /// <summary>
        ///     POST Home/Import endpoint
        ///     - handles the uploaded file and then displays a view corresponding to the result
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost("Import")]
        [ValidateAntiForgeryToken]
        public ActionResult Import(ImportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var portfolioFile = model.Portfolio;
                var characters =
                    _portfolioImportService.ImportPortfolio(portfolioFile.OpenReadStream())
                        .Select(c => _characterFormattingService.Format(c));

                return View("ImportResult", characters);
            }

            return View();
        }

        /// <summary>
        ///     GET Home/Index endpoint
        ///     - displays the homepage view
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     GET Home/Legalities endpoint
        ///     - displays the disclaimer/impress/privacy view
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet("Legalities")]
        public IActionResult Legalities()
        {
            return View();
        }

        #endregion
    }
}