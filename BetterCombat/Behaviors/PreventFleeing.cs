using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
    class PreventFleeing : MissionBehavior {

		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnAgentFleeing(Agent affectedAgent) {

            double chance = SubModule._settings.FleeingChance;
            double random = MBRandom.RandomFloat;

            if (random <= chance) {
                base.OnAgentFleeing(affectedAgent);
                affectedAgent.SetMorale(100);
                affectedAgent.StopRetreatingMoraleComponent();
                affectedAgent.StopRetreating();
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
