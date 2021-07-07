using System;
using NaughtyAttributes;
using UnityEngine;

namespace GamesTan.Tutorial104 {
    // 1. layer 筛选 过滤
    public class _0601_Skill : _0501_Skill {
        
        [Header("---------Bullet---------")] //
        public GameObject bulletPrefab;

        public Transform bulletPoint;
        public bool IsAttachBulletToParent = false;

        public float bulletDelay;
        [ReadOnly] public float bulletTimer;
        [ReadOnly] public bool hasBulletReleased;

        protected override void OnFire() {
            hasBulletReleased = false;
            bulletTimer = 0;
            base.OnFire();
        }

        protected override void OnUpdate() {
            durationTimer -= Time.deltaTime;
            if (isPlaying) {
                if (durationTimer < 0) {
                    isPlaying = false;
                    OnDone();
                }

                // 增加子弹的释放
                if (!hasBulletReleased) {
                    bulletTimer += Time.deltaTime;
                    if (bulletTimer > bulletDelay) {
                        CreateBullet();
                        hasBulletReleased = true;
                    }
                }
            }
        }


        protected virtual void CreateBullet() {
            if (bulletPrefab != null) {
                if (bulletPoint != null) {
                    var go = GameObject.Instantiate(bulletPrefab, IsAttachBulletToParent ? bulletPoint : null);
                    go.transform.position = bulletPoint.position;
                    go.transform.localScale = Vector3.one;
                    go.transform.rotation = bulletPoint.rotation;
                }
            }
        }
    }
}