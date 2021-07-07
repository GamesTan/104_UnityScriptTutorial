using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0501_Skill : _0402_Skill {
        [Header("------------")]
        public GameObject effectPrefab;
        public Transform hangPoint;
        public bool isAttachToPoint;

        protected override void OnFire() {
            base.OnFire();
            if (effectPrefab != null) {
                if (hangPoint != null) {
                    var go = GameObject.Instantiate(effectPrefab, isAttachToPoint ? hangPoint : null);
                    go.transform.position = hangPoint.position;
                    go.transform.localScale = Vector3.one;
                    go.transform.rotation = hangPoint.rotation;
                }
            }
        }
    }
}