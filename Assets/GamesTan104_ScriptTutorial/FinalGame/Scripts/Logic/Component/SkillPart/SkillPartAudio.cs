using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    [System.Serializable]
    public class SkillPartAudio : DelaySkillPart {
        public AudioClip audioClip;

        protected override void _OnDelayCall() {
            if (audioClip != null) {
                AudioManager.Instance.PlayAudio(audioClip);
            }
        }
    }
}