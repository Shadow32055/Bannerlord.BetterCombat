using BetterCombat.Utils;
using System.Collections.Generic;
using TaleWorlds.MountAndBlade;

namespace BetterCombat.Custom {
    public class HealthManager {

        private List<float> outputs = new List<float>();
        private float maxHealing = Helper.settings.HealingAmount;
        private float possibleHealing;

        public HealthManager(Agent agent) {
            possibleHealing = maxHealing;
        }

        public void AddOutput(float value) {
            //Helper.DisplayFriendlyMsg("Added value to stack: " + value.ToString());
            if (value > 0) {
                possibleHealing -= value;
            }

            outputs.Add(value);
        }

        public float GetOutput() {
            float output = 0;

            if (outputs.Count > 0) {
                foreach (float value in outputs) {
                    output += value;
                }
            }

            outputs.Clear();

            return output;
        }

        public bool AvaiableHealingLeft() {
            if (Helper.settings.HealingLimit) {
                if (possibleHealing > 0) {
                    return true;
                }
                return false;
            } else {
                return true;
            }
        }

        public float GetHealAmount(float healAmount, Agent agent) {
            if ((healAmount + agent.Health) > agent.HealthLimit) {
                return agent.HealthLimit - agent.Health;
            }

            return healAmount;
        }

    }
}
