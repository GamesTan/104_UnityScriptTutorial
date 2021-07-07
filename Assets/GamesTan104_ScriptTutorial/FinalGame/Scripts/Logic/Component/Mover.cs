using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    public class Mover : MonoBehaviour {
        protected Player player;
        protected Animator anim;
        protected Rigidbody tranRig;
        
        public float speed = 5;
        
        public void Awake() {
            player = GetComponent<Player>();
            if (anim == null) {
                anim = player.GetComponentInChildren<Animator>();
            }

            tranRig = player.GetComponent<Rigidbody>();
        }

        public virtual void Update() {
            // 玩家释放技能的时候 不能移动
            if (player.IsPlayingSkill) {
                tranRig.velocity = Vector3.zero;
                anim.SetFloat("MoveSpeed", 0);
                return;
            }
            DealInput();
        }

        protected void DealInput() {
            var xVal = Input.GetAxis("Horizontal");
            var yVal = Input.GetAxis("Vertical");
            var vel = new Vector3(xVal, 0, yVal);
            var tran = player.transform;
            tran.forward = Vector3.Lerp(tran.forward, (vel).normalized, 0.1f).normalized;
            var moveSpeed = Mathf.Abs(vel.magnitude) - 0.1f;
            anim.SetFloat("MoveSpeed", moveSpeed);

            ApplyVec(tran, vel.normalized * speed);
            if (Input.GetKey(KeyCode.F)) {
                //Input.GetKeyDown
                player?.Fire(0);
            }
        }

        protected virtual void ApplyVec(Transform tran, Vector3 vel) {
            tranRig.velocity = new Vector3(vel.x, tranRig.velocity.y, vel.z);
            //tran.position += vel * Time.deltaTime;
        }
    }
}