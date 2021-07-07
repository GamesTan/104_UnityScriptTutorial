using System;
using NaughtyAttributes;
using UnityEngine;

namespace GamesTan.Tutorial104 {
    [Serializable]
    public partial class Skill : MonoBehaviour {
        protected Player player;
        [ReadOnly] [SerializeField] private float cdTimer = 0;
        public float cD = 1;
        public float CdProgress => Mathf.Clamp01(1 - cdTimer / cD);
        public float CdTimer => cdTimer;

        public int skillHealth = -5;
        public int skillPower = 10;

        public void Awake() {
            player = GetComponent<Player>();
        }

        public void Update() {
            cdTimer -= Time.deltaTime;
            if (cdTimer < 0) cdTimer = 0;
            OnUpdate();
        }
        protected virtual void OnUpdate() { }

        public bool Fire() {
            if (cdTimer > 0) return false;
            cdTimer = cD;
            player.health += skillHealth;
            player.power += skillPower;
            OnFire();
            return true;
        }

        protected virtual void OnFire() { }
    }
}