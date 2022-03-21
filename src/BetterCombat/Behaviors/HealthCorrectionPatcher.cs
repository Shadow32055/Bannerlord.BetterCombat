using System;
using TaleWorlds.CampaignSystem;

namespace BetterCombat.Behaviors {
    class HealthCorrectionPatcher : CampaignBehaviorBase {
        public override void RegisterEvents() {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, new Action<CampaignGameStarter>(this.OnSessionLaunched));
        }

        public override void SyncData(IDataStore dataStore) {}

        private void OnSessionLaunched(CampaignGameStarter campaignGameStarter) {
            foreach (Hero hero in Hero.AllAliveHeroes) {
                if (hero.HitPoints > hero.MaxHitPoints) {
                    hero.HitPoints = hero.MaxHitPoints;
                }
            }

            /*foreach (CharacterObject co in CharacterObject.All) {
                Hero hero = (Hero)co.HeroObject;

                if (hero == null)
                    continue;

                if (hero.HitPoints > hero.MaxHitPoints) {
                    hero.HitPoints = hero.MaxHitPoints;
                }
            }*/

            /*foreach (MobileParty party in MobileParty.All) {
                foreach (TroopRosterElement tre in party.Party.MemberRoster.GetTroopRoster()) {
                    CharacterObject co = (CharacterObject)tre.Character;
                    Hero hero = (Hero)co.HeroObject;
                    if (hero.HitPoints > hero.MaxHitPoints) {
                        hero.HitPoints = hero.MaxHitPoints;
                    }
                }
            }*/
        }
    }
}
