using BetterCore.Utils;
using HarmonyLib;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Patches {

    [HarmonyPatch]
    internal class SandboxAgentApplyDamageModelPatch {

        [HarmonyPrefix]
        [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.CalculateDamage))]
        private static bool CalculateDamagePrefix(ref float __result, ref AttackInformation attackInformation) {
            if (!BetterCombat.Settings.DisableFriendlyFire)
                return true;

            if (attackInformation.AttackerFormation == null)
                return true;

            if (attackInformation.AttackerFormation.Team == null)
                return true;

            if (attackInformation.VictimFormation == null)
                return true;

            if (attackInformation.VictimFormation.Team == null)
                return true;

            if(BetterCombat.Settings.FriendlyFirePlayerOnly && !attackInformation.AttackerFormation.Team.IsPlayerAlly)
                return true;

            if (attackInformation.AttackerFormation.Team.Side.Equals(attackInformation.VictimFormation.Team.Side)) {
                __result = 0f;
                return false;
            } else {
                return true;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideCrushedThrough))]
        public static void DecideCrushedThroughPostfix(ref bool __result, Agent attackerAgent) {
            if (!BetterCombat.Settings.CrushThroughActive)
                return;

            if (attackerAgent == null)
                return;

            if (!attackerAgent.IsPlayerControlled && BetterCombat.Settings.CrushThroughPlayerOnly)
                return;

            if (!MathHelper.RandomChance(BetterCombat.Settings.CrushThroughChance))
                return;

            //NotifyHelper.WriteToChat("Crush through!");

            __result = true;
        }
    }
}
