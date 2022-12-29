using System;
using BetterCombat.Utils;
using BetterCombat.Custom;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
	public class HealthRegen : MissionBehavior {

		private float lastHealthPlayer;
		private bool tookDamagePlayer;
		private MissionTime nextHealPlayer;
		private readonly HealthManager hm;

		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

		public HealthRegen(HealthManager hm) {
			this.hm = hm;
        }

		public override void OnMissionTick(float dt) {
			base.OnMissionTick(dt);

			try {
				Mission mission = Mission.Current;
				if (mission != null && mission.MainAgent != null) {

					if (Helper.settings.PlayerHealthRegenAmount > 0) {
						if (this.nextHealPlayer.IsPast) {

							if (tookDamagePlayer) {
								tookDamagePlayer = false;
							}

							if (this.lastHealthPlayer > mission.MainAgent.Health) {
								tookDamagePlayer = true;
								this.nextHealPlayer = MissionTime.SecondsFromNow(Helper.settings.PlayerRegenDamageDelay);
							} else {
								this.nextHealPlayer = MissionTime.SecondsFromNow(Helper.settings.PlayerHealthRegenInterval);

								float healAmount = Helper.settings.PlayerHealthRegenAmount;

								

								Regenerate(mission.MainAgent, healAmount);

							}
							this.lastHealthPlayer = mission.MainAgent.Health;
						}
					}
					
				} else {
					this.nextHealPlayer = MissionTime.Zero;
				}
			} catch (Exception e) {
				Helper.WriteToLog("Problem with health regen, cause: " + e);
			}
		}

		private void Regenerate(Agent agent, float amount) {
			if (agent.Health < agent.HealthLimit) {
				float healAmount = hm.GetHealAmount(amount, agent);

				if (agent == Mission.Current.MainAgent) {
					hm.AddOutput(healAmount);
					if (hm.AvaiableHealingLeft()) {
						agent.Health += healAmount;
					}
				} else {
					agent.Health += healAmount;
				}
			}
		}
	}
}
