using BetterCombat.Behaviors;
using BetterCombat.Settings;
using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterCombat {
    public class BetterCombat : MBSubModuleBase {

		public static MCMSettings Settings { get; private set; } = new MCMSettings();
        public static string ModName { get; private set; } = "BetterCombat";

        private bool isInitialized = false;
        private bool isLoaded = false;

        //FIRST
        protected override void OnSubModuleLoad() {
            try {
                base.OnSubModuleLoad();

                if (isInitialized)
                    return;

                Harmony h = new("Bannerlord.Shadow." + ModName);

                h.PatchAll();

                isInitialized = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnSubModuleLoad threw exception " + e);
            }
        }

        //SECOND
        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            try {
                base.OnBeforeInitialModuleScreenSetAsRoot();

                if (isLoaded)
                    return;

                ModName = base.GetType().Assembly.GetName().Name;

                Settings = MCMSettings.Instance ?? throw new NullReferenceException("Settings are null");

                NotifyHelper.WriteMessage(ModName + " Loaded.", MsgType.Good);
                Integrations.BetterCombatLoaded = true;
                HealthHelper.HealLimit = Settings.HealingThreshold;

                isLoaded = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnBeforeInitialModuleScreenSetAsRoot threw exception " + e);
            }
        }

        public override void OnMissionBehaviorInitialize(Mission mission) {
			base.OnMissionBehaviorInitialize(mission);

			if (Settings.HealthRegenEnabled) {
				mission.AddMissionBehavior(new HealthRegen());
			}

			if (Settings.HealthOnHitEnabled) {;
				mission.AddMissionBehavior(new HealthOnHit());
			}

			if (Settings.EnableFleeing) {
				mission.AddMissionBehavior(new PreventFleeing());
			}
		}
    }
}
