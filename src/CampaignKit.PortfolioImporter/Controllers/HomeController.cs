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

using System.Linq;

using CampaignKit.PortfolioImporter.Services;
using CampaignKit.PortfolioImporter.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace CampaignKit.PortfolioImporter.Controllers
{
    /// <summary>
    ///     Class HomeController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        #region Fields

        private readonly ICharacterFormattingService _characterFormattingService;

        private readonly IPortfolioImportService _portfolioImportService;

        #endregion

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

        #region Methods

        /// <summary>
        ///     GET Home/Import endpoint
        ///     - displays the file upload view
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import(ImportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var portofolioFile = model.Portfolio;
                var characters =
                    _portfolioImportService.ImportPortfolio(portofolioFile.OpenReadStream())
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
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     GET Home/Legalities endpoint
        ///     - displays the disclaimer/impress/privacy view
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Legalities()
        {
            return View();
        }

        #endregion
    }
}