using System;
using TaleWorlds.Core;
using BetterCombat.Utils;
using BetterCombat.Custom;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
	public class HealthOnHit : MissionBehavior {

		private HealthManager hm;
		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

		public HealthOnHit(HealthManager hm) {
			this.hm = hm;
        }

        public override void OnAgentHit(Agent affectedAgent, Agent affectorAgent, in MissionWeapon affectorWeapon, in Blow blow, in AttackCollisionData attackCollisionData) {
            base.OnAgentHit(affectedAgent, affectorAgent, affectorWeapon, blow, attackCollisionData);

			try {
				if (affectorAgent.Character != null && affectedAgent.Character != null) {
					if (affectorAgent == Agent.Main && attackCollisionData.InflictedDamage > 0f) {

						float healAmount = attackCollisionData.InflictedDamage * Helper.settings.PlayerPercentHealthOnHit;

						if (healAmount < Helper.settings.PlayerMinHealthOnHit) {
							healAmount = Helper.settings.PlayerMinHealthOnHit;
						}

						if (healAmount > Helper.settings.PlayerMaxHealthOnHit) {
							healAmount = Helper.settings.PlayerMaxHealthOnHit;
						}

						float refinedHealthAmount = GetHealAmount(healAmount, affectorAgent);

						if (affectorAgent.Health < affectorAgent.HealthLimit) {
							if (hm.AvaiableHealingLeft()) {
								affectorAgent.Health += healAmount;
								hm.AddOutput(healAmount);
							}
						}
					}
				}

			} catch (Exception e) {
				Helper.WriteToLog("Problem with health on hit, cause: " + e);
			}
		}

		private float GetHealAmount(float healAmount, Agent agent) {
			if ((healAmount + agent.Health) > agent.HealthLimit) {
				return agent.HealthLimit - agent.Health;
			}

			return healAmount;
		}
	}
}
