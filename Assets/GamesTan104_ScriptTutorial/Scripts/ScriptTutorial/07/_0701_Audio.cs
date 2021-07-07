using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0701_Audio : MonoBehaviour {
        [OnValueChanged("SetMusicProgress")] [Range(0, 1)]
        public float musicProgress;

        [OnValueChanged("SetMusicVolume")] [Range(0, 2)]
        public float musicVolume;

        [OnValueChanged("SetAudioVolume")] [Range(0, 2)]
        public float audioVolume;
        
        [MinMaxSlider(0.05f,1)]
        public Vector2 randomRange = new Vector2(0.1f, 1f);

        public List<AudioClip> audioClips = new List<AudioClip>();
        public AudioClip musicClip;


        
        private void Start() {
            AudioManager.Instance.PlayMusic(musicClip);
            StartCoroutine(AutoPlayAudios());
        }

        IEnumerator AutoPlayAudios() {
            if (audioClips.Count == 0) yield break;
            while (true) {
                var time = UnityEngine.Random.Range(randomRange.x, randomRange.y);
                var idx = UnityEngine.Random.Range(0, audioClips.Count);
                AudioManager.Instance.PlayAudio(audioClips[idx]);
                yield return new WaitForSeconds(time);
            }
        }

        [Button()]
        public void Silence() {
            AudioManager.Instance.Silence();
        }


        void SetMusicProgress() {
            AudioManager.Instance.SetMusicProgress(musicProgress);
        }

        private void SetMusicVolume() {
            Debug.Log("SetMusicVolume " + musicVolume);
            AudioManager.Instance.SetMusicVolume(musicVolume);
        }

        private void SetAudioVolume( ) {
            Debug.Log("SetAudioVolume " + audioVolume);
            AudioManager.Instance.SetAudioVolume(audioVolume);
        }
    }
}