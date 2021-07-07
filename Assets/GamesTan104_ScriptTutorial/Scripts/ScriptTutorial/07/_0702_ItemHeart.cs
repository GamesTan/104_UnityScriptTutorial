using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0702_ItemHeart : Item {
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