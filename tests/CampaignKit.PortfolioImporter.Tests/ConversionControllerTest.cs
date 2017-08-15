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
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;

using CampaignKit.PortfolioImporter.ApiModels;
using CampaignKit.PortfolioImporter.Controllers;
using CampaignKit.PortfolioImporter.Services;
using CampaignKit.PortfolioImporter.Tests.IntegrationTests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace CampaignKit.PortfolioImporter.Tests
{
    /// <summary>
    ///     Class ConversionControllerTest.
    /// </summary>
    [TestClass]
    public class ConversionControllerTest
    {
        #region Fields

        private readonly string _fileContent;
        private readonly TestFixture<Startup> _fixture;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConversionControllerTest" /> class.
        /// </summary>
        public ConversionControllerTest()
        {
            var assembly = typeof(ConversionControllerTest).GetTypeInfo().Assembly;
            using (var resourceStream = assembly.GetManifestResourceStream("CampaignKit.PortfolioImporter.Tests.Properties.TestData.por"))
            using (var memoryStream = new MemoryStream())
            {
                resourceStream.CopyTo(memoryStream);
                _fileContent = Convert.ToBase64String(memoryStream.ToArray());
            }

            _fixture = new TestFixture<Startup>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Tests the post method by instantiating the controller directly.
        /// </summary>
        [TestMethod]
        public void TestPost()
        {
            var controller = new ConversionController(new DefaultPortfolioImportService(), new DefaultCharacterFormattingService());

            var result = controller.Post(new ConversionPostModel { Portfolio = _fileContent });

            var json = JsonConvert.SerializeObject(result.Value, result.SerializerSettings);
            var decoded = JsonConvert.DeserializeAnonymousType(json,
                new
                {
                    Data = new[] { new { Type = "", Id = "", Attributes = new { Name = "", FormattedStatBlock = "" } } },
                    Errors = new[] { new { Message = "" } }
                });

            Assert.AreNotEqual(decoded.Data, null);
            Assert.AreEqual(decoded.Data.Any(), true);
            Assert.AreEqual(decoded.Errors, null);
        }

        /// <summary>
        ///     Tests the post method's higher level integration by starting a testing instance of the web server.
        /// </summary>
        [TestMethod]
        public void TestPost_Integration()
        {
            var input = JsonConvert.SerializeObject(new { Portfolio = _fileContent });

            var response = _fixture.Client.PostAsync("/api/Conversion", new StringContent(input, Encoding.UTF8, "application/json")).Result;
            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadAsStringAsync().Result;
            var decoded = JsonConvert.DeserializeAnonymousType(json,
                new
                {
                    Data = new[] { new { Type = "", Id = "", Attributes = new { Name = "", FormattedStatBlock = "" } } },
                    Errors = new[] { new { Message = "" } }
                });

            Assert.AreNotEqual(decoded.Data, null);
            Assert.AreEqual(decoded.Data.Any(), true);
            Assert.AreEqual(decoded.Errors, null);
        }

        #endregion
    }
}