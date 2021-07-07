using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    [System.Serializable]
    public class AddHealSkill : BaseSkill {
        [Header("----Demo 拓展----")]
        public int skillHealth = -5;
        public int skillPower = 10;

        protected override void OnFire() {
            base.OnFire();
            player.health += skillHealth;
            player.power += skillPower;
        }
    }
}