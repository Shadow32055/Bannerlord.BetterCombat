using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterCombat.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        const string healingHeader = "{=BC_T1ldYr}Healing";
        const string lifeStealHeader = "{=BC_vswqsP}Lifesteal";
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
        /// HEALING LIMIT
        /// </summary>

        [SettingPropertyGroup(healingHeader + "/" + healingLimitHeader)]
        [SettingPropertyBool("{=BC_XHBWnA}Healing Limit", IsToggle = true, Order = 0, RequireRestart = false, HintText = "{=BC_JzNe5x}Limit on the amount of healing possible each battle")]
        public bool HealingLimit { get; set; } = false;

        [SettingPropertyGroup(healingHeader + "/" + healingLimitHeader)]
        [SettingPropertyFloatingInteger("{=BC_pWvBgz}Healing Amount", 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_auAAgh}Maxium health percent threshold. Setting to 80% means you cant heal over 80%")]
        public float HealingThreshold { get; set; } = 0;

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



        [SettingPropertyGroup(combatHeader + "/" + fleeingHeader)]
        [SettingPropertyBool("{=BC_opw7iq}Prevent Troops From Fleeing", Order = 0, RequireRestart = false, HintText = "{=BC_okw0a2}Should troops flee")]
        public bool PerventFleeing { get; set; } = false;

        [SettingPropertyGroup(combatHeader + "/" + fleeingHeader)]
        [SettingPropertyFloatingInteger("{=BC_5th0a2}Chance Troops Will Cancel Retreat", 0f, 1f, "0.0 %", Order = 0, RequireRestart = false, HintText = "{=BC_C7twl6}Chance troops will skip retreating when moral triggers a retreat")]
        public float FleeingChance { get; set; } = .50f;



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
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
