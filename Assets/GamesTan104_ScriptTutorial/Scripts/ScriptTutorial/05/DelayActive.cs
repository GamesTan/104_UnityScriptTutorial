using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class DelayActive : DelayBase {
        public bool IsActive = true;

        public override void OnReset() {
            base.OnReset();
            target.SetActive(!IsActive);
        }


        protected override void OnDelayCall(bool isEditor = false) {
            base.OnDelayCall();
            if (!isEditor) {
                if (target.activeSelf != target) {
                    target.SetActive(IsActive);
                    var ps = target.GetComponent<ParticleSystem>();
                    if (IsActive) {
                        ps.Play();
                    }
                    else {
                        ps.Stop();
                    }
                }
            }
            
            
#if UNITY_EDITOR
            if (isEditor) {
                if (target.activeSelf != target) {
                    target.SetActive(false);
                    var particles = target.GetComponentsInChildren<ParticleSystem>();
                    foreach (var ps in particles) {
                        ps.useAutoRandomSeed = false;
                    }

                    target.SetActive(IsActive);
                }

                if (IsActive) {
                    var realTime = timer - delay - preDelay;
                    var particleSystems = target.GetComponentsInChildren<ParticleSystem>();
                    particleSystems[0].Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    for (int i = particleSystems.Length - 1; i >= 0; i--) {
                        particleSystems[i].Play(false);
                        particleSystems[i].Simulate(realTime, false, false, true);
                        if (realTime <= 0.0f) {
                            particleSystems[i].Play(false);
                            particleSystems[i].Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
                        }
                    }
                }
            }
#endif
        }
    }
}