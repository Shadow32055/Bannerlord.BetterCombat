using BetterCore.Utils;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
    class PreventFleeing : MissionBehavior {

		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnAgentFleeing(Agent affectedAgent) {
            base.OnAgentFleeing(affectedAgent);
            try {
                if (!BetterCombat.Settings.EnableFleeing)
                    return;

                if (affectedAgent == null)
                    return;

                if (affectedAgent.Team == null)
                    return;

                if (BetterCombat.Settings.FleeingPlayerOnly && !affectedAgent.Team.IsPlayerAlly)
                    return;

                if (!MathHelper.RandomChance(BetterCombat.Settings.FleeingChance))
                    return;

                affectedAgent.SetMorale(100);
                affectedAgent.StopRetreatingMoraleComponent();
                affectedAgent.StopRetreating();
                //NotifyHelper.WriteToChat("Prevented fleeing");

            } catch (Exception e) {
                NotifyHelper.WriteError(BetterCombat.ModName, "PreventFleeing.OnAgentFleeing threw exception: " + e);
            }
        }

        /*public override void OnAgentPanicked(Agent affectedAgent) {
            base.OnAgentPanicked(affectedAgent);
            affectedAgent.SetMorale(100);
            affectedAgent.StopRetreatingMoraleComponent();
            affectedAgent.StopRetreating();
        }*/
    }
}
