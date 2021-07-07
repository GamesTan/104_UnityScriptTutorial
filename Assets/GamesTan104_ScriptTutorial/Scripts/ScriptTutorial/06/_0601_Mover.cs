using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0601_Mover : _0501_Mover {
        public Rigidbody tranRig => player.GetComponent<Rigidbody>();

        protected override void ApplyVec(Transform tran, Vector3 vel) {
            tranRig.velocity = new Vector3(vel.x, tranRig.velocity.y, vel.z);
            //tran.position += vel * Time.deltaTime;
        }

        public override void Update() {
            // 玩家释放技能的时候 不能移动
            if (player.IsPlayingSkill) {
                moveSpeed = 0;
                tranRig.velocity = Vector3.zero;
                anim.SetFloat("MoveSpeed", moveSpeed);
                return;
            }
            DealInput();
        }
    }
}