using System.Collections.Generic;

using Newtonsoft.Json;

namespace CampaignKit.PortfolioImporter.Entities.SRD5e
{
    public class SpecialAbility
    {
        #region Properties

        [JsonProperty(PropertyName = "attack_bonus")]
        public int AttackBonus { get; set; }

        [JsonProperty(PropertyName = "damage_dice")]
        public string DamageDice { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion
    }

    public class Action
    {
        #region Properties

        [JsonProperty(PropertyName = "attack_bonus")]
        public int AttackBonus { get; set; }

        [JsonProperty(PropertyName = "damage_bonus")]
        public int? DamageBonus { get; set; }

        [JsonProperty(PropertyName = "damage_dice")]
        public string DamageDice { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion
    }

    public class LegendaryAction
    {
        #region Properties

        [JsonProperty(PropertyName = "attack_bonus")]
        public int AttackBonus { get; set; }

        [JsonProperty(PropertyName = "damage_dice")]
        public string DamageDice { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion
    }

    public class Reaction
    {
        #region Properties

        [JsonProperty(PropertyName = "attack_bonus")]
        public int AttackBonus { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        #endregion
    }

    // ReSharper disable once InconsistentNaming
    public class SRD5eMonster
    {
        #region Properties

        [JsonProperty(PropertyName = "acrobatics")]
        public int? Acrobatics { get; set; }

        [JsonProperty(PropertyName = "actions")]
        public List<Action> Actions { get; set; }

        [JsonProperty(PropertyName = "alignment")]
        public string Alignment { get; set; }

        [JsonProperty(PropertyName = "arcana")]
        public int? Arcana { get; set; }

        [JsonProperty(PropertyName = "armor_class")]
        public int ArmorClass { get; set; }

        [JsonProperty(PropertyName = "athletics")]
        public int? Athletics { get; set; }

        [JsonProperty(PropertyName = "challenge_rating")]
        public double ChallengeRating { get; set; }

        [JsonProperty(PropertyName = "charisma")]
        public int? Charisma { get; set; }

        [JsonProperty(PropertyName = "charisma_save")]
        public int? CharismaSave { get; set; }

        [JsonProperty(PropertyName = "condition_immunities")]
        public string ConditionImmunities { get; set; }

        [JsonProperty(PropertyName = "constitution")]
        public int Constitution { get; set; }

        [JsonProperty(PropertyName = "constitution_save")]
        public int ConstitutionSave { get; set; }

        [JsonProperty(PropertyName = "damage_immunities")]
        public string DamageImmunities { get; set; }

        [JsonProperty(PropertyName = "damage_resistances")]
        public string DamageResistances { get; set; }

        [JsonProperty(PropertyName = "damage_vulnerabilities")]
        public string DamageVulnerabilities { get; set; }

        [JsonProperty(PropertyName = "deception")]
        public int? Deception { get; set; }

        [JsonProperty(PropertyName = "dexterity")]
        public int Dexterity { get; set; }

        [JsonProperty(PropertyName = "dexterity_save")]
        public int? DexteritySave { get; set; }

        [JsonProperty(PropertyName = "history")]
        public int History { get; set; }

        [JsonProperty(PropertyName = "hit_dice")]
        public string HitDice { get; set; }

        [JsonProperty(PropertyName = "hit_points")]
        public int HitPoints { get; set; }

        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; }

        [JsonProperty(PropertyName = "insight")]
        public int? Insight { get; set; }

        [JsonProperty(PropertyName = "intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty(PropertyName = "intelligence_save")]
        public int IntelligenceSave { get; set; }

        [JsonProperty(PropertyName = "intimidation")]
        public int? Intimidation { get; set; }

        [JsonProperty(PropertyName = "investigation")]
        public int? Investigation { get; set; }

        [JsonProperty(PropertyName = "languages")]
        public string Languages { get; set; }

        [JsonProperty(PropertyName = "legendary_actions")]
        public List<LegendaryAction> LegendaryActions { get; set; }

        [JsonProperty(PropertyName = "medicine")]
        public int? Medicine { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "nature")]
        public int? Nature { get; set; }

        [JsonProperty(PropertyName = "perception")]
        public int Perception { get; set; }

        [JsonProperty(PropertyName = "performance")]
        public int? Performance { get; set; }

        [JsonProperty(PropertyName = "persuasion")]
        public int? Persuasion { get; set; }

        [JsonProperty(PropertyName = "reactions")]
        public List<Reaction> Reactions { get; set; }

        [JsonProperty(PropertyName = "religion")]
        public int? Religion { get; set; }

        [JsonProperty(PropertyName = "senses")]
        public string Senses { get; set; }

        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }

        [JsonProperty(PropertyName = "special_abilities")]
        public List<SpecialAbility> SpecialAbilities { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public string Speed { get; set; }

        [JsonProperty(PropertyName = "stealth")]
        public int? Stealth { get; set; }

        [JsonProperty(PropertyName = "strength")]
        public int Strength { get; set; }

        [JsonProperty(PropertyName = "strength_save")]
        // ReSharper disable once InconsistentNaming
        public int? Strength_save { get; set; }

        [JsonProperty(PropertyName = "subtype")]
        public string Subtype { get; set; }

        [JsonProperty(PropertyName = "survival")]
        public int? Survival { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "url")]
        // ReSharper disable once InconsistentNaming
        public string URL { get; set; }

        [JsonProperty(PropertyName = "wisdom")]
        public int Wisdom { get; set; }

        [JsonProperty(PropertyName = "wisdom_save")]
        public int WisdomSave { get; set; }

        #endregion
    }
}