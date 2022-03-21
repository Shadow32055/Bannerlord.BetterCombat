using HarmonyLib;
using TaleWorlds.Core;
using BetterCombat.Utils;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using System;

namespace BetterCombat.Patches {

    [HarmonyPatch]
    class PostfixPatches {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Mission), "DecideAgentKnockedByBlow")]
        public static void DecideAgentKnockedByBlow(Agent attacker, Agent victim, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon,
            bool isInitialBlowShrugOff, ref Blow blow) {

            if (Helper.settings.PreventKnockdown) {
                if (victim.IsMainAgent) {

                    blow.BlowFlag &= ~BlowFlags.KnockBack;
                    blow.BlowFlag &= ~BlowFlags.KnockDown;
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Mission), "DecideAgentShrugOffBlow")]
        protected static void DecideAgentShrugOffBlow(Agent victimAgent, AttackCollisionData collisionData, ref Blow blow, ref bool __result) {

            if (Helper.settings.ShrugOffBlow) {
                if (victimAgent.IsMainAgent || (victimAgent.IsMount && victimAgent.IsMine)) {

                    blow.BlowFlag |= BlowFlags.ShrugOff;
                    __result = true;
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "CanHitMultipleTargets", MethodType.Getter)]
        public static void Postfix(ref bool __result, WeaponComponentData __instance) {

            if (Helper.settings.MutliHitTwoHanded && Helper.settings.MutliHitOneHanded) {
                __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                   __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword ||
                   __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                   __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                   __instance.WeaponClass == WeaponClass.Dagger;

            } else if (Helper.settings.MutliHitOneHanded) {
                __result = __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                   __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                   __instance.WeaponClass == WeaponClass.Dagger;

            } else if (Helper.settings.MutliHitTwoHanded) {
                __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                   __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword;

            } else {
                __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        public static void GetDailyHealingHpForHeroes(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false) {

            __result.AddFactor(Helper.settings.CampaignHealthRegenMultiplier, new TextObject("Campaign Regen Multiplier", null));

        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
        public static void GetDailyHealingForRegulars(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false) {

            __result.AddFactor(Helper.settings.CampaignHealthRegenMultiplier, new TextObject("Campaign Regen Multiplier", null));

        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
        public static void MaxHitpoints(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions = false) {

            if (character.IsHero && character.IsPlayerCharacter) {



                if (Helper.settings.PlayerPercentHealthPerLevel) {
                    __result.AddFactor((float)Math.Round(character.Level * Helper.settings.PlayerPercent), new TextObject("Percent Level", null));
                }

                if (Helper.settings.PlayerFlatHealthPerLevel) {
                    __result.Add((float)Math.Round(character.Level * Helper.settings.PlayerFlatAmount), new TextObject("Flat Level", null));
                }

                //Heroes
            } else if (character.IsHero && !(character.IsPlayerCharacter)) {



                if (Helper.settings.HeroPercentHealthPerLevel) {
                    __result.AddFactor((float)Math.Round(character.Level * Helper.settings.HeroPercent), new TextObject("Percent Level", null));
                }

                if (Helper.settings.HeroFlatHealthPerLevel) {
                    __result.Add((float)Math.Round(character.Level * Helper.settings.HeroFlatAmount), new TextObject("Flat Level", null));
                }

                //Troops
            } else if (!(character.IsHero)) {

                __result.Add((float)Math.Round(character.GetSkillValue(DefaultSkills.Athletics) * Helper.settings.TroopHealthAthletics), new TextObject("Athletics", null));

                if (Helper.settings.TroopPercentHealthPerLevel) {
                    __result.AddFactor((float)Math.Round(character.Level * Helper.settings.TroopPercent), new TextObject("Percent Level", null));
                }

                if (Helper.settings.TroopFlatHealthPerLevel) {
                    __result.Add((float)Math.Round(character.Level * Helper.settings.TroopFlatAmount), new TextObject("Flat Level", null));
                }
            }
        }
    }
}
