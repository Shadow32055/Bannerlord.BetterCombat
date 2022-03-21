using System;
using BetterCombat.Utils;
using TaleWorlds.Library;
using BetterCombat.Custom;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Localization;

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
                            Helper.DisplayMsg(new TextObject("{=BC_qezRvY}Bandaging canceled due to movment!").ToString());
                            activlyBandaging = false;
                        }

                        if (bandageTime.IsPast) {
                            float healAmount = GetHealAmount(Helper.settings.BandageHealAmount);
                            if (hm.AvaiableHealingLeft()) {
                                Mission.Current.MainAgent.Health += healAmount;
                                hm.AddOutput(healAmount);
                                bandagesLeft--;
                            } else {
                                Helper.DisplayMsg(new TextObject("{=BC_7cWw3B}No more avaiable healing!").ToString());
                            }

                            activlyBandaging = false;

                            string text;
                            if (bandagesLeft < 2) {
                                text = String.Format(new TextObject("{=BC_YZj7gF}Bandage applied! Only {0} bandage left!").ToString(), bandagesLeft);
                            } else {
                                text = String.Format(new TextObject("{=BC_q2WCze}Bandage applied! {0} bandages left!").ToString(), bandagesLeft);
                            }

                            Helper.DisplayMsg(text);
                        }
                    }

                    if (Input.IsKeyPressed(Helper.bandageKey)) {
                        UseBandage();
                    }

                }
            } catch (Exception e) {
                Helper.WriteToLog("Problem with bandages, cause: " + e);
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
                            bandageTime = MissionTime.SecondsFromNow(Helper.settings.BandageTime);
                            activlyBandaging = true;
                            Helper.DisplayMsg(String.Format(new TextObject("{=BC_RnoIZo}Applying bandage... It will take {0} seconds.").ToString(), Helper.settings.BandageTime));
                        } else {
                            Helper.DisplayMsg(new TextObject("{=BC_359Qlt}You're health is full.").ToString());
                        }
                    } else {
                        Helper.DisplayMsg(new TextObject("{=BC_v3QHtG}You're already applying a bandage!").ToString());
                    }
                } else {
                    Helper.DisplayWarningMsg(new TextObject("{=BC_dU1uDF}Out of bandages!").ToString());
                }
            } else {
                Helper.DisplayWarningMsg(new TextObject("{=BC_CfS4GM}You can't bandage while moving!").ToString());
            }
        }
    }
}
