using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    public class BaseSkillPart {
        [HideInInspector] public Player player;
        public virtual void OnAwake() { }
        public virtual void OnFire() { }
        public virtual void OnUpdate(float dt) { }
        public virtual void OnDone() { }
    }
}