using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    [System.Serializable]
    public class SkillPartEffect : DelaySkillPart {
        public GameObject prefab;
        public Transform hangPoint;
        public bool isAttachToPoint;

        protected override void _OnDelayCall() {
            if (prefab != null) {
                if (hangPoint != null) {
                    var go = GameObject.Instantiate(prefab, isAttachToPoint ? hangPoint : null);
                    go.transform.position = hangPoint.position;
                    go.transform.localScale = Vector3.one;
                    go.transform.rotation = hangPoint.rotation;
                }
            }
        }
    }
}