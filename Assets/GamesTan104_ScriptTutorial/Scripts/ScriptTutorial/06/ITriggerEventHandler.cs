using UnityEngine;

namespace GamesTan.Tutorial104 {
    public interface ITriggerEventHandler {
        void OnChildTriggerEnter(ChildTrigger src, Collider target);

        void OnChildTriggerExit(ChildTrigger src, Collider target);
    }
}