using BetterCore.Utils;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
    public class HealthOnHit : MissionBehavior {

		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnDeploymentFinished() {
            base.OnDeploymentFinished();
            if (BetterCombat.Settings.HealingLimit) {
                HealthHelper.HealLimit = BetterCombat.Settings.HealingThreshold;
            } else {
                HealthHelper.HealLimit = 1f;
            }
        }

        public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData) {
            base.OnAgentHit(affectedAgent, affectorAgent, affectorWeapon, blow, attackCollisionData);

			try {
				if (affectorAgent == null || affectedAgent == null)
					return;

				if (Mission.Current.MainAgent == null && BetterCombat.Settings.HealthOnHitPlayerOnly)
					return;

				if (affectorAgent != Mission.Current.MainAgent && BetterCombat.Settings.HealthOnHitPlayerOnly)
					return;

				if (attackCollisionData.InflictedDamage <= 0)
					return;

				float healAmount = attackCollisionData.InflictedDamage * BetterCombat.Settings.PlayerPercentHealthOnHit;

				if (healAmount < BetterCombat.Settings.PlayerMinHealthOnHit) {
					healAmount = BetterCombat.Settings.PlayerMinHealthOnHit;
				}

				if (healAmount > BetterCombat.Settings.PlayerMaxHealthOnHit) {
					healAmount = BetterCombat.Settings.PlayerMaxHealthOnHit;
				}

				HealthHelper.HealAgent(affectorAgent, healAmount);

			} catch (Exception e) {
				NotifyHelper.WriteError(BetterCombat.ModName, "Problem with health on hit, cause: " + e);
			}
		}
	}
}
