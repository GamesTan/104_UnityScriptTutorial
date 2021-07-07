using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class Mover : MonoBehaviour {
        private Player player;
        public Vector2 InputVec; // 
        public void Awake() {
            player = GetComponent<Player>();
        }

        void Update() {
            var xVal = Input.GetAxis("Horizontal");
            var yVal = Input.GetAxis("Vertical");
            player.transform.position += new Vector3(xVal,0,yVal) * Time.deltaTime *3;
            
            InputVec = new Vector2(xVal, yVal);
            if (Input.GetKey(KeyCode.F)) {
                //Input.GetKeyDown
                player?.Fire(0);
            }
        }
    }
}