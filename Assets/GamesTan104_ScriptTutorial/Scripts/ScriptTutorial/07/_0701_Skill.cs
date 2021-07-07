using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0701_Skill : _0601_Skill {
        public AudioClip audioClip;

        protected override void CreateBullet() {
            base.CreateBullet();
            if (audioClip != null) {
                AudioManager.Instance.PlayAudio(audioClip);
            }
        }
    }
}