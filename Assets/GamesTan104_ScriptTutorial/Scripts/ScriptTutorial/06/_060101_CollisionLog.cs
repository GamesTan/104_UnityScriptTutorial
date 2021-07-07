using System;
using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _060101_CollisionLog : MonoBehaviour {
        public string myName => "" + transform.parent.name + "/" + name;

        private void OnTriggerEnter(Collider other) {
            Debug.Log(myName + "  " + " OnTriggerEnter " + other.name);
        }

        private void OnTriggerStay(Collider other) {
            Debug.Log(myName + "  " + "OnTriggerStay " + other.name);
        }

        private void OnTriggerExit(Collider other) {
            Debug.Log(myName + "  " + "OnTriggerExit " + other.name);
        }

        private void OnCollisionEnter(Collision other) {
            Debug.Log(myName + "  " + "OnCollisionEnter " + other.collider.name);
        }

        private void OnCollisionStay(Collision other) {
            Debug.Log(myName + "  " + "OnCollisionStay " + other.collider.name);
        }

        private void OnCollisionExit(Collision other) {
            Debug.Log(myName + "  " + "OnCollisionExit " + other.collider.name);
        }
    }
}