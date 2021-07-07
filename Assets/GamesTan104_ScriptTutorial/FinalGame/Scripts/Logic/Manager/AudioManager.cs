using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    public class AudioManager : MonoBehaviour {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioSource musicSource;
        private AudioClip musicClip;

        public void Awake() {
            Instance = this;
        }

        public void PlayAudio(AudioClip clip) {
            audioSource.PlayOneShot(clip);
        }

        public void PlayMusic(AudioClip clip) {
            musicClip = clip;
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }

        public void SetMusicProgress(float progress) {
            if (musicClip == null) return;
            musicSource.time = progress * musicClip.length;
        }

        public void Silence() {
            musicSource.volume = 0;
            audioSource.volume = 0;
        }

        public void SetMusicVolume(float val) {
            musicSource.volume = val;
        }

        public void SetAudioVolume(float val) {
            audioSource.volume = val;
        }
    }
}