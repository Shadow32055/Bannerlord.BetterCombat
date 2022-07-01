using System;
using System.Collections.Generic;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v1;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base;
using MCM.Abstractions.Settings.Base.Global;

namespace BetterCombat.Settings {
    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettings {

        const string healthAdjustHeader = "{=BC_dcTZTc}Health Adjustments";
        const string playerHeader = "{=BC_WSwISD}Player";
        const string heroesHeader = "{=BC_Y3b3aj}Heroes";
        const string troopsHeader = "{=BC_9ChrRZ}Troops";
        const string percentHeader = "{=BC_iQO7dg}Percent";
        const string flatHeader = "{=BC_svyNju}Flat";
        const string campRegenHeader = "{=BC_my4drh}Campaign Regen";

        /// <summary>
        /// PLAYER
        /// </summary>

        [SettingPropertyGroup(healthAdjustHeader + "/" + campRegenHeader)]
        [SettingPropertyFloatingInteger("{=BC_AN0I1h}Campaign Health Regen Multiplier", 0f, 1000f, "0.0 x", Order = 0, RequireRestart = false, HintText = "{=BC_20Rrad}Multiplier for the amount of health restored each hour (I think?) out of battle (on campaign map). Zero disables healing outside of battles.")]
        public float CampaignHealthRegenMultiplier { get; set; } = 1;

        [SettingPropertyGroup(healthAdjustHeader + "/" +  playerHeader + "/" + percentHeader)]
        [SettingPropertyBool("{=BC_GLbKVu}Percent Health per Level", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_VXzieI}Increase of health per level as percent")]
        public bool PlayerPercentHealthPerLevel { get; set; } = false;

        [SettingPropertyGroup(healthAdjustHeader + "/" + playerHeader + "/" + percentHeader)]
        [SettingPropertyFloatingInteger("{=BC_irO3ih}Percent", 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_4XIzLW}Increase of health per level as percent")]
        public float PlayerPercent { get; set; } = 0;

        [SettingPropertyGroup(healthAdjustHeader + "/" + playerHeader + "/" + flatHeader)]
        [SettingPropertyBool("{=BC_X2bMDl}Flat Health per Level", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_b34y4o}Increase of health per level as flat amount")]
        public bool PlayerFlatHealthPerLevel { get; set; } = false;

        [SettingPropertyGroup(healthAdjustHeader + "/" + playerHeader + "/" + flatHeader)]
        [SettingPropertyFloatingInteger("{=BC_sgsgLw}Flat Amount", 1f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_otgBbg}Increase of health per level as flat amount")]
        public float PlayerFlatAmount { get; set; } = 0;

        /// <summary>
        /// HEROES
        /// </summary>

        [SettingPropertyGroup(healthAdjustHeader + "/" + heroesHeader + "/" + percentHeader)]
        [SettingPropertyBool("{=BC_6c8ZVc}Percent Health per Level", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_FDPiPM}Increase of health per level as percent")]
        public bool HeroPercentHealthPerLevel { get; set; } = false;

        [SettingPropertyGroup(healthAdjustHeader + "/" + heroesHeader + "/" + percentHeader)]
        [SettingPropertyFloatingInteger("{=BC_5v5KiC}Percent", 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_gdQjpc}Increase of health per level as percent")]
        public float HeroPercent { get; set; } = 0;

        [SettingPropertyGroup(healthAdjustHeader + "/" + heroesHeader + "/" + flatHeader)]
        [SettingPropertyBool("{=BC_Nz1V9j}Flat Health per Level", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_zTrqoY}Increase of health per level as flat amount")]
        public bool HeroFlatHealthPerLevel { get; set; } = false;

        [SettingPropertyGroup(healthAdjustHeader + "/" + heroesHeader + "/" + flatHeader)]
        [SettingPropertyFloatingInteger("{=BC_bstg46}Flat Amount", 1f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_IGWiSJ}Increase of health per level as flat amount")]
        public float HeroFlatAmount { get; set; } = 0;

        /// <summary>
        /// TROOPS
        /// </summary>

        [SettingPropertyGroup(healthAdjustHeader + "/" + troopsHeader)]
        [SettingPropertyFloatingInteger("{=BC_Suq0vt}Health from Athletics", 0f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_gBBK3L}Increase of health per point of athletics")]
        public float TroopHealthAthletics { get; set; } = 0;

        [SettingPropertyGroup(healthAdjustHeader + "/" + troopsHeader + "/" + percentHeader)]
        [SettingPropertyBool("{=BC_00jcfx}Percent Health per Level", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_7DZ5hW}Increase of health per level as percent")]
        public bool TroopPercentHealthPerLevel { get; set; } = false;

        [SettingPropertyGroup(healthAdjustHeader + "/" + troopsHeader + "/" + percentHeader)]
        [SettingPropertyFloatingInteger("{=BC_20yQKJ}Percent", 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_T0Ooeh}Increase of health per level as percent")]
        public float TroopPercent { get; set; } = 0;

        [SettingPropertyGroup(healthAdjustHeader + "/" + troopsHeader + "/" + flatHeader)]
        [SettingPropertyBool("{=BC_QGqnjW}Flat Health per Level", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_imb8dh}Increase of health per level as flat amount")]
        public bool TroopFlatHealthPerLevel { get; set; } = false;

        [SettingPropertyGroup(healthAdjustHeader + "/" + troopsHeader + "/" + flatHeader)]
        [SettingPropertyFloatingInteger("{=BC_LbmQFL}Flat Amount", 1f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_zEYhaj}Increase of health per level as flat amount")]
        public float TroopFlatAmount { get; set; } = 0;

        /// <summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        const string healingHeader = "{=BC_T1ldYr}Healing";
        const string lifeStealHeader = "{=BC_vswqsP}Lifesteal";
        const string bandageHeader = "{=BC_wj2XMD}Bandages";
        const string healingLimitHeader = "{=BC_Qui3WS}Healing Limit";
        const string regenHeader = "{=BC_FiUuOv}Regeneration";

        /// <summary>
        /// LIFE STEAL
        /// </summary>

        [SettingPropertyGroup(healingHeader + "/" + lifeStealHeader)]
        [SettingPropertyBool("{=BC_licHNP}Heal On Hit", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_xACH0R}Integration of nemoofnemo's mod 'Heal on hit'")]
        public bool HealthOnHitEnabled { get; set; } = false;

        [SettingPropertyGroup(healingHeader + "/" + lifeStealHeader)]
        [SettingPropertyFloatingInteger("{=BC_QoOgnb}Percent Health Return", 0.01f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_jNQdIU}Percentage of damage dealt to be returned as health.")]
        public float PlayerPercentHealthOnHit { get; set; } = 0;

        [SettingPropertyGroup(healingHeader + "/" + lifeStealHeader)]
        [SettingPropertyFloatingInteger("{=BC_Pv8jKZ}Minimum Health Return", 0f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_U7yfNX}Minimum health to return each hit.")]
        public float PlayerMinHealthOnHit { get; set; } = 0;

        [SettingPropertyGroup(healingHeader + "/" + lifeStealHeader)]
        [SettingPropertyFloatingInteger("{=BC_7F1hBJ}Maximum Health Return", 0f, 1000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_Yom4eb}Maximum health to return each hit.")]
        public float PlayerMaxHealthOnHit { get; set; } = 1000;

        /// <summary>
        /// BANDAGES
        /// </summary>

        [SettingPropertyGroup(healingHeader + "/" + bandageHeader)]
        [SettingPropertyBool("{=BC_Ljnvjd}Enable Bandages", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_l4xYCv}Whether player can use bandages on battlefield")]
        public bool BandageEnabled { get; set; } = false;

        [SettingPropertyGroup(healingHeader + "/" + bandageHeader)]
        [SettingPropertyInteger("{=BC_WI3k5M}Number of Bandages", 1, 100, "0 {=BC_wj2XMD}Bandages", Order = 0, RequireRestart = false, HintText = "{=BC_AuTuGq}Number of bandages for use each mission")]
        public int BandageAmount { get; set; } = 1;

        [SettingPropertyGroup(healingHeader + "/" + bandageHeader)]
        [SettingPropertyFloatingInteger("{=BC_kKKj82}Health Per Bandage", 1f, 300f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_Z7T6KB}How much health each bandage applies")]
        public float BandageHealAmount { get; set; } = 1;

        [SettingPropertyGroup(healingHeader + "/" + bandageHeader)]
        [SettingPropertyFloatingInteger("{=BC_L2llEt}Bandage Time", 0f, 60f, "0.0 {=BC_mIjl1T}Seconds", Order = 0, RequireRestart = false, HintText = "{=BC_IdToPT}How long it takes to bandage, can't move during this time")]
        public float BandageTime { get; set; } = 0;

        [SettingPropertyGroup(healingHeader + "/" + bandageHeader)]
        [SettingProperty("{=BC_MfXZnQ}Bandage Key", Order = 0, RequireRestart = true, HintText = "{=BC_19RaR4}What key to use for Bandages. Examples 'Q', 'Numpad0'")]
        public string BandageKey { get; set; } = "Q";

        /// <summary>
        /// HEALING LIMIT
        /// </summary>

        [SettingPropertyGroup(healingHeader + "/" + healingLimitHeader)]
        [SettingPropertyBool("{=BC_XHBWnA}Healing Limit", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_JzNe5x}Limit on the amount of healing possible each battle")]
        public bool HealingLimit { get; set; } = false;

        [SettingPropertyGroup(healingHeader + "/" + healingLimitHeader)]
        [SettingPropertyFloatingInteger("{=BC_pWvBgz}Healing Amount", 0f, 10000f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_auAAgh}Amount of health that can be restored each battle")]
        public float HealingAmount { get; set; } = 0;

        /// <summary>
        /// REGENERATION
        /// </summary>

        [SettingPropertyGroup(healingHeader + "/" + regenHeader)]
        [SettingPropertyBool("{=BC_RpREOe}Passive Regeneration", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_j9krAw}Integration of Jeffear's mod 'Combat Health Regen for Player and Mount'")]
        public bool HealthRegenEnabled { get; set; } = false;

        [SettingPropertyGroup(healingHeader + "/" + regenHeader)]
        [SettingPropertyFloatingInteger("{=BC_9ggXgX}Player Health Regen Amount", 0f, 300f, "0.0 HP", Order = 0, RequireRestart = false, HintText = "{=BC_uVlRMg}Health restored each regeneration")]
        public float PlayerHealthRegenAmount { get; set; } = 0;

        [SettingPropertyGroup(healingHeader + "/" + regenHeader)]
        [SettingPropertyFloatingInteger("{=BC_nyPRtj}Player Health Regen Interval", 1f, 120f, "0.0 {=BC_mIjl1T}Seconds", Order = 0, RequireRestart = false, HintText = "{=BC_2hoYrw}Time between each regeneration")]
        public float PlayerHealthRegenInterval { get; set; } = 1;

        [SettingPropertyGroup(healingHeader + "/" + regenHeader)]
        [SettingPropertyFloatingInteger("{=BC_MNHBnI}Player Regen Damage Delay", 1f, 120f, "0.0 {=BC_mIjl1T}Seconds", Order = 0, RequireRestart = false, HintText = "{=BC_ZkbaIF}Time until next heal after damage")]
        public float PlayerRegenDamageDelay { get; set; } = 1;

        /// <summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        const string combatHeader = "{=BC_doG96p}Combat Adjustments";
        const string interruptHeader = "{=BC_QiQdsa}Interrupt";
        const string multiHitHeader = "{=BC_eE2pN7}Hit Multiple Targets";
        const string sliceHeader = "{=BC_ctf4YT}Slice Through";
        const string fleeingHeader = "{=BC_g3ktYT}Fleeing";


        [SettingPropertyGroup(combatHeader + "/" + interruptHeader)]
        [SettingPropertyBool("{=BC_P7uAXC}Player Shrug Off Blow", Order = 0, RequireRestart = false, HintText = "{=BC_HIiVJT}Whether the player can shrug off blows")]
        public bool ShrugOffBlow { get; set; } = false;

        [SettingPropertyGroup(combatHeader + "/" + interruptHeader)]
        [SettingPropertyBool("{=BC_pevCBh}Prevent Player Knockdown", Order = 0, RequireRestart = false, HintText = "{=BC_Qahm4a}Whether the player can be knocked down")]
        public bool PreventKnockdown { get; set; } = false;


        [SettingPropertyGroup(combatHeader + "/" + multiHitHeader)]
        [SettingPropertyBool("{=BC_QcnUvW}All Two Handed Weapons", Order = 0, RequireRestart = false, HintText = "{=BC_Pzd6yj}Whether weapons can hit multiple targets. Slowing down momentum with each target hit (reducing damage). (Active for all)")]
        public bool MutliHitTwoHanded { get; set; } = false;

        [SettingPropertyGroup(combatHeader + "/" + multiHitHeader)]
        [SettingPropertyBool("{=BC_ou9xlu}All One handed Weapons", Order = 0, RequireRestart = false, HintText = "{=BC_op9z9z}Whether weapons can hit multiple targets. Slowing down momentum with each target hit (reducing damage). (Active for all)")]
        public bool MutliHitOneHanded { get; set; } = false;


        [SettingPropertyGroup(combatHeader + "/" + sliceHeader)]
        [SettingPropertyBool("{=BC_h1h5go}Slice Through", Order = 0, IsToggle = true, RequireRestart = false, HintText = "{=BC_4E7oI9}Whether momentum is reduced after each hit. If enabled swing speed will be constant no matter how many enemies hit. (Active for all)")]
        public bool CutThroughActive { get; set; } = false;

        [SettingPropertyGroup(combatHeader + "/" + sliceHeader)]
        [SettingPropertyBool("{=BC_dH3sFR}Slice Through Player Only", Order = 0, RequireRestart = false, HintText = "{=BC_C7X0a2}Should Slice through be for player only")]
        public bool CutThroughPlayerOnly { get; set; } = false;

        [SettingPropertyGroup(combatHeader + "/" + sliceHeader)]
        [SettingPropertyFloatingInteger("{=BC_9g69gX}Slice Through Chance", 0f, 1f, "0.00%", Order = 0, RequireRestart = false, HintText = "{=BC_uV45Mg}Chance to slice through target")]
        public float CutThroughChance { get; set; } = 0.02f;


        [SettingPropertyGroup(combatHeader + "/" + fleeingHeader)]
        [SettingPropertyBool("{=BC_opw7iq}Prevent Troops From Fleeing", Order = 0, RequireRestart = false, HintText = "{=BC_okw0a2}Should troops flee")]
        public bool PerventFleeing { get; set; } = false;

        [SettingPropertyGroup(combatHeader + "/" + fleeingHeader)]
        [SettingPropertyFloatingInteger("{=BC_5th0a2}Chance Troops Will Cancel Retreat", 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_C7twl6}Chance troops will skip retreating when moral triggers a retreat")]
        public float FleeingChance { get; set; } = .50f;


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get; } = "Better Combat";
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;




        /*public override IDictionary<string, Func<BaseSettings>> GetAvailablePresets() {
            IDictionary<string, Func<BaseSettings>> basePresets = base.GetAvailablePresets();
            basePresets.Add("{=BC_LpHW65}Vanilla Settings", () => new MCMSettings {


            });
            return basePresets;
        }*/
    }
}
