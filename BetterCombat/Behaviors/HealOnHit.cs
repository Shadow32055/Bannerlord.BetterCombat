using BetterCombat.Custom;
using BetterCore.Utils;
using System;
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

						float healAmount = attackCollisionData.InflictedDamage * SubModule._settings.PlayerPercentHealthOnHit;

						if (healAmount < SubModule._settings.PlayerMinHealthOnHit) {
							healAmount = SubModule._settings.PlayerMinHealthOnHit;
						}

						if (healAmount > SubModule._settings.PlayerMaxHealthOnHit) {
							healAmount = SubModule._settings.PlayerMaxHealthOnHit;
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
				Logger.SendMessage("Problem with health on hit, cause: " + e, Severity.High);
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
