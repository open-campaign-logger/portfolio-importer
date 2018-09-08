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

using System.IO;
using System.Linq;
using System.Text;
using System.Xml.XPath;

using CampaignKit.PortfolioImporter.Entities;
using CampaignKit.PortfolioImporter.Extensions;

namespace CampaignKit.PortfolioImporter.Services
{
    /// <summary>
    ///     Interface ICharacterFormattingService
    /// </summary>
    public interface ICharacterFormattingService
    {
        #region Methods

        /// <summary>
        ///     Formats the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>FormattedCharacter.</returns>
        FormattedCharacter Format(Character character);

        #endregion
    }

    /// <summary>
    ///     Class DefaultCharacterFormattingService.
    /// </summary>
    /// <seealso cref="ICharacterFormattingService" />
    public class DefaultCharacterFormattingService : ICharacterFormattingService
    {
        #region Implementations

        /// <summary>
        ///     Formats the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>FormattedCharacter.</returns>
        public FormattedCharacter Format(Character character)
        {
            if (character == null) return null;

            var doc = new XPathDocument(new StringReader(character.Xml));
            var nav = doc.CreateNavigator().SelectSingleNode("//character");

            StringBuilder formattedText;
            switch (character.Game)
            {
                case "5th Edition SRD":
                    formattedText = FormatForDnd5E(nav);
                    break;
                case "Pathfinder Roleplaying Game":
                    formattedText = FormatForPathfinder(nav);
                    break;
                default:
                    formattedText = new StringBuilder();
                    break;
            }

            return new FormattedCharacter
            {
                FormattedText = formattedText?.ToString(),
                Html = character.Html,
                Name = character.Name,
                Text = character.Text,
                Xml = character.Xml
            };
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Formats for dnd5e.
        /// </summary>
        /// <param name="nav">The nav.</param>
        /// <returns>StringBuilder.</returns>
        private static StringBuilder FormatForDnd5E(XPathNavigator nav)
        {
            var formattedText = new StringBuilder();

            formattedText.AppendLine(
                $"{{b|@\"{nav.Get("./@name")}\"}} (played by {nav.Get("./@playername")}) - {nav.Get("./classes/@summary").ToTitleCase()}");
            formattedText.AppendLine(
                $"{{i|{nav.Get("./size/@name").ToSentenceStart()} {nav.Get("./personal/@gender").ToLower()} {nav.Get("./race/@displayname").ToLower()}, {nav.Get("./alignment/@name").ToLower()}}}");
            formattedText.AppendLine(
                $"Age {nav.Get("./personal/@age")}, height {nav.Get("./personal/charheight/@text")}, weight {nav.Get("./personal/charweight/@text").Replace("lb.", " lbs")}, {nav.Get("./personal/@hair").ToLower()} hair, {nav.Get("./personal/@eyes").ToLower()} eyes, {nav.Get("./personal/@skin").ToLower()} skin");
            formattedText.AppendLine("---");

            formattedText.AppendLine(
                $"{{b|Initiative}} {nav.Get("./initiative/@total").EnsureSigned()}");
            formattedText.AppendLine(
                $"{{b|Armor Class}} {nav.Get("./armorclass/@ac")} ({string.Join(", ", nav.Select("./defenses/armor").GetMany(s => $"{s.Get("./@name")} {s.Get("./@ac").EnsureSigned()}")).ToLower().OrDash()})");
            formattedText.AppendLine(
                $"{{b|Hit Points}} {nav.Get("./health/@hitpoints")} ({nav.Get("./health/@hitdice").SplitTrim(1, ';')})");
            formattedText.AppendLine(
                $"{{b|Speed}} {nav.Get("./movement/speed/@text").Replace("'", " ft.")}");
            formattedText.AppendLine("---");

            formattedText.Append(
                $"{{b|STR}} {nav.Get("./abilityscores/abilityscore[@name='Strength']/abilvalue/@text")} ({nav.Get("./abilityscores/abilityscore[@name='Strength']/abilbonus/@text").EnsureSigned()}) ");
            formattedText.Append(
                $"{{b|DEX}} {nav.Get("./abilityscores/abilityscore[@name='Dexterity']/abilvalue/@text")} ({nav.Get("./abilityscores/abilityscore[@name='Dexterity']/abilbonus/@text").EnsureSigned()}) ");
            formattedText.Append(
                $"{{b|CON}} {nav.Get("./abilityscores/abilityscore[@name='Constitution']/abilvalue/@text")} ({nav.Get("./abilityscores/abilityscore[@name='Constitution']/abilbonus/@text").EnsureSigned()}) ");
            formattedText.Append(
                $"{{b|INT}} {nav.Get("./abilityscores/abilityscore[@name='Intelligence']/abilvalue/@text")} ({nav.Get("./abilityscores/abilityscore[@name='Intelligence']/abilbonus/@text").EnsureSigned()}) ");
            formattedText.Append(
                $"{{b|WIS}} {nav.Get("./abilityscores/abilityscore[@name='Wisdom']/abilvalue/@text")} ({nav.Get("./abilityscores/abilityscore[@name='Wisdom']/abilbonus/@text").EnsureSigned()}) ");
            formattedText.AppendLine(
                $"{{b|CHA}} {nav.Get("./abilityscores/abilityscore[@name='Charisma']/abilvalue/@text")} ({nav.Get("./abilityscores/abilityscore[@name='Charisma']/abilbonus/@text").EnsureSigned()})");
            formattedText.AppendLine("---");

            formattedText.AppendLine(
                $"{{b|Proficiency}} {nav.Get("./proficiencybonus/@total")}");
            formattedText.AppendLine(
                $"{{b|Skills}} {string.Join(", ", nav.Select("./skills/skill").GetMany(s => $"{s.Get("./@name")} {s.Get("./@value").EnsureSigned()}"))}");
            formattedText.AppendLineIfNotDash(
                $"{{b|Damage Vulnerabilities}} {nav.Get("./damagevulnerabilities/@text").ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"{{b|Damage Resistances}} {nav.Get("./damageresistances/@text").ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"{{b|Damage Immunities}} {nav.Get("./damageimmunities/@text").ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"{{b|Condition Immunities}} {nav.Get("./conditionimmunities/@text").ToLower().OrDash()}");
            //formattedText.AppendLine(
            //    $"{{b|Armor Proficiencies}} {nav.Get("./armorproficiencies/@text").ToLower().OrDash()}");
            //formattedText.AppendLine(
            //    $"{{b|Weapon Proficiencies}} {nav.Get("./weaponproficiencies/@text").ToLower().OrDash()}");
            //formattedText.AppendLine(
            //    $"{{b|Tool Proficiencies}} {nav.Get("./toolproficiencies/@text").ToLower().OrDash()}");
            formattedText.AppendLine( // TODO: handle ./senses sub-elements
                $"{{b|Senses}} {string.Join(", ", nav.Select("./otherspecials/special[@type='Sense']").GetMany(s => s.Get("./@shortname"))).ToLower().OrDash()}, passive Perception {nav.Get("./skills/skill[@name='Perception']/@passive")}");
            formattedText.AppendLine(
                $"{{b|Languages}} {string.Join(", ", nav.Select("./languages/language").GetMany(l => l.Get("./@name"))).OrDash()}");
            formattedText.AppendLine(
                $"{{b|Challenge}} {nav.Get("./classes/@level").ToChallengeRating()} (tbd XP)");
            formattedText.AppendLine("---");

            foreach (
                var situationalmodifier in
                nav.Select("./allsaves/situationalmodifiers/situationalmodifier")
                    .GetMany(s => $"{{bi|{s.Get("./@source")}}}. {s.Get("./@text")}."))
                formattedText.AppendLine(situationalmodifier);
            foreach (
                var situationalmodifier in
                nav.Select("./otherspecials/special[not(@type='Sense')]")
                    .GetMany(s => $"{{bi|{s.Get("./@name")}}}. {s.Get("./description").ToShortened(150)}"))
                formattedText.AppendLine(situationalmodifier);
            //formattedText.AppendLine(
            //    $"{{bi|Innate Spellcasting}}. ?");
            formattedText.AppendLine(
                $"{{bi|Spellcasting}}. {string.Join("; ", nav.Select("./classes/class[@casterlevel]").GetMany(c => $"{c.Get("./@name")} ({c.Get("./@castersource").ToLower()} {c.Get("./@spells").ToLower()} casting, using {c.Get("./@spellability")})"))}.");
            formattedText.AppendLineIfNotDash(
                $"Cantrips (at will): {string.Join(", ", nav.Select("./cantrips/spell").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"1st level ({nav.Get("./spellslots/spellslot[@name='1st']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=1] | ./spellsmemorized/spell[@level=1]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"2nd level ({nav.Get("./spellslots/spellslot[@name='2nd']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=2] | ./spellsmemorized/spell[@level=2]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"3rd level ({nav.Get("./spellslots/spellslot[@name='3rd']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=3] | ./spellsmemorized/spell[@level=3]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"4th level ({nav.Get("./spellslots/spellslot[@name='4th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=4] | ./spellsmemorized/spell[@level=4]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"5th level ({nav.Get("./spellslots/spellslot[@name='5th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=5] | ./spellsmemorized/spell[@level=5]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"6th level ({nav.Get("./spellslots/spellslot[@name='6th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=6] | ./spellsmemorized/spell[@level=6]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"7th level ({nav.Get("./spellslots/spellslot[@name='7th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=7] | ./spellsmemorized/spell[@level=7]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"8th level ({nav.Get("./spellslots/spellslot[@name='8th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=8] | ./spellsmemorized/spell[@level=8]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            formattedText.AppendLineIfNotDash(
                $"9th level ({nav.Get("./spellslots/spellslot[@name='9th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=9] | ./spellsmemorized/spell[@level=9]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
            //formattedText.AppendLine(
            //    $"{{bi|Psionics}}. ?");
            formattedText.AppendLine("---");

            formattedText.AppendLine("{b|Actions}");
            foreach (
                var weapon in
                nav.Select("./melee/weapon")
                    .GetMany(
                        m =>
                            $"{{bi|{m.Get("./@name")}}}. {{i|Melee Weapon Attack:}} {m.Get("./@attack")} to hit, reach tbd. {{i|Hit:}} {m.Get("./@damage")} damage." +
                            (m.Select("./rangedattack").Count == 0
                                ? string.Empty
                                : $" {{i|Ranged Weapon Attack:}} {m.Get("./rangedattack/@attack")} to hit, range {m.Get("./rangedattack/@range")} {{i|Hit:}} {m.Get("./@damage")} damage."
                            ))
            )
                formattedText.AppendLine(weapon);
            foreach (
                var weapon in
                nav.Select("./ranged/weapon")
                    .GetMany(
                        r =>
                            $"{{bi|{r.Get("./@name")}}}. {{i|Ranged Weapon Attack:}} {r.Get("./rangedattack/@attack")} to hit, range {r.Get("./rangedattack/@range")} {{i|Hit:}} {r.Get("./@damage")} damage.")
            )
                formattedText.AppendLine(weapon);

            formattedText.AppendLine("---");

            formattedText.AppendLineIfNotDash(
                $"{{b|Spellbook}} {string.Join(", ", nav.Select("./spellbook/spell").GetMany(c => $"{c.Get("./@name")}")).ToLower().OrDash()}");
            formattedText.AppendLine(
                $"{{b|Gear}} {string.Join("; ", nav.Select("./gear/item").GetMany(i => $"{i.Get("./@name")} ({i.Get("./@quantity")})")).ToLower().OrDash()}");
            formattedText.AppendLine(
                $"{{b|Money}} {string.Join(", ", nav.Select("./money/coins").GetMany(c => $"{c.Get("./@count")}{c.Get("./@abbreviation")}").Where(c => !c.StartsWith("0"))).ToLower().OrDash()}");

            return formattedText;
        }

        /// <summary>
        ///     Formats for pathfinder.
        /// </summary>
        /// <param name="nav">The nav.</param>
        /// <returns>StringBuilder.</returns>
        private static StringBuilder FormatForPathfinder(XPathNavigator nav)
        {
            var formattedText = new StringBuilder();

            //formattedText.AppendLine(
            //    $"{{b|{nav.Get("./@name")}}} ({nav.Get("./challengerating/@text")})");
            //formattedText.AppendLine(
            //    $"{nav.Get("./alignment/@name").ToInitials().ToUpper()} {nav.Get("./size/@name").ToLower()} {nav.Get("./race/@name").ToLower()} {nav.Get("./classes/@summary").ToLower()}");

            return formattedText;
        }

        #endregion
    }
}