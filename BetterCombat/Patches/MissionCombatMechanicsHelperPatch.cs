using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Patches {
    [HarmonyPatch]
    internal class MissionCombatMechanicsHelperPatch {

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
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterCombat.ModName, "MissionCombatMechanicsHelper.DecideAgentKnockedDownByBlow threw exception: " + e);
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
    }
}
