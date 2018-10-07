using Newtonsoft.Json;
using System.Collections.Generic;

namespace CampaignKit.PortfolioImporter.Entities.SRDPathfinder
{

	public class Spell
    {   
        [JsonProperty(PropertyName="spell-like abilities")]
        public string SpelllikeAbilities { get; set; }

        [JsonProperty(PropertyName="spells prepared")]
        public string SpellsPrepared { get; set; }
    }

    public class Section
    {

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "subtype")]
        public string Subtype { get; set; }

        [JsonProperty(PropertyName = "sections")]
        public List<Section> Sections { get; set; }
    }

    public class SRDPathfinderMonster
    {

        [JsonProperty(PropertyName = "dexterity")]
        public string Dexterity { get; set; }

        [JsonProperty(PropertyName = "ac")]
        public string AC { get; set; }

        [JsonProperty(PropertyName = "special_attacks")]
        public string SpecialAttacks { get; set; }

        [JsonProperty(PropertyName = "intelligence")]
        public string Intelligence { get; set; }

        [JsonProperty(PropertyName = "racial_modifiers")]
        public string RacialModifiers { get; set; }

        [JsonProperty(PropertyName = "sex")]
        public string Sex { get; set; }

        [JsonProperty(PropertyName = "melee")]
        public string Melee { get; set; }

        [JsonProperty(PropertyName = "cr")]
        public string CR { get; set; }

        [JsonProperty(PropertyName = "xp")]
        public string XP { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public string Speed { get; set; }

        [JsonProperty(PropertyName = "alignment")]
        public string Alignment { get; set; }

        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }

        [JsonProperty(PropertyName = "strength")]
        public string Strength { get; set; }

        [JsonProperty(PropertyName = "constitution")]
        public string Constitution { get; set; }

        [JsonProperty(PropertyName = "immune")]
        public string Immune { get; set; }

        [JsonProperty(PropertyName = "ranged")]
        public string Ranged { get; set; }

        [JsonProperty(PropertyName = "init")]
        public string Init { get; set; }

        [JsonProperty(PropertyName = "languages")]
        public string Languages { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "charisma")]
        public string Charisma { get; set; }

        [JsonProperty(PropertyName = "fortitude")]
        public string Fortitude { get; set; }

        [JsonProperty(PropertyName = "spells")]
        public List<Spell> Spells { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "feats")]
        public string Feats { get; set; }

        [JsonProperty(PropertyName = "senses")]
        public string Senses { get; set; }

        [JsonProperty(PropertyName = "gear")]
        public string Gear { get; set; }

        [JsonProperty(PropertyName = "sections")]
        public List<Section> Sections { get; set; }

        [JsonProperty(PropertyName = "hp")]
        public string HP { get; set; }

        [JsonProperty(PropertyName = "weaknesses")]
        public string Weaknesses { get; set; }

        [JsonProperty(PropertyName = "wisdom")]
        public string Wisdom { get; set; }

        [JsonProperty(PropertyName = "creature_type")]
        public string CreatureType { get; set; }

        [JsonProperty(PropertyName = "special_qualities")]
        public string SpecialQualities { get; set; }

        [JsonProperty(PropertyName = "base_attack")]
        public string BaseAttack { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }

        [JsonProperty(PropertyName = "skills")]
        public string Skills { get; set; }

        [JsonProperty(PropertyName = "reflex")]
        public string Reflex { get; set; }

        [JsonProperty(PropertyName = "cmd")]
        public string CMD { get; set; }

        [JsonProperty(PropertyName = "cmb")]
        public string CMB { get; set; }

        [JsonProperty(PropertyName = "will")]
        public string Will { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; }

        [JsonProperty(PropertyName = "sr")]
        public string SR { get; set; }

        [JsonProperty(PropertyName = "creature_subtype")]
        public string CreatureSubtype { get; set; }
    }

}
