using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace GamesTan.Tutorial104 {


    public class _0401_Animation : MonoBehaviour {
        public Animation _animation;
        public Animator _animator;

        [Header("All Animators")] public List<string> names = new List<string>();
        

        [Button()]
        void ShowAnimations() {
            StartCoroutine(PlayAllAnimation());
        }

        IEnumerator PlayAllAnimation() {
            var lst = new List<string>();
            foreach (AnimationState clipState in _animation) {
                lst.Add(clipState.name);
            }

            yield return new WaitForSeconds(1);
            _animation.Play("Warrior_Gethit");
            yield return new WaitForSeconds(1);
            _animation.CrossFade("Warrior_Run");
            var stateAnim = _animation["Warrior_Run"];
            stateAnim.wrapMode = WrapMode.Loop;
            yield return new WaitForSeconds(3);
            stateAnim.speed = 0.2f;
            yield return new WaitForSeconds(4);
            stateAnim.speed = 1.2f;

            foreach (var clipName in lst) {
                _animation.Play(clipName);
                Debug.Log("Playing Animation " + clipName);
                var clip = _animation.GetClip(clipName);
                var len = clip.length;
                var state = _animation[clipName];
                state.speed = 2;
                float timer = 0;
                while (timer < len) {
                    timer += Time.deltaTime * state.speed;
                    yield return null;
                }
            }
        }
        
        
        [Button()]
        void ShowAnimators() {
            StartCoroutine(PlayAnimator());
        }


        IEnumerator PlayAnimator() {
            yield return new WaitForSeconds(1);
            _animator.SetTrigger("Hit");
            yield return new WaitForSeconds(1);
            _animator.SetFloat("MoveSpeed", 1);
            yield return new WaitForSeconds(3);
            _animator.speed = 0.2f;
            yield return new WaitForSeconds(4);
            _animator.speed = 1.2f;
            foreach (var name in names) {
                Debug.Log("Play Animator ");
                _animator.Play(name);
                _animator.Update(0);
                var state = _animator.GetCurrentAnimatorStateInfo(0);
                var len = state.length; // 动画时长
                float timer = 0;
                while (timer < len) {
                    timer += Time.deltaTime;
                    yield return null;
                    state = _animator.GetCurrentAnimatorStateInfo(0);
                    if (!state.IsName(name)) {
                        break;
                    }
                }
            }
        }

    }
}