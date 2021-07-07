using System;
using NaughtyAttributes;
using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0402_Skill : Skill {
        public Animator anim;
        public float duration = 1.5f;
        [ReadOnly] public float durationTimer = 0;
        [ReadOnly] public bool isPlaying = false;

        public void Start() {
            if (anim == null) {
                anim = player.GetComponentInChildren<Animator>();
            }
        }

        protected override void OnUpdate() {
            base.OnUpdate();
            durationTimer -= Time.deltaTime;
            if (isPlaying) {
                if (durationTimer < 0) {
                    isPlaying = false;
                    OnDone();
                }
            }
        }

        protected virtual void OnDone() {
            player.curSkill = null;
        }

        protected override void OnFire() {
            player.curSkill = this;
            isPlaying = true;
            durationTimer = duration;
            anim.SetTrigger("Attack");
        }
    }
}