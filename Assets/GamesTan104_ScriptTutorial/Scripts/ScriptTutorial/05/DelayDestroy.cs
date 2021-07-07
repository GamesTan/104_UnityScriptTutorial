using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace GamesTan.Tutorial104 {
    public class DelayDestroy : DelayBase {
        public override void OnReset() {
            base.OnReset();
#if UNITY_EDITOR
            target.SetActive(true);
#endif
        }

        protected override void OnDelayCall(bool isEditor = false) {
            base.OnDelayCall();
            // Editor 模式下 非运行状态 就设置为Active 为false 
#if UNITY_EDITOR
            if (!Application.isPlaying) {
                target.SetActive(false);
                return;
            }
#endif
            GameObject.Destroy(target);
        }
    }
}