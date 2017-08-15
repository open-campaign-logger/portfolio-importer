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
using System.Xml.XPath;

namespace CampaignKit.PortfolioImporter.Extensions
{
    /// <summary>
    ///     Class XPathNavigatorExtension.
    /// </summary>
    public static class XPathNavigatorExtensions
    {
        #region Methods

        /// <summary>
        ///     Gets the specified xpath's first match.
        /// </summary>
        /// <param name="nav">The nav.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns>System.String.</returns>
        public static string Get(this XPathNavigator nav, string xpath)
        {
            var iter = nav.Select(xpath);
            while (iter.MoveNext())
                return iter.Current.Value;

            return "<no value>";
        }

        /// <summary>
        ///     Gets all strings retrieved by selector while iterating the specified iterator.
        /// </summary>
        /// <param name="iter">The iter.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> GetMany(this XPathNodeIterator iter, Func<XPathNavigator, string> selector)
        {
            while (iter.MoveNext())
                yield return selector.Invoke(iter.Current);
        }

        #endregion
    }
}