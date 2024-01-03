using HarmonyLib;
using TaleWorlds.Core;
using BetterCore.Utils;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.GameComponents;
using System;
using TaleWorlds.CampaignSystem.Party;

namespace BetterCombat.Patches {

    [HarmonyPatch]
    class PostfixPatches {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "DecideAgentKnockedDownByBlow")]
        public static void DecideAgentKnockedDownByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, ref Blow blow) {
            try {
                if (SubModule._settings.PreventKnockdown) {
                    if (victimAgent.IsMainAgent) {

                        blow.BlowFlag &= ~BlowFlags.KnockBack;
                        blow.BlowFlag &= ~BlowFlags.KnockDown;
                    }
                }
            } catch (Exception e){
                Logger.SendMessage("MissionCombatMechanicsHelper.DecideAgentKnockedDownByBlow threw exception: " + e, Severity.High);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "DecideAgentShrugOffBlow")]
        public static void DecideAgentShrugOffBlow(Agent victimAgent, AttackCollisionData collisionData, ref Blow blow, ref bool __result) {

            if (SubModule._settings.ShrugOffBlow) {
                if (victimAgent.IsMainAgent || (victimAgent.IsMount && victimAgent.IsMine)) {

                    blow.BlowFlag |= BlowFlags.ShrugOff;
                    __result = true;
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "CanHitMultipleTargets", MethodType.Getter)]
        public static void Postfix(ref bool __result, WeaponComponentData __instance) {
            try {
                if (SubModule._settings.MutliHitTwoHanded && SubModule._settings.MutliHitOneHanded) {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                       __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword ||
                       __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                       __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                       __instance.WeaponClass == WeaponClass.Dagger;

                } else if (SubModule._settings.MutliHitOneHanded) {
                    __result = __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                       __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                       __instance.WeaponClass == WeaponClass.Dagger;

                } else if (SubModule._settings.MutliHitTwoHanded) {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                       __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword;

                } else {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace;
                }
            } catch (Exception e) {
                Logger.SendMessage("WeaponComponentData.CanHitMultipleTargets threw exception: " + e, Severity.High);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        public static void GetDailyHealingHpForHeroes(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false) {

            __result.AddFactor(SubModule._settings.CampaignHealthRegenMultiplier, new TextObject("Campaign Regen Multiplier", null));

        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
        public static void GetDailyHealingForRegulars(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false) {

            __result.AddFactor(SubModule._settings.CampaignHealthRegenMultiplier, new TextObject("Campaign Regen Multiplier", null));

        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
        public static void MaxHitpoints(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions = false) {
            try {
                if (character.IsHero && character.IsPlayerCharacter) {

                    if (SubModule._settings.PlayerPercentHealthPerLevel) {
                        __result.AddFactor((float)Math.Round(character.Level * SubModule._settings.PlayerPercent), new TextObject("Percent Level", null));
                    }

                    if (SubModule._settings.PlayerFlatHealthPerLevel) {
                        __result.Add((float)Math.Round(character.Level * SubModule._settings.PlayerFlatAmount), new TextObject("Flat Level", null));
                    }

                    //Heroes
                } else if (character.IsHero && !(character.IsPlayerCharacter)) {

                    if (SubModule._settings.HeroPercentHealthPerLevel) {
                        __result.AddFactor((float)Math.Round(character.Level * SubModule._settings.HeroPercent), new TextObject("Percent Level", null));
                    }

                    if (SubModule._settings.HeroFlatHealthPerLevel) {
                        __result.Add((float)Math.Round(character.Level * SubModule._settings.HeroFlatAmount), new TextObject("Flat Level", null));
                    }

                    //Troops
                } else if (!(character.IsHero)) {

                    __result.Add((float)Math.Round(character.GetSkillValue(DefaultSkills.Athletics) * SubModule._settings.TroopHealthAthletics), new TextObject("Athletics", null));

                    if (SubModule._settings.TroopPercentHealthPerLevel) {
                        __result.AddFactor((float)Math.Round(character.Level * SubModule._settings.TroopPercent), new TextObject("Percent Level", null));
                    }

                    if (SubModule._settings.TroopFlatHealthPerLevel) {
                        __result.Add((float)Math.Round(character.Level * SubModule._settings.TroopFlatAmount), new TextObject("Flat Level", null));
                    }
                }
            } catch (Exception e) {
                Logger.SendMessage("DefaultCharacterStatsModel.MaxHitpoints threw exception: " + e, Severity.High);
            }
        }

        //TODO: add adjustable variable
       /* [HarmonyPatch(typeof(Mission), "GetDamageMultiplierOfCombatDifficulty")]
        public static void GetDamageMultiplierOfCombatDifficulty(ref float __result) {
            try {
                __result = 1f;
            } catch {}
        }*/
    }
}
