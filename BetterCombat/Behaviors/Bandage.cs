using BetterCombat.Custom;
using BetterCore.Utils;
using System;
using TaleWorlds.Library;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using Logger = BetterCore.Utils.Logger;

namespace BetterCombat.Behaviors {
    public class Bandage : MissionBehavior {

        private static MissionTime bandageTime;
        private static bool activlyBandaging = false;
        private int bandagesLeft;
        private HealthManager hm;

        public override MissionBehaviorType BehaviorType => MissionBehaviorType.Other;

        public Bandage(HealthManager hm, int bandages) {
            this.hm = hm;
            bandagesLeft = bandages;
        }

        public override void OnMissionTick(float dt) {
            base.OnMissionTick(dt);
            try {
                //Check if we are in a mission
                if (Mission.Current != null && Mission.Current.MainAgent != null) {

                    if (activlyBandaging) {
                        if (IsMoving(Mission.Current.MainAgent.MovementVelocity)) {
                            Logger.SendMessage(new TextObject("{=BC_qezRvY}Bandaging canceled due to movment!").ToString(), Severity.Alert);
                            activlyBandaging = false;
                        }

                        if (bandageTime.IsPast) {
                            float healAmount = GetHealAmount(SubModule._settings.BandageHealAmount);
                            if (hm.AvaiableHealingLeft()) {
                                Mission.Current.MainAgent.Health += healAmount;
                                hm.AddOutput(healAmount);
                                bandagesLeft--;
                            } else {
                                Logger.SendMessage(new TextObject("{=BC_7cWw3B}No more avaiable healing!").ToString(), Severity.Alert);
                            }

                            activlyBandaging = false;

                            string text;
                            if (bandagesLeft < 2) {
                                text = String.Format(new TextObject("{=BC_YZj7gF}Bandage applied! Only {0} bandage left!").ToString(), bandagesLeft);
                            } else {
                                text = String.Format(new TextObject("{=BC_q2WCze}Bandage applied! {0} bandages left!").ToString(), bandagesLeft);
                            }

                            Logger.SendMessage(text, Severity.Normal);
                        }
                    }

                    if (Input.IsKeyPressed(SubModule.bandageKey)) {
                        UseBandage();
                    }

                }
            } catch (Exception e) {
                Logger.PrintToLog("Problem with bandages, cause: " + e);
            }
        }

        private float GetHealAmount(float healAmount) {
            if ((healAmount + Mission.Current.MainAgent.Health) > Mission.Current.MainAgent.HealthLimit) {
                return Mission.Current.MainAgent.HealthLimit - Mission.Current.MainAgent.Health;
            }

            return healAmount;
        }

        private static bool IsMoving(Vec2 velocity) {
            Vec2 vec = Vec2.Zero - new Vec2(1, 1);
            Vec2 vec2 = Vec2.Zero + new Vec2(1, 1);

            return velocity.x < vec.x || velocity.x > vec2.x || velocity.y < vec.y || velocity.y > vec2.y;
        }

        public void UseBandage() {
            if (!IsMoving(Mission.Current.MainAgent.MovementVelocity)) {
                if (bandagesLeft > 0) {
                    if (!activlyBandaging) {
                        if (Mission.Current.MainAgent.Health != Mission.Current.MainAgent.HealthLimit) {
                            bandageTime = MissionTime.SecondsFromNow(SubModule._settings.BandageTime);
                            activlyBandaging = true;
                            Logger.SendMessage(String.Format(new TextObject("{=BC_RnoIZo}Applying bandage... It will take {0} seconds.").ToString(), SubModule._settings.BandageTime), Severity.Normal);
                        } else {
                            Logger.SendMessage(new TextObject("{=BC_359Qlt}You're health is full.").ToString(), Severity.Normal);
                        }
                    } else {
                        Logger.SendMessage(new TextObject("{=BC_v3QHtG}You're already applying a bandage!").ToString(), Severity.Normal);
                    }
                } else {
                    Logger.SendMessage(new TextObject("{=BC_dU1uDF}Out of bandages!").ToString(), Severity.Alert);
                }
            } else {
                Logger.SendMessage(new TextObject("{=BC_CfS4GM}You can't bandage while moving!").ToString(), Severity.Alert);
            }
        }
    }
}
