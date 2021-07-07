using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _060102_AutoMove : MonoBehaviour {
        public float moveSpeed = 2;

        public void Update() {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}