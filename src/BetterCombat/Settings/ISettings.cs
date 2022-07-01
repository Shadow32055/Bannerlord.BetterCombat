namespace BetterCombat.Settings {
    public interface ISettings {
        
        bool PlayerPercentHealthPerLevel { get; set; }
        float PlayerPercent { get; set; }
        bool PlayerFlatHealthPerLevel { get; set; }
        float PlayerFlatAmount { get; set; }
        bool HeroPercentHealthPerLevel { get; set; }
        float HeroPercent { get; set; }
        bool HeroFlatHealthPerLevel { get; set; }
        float HeroFlatAmount { get; set; }
        float TroopHealthAthletics { get; set; }
        bool TroopPercentHealthPerLevel { get; set; }
        float TroopPercent { get; set; }
        bool TroopFlatHealthPerLevel { get; set; }
        float TroopFlatAmount { get; set; }
        bool HealthOnHitEnabled { get; set; }
        float PlayerPercentHealthOnHit { get; set; }
        float PlayerMinHealthOnHit { get; set; }
        float PlayerMaxHealthOnHit { get; set; }
        bool BandageEnabled { get; set; }
        int BandageAmount { get; set; }
        float BandageHealAmount { get; set; }
        float BandageTime { get; set; }
        string BandageKey { get; set; }
        bool HealingLimit { get; set; }
        float HealingAmount { get; set; }
        bool HealthRegenEnabled { get; set; }
        float CampaignHealthRegenMultiplier { get; set; }
        float PlayerHealthRegenAmount { get; set; }
        float PlayerHealthRegenInterval { get; set; }
        float PlayerRegenDamageDelay { get; set; }
        bool ShrugOffBlow { get; set; }
        bool PreventKnockdown { get; set; }
        bool MutliHitTwoHanded { get; set; }
        bool MutliHitOneHanded { get; set; }
        bool CutThroughActive { get; set; }
        bool CutThroughPlayerOnly { get; set; }
        float CutThroughChance { get; set; }
        bool PerventFleeing { get; set; }
        float FleeingChance { get; set; }
    }
}
