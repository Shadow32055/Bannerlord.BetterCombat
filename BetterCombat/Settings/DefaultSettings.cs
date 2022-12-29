namespace BetterCombat.Settings {
    public class DefaultSettings : ISettings {
        public float CampaignHealthRegenMultiplier { get; set; } = 1;
        public bool PlayerPercentHealthPerLevel { get; set; } = false;
        public float PlayerPercent { get; set; } = 0;
        public bool PlayerFlatHealthPerLevel { get; set; } = false;
        public float PlayerFlatAmount { get; set; } = 0;
        public bool HeroPercentHealthPerLevel { get; set; } = false;
        public float HeroPercent { get; set; } = 0;
        public bool HeroFlatHealthPerLevel { get; set; } = false;
        public float HeroFlatAmount { get; set; } = 0;
        public float TroopHealthAthletics { get; set; } = 0;
        public bool TroopPercentHealthPerLevel { get; set; } = false;
        public float TroopPercent { get; set; } = 0;
        public bool TroopFlatHealthPerLevel { get; set; } = false;
        public float TroopFlatAmount { get; set; } = 0;
        public bool HealthOnHitEnabled { get; set; } = false;
        public float PlayerPercentHealthOnHit { get; set; } = 0;
        public float PlayerMinHealthOnHit { get; set; } = 0;
        public float PlayerMaxHealthOnHit { get; set; } = 1000;
        public bool BandageEnabled { get; set; } = false;
        public int BandageAmount { get; set; } = 1;
        public float BandageHealAmount { get; set; } = 1;
        public float BandageTime { get; set; } = 0;
        public string BandageKey { get; set; } = "Q";
        public bool HealingLimit { get; set; } = false;
        public float HealingAmount { get; set; } = 0;
        public bool HealthRegenEnabled { get; set; } = false;
        public float PlayerHealthRegenAmount { get; set; } = 0;
        public float PlayerHealthRegenInterval { get; set; } = 1;
        public float PlayerRegenDamageDelay { get; set; } = 1;
        public bool ShrugOffBlow { get; set; } = false;
        public bool PreventKnockdown { get; set; } = false;
        public bool MutliHitTwoHanded { get; set; } = false;
        public bool MutliHitOneHanded { get; set; } = false;
        public bool CutThroughActive { get; set; } = false;
        public bool CutThroughPlayerOnly { get; set; } = false;
        public float CutThroughChance { get; set; } = 0.02f;
        public bool PerventFleeing { get; set; } = false;
        public float FleeingChance { get; set; } = .5f;
    }
}
