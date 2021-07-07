using System.Collections.Generic;
using NaughtyAttributes;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace GamesTan.Tutorial104 {
    [ExecuteInEditMode]
    public class EffectEditorTool : MonoBehaviour {
#if UNITY_EDITOR
        public string stateName;
        public GameObject animOwner;
        public GameObject effectGo;
        [ReadOnly] public float timer = 0;

        [Range(0, 1)] [OnValueChanged("OnSliderChanged")]
        public float sliderRange;

        public bool isAutoUpdate = false; // 是否自动播放
        public bool isLoop = true; // 是否循环播放

        private Animator anim => animOwner.GetComponentInChildren<Animator>();

        public void OnEnable() {
            EditorApplication.update -= DoUpdate;
            EditorApplication.update += DoUpdate;
        }

        public void OnDisable() {
            EditorApplication.update -= DoUpdate;
        }

        void DoUpdate() {
            if (anim == null || effectGo == null) return;
            if (isAutoUpdate) {
                timer += Time.deltaTime;
                var len = GetAnimationLen();
                sliderRange = timer / len;
                UpdateAnimationAndParticles(sliderRange);
                if (isLoop && timer > GetAnimationLen()) {
                    timer = 0;
                    Reset();
                }
            }
        }


        public void OnSliderChanged() {
            if (animOwner == null) return;
            if (effectGo == null) return;
            var len = GetAnimationLen();
            timer = sliderRange * len;
            UpdateAnimationAndParticles(sliderRange);
        }

        private float GetAnimationLen() {
            if (anim == null) return -1;
            var innerAc = anim.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
            var sm = innerAc.layers[0].stateMachine;
            var animName = "";
            foreach (var state in sm.states) {
                if (stateName == state.state.name) {
                    animName = state.state.motion.name;
                }
            }

            var anims = anim.runtimeAnimatorController.animationClips;
            float len = -1;
            foreach (var clip in anims) {
                if (clip.name == animName) {
                    len = clip.length;
                    break;
                }
            }

            return len;
        }

        private void UpdateAnimationAndParticles(float val) {
            if (timer < 0) return;
            PlayAnimation(val);
            UpdateParticle(timer);
        }


        [Button()]
        public void Reset() {
            var allDelayEffect = effectGo.GetComponentsInChildren<DelayBase>();
            foreach (var item in allDelayEffect) {
                item.OnReset();
            }

            foreach (var item in allDelayEffect) {
                item.Start();
            }
        }


        private void UpdateParticle(float time) {
            var allDelayEffect = effectGo.GetComponentsInChildren<DelayBase>();
            foreach (var effect in allDelayEffect) {
                effect.EditorUpdate(time);
            }
        }

        private void PlayAnimation(float normalizeTime) {
            if (anim == null)
                return;
            anim.Play(stateName, 0, normalizeTime);
            anim.Update(0);
        }

        #region 重置 位置，方便调整特效

        class TransInfo {
            public Vector3 pos;
            public Vector3 rot;
        }

        [Button()]
        public void ApplyOffset() {
            List<TransInfo> allTransInfos = new List<TransInfo>();
            foreach (Transform tran in effectGo.transform) {
                allTransInfos.Add(new TransInfo() {pos = tran.position, rot = tran.eulerAngles});
            }

            effectGo.transform.localPosition = Vector3.zero;
            effectGo.transform.localEulerAngles = Vector3.zero;
            for (int i = 0; i < allTransInfos.Count; i++) {
                var tran = effectGo.transform.GetChild(i);
                tran.position = allTransInfos[i].pos;
                tran.eulerAngles = allTransInfos[i].rot;
            }
        }

        #endregion

#endif
    }
}