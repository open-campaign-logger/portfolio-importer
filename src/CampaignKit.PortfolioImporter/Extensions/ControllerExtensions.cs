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

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CampaignKit.PortfolioImporter.Extensions
{
    /// <summary>
    ///     Class ControllerExtensions.
    /// </summary>
    public static class ControllerExtensions
    {
        #region Methods

        /// <summary>
        ///     Returns a dasherized json string of data.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="data">The data.</param>
        /// <returns>JsonResult.</returns>
        public static JsonResult DasherizedJson(this Controller controller, object data)
        {
            return controller?.Json(data,
                new JsonSerializerSettings { ContractResolver = new DasherizedPropertyNamesContractResolver() });
        }

        #endregion

        #region Nested Types

        /// <summary>
        ///     Class DasherizedPropertyNamesContractResolver.
        /// </summary>
        /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
        private class DasherizedPropertyNamesContractResolver : DefaultContractResolver
        {
            #region Methods

            /// <summary>
            ///     Resolves the name of the property.
            /// </summary>
            /// <param name="propertyName">Name of the property.</param>
            /// <returns>Resolved name of the property.</returns>
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName?.Dasherize();
            }

            #endregion
        }

        #endregion
    }
}