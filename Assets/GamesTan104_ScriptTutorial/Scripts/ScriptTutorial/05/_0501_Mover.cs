using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0501_Mover : MonoBehaviour {
        protected Player player;
        public Vector2 InputVec; // 
        public Animator anim;
        public float moveSpeed = 3;
        public float Speed = 5;

        public void Awake() {
            player = GetComponent<Player>();
            if (anim == null) {
                anim = player.GetComponentInChildren<Animator>();
            }
        }


        public virtual void Update() {
            // 玩家释放技能的时候 不能移动
            if (player.IsPlayingSkill) {
                moveSpeed = 0;
                anim.SetFloat("MoveSpeed", moveSpeed);
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
            moveSpeed = Mathf.Abs(vel.magnitude) - 0.1f;
            anim.SetFloat("MoveSpeed", moveSpeed);

            ApplyVec(tran, vel.normalized * Speed);
            InputVec = new Vector2(xVal, yVal);
            if (Input.GetKey(KeyCode.F)) {
                //Input.GetKeyDown
                player?.Fire(0);
            }
        }

        protected virtual void ApplyVec(Transform tran, Vector3 vel) {
            tran.position += vel * Time.deltaTime;
        }
    }
}