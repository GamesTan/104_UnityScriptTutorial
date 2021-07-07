using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    public class ItemHeart : Item {
        public int count;
        public AudioClip audio;
        protected override void OnTriggerTarget(Player player) {
            player.health += 30;
            if (audio != null) {
                AudioManager.Instance.PlayAudio(audio);
            }
        }
    }
}