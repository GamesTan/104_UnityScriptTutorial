using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class Bullet : MonoBehaviour, ITriggerEventHandler {
        public GameObject hitEffectPrefab;
        public float lifeTime = 1;
        protected float lifeTimer;
        public float force = 300;

        public void Awake() {
            var children = GetComponentsInChildren<ChildTrigger>();
            foreach (var item in children) {
                item.Proxy = this;
            }
        }

        public void Update() {
            lifeTimer += Time.deltaTime;
            if (lifeTimer > lifeTime) {
                DoDestroy();
            }
        }

        protected virtual void DoDestroy() {
            GameObject.Destroy(gameObject);
        }

        public void OnTriggerEnter(Collider other) {
            _OnTriggerEnter(other);
        }

        public void OnTriggerExit(Collider other) {
            _OnTriggerEnter(other);
        }

        public void OnChildTriggerEnter(ChildTrigger src, Collider target) {
            Debug.Log($" OnChildTriggerEnter  {src.name} {target.name}");
            _OnTriggerEnter(target);
        }

        public void OnChildTriggerExit(ChildTrigger src, Collider target) {
            Debug.Log($" OnChildTriggerExit {src.name} {target.name}");
            _OnTriggerEnter(target);
        }

        protected virtual void _OnTriggerEnter(Collider other) {
            var rigid = other.GetComponent<Rigidbody>();
            if (rigid == null) {
                return;
            }
            var diff = other.transform.position - transform.position;
            rigid.AddForce(diff.normalized * force);
            
            if (hitEffectPrefab == null) return;
            var tran = GameObject.Instantiate(hitEffectPrefab).transform;
            tran.position = transform.position;
            tran.rotation = transform.rotation;
            tran.localScale = Vector3.one;
        }

        protected virtual void _OnTriggerExit(Collider other) { }

    }
}