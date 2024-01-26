using BetterCore.Utils;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Behaviors {
    public class HealthRegen : MissionBehavior {

		private float lastHealthPlayer;
		private MissionTime nextHealPlayer = MissionTime.Zero;
		private MissionTime nextHealthCheck = MissionTime.Zero;

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public override void OnDeploymentFinished() {
            base.OnDeploymentFinished();
            HealthHelper.HealLimit = BetterCombat.Settings.HealingThreshold;
        }

        public override void OnMissionTick(float dt) {
			base.OnMissionTick(dt);

			try {
                if (Mission.Current == null)
                    return;

                if (Mission.Current.MainAgent == null)
                    return;

                if (BetterCombat.Settings.PlayerHealthRegenAmount == 0)
                    return;

				if (Mission.Current.MainAgent.Health == Mission.Current.MainAgent.HealthLimit) {
                    lastHealthPlayer = Mission.Current.MainAgent.HealthLimit;
                    return;
				}

				if (nextHealthCheck.IsPast) {
					if (lastHealthPlayer > Mission.Current.MainAgent.Health) {
                        nextHealPlayer = MissionTime.SecondsFromNow(BetterCombat.Settings.PlayerRegenDamageDelay);
						lastHealthPlayer = Mission.Current.MainAgent.Health;
					}
                    nextHealthCheck = MissionTime.SecondsFromNow(1);
                }

				if (nextHealPlayer.IsPast) {
                    nextHealPlayer = MissionTime.SecondsFromNow(BetterCombat.Settings.PlayerHealthRegenInterval);
					HealthHelper.HealAgent(Mission.Current.MainAgent, BetterCombat.Settings.PlayerHealthRegenAmount);
				}
			} catch (Exception e) {
				NotifyHelper.WriteError(BetterCombat.ModName, "Player health regen threw exception: " + e);
			}
		}
	}
}
