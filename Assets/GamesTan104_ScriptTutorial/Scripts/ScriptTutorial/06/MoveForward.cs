using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class MoveForward : MonoBehaviour {
        public float moveSpeed = 5;
        private void Update() {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}