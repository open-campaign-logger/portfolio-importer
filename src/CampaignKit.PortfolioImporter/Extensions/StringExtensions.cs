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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CampaignKit.PortfolioImporter.Extensions
{
    /// <summary>
    ///     Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
        #region Static Fields

        #region Constants

        private const string Dash = "—";

        #endregion

        #endregion

        #region Methods

        /// <summary>
        ///     Appends the line if not dash.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="s">The s.</param>
        /// <returns>StringBuilder.</returns>
        // ReSharper disable once UnusedMember.Global
        public static StringBuilder AppendLineIfNotDash(this StringBuilder sb, string s)
        {
            if (s != null && !s.EndsWith(Dash))
                sb?.AppendLine(s);

            return sb;
        }

        /// <summary>
        ///     Dasherizes the specified string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string Dasherize(this string s)
        {
            if (s == null) return null;

            var dasherize = new Regex("[ _]");
            return dasherize.Replace(s.Decamelize(), "-");
        }

        /// <summary>
        ///     Decamelizes the specified string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string Decamelize(this string s)
        {
            if (s == null) return null;

            var decamelize = new Regex("([a-z0-9])([A-Z])");
            return decamelize.Replace(s, "$1_$2").ToLower();
        }

        /// <summary>
        ///     Ensures a string (representing a possible number) starts with a plus or minus.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string EnsureSigned(this string s)
        {
            return s.StartsWith("-") || s.StartsWith("+") ? s : $"+{s}";
        }

        /// <summary>
        ///     Returns the specified string of not null or white space,
        ///     a dash (-) otherwise.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string OrDash(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return Dash;

            return s;
        }

        /// <summary>
        ///     Splits a string and trims the resulting parts.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="index">The index.</param>
        /// <param name="separators">The separators.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string SplitTrim(this string s, int index, params char[] separators)
        {
            var result = s.Split(separators).Select(part => part.Trim()).ToList();
            return result.Skip(index).FirstOrDefault() ?? result.FirstOrDefault();
        }

        /// <summary>
        ///     To challenge rating.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string ToChallengeRating(this string s)
        {
            if (!int.TryParse(s, out var level)) return "?";

            level -= 1;
            if (level > 0) return level.ToString();

            level -= 1;
            return $"1/{Math.Pow(2, -level)}";
        }

        /// <summary>
        ///     To initials.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string ToInitials(this string s)
        {
            var initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");
            return initials.Replace(s, "$1");
        }

        /// <summary>
        ///     To sentence start.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string ToSentenceStart(this string s)
        {
            var sentenceStart = new Regex(@"(\s*)(\p{L})(.*)");
            return sentenceStart.Replace(s.ToLower(),
                match => $"{match.Groups[1].Value}{match.Groups[2].Value.ToUpper()}{match.Groups[3].Value}");
        }

        /// <summary>
        ///     To shortened.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="limit">The limit.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string ToShortened(this string s, int limit)
        {
            if (s == null) return null;
            if (limit < 3) return string.Empty;

            s = s.Trim();
            if (s.Length > limit)
            {
                s = s.Substring(0, limit - 3);
                var lastLinebreak = s.LastIndexOf("\n", StringComparison.Ordinal);
                if (lastLinebreak > limit * .9)
                    s = s.Substring(0, lastLinebreak).Trim();

                s = $"{s}...";
            }

            return s;
        }

        /// <summary>
        ///     To title case.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        // ReSharper disable once UnusedMember.Global
        public static string ToTitleCase(this string s)
        {
            var titleCase = new Regex(@"(\s*)([\p{L}0-9])([\p{L}0-9]*)(\s*)");
            return titleCase.Replace(s.ToLower(),
                match =>
                    $"{match.Groups[1].Value}{match.Groups[2].Value.ToUpper()}{match.Groups[3].Value}{match.Groups[4].Value}");
        }

        #endregion
    }
}