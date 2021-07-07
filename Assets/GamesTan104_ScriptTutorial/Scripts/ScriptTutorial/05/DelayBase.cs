using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class DelayBase : MonoBehaviour {
        public float preDelay = 0;
        public float delay = 1;
        public GameObject target;

        protected float timer;
        public void Start() {
            timer = 0;
            if (target == null) {
                target = gameObject;
            }
        }

        public void Update() {
#if UNITY_EDITOR
            if (!Application.isPlaying) return;
#endif
            timer += Time.deltaTime;
            if (timer > (delay + preDelay)) {
                OnDelayCall();
            }
        }


        protected virtual void OnDelayCall(bool isEditor = false) { }
        
        
        public virtual void OnReset() {
            timer = 0;
        }
        
        
        public void EditorUpdate(float targetTimer) {
            this.timer = targetTimer;
            if (targetTimer > (delay + preDelay)) {
                OnDelayCall(true);
            }
            else {
                OnReset();
            }
        }
    }
}