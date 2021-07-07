using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0402_Mover : MonoBehaviour {
        private Player player;
        public Vector2 InputVec; // 
        public Animator anim;

        public void Awake() {
            player = GetComponent<Player>();
        }

        public float moveSpeed = 0;

        void Update() {
            // 玩家释放技能的时候 不能移动
            if (player.IsPlayingSkill) {
                //moveSpeed = -0.1f;
                //anim.SetFloat("MoveSpeed", moveSpeed);
                return;
            }
            
            var xVal = Input.GetAxis("Horizontal");
            var yVal = Input.GetAxis("Vertical");
            var vel = new Vector3(xVal, 0, yVal);
            var tran = player.transform;
            tran.position += vel * Time.deltaTime * 3;
            tran.forward = Vector3.Lerp(tran.forward, (vel).normalized, 0.1f).normalized;
            moveSpeed = Mathf.Abs(vel.magnitude) - 0.1f;
            anim.SetFloat("MoveSpeed", moveSpeed);

            InputVec = new Vector2(xVal, yVal);
            if (Input.GetKey(KeyCode.F)) {
                //Input.GetKeyDown
                player?.Fire(0);
            }
        }
    }
}