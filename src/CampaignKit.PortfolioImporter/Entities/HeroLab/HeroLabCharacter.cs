using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace CampaignKit.PortfolioImporter.Entities.HeroLab
{

	public class HeroLabCharacter : Character
	{

		#region Character Properties

		private HeroLabCharacterRootDocument _rootDocument;

		public HeroLabCharacterRootDocument rootDocument
		{
			get
			{
				if (_rootDocument == null)
				{
					XmlSerializer serializer = new XmlSerializer(typeof(HeroLabCharacterRootDocument));
					using (TextReader reader = new StringReader(Xml))
					{
						_rootDocument = (HeroLabCharacterRootDocument)serializer.Deserialize(reader);
					}
				}
				return _rootDocument;
			}
		}

		public CharacterDetail detailDocument
		{
			get
			{
				return rootDocument.Public.Character;
			}
		}

		#endregion

		#region Character Data Accessors

		public bool is5e()
		{
			return detailDocument.Abilityscores != null && detailDocument.Abilityscores.Abilityscore != null && detailDocument.Abilityscores.Abilityscore.Count > 0;
		}

		public bool isPathfinder()
		{
			return !is5e();
		}

		private string getAbilityScore(string ability)
		{
			StringBuilder sb = new StringBuilder();
			if (is5e())
			{
				if (detailDocument.Abilityscores != null && detailDocument.Abilityscores.Abilityscore != null && detailDocument.Abilityscores.Abilityscore.Count > 0)
				{
					foreach (Abilityscore ab in detailDocument.Abilityscores.Abilityscore)
					{
						if (ab.Name.Equals(ability)) { sb.Append(ab.Abilvalue.Text); }
					}
				}
			}
			else
			{
				if (detailDocument.Attributes != null && detailDocument.Attributes.Attribute != null && detailDocument.Attributes.Attribute.Count > 0)
				{
					foreach (Attribute ab in detailDocument.Attributes.Attribute)
					{
						if (ab.Name.Equals(ability)) { sb.Append(ab.Attrvalue.Text); }
					}
				}
			}
			return sb.ToString().Trim();
		}

		private string getAbilityBonus(string ability)
		{
			StringBuilder sb = new StringBuilder();
			if (is5e())
			{
				foreach (Abilityscore ab in detailDocument.Abilityscores.Abilityscore)
				{
					if (ab.Name.Equals(ability)) { sb.Append(ab.Abilbonus.Text); }
				}
			}
			else
			{
				foreach (Attribute ab in detailDocument.Attributes.Attribute)
				{
					if (ab.Name.Equals(ability)) { sb.Append(ab.Attrbonus.Text); }
				}
			}
			return sb.ToString().Trim();
		}

		private string getSTR() { return getAbilityScore("Strength"); }
		private string getDEX() { return getAbilityScore("Dexterity"); }
		private string getCON() { return getAbilityScore("Constitution"); }
		private string getINT() { return getAbilityScore("Intelligence"); }
		private string getWIS() { return getAbilityScore("Wisdom"); }
		private string getCHA() { return getAbilityScore("Charisma"); }
		private string getSTRBonus() { return getAbilityBonus("Strength"); }
		private string getDEXBonus() { return getAbilityBonus("Dexterity"); }
		private string getCONBonus() { return getAbilityBonus("Constitution"); }
		private string getINTBonus() { return getAbilityBonus("Intelligence"); }
		private string getWISBonus() { return getAbilityBonus("Wisdom"); }
		private string getCHABonus() { return getAbilityBonus("Charisma"); }


		public List<Weapon> getWeapons()
		{
			List<Weapon> result = new List<Weapon>();
			if (detailDocument.Melee != null && detailDocument.Melee.Weapon != null && detailDocument.Melee.Weapon.Count > 0)
			{
				result.AddRange(detailDocument.Melee.Weapon);
			}
			if (detailDocument.Ranged != null && detailDocument.Ranged.Weapon != null && detailDocument.Ranged.Weapon.Count > 0)
			{
				result.AddRange(detailDocument.Ranged.Weapon);
			}
			return result;
		}

		public List<Spell> getSpells()
		{
			List<Spell> result = new List<Spell>();
			if (detailDocument.Spellsknown != null && detailDocument.Spellsknown.Spell != null && detailDocument.Spellsknown.Spell.Count > 0)
			{
				result.AddRange(detailDocument.Spellsknown.Spell);
			}
			if (detailDocument.Racespells != null && detailDocument.Racespells.Spell != null && detailDocument.Racespells.Spell.Count > 0)
			{
				result.AddRange(detailDocument.Racespells.Spell);
			}
			return result;
		}

		#endregion

		#region Formatting Code

		public override string getCompactStatBlockFormat()
		{
			throw new System.NotImplementedException();
		}

		private TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

		private string getCharacterName() { return detailDocument.Name; }
		private string getPlayerName() { return detailDocument.Playername; }
		private string getClassesSummary() { return textInfo.ToTitleCase(detailDocument.Classes.Summary); }
		private string getSize() { return detailDocument.Size.Name; }
		private string getGender() { return detailDocument.Personal.Gender; }
		private string getAlignment() { return detailDocument.Alignment.Name.ToLower(); }
		private string getAge() { return detailDocument.Personal.Age; }
		private string getHeight() { return detailDocument.Personal.Charheight.Text; }
		private string getWeight() { return detailDocument.Personal.Charweight.Text.Replace("lb.", " lbs"); }
		private string getRace() { return detailDocument.Race.Displayname; }
		private string getHair() { return detailDocument.Personal.Hair.ToLower(); }
		private string getEyes() { return detailDocument.Personal.Eyes.ToLower(); }
		private string getSkin() { return detailDocument.Personal.Skin.ToLower(); }

		private string getInitiative() { return detailDocument.Initiative.Total; }
		private string getAc() { return detailDocument.Armorclass.Ac; }
		private string getArmor() { return string.Join(", ", detailDocument.Defenses.Armor.Select(x => x.Name + " " + x.Ac)); }
		private string getHp() { return detailDocument.Health.Hitpoints; }
		private string getHitdice()
		{
			string result = detailDocument.Health._Hitdice;
			if (result.IndexOf(";") > 0)
			{
				result = result.Split(";")[1];
			}
			return result;
		}
		private string getSpeed() { return detailDocument.Movement.Speed.Text.Replace("'", " ft."); }

		private string getDamageVulnerabilites()
		{
			if (is5e()) { return detailDocument.Damagevulnerabilities.Text; }
			else { return string.Join(", ", detailDocument.Weaknesses.Special.Select(s => s.Shortname)); }
		}
		private string getDamageResistances()
		{
			if (is5e()) { return detailDocument.Damageresistances.Text; }
			else { return string.Join(", ", detailDocument.Damagereduction.Special.Select(s => s.Shortname)); }
		}
		private string getDamageImmunities()
		{
			if (is5e()) { return detailDocument.Damageimmunities.Text; }
			else { return string.Join(", ", detailDocument.Immunities.Special.Select(s => s.Shortname)); }
		}
		private string getConditionImmunities()
		{
			if (is5e()) { return detailDocument.Conditionimmunities.Text; }
			else{ return string.Join(", ", detailDocument.Resistances.Special.Select(s => s.Shortname));}
		}

		public override string getDefaultFormat()
		{
			
			var formattedText = new StringBuilder();
					   
			formattedText.AppendLine($"{{b|@\"{getCharacterName()}\"}} (played by {getPlayerName()}) - {getClassesSummary()}");
			formattedText.AppendLine($"{{i|{getSize()} {getGender()} {getRace()}, {getAlignment()}}}");
			formattedText.AppendLine($"Age {getAge()}, height {getHeight()}, weight {getWeight()}, {getHair()} hair, {getEyes()} eyes, {getSkin()} skin");
			formattedText.AppendLine("---");
			
			formattedText.AppendLine($"{{b|Initiative}} {getInitiative()}");
			formattedText.AppendLine($"{{b|Armor Class}} {getAc()} ({getArmor()})");
			formattedText.AppendLine($"{{b|Hit Points}} {getHp()} ({getHitdice()})");
			formattedText.AppendLine($"{{b|Speed}} {getSpeed()}");
			formattedText.AppendLine("---");

			formattedText.Append($"{{b|STR}} {getSTR()} ({getSTRBonus()}) ");
			formattedText.Append($"{{b|DEX}} {getDEX()} ({getDEXBonus()}) ");
			formattedText.Append($"{{b|CON}} {getCON()} ({getCONBonus()}) ");
			formattedText.Append($"{{b|INT}} {getINT()} ({getINTBonus()}) ");
			formattedText.Append($"{{b|WIS}} {getWIS()} ({getWISBonus()}) ");
			formattedText.AppendLine($"{{b|CHA}} {getCHA()} ({getCHABonus()})");
			formattedText.AppendLine("---");

			if (is5e())
			{
				formattedText.AppendLine($"{{b|Proficiency}} {detailDocument.Proficiencybonus.Total}");
			}

			List<Skill> proficientSkills = new List<Skill>();
			string skills = string.Join(", ", proficientSkills.Select(s => $"{s.Name} {s.Value}"));
			proficientSkills.AddRange(detailDocument.Skills.Skill.FindAll(s => !s.Ranks.Equals("0")));
			formattedText.AppendLine($"{{b|Skills}} {skills}");

			formattedText.AppendLine($"{{b|Damage Vulnerabilities}} {getDamageVulnerabilites()}");
			formattedText.AppendLine($"{{b|Damage Resistances}} {getDamageResistances()}");
			formattedText.AppendLine($"{{b|Damage Immunities}} {getDamageImmunities()}");
			formattedText.AppendLine($"{{b|Condition Immunities}} {getConditionImmunities()}");

			string senses = string.Join(", ", detailDocument.Senses.Special.Select(s => s.Shortname));
			if (is5e())
			{
				senses += $", passive Perception {detailDocument.Skills.Skill.Find(s => s.Name.Equals("Perception")).Passive}";
			}
			string languages = string.Join(", ", detailDocument.Languages.Language.Select(s => s.Name));
			string challenge = detailDocument.Challengerating.Text;
			string xp = detailDocument.Xpaward.Text;

			formattedText.AppendLine($"{{b|Senses}} {senses}");
			formattedText.AppendLine($"{{b|Languages}} {languages}");
			formattedText.AppendLine($"{{b|Challenge}} {challenge} ({xp} XP)");
			formattedText.AppendLine("---");
			
			if (is5e())
			{
				formattedText.AppendLine(string.Join("\r\n", detailDocument.Abilityscores.Abilityscore
					.FindAll(s => s.Savingthrow.Situationalmodifiers.Equals("yes"))
					.Select(s => $"{{bi|{s.Name}}}. {s.Savingthrow.Text}.")));

				formattedText.AppendLine(string.Join("\r\n", detailDocument.Allsaves.Situationalmodifiers
					.Select(s => $"{{bi|{s.Situationalmodifier.Text}}}.")));
			}
			else
			{
				formattedText.AppendLine(string.Join("\r\n", detailDocument.Saves.Save
					.Select(s => $"{{bi|{s.Name}}}. {s._save}.")));

				formattedText.AppendLine(string.Join("\r\n", detailDocument.Saves.Allsaves.Situationalmodifiers
					.Select(s => $"{{bi|{s.Situationalmodifier.Text}}}.")));
			}


			formattedText.AppendLine(string.Join("\r\n", detailDocument.Otherspecials.Special
				.FindAll(s => !s.Type.Equals("Sense"))
				.Select(s => $"{{bi|{s.Name}}}. {s.Description.Substring(0, 150)}")));

			return formattedText.ToString();

			//foreach (Class cl in detailDocument.Classes.Class.FindAll(s => !s.Casterlevel.Equals("0")))
			//{
			//	formattedText.AppendLine(
			//		$"{{bi|Spellcasting}}. {string.Join("; ", nav.Select("./classes/class[@casterlevel]").GetMany(c => $"{c.Get("./@name")} ({c.Get("./@castersource").ToLower()} {c.Get("./@spells").ToLower()} casting, using {c.Get("./@spellability")})"))}.");
			//}

			
			//formattedText.AppendLineIfNotDash(
			//	$"Cantrips (at will): {string.Join(", ", nav.Select("./cantrips/spell").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"1st level ({nav.Get("./spellslots/spellslot[@name='1st']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=1] | ./spellsmemorized/spell[@level=1]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"2nd level ({nav.Get("./spellslots/spellslot[@name='2nd']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=2] | ./spellsmemorized/spell[@level=2]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"3rd level ({nav.Get("./spellslots/spellslot[@name='3rd']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=3] | ./spellsmemorized/spell[@level=3]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"4th level ({nav.Get("./spellslots/spellslot[@name='4th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=4] | ./spellsmemorized/spell[@level=4]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"5th level ({nav.Get("./spellslots/spellslot[@name='5th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=5] | ./spellsmemorized/spell[@level=5]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"6th level ({nav.Get("./spellslots/spellslot[@name='6th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=6] | ./spellsmemorized/spell[@level=6]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"7th level ({nav.Get("./spellslots/spellslot[@name='7th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=7] | ./spellsmemorized/spell[@level=7]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"8th level ({nav.Get("./spellslots/spellslot[@name='8th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=8] | ./spellsmemorized/spell[@level=8]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			//formattedText.AppendLineIfNotDash(
			//	$"9th level ({nav.Get("./spellslots/spellslot[@name='9th']/@count")} slots): {string.Join(", ", nav.Select("./spellsknown/spell[@level=9] | ./spellsmemorized/spell[@level=9]").GetMany(s => $"{{bi|{s.Get("./@name")}}}")).ToLower().OrDash()}");
			////formattedText.AppendLine(
			////    $"{{bi|Psionics}}. ?");
			//formattedText.AppendLine("---");

			//formattedText.AppendLine("{b|Actions}");
			//foreach (
			//	var weapon in
			//	nav.Select("./melee/weapon")
			//		.GetMany(
			//			m =>
			//				$"{{bi|{m.Get("./@name")}}}. {{i|Melee Weapon Attack:}} {m.Get("./@attack")} to hit, reach tbd. {{i|Hit:}} {m.Get("./@damage")} damage." +
			//				(m.Select("./rangedattack").Count == 0
			//					? string.Empty
			//					: $" {{i|Ranged Weapon Attack:}} {m.Get("./rangedattack/@attack")} to hit, range {m.Get("./rangedattack/@range")} {{i|Hit:}} {m.Get("./@damage")} damage."
			//				))
			//)
			//	formattedText.AppendLine(weapon);
			//foreach (
			//	var weapon in
			//	nav.Select("./ranged/weapon")
			//		.GetMany(
			//			r =>
			//				$"{{bi|{r.Get("./@name")}}}. {{i|Ranged Weapon Attack:}} {r.Get("./rangedattack/@attack")} to hit, range {r.Get("./rangedattack/@range")} {{i|Hit:}} {r.Get("./@damage")} damage.")
			//)
			//	formattedText.AppendLine(weapon);

			//formattedText.AppendLine("---");

			//formattedText.AppendLineIfNotDash(
			//	$"{{b|Spellbook}} {string.Join(", ", nav.Select("./spellbook/spell").GetMany(c => $"{c.Get("./@name")}")).ToLower().OrDash()}");
			//formattedText.AppendLine(
			//	$"{{b|Gear}} {string.Join("; ", nav.Select("./gear/item").GetMany(i => $"{i.Get("./@name")} ({i.Get("./@quantity")})")).ToLower().OrDash()}");
			//formattedText.AppendLine(
			//	$"{{b|Money}} {string.Join(", ", nav.Select("./money/coins").GetMany(c => $"{c.Get("./@count")}{c.Get("./@abbreviation")}").Where(c => !c.StartsWith("0"))).ToLower().OrDash()}");

			//return formattedText;


		}

		public override string getStatBlockFormat()
		{

			Statblock5e statblock = new Statblock5e();

			//// Creature Heading
			//statblock.Creatureheading
			//	= new Creatureheading(getCharacterName(),
			//		getCharacterType(),
			//		getCharacterAlignment());

			//// Top Stats
			//statblock.Topstats
			//	= new Topstats(getArmorClass(),
			//		getHitPoints() + " (" + getHitDice() + ")",
			//		getAlignment());

			//// Abilities
			//statblock.Topstats.Abilitiesblock
			//	= new Abilitiesblock(getSTR(), getSTRBonus(),
			//		getDEX(), getDEXBonus(),
			//		getCON(), getCONBonus(),
			//		getINT(), getINTBonus(),
			//		getWIS(), getWISBonus(),
			//		getCHA(), getCHABonus());

			//// Immunities
			//string val = string.Join(", ", getImmunities().ToArray()).Trim();
			//if (!string.IsNullOrEmpty(val)) { statblock.Topstats.Propertyline.Add(new Propertyline("Immunities", val)); }

			//// Resistances
			//val = string.Join(", ", getResistances().ToArray()).Trim();
			//if (!string.IsNullOrEmpty(val)) { statblock.Topstats.Propertyline.Add(new Propertyline("Resistances", val)); }

			//// Weaknesses
			//val = string.Join(", ", getWeaknesses().ToArray()).Trim();
			//if (!string.IsNullOrEmpty(val)) { statblock.Topstats.Propertyline.Add(new Propertyline("Weaknesses", val)); }

			//// Saves
			//List<string> saves = new List<string>();
			//foreach (string key in getSaves().Keys)
			//{
			//	getSaves().TryGetValue(key, out val);
			//	saves.Add(key + " (" + val + ")");
			//}
			//val = string.Join(" ", saves.ToArray()).Trim();
			//if (!string.IsNullOrEmpty(val)) { statblock.Topstats.Propertyline.Add(new Propertyline("Saves", val)); }

			//// Senses
			//val = string.Join(", ", getSenses().ToArray()).Trim();
			//if (!string.IsNullOrEmpty(val)) { statblock.Topstats.Propertyline.Add(new Propertyline("Senses", val)); }

			//// Languages
			//val = string.Join(", ", getLanguages().ToArray());
			//if (!string.IsNullOrEmpty(val)) { statblock.Topstats.Propertyline.Add(new Propertyline("Languages", val)); }

			//// Challenge Rating
			//if (!string.IsNullOrEmpty(getCR()))
			//{
			//	statblock.Topstats.Propertyline.Add(new Propertyline("Challenge", getCR() + "(" + getXPAward() + ")"));
			//}

			//// Actions
			//statblock.H3 = "Actions";
			//statblock.Propertyblock = new List<Propertyblock>();

			//// Special
			//foreach (string key in getSpecial().Keys)
			//{
			//	getSpecial().TryGetValue(key, out val);
			//	statblock.Propertyblock.Add(new Propertyblock(key, val));
			//}

			//// Weapons
			//foreach (Weapon wp in getWeapons())
			//{
			//	StringBuilder sb = new StringBuilder();
			//	sb.Append(wp.Name);
			//	sb.Append(": ");
			//	sb.Append(wp.Attack);
			//	sb.Append(" to hit, Hit: ");
			//	sb.Append(wp.Damage);

			//	statblock.Propertyblock.Add(new Propertyblock(wp.Name, sb.ToString()));

			//}

			//XmlSerializer serializer = new XmlSerializer(typeof(Statblock5e));
			//StringWriter sw = new StringWriter();
			//XmlTextWriter tw = new XmlTextWriter(sw);
			//serializer.Serialize(tw, statblock);

			// return sw.ToString();

			return string.Empty;
		}

		#endregion

	}

}
