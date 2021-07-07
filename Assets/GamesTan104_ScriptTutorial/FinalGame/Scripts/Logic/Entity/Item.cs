using UnityEngine;

namespace GamesTan.Tutorial104_Final {
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