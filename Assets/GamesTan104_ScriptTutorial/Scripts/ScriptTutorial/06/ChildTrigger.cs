using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class ChildTrigger : MonoBehaviour {
        public ITriggerEventHandler Proxy;

        public void OnTriggerEnter(Collider other) {
            Debug.Log("OnTriggerEnter " + other.name);
            Proxy?.OnChildTriggerEnter(this, other);
        }

        public void OnTriggerExit(Collider other) {
            Debug.Log("OnTriggerExit " + other.name);
            Proxy?.OnChildTriggerExit(this, other);
        }
    }
}