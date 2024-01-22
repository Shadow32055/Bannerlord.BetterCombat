using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterCombat.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {



        /// <summary>
        /// LIFE STEAL
        /// </summary>

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.LifeStealHeader)]
        [SettingPropertyBool(Strings.HealHitText, IsToggle = true, Order = 0, RequireRestart = false, HintText = Strings.HealHitHint)]
        public bool HealthOnHitEnabled { get; set; } = false;

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.LifeStealHeader)]
        [SettingPropertyFloatingInteger(Strings.HealHitPercentText, 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.HealHitPercentHint)]
        public float PlayerPercentHealthOnHit { get; set; } = 0;

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.LifeStealHeader)]
        [SettingPropertyFloatingInteger(Strings.HealHitMinText, 0f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = Strings.HealHitMinHint)]
        public float PlayerMinHealthOnHit { get; set; } = 0;

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.LifeStealHeader)]
        [SettingPropertyFloatingInteger(Strings.HealHitMaxText, 0f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = Strings.HealHitMaxHint)]
        public float PlayerMaxHealthOnHit { get; set; } = 1000;


        /// <summary>
        /// HEALING LIMIT
        /// </summary>

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.HealingLimitHeader)]
        [SettingPropertyBool(Strings.HealingLimitText, IsToggle = true, Order = 0, RequireRestart = false, HintText = Strings.HealingLimitHint)]
        public bool HealingLimit { get; set; } = false;

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.HealingLimitHeader)]
        [SettingPropertyFloatingInteger(Strings.HealingAmountText, 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.HealingAmountHint)]
        public float HealingThreshold { get; set; } = 0;

        /// <summary>
        /// REGENERATION
        /// </summary>

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.RegenHeader)]
        [SettingPropertyBool(Strings.RegenerationText, IsToggle = true, Order = 0, RequireRestart = false, HintText = Strings.RegenerationHint)]
        public bool HealthRegenEnabled { get; set; } = false;

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.RegenHeader)]
        [SettingPropertyFloatingInteger(Strings.RegenAmountText, 0f, 300f, "0.0 HP", Order = 0, RequireRestart = false, HintText = Strings.RegenAmountHint)]
        public float PlayerHealthRegenAmount { get; set; } = 0;

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.RegenHeader)]
        [SettingPropertyFloatingInteger(Strings.RegenIntervalText, 1f, 120f, "0.0 " + Strings.SecondsValue, Order = 0, RequireRestart = false, HintText = Strings.RegenIntervalHint)]
        public float PlayerHealthRegenInterval { get; set; } = 1;

        [SettingPropertyGroup(Strings.HealingHeader + "/" + Strings.RegenHeader)]
        [SettingPropertyFloatingInteger(Strings.RegenDelayText, 1f, 120f, "0.0 " + Strings.SecondsValue, Order = 0, RequireRestart = false, HintText = Strings.RegenDelayHint)]
        public float PlayerRegenDamageDelay { get; set; } = 1;

        /// <summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>



        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.InterruptHeader)]
        [SettingPropertyBool(Strings.ShrugOffText, Order = 0, RequireRestart = false, HintText = Strings.ShrugOffHint)]
        public bool ShrugOffBlow { get; set; } = false;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.InterruptHeader)]
        [SettingPropertyBool(Strings.KnockdownText, Order = 0, RequireRestart = false, HintText = Strings.KnockdownHint)]
        public bool PreventKnockdown { get; set; } = false;



        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.MultiHitHeader)]
        [SettingPropertyBool(Strings.TwoHandedText, Order = 0, RequireRestart = false, HintText = Strings.TwoHandedHint)]
        public bool MultiHitTwoHanded { get; set; } = false;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.MultiHitHeader)]
        [SettingPropertyBool(Strings.OneHandedText, Order = 0, RequireRestart = false, HintText = Strings.OneHandedHint)]
        public bool MultiHitOneHanded { get; set; } = false;



        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.SliceText)]
        [SettingPropertyBool(Strings.SliceText, Order = 0, IsToggle = true, RequireRestart = false, HintText = Strings.SliceHint)]
        public bool SliceThroughActive { get; set; } = false;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.SliceText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool SliceThroughPlayerOnly { get; set; } = false;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.SliceText)]
        [SettingPropertyFloatingInteger(Strings.ChanceText, 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.ChanceHint)]
        public float SliceThroughChance { get; set; } = .50f;

        

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.CrushText)]
        [SettingPropertyBool(Strings.CrushText, Order = 0, IsToggle = true, RequireRestart = false, HintText = Strings.CrushHint)]
        public bool CrushThroughActive { get; set; } = false;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.CrushText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool CrushThroughPlayerOnly { get; set; } = false;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.CrushText)]
        [SettingPropertyFloatingInteger(Strings.ChanceText, 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.ChanceHint)]
        public float CrushThroughChance { get; set; } = .50f;



        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.FleeingHeader)]
        [SettingPropertyBool(Strings.FleeText, Order = 0, IsToggle = true, RequireRestart = false, HintText = Strings.FleeHint)]
        public bool EnableFleeing { get; set; } = false;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.FleeingHeader)]
        [SettingPropertyFloatingInteger(Strings.FleeChanceText, 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = Strings.FleeChanceHint)]
        public float FleeingChance { get; set; } = .50f;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.FleeingHeader)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool FleeingPlayerOnly { get; set; } = false;



        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.FriendlyFireText)]
        [SettingPropertyBool(Strings.FriendlyFireText, Order = 0, RequireRestart = false, HintText = Strings.FriendlyFireHint)]
        public bool EnableFriendlyFire { get; set; } = true;

        [SettingPropertyGroup(Strings.CombatHeader + "/" + Strings.FriendlyFireText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool FriendlyFirePlayerOnly { get; set; } = true;





        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
    }
}
