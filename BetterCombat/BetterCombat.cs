using BetterCombat.Behaviors;
using BetterCombat.Settings;
using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.MountAndBlade;

namespace BetterCombat {
    public class BetterCombat : MBSubModuleBase {

		public static MCMSettings Settings { get; private set; }
        public static string ModName { get; private set; } = "ForgotToSet";

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
                NotifyHelper.ReportError(ModName, "OnSubModuleLoad threw exception " + e);
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

                NotifyHelper.ChatMessage(ModName + " Loaded.", MsgType.Good);
                Integrations.BetterHealthLoaded = true;

                isLoaded = true;
            } catch (Exception e) {
                NotifyHelper.ReportError(ModName, "OnBeforeInitialModuleScreenSetAsRoot threw exception " + e);
            }
        }

        public override void OnMissionBehaviorInitialize(Mission mission) {
			base.OnMissionBehaviorInitialize(mission);

			if (Settings.HealthRegenEnabled) {
                NotifyHelper.PrintToLog("Loading HealthRegen.");
				mission.AddMissionBehavior(new HealthRegen());
			}

			if (Settings.HealthOnHitEnabled) {
                NotifyHelper.PrintToLog("Loading HealOnHit.");
				mission.AddMissionBehavior(new HealthOnHit());
			}

			if (Settings.PerventFleeing) {
                NotifyHelper.PrintToLog("Loading PerventFleeing.");
				mission.AddMissionBehavior(new PreventFleeing());
			}
		}
    }
}
