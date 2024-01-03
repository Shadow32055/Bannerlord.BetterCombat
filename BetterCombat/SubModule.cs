using BetterCombat.Behaviors;
using BetterCombat.Custom;
using BetterCombat.Settings;
using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BetterCombat {
    public class SubModule : MBSubModuleBase {

		private HealthManager? hm;
		public static MCMSettings _settings;
        public static InputKey bandageKey = InputKey.Q;

        protected override void OnSubModuleLoad() {
            base.OnSubModuleLoad();

            Harmony h = new("Bannerlord.Shadow.BetterCombat");

            h.PatchAll();
        }

		protected override void OnBeforeInitialModuleScreenSetAsRoot() {
			base.OnBeforeInitialModuleScreenSetAsRoot();

			string modName = base.GetType().Assembly.GetName().Name;
			
			Helper.SetModName(modName);

            if (MCMSettings.Instance is not null) {
                _settings = MCMSettings.Instance;
            } else {
                Logger.SendMessage("Failed to find settings instance!", Severity.High);
            }

			RegisterBandageKey();
		}

		public override void OnMissionBehaviorInitialize(Mission mission) {
			base.OnMissionBehaviorInitialize(mission);

			hm = new HealthManager(mission.MainAgent);

			if (_settings.HealthRegenEnabled) {
				Logger.PrintToLog("Loading HealthRegen.");
				mission.AddMissionBehavior(new HealthRegen(hm));
			}

			if (_settings.HealthOnHitEnabled) {
                Logger.PrintToLog("Loading HealOnHit.");
				mission.AddMissionBehavior(new HealthOnHit(hm));
			}

			if (_settings.BandageEnabled) {
                Logger.PrintToLog("Loading Bandages.");
				mission.AddMissionBehavior(new Bandage(hm, _settings.BandageAmount));
			}

			if (_settings.PerventFleeing) {
                Logger.PrintToLog("Loading PerventFleeing.");
				mission.AddMissionBehavior(new PreventFleeing());
			}
		}

		protected override void OnGameStart(Game game, IGameStarter gameStarter) {
			base.OnGameStart(game, gameStarter);
			if (game.GameType is Campaign) {
				CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarter;
				if (campaignGameStarter != null) {
					campaignGameStarter.AddBehavior(new HealthCorrectionPatcher());
				}
			}
		}

        public static void RegisterBandageKey() {
            try {
                if (Enum.IsDefined(typeof(InputKey), _settings.BandageKey)) {
                    bandageKey = (InputKey)Enum.Parse(typeof(InputKey), _settings.BandageKey);
                    //DisplayWarningMsg("Key: " + settings.CallKey);
                } else {
                    throw new Exception();
                }
            } catch (Exception e) {
                Logger.SendMessage("Issue registering bandage key. '" + _settings.BandageKey + "' is not a valid key. Using deafult 'Q' key.", Severity.High);
                Logger.PrintToLog("register key exception: " + e);
            }
        }
    }
}
