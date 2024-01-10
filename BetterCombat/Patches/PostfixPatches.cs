using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Patches {

    [HarmonyPatch]
    class PostfixPatches {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "DecideAgentKnockedDownByBlow")]
        public static void DecideAgentKnockedDownByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, ref Blow blow) {
            try {
                if (BetterCombat.Settings.PreventKnockdown) {
                    if (victimAgent.IsMainAgent) {

                        blow.BlowFlag &= ~BlowFlags.KnockBack;
                        blow.BlowFlag &= ~BlowFlags.KnockDown;
                    }
                }
            } catch (Exception e){
                NotifyHelper.ReportError(BetterCombat.ModName, "MissionCombatMechanicsHelper.DecideAgentKnockedDownByBlow threw exception: " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(MissionCombatMechanicsHelper), "DecideAgentShrugOffBlow")]
        public static void DecideAgentShrugOffBlow(Agent victimAgent, AttackCollisionData collisionData, ref Blow blow, ref bool __result) {

            if (BetterCombat.Settings.ShrugOffBlow) {
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
                if (BetterCombat.Settings.MutliHitTwoHanded && BetterCombat.Settings.MutliHitOneHanded) {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                       __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword ||
                       __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                       __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                       __instance.WeaponClass == WeaponClass.Dagger;

                } else if (BetterCombat.Settings.MutliHitOneHanded) {
                    __result = __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                       __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                       __instance.WeaponClass == WeaponClass.Dagger;

                } else if (BetterCombat.Settings.MutliHitTwoHanded) {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                       __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword;

                } else {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace;
                }
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterCombat.ModName, "WeaponComponentData.CanHitMultipleTargets threw exception: " + e);
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
