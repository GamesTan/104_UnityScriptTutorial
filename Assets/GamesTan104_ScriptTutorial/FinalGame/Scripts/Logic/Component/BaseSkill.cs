using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    public class BaseSkill : MonoBehaviour {
        protected Player player;
        [Header("冷却")] public float cD = 1;

        [ReadOnly] [SerializeField] //
        private float cdTimer = 0;

        public float CdProgress => Mathf.Clamp01(1 - cdTimer / cD);
        public float CdTimer => cdTimer;

        [Header("技能时长")] public float duration = 1.5f;
        [ReadOnly] public float durationTimer = 0;
        [ReadOnly] public bool isPlaying = false;

        [Header("功能模块")] //
        public SkillPartAnimation partAnim = new SkillPartAnimation();
        public SkillPartBullet partBullet = new SkillPartBullet();
        public SkillPartEffect partEffect = new SkillPartEffect();
        public SkillPartAudio partAudio = new SkillPartAudio();

        protected List<BaseSkillPart> parts = new List<BaseSkillPart>();

        public void Awake() {
            player = GetComponent<Player>();
            RegisterSkillParts();
            foreach (var part in parts) {
                part.player = player;
                part.OnAwake();
            }
        }

        protected virtual void RegisterSkillParts() {
            parts.Add(partAnim);
            parts.Add(partBullet);
            parts.Add(partEffect);
            parts.Add(partAudio);
        }

        public void Start() {
            OnStart();
        }

        public void Update() {
            cdTimer -= Time.deltaTime;
            if (cdTimer < 0) cdTimer = 0;
            OnUpdate();
        }

        public bool Fire() {
            if (cdTimer > 0) return false;
            cdTimer = cD;
            OnFire();
            return true;
        }

        protected virtual void OnStart() { }

        protected virtual void OnFire() {
            player.curSkill = this;
            isPlaying = true;
            durationTimer = duration;
            foreach (var part in parts) {
                part.OnFire();
            }
        }

        protected virtual void OnUpdate() {
            var dt = Time.deltaTime;
            durationTimer -= dt;
            if (isPlaying) {
                if (durationTimer < 0) {
                    isPlaying = false;
                    OnDone();
                    return;
                }

                foreach (var part in parts) {
                    part.OnUpdate(dt);
                }
            }
        }

        protected virtual void OnDone() {
            foreach (var part in parts) {
                part.OnDone();
            }

            player.curSkill = null;
        }
    }
}