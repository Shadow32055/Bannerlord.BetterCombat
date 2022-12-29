using System;
using HarmonyLib;
using BetterCombat.Utils;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;

namespace BetterCombat.Patches {

	[HarmonyPatch]
	class PrefixPatches {

		/*[HarmonyPrefix]
		[HarmonyPatch(typeof(CustomBattleAgentLogic), "OnAgentRemoved")]

		public static bool Prefix(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow) {

			try {

				//if dont die is enabled

				if (agentState != AgentState.Killed || affectedAgent == null) {
					return true;
				}

				if (affectedAgent.Character == null) {
					return true;
				}

				if (!affectedAgent.Character.IsHero) {
					return true;
				}


				Hero hero = ((CharacterObject)affectedAgent.Character).HeroObject;

				if (!hero.IsPlayerCompanion && hero.Clan != Clan.PlayerClan) {
					return true;
				} else {
					affectedAgent.Origin.SetWounded();
					return false;
				}


			} catch (Exception e) {
				Helper.WriteToLog("Issue with on agent removed, dont die. " + e);
			}

			return true;
		}*/

		[HarmonyPrefix]
		[HarmonyPatch(typeof(Mission), "UpdateMomentumRemaining")]
		private static bool UpdateMomentumRemaining(ref float momentumRemaining, Blow b, in AttackCollisionData collisionData, Agent attacker, Agent victim, in MissionWeapon attackerWeapon, ref bool isCrushThrough) {
			try {

				if (!Helper.settings.CutThroughActive) {
					//cut through not enabled, let TW method run
					return true;
				}

				if (attacker == null) {
					return true;
				}

				if (Helper.settings.CutThroughPlayerOnly && !attacker.IsPlayerControlled)
					return true;


				double random = MBRandom.RandomFloat;

				if (random <= Helper.settings.CutThroughChance) {

					/*if (attacker.IsMainAgent) {
						Helper.DisplayFriendlyMsg("cut through!");
					}*/

					return false;
				}

			} catch (Exception e) {
				Helper.WriteToLog("Issue with Mission.UpdateMomentumRemaining prefix. Exception: " + e);
			}

			return true;
		}
	}
}
