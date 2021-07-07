using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    [System.Serializable]
    public class SkillPartAnimation : BaseSkillPart {
        protected Animator anim;
        public override void OnAwake() {
            if (anim == null) {
                anim = player.GetComponentInChildren<Animator>();
            }
        }
        public override void OnFire() {
            anim?.SetTrigger("Attack");
        }
    }
}