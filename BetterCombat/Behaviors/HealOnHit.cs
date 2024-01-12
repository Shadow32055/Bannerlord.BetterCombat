using BetterCore.Utils;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
    public class HealthOnHit : MissionBehavior {

		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData) {
            base.OnAgentHit(affectedAgent, affectorAgent, affectorWeapon, blow, attackCollisionData);

			try {
				if (affectorAgent.Character != null && affectedAgent.Character != null) {
					if (affectorAgent == Agent.Main && attackCollisionData.InflictedDamage > 0f) {

						float healAmount = attackCollisionData.InflictedDamage * BetterCombat.Settings.PlayerPercentHealthOnHit;

						if (healAmount < BetterCombat.Settings.PlayerMinHealthOnHit) {
							healAmount = BetterCombat.Settings.PlayerMinHealthOnHit;
						}

						if (healAmount > BetterCombat.Settings.PlayerMaxHealthOnHit) {
							healAmount = BetterCombat.Settings.PlayerMaxHealthOnHit;
						}

						float refinedHealthAmount = 0;

						if (BetterCombat.Settings.HealingLimit) {
                            refinedHealthAmount = HealthHelper.GetMaxHealAmount(healAmount, affectorAgent.Health, BetterCombat.Settings.HealingThreshold * affectorAgent.HealthLimit);
                        } else {
                            refinedHealthAmount = HealthHelper.GetMaxHealAmount(healAmount, affectorAgent.Health, affectorAgent.HealthLimit);
						}

						if (affectorAgent.Health < affectorAgent.HealthLimit) {

							affectorAgent.Health += healAmount;
						}
					}
				}

			} catch (Exception e) {
				NotifyHelper.ReportError(BetterCombat.ModName, "Problem with health on hit, cause: " + e);
			}
		}
	}
}
