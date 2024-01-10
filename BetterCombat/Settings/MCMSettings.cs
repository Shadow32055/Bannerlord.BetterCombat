using BetterCombat.Localizations;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterCombat.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {



        /// <summary>
        /// LIFE STEAL
        /// </summary>

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.LifeStealHeader)]
        [SettingPropertyBool(RefValues.HealHitText, IsToggle = true, Order = 0, RequireRestart = false, HintText = RefValues.HealHitHint)]
        public bool HealthOnHitEnabled { get; set; } = false;

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.LifeStealHeader)]
        [SettingPropertyFloatingInteger(RefValues.HealHitPercentText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = RefValues.HealHitPercentHint)]
        public float PlayerPercentHealthOnHit { get; set; } = 0;

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.LifeStealHeader)]
        [SettingPropertyFloatingInteger(RefValues.HealHitMinText, 0f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = RefValues.HealHitMinHint)]
        public float PlayerMinHealthOnHit { get; set; } = 0;

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.LifeStealHeader)]
        [SettingPropertyFloatingInteger(RefValues.HealHitMaxText, 0f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = RefValues.HealHitMaxHint)]
        public float PlayerMaxHealthOnHit { get; set; } = 1000;


        /// <summary>
        /// HEALING LIMIT
        /// </summary>

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.HealingLimitHeader)]
        [SettingPropertyBool(RefValues.HealingLimitText, IsToggle = true, Order = 0, RequireRestart = false, HintText = RefValues.HealingLimitHint)]
        public bool HealingLimit { get; set; } = false;

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.HealingLimitHeader)]
        [SettingPropertyFloatingInteger(RefValues.HealingAmountText, 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = RefValues.HealingAmountHint)]
        public float HealingThreshold { get; set; } = 0;

        /// <summary>
        /// REGENERATION
        /// </summary>

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.RegenHeader)]
        [SettingPropertyBool(RefValues.RegenerationText, IsToggle = true, Order = 0, RequireRestart = false, HintText = RefValues.RegenerationHint)]
        public bool HealthRegenEnabled { get; set; } = false;

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.RegenHeader)]
        [SettingPropertyFloatingInteger(RefValues.RegenAmountText, 0f, 300f, "0.0 HP", Order = 0, RequireRestart = false, HintText = RefValues.RegenAmountHint)]
        public float PlayerHealthRegenAmount { get; set; } = 0;

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.RegenHeader)]
        [SettingPropertyFloatingInteger(RefValues.RegenIntervalText, 1f, 120f, "0.0 " + RefValues.SecondsValue, Order = 0, RequireRestart = false, HintText = RefValues.RegenIntervalHint)]
        public float PlayerHealthRegenInterval { get; set; } = 1;

        [SettingPropertyGroup(RefValues.HealingHeader + "/" + RefValues.RegenHeader)]
        [SettingPropertyFloatingInteger(RefValues.RegenDelayText, 1f, 120f, "0.0 " + RefValues.SecondsValue, Order = 0, RequireRestart = false, HintText = RefValues.RegenDelayHint)]
        public float PlayerRegenDamageDelay { get; set; } = 1;

        /// <summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>



        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.InterruptHeader)]
        [SettingPropertyBool(RefValues.ShrugOffText, Order = 0, RequireRestart = false, HintText = RefValues.ShrugOffHint)]
        public bool ShrugOffBlow { get; set; } = false;

        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.InterruptHeader)]
        [SettingPropertyBool(RefValues.KnockdownText, Order = 0, RequireRestart = false, HintText = RefValues.KnockdownHint)]
        public bool PreventKnockdown { get; set; } = false;



        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.MultiHitHeader)]
        [SettingPropertyBool(RefValues.TwoHandedText, Order = 0, RequireRestart = false, HintText = RefValues.TwoHandedHint)]
        public bool MutliHitTwoHanded { get; set; } = false;

        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.MultiHitHeader)]
        [SettingPropertyBool(RefValues.OneHandedText, Order = 0, RequireRestart = false, HintText = RefValues.OneHandedHint)]
        public bool MutliHitOneHanded { get; set; } = false;



        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.SliceHeader)]
        [SettingPropertyBool(RefValues.SliceText, Order = 0, IsToggle = true, RequireRestart = false, HintText = RefValues.SliceHint)]
        public bool CutThroughActive { get; set; } = false;

        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.SliceHeader)]
        [SettingPropertyBool(RefValues.SlicePlayerText, Order = 0, RequireRestart = false, HintText = RefValues.SlicePlayerHint)]
        public bool CutThroughPlayerOnly { get; set; } = false;



        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.FleeingHeader)]
        [SettingPropertyBool(RefValues.FleeText, Order = 0, RequireRestart = false, HintText = RefValues.FleeHint)]
        public bool PerventFleeing { get; set; } = false;

        [SettingPropertyGroup(RefValues.CombatHeader + "/" + RefValues.FleeingHeader)]
        [SettingPropertyFloatingInteger(RefValues.FleeChanceText, 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = RefValues.FleeChanceHint)]
        public float FleeingChance { get; set; } = .50f;



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
