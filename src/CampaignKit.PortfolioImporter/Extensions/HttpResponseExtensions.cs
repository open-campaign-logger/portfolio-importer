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

using Microsoft.AspNetCore.Http;

namespace CampaignKit.PortfolioImporter.Extensions
{
    /// <summary>
    ///     Class HttpResponseExtensions.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class HttpResponseExtensions
    {
        #region Methods

        /// <summary>
        ///     Allows access from the specified host.
        ///     CORS header.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="host">The host.</param>
        public static void AllowAccessFrom(this HttpResponse response, string host)
        {
            response?.Headers.Add("Access-Control-Allow-Origin", host);
        }

        /// <summary>
        ///     Allows access from any host.
        ///     CORS header.
        /// </summary>
        /// <param name="response">The response.</param>
        public static void AllowAccessFromAnyHost(this HttpResponse response)
        {
            response.AllowAccessFrom("*");
        }

        #endregion
    }
}