using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class Item : MonoBehaviour {
        protected virtual void OnTriggerEnter(Collider other) {
            var player = other.GetComponent<Player>();
            if (player != null) {
                OnTriggerTarget(player);
                GameObject.Destroy(gameObject);
            }
        }
        protected virtual void OnTriggerTarget(Player player) { }
    }
}