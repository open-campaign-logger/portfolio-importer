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

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CampaignKit.PortfolioImporter.Filters
{
    /// <summary>
    ///     Class RequestFormSizeLimitAttribute.
    /// </summary>
    /// <seealso cref="T:System.Attribute" />
    /// <seealso cref="T:Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter" />
    /// <seealso cref="T:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    // ReSharper disable once UnusedMember.Global
    public class RequestFormSizeLimitAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        #region Fields

        private readonly FormOptions _formOptions;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="T:CampaignKit.PortfolioImporter.Filters.RequestFormSizeLimitAttribute" /> class.
        /// </summary>
        /// <param name="valueCountLimit">The value count limit.</param>
        public RequestFormSizeLimitAttribute(int valueCountLimit)
        {
            _formOptions = new FormOptions
            {
                ValueCountLimit = valueCountLimit
            };
        }

        #endregion

        #region Properties

        /// <inheritdoc />
        /// <summary>
        ///     Gets the order value for determining the order of execution of filters. Filters execute in
        ///     ascending numeric value of the <see cref="P:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter.Order" /> property.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; }

        #endregion

        #region Implementations

        /// <inheritdoc />
        /// <summary>
        ///     Called early in the filter pipeline to confirm request is authorized.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext" />.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var features = context.HttpContext.Features;
            var formFeature = features.Get<IFormFeature>();

            if (formFeature?.Form == null)
                features.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, _formOptions));
        }

        #endregion
    }
}