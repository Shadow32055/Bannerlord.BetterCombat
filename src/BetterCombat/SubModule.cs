using HarmonyLib;
using TaleWorlds.Core;
using BetterCombat.Utils;
using BetterCombat.Custom;
using BetterCombat.Settings;
using BetterCombat.Behaviors;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;


namespace BetterCombat {
	public class SubModule : MBSubModuleBase {

		private HealthManager hm;

		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();
		}

		protected override void OnBeforeInitialModuleScreenSetAsRoot() {
			base.OnBeforeInitialModuleScreenSetAsRoot();

			string modName = base.GetType().Assembly.GetName().Name;

			new Harmony("Bannerlord.Shadow.BetterCombat").PatchAll();
			Helper.SetModName(modName);
			Helper.settings = SettingsManager.Instance;
			Helper.RegisterBandageKey();
		}

		public override void OnMissionBehaviorInitialize(Mission mission) {
			base.OnMissionBehaviorInitialize(mission);

			hm = new HealthManager(mission.MainAgent);

			if (Helper.settings.HealthRegenEnabled) {
				Helper.WriteToLog("Loading HealthRegen.");
				mission.AddMissionBehavior(new HealthRegen(hm));
			}

			if (Helper.settings.HealthOnHitEnabled) {
				Helper.WriteToLog("Loading HealOnHit.");
				mission.AddMissionBehavior(new HealthOnHit(hm));
			}

			if (Helper.settings.BandageEnabled) {
				Helper.WriteToLog("Loading Bandages.");
				mission.AddMissionBehavior(new Bandage(hm, Helper.settings.BandageAmount));
			}

			if (Helper.settings.PerventFleeing) {
				Helper.WriteToLog("Loading PerventFleeing.");
				mission.AddMissionBehavior(new PreventFleeing());
			}
		}

		protected override void OnGameStart(Game game, IGameStarter gameStarter) {
			base.OnGameStart(game, gameStarter);
			if (game.GameType is Campaign) {
				CampaignGameStarter campaignGameStarter = gameStarter as CampaignGameStarter;
				if (campaignGameStarter != null) {
					campaignGameStarter.AddBehavior(new HealthCorrectionPatcher());
				}
			}
		}
	}
}
