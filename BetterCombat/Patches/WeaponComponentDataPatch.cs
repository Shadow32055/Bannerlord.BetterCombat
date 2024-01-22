using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.Core;

namespace BetterCombat.Patches {

    [HarmonyPatch]
    internal class WeaponComponentDataPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(WeaponComponentData), "CanHitMultipleTargets", MethodType.Getter)]
        public static void Postfix(ref bool __result, WeaponComponentData __instance) {
            try {
                if (BetterCombat.Settings.MultiHitTwoHanded && BetterCombat.Settings.MultiHitOneHanded) {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                       __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword ||
                       __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                       __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                       __instance.WeaponClass == WeaponClass.Dagger;

                } else if (BetterCombat.Settings.MultiHitOneHanded) {
                    __result = __instance.WeaponClass == WeaponClass.OneHandedSword || __instance.WeaponClass == WeaponClass.OneHandedPolearm ||
                       __instance.WeaponClass == WeaponClass.OneHandedAxe || __instance.WeaponClass == WeaponClass.Mace ||
                       __instance.WeaponClass == WeaponClass.Dagger;

                } else if (BetterCombat.Settings.MultiHitTwoHanded) {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace ||
                       __instance.WeaponClass == WeaponClass.TwoHandedPolearm || __instance.WeaponClass == WeaponClass.TwoHandedSword;

                } else {
                    __result = __instance.WeaponClass == WeaponClass.TwoHandedAxe || __instance.WeaponClass == WeaponClass.TwoHandedMace;
                }
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterCombat.ModName, "WeaponComponentData.CanHitMultipleTargets threw exception: " + e);
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
