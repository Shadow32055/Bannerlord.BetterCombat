using BetterCore.Utils;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
    public class HealthRegen : MissionBehavior {

		private float lastHealthPlayer;
		private bool tookDamagePlayer;
		private MissionTime nextHealPlayer;

		public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;



		public override void OnMissionTick(float dt) {
			base.OnMissionTick(dt);

			try {
				Mission mission = Mission.Current;
				if (mission != null && mission.MainAgent != null) {

					if (BetterCombat.Settings.PlayerHealthRegenAmount > 0) {
						if (this.nextHealPlayer.IsPast) {

							if (tookDamagePlayer) {
								tookDamagePlayer = false;
							}

							if (this.lastHealthPlayer > mission.MainAgent.Health) {
								tookDamagePlayer = true;
								this.nextHealPlayer = MissionTime.SecondsFromNow(BetterCombat.Settings.PlayerRegenDamageDelay);
							} else {
								this.nextHealPlayer = MissionTime.SecondsFromNow(BetterCombat.Settings.PlayerHealthRegenInterval);

								float healAmount = BetterCombat.Settings.PlayerHealthRegenAmount;

								

								Regenerate(mission.MainAgent, healAmount);

							}
							this.lastHealthPlayer = mission.MainAgent.Health;
						}
					}
					
				} else {
					this.nextHealPlayer = MissionTime.Zero;
				}
			} catch (Exception e) {
				NotifyHelper.ReportError(BetterCombat.ModName, "Problem with health regen, cause: " + e);
			}
		}

		private void Regenerate(Agent agent, float amount) {
			if (agent.Health < agent.HealthLimit) {
				float healAmount = HealthHelper.GetMaxHealAmount(amount, agent);

				if (agent == Mission.Current.MainAgent) {
					agent.Health += healAmount;
				}
			}
		}
	}
}
