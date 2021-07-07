using NaughtyAttributes;

namespace GamesTan.Tutorial104_Final {
    public class DelaySkillPart : BaseSkillPart {
        public float delay;
        protected float delayTimer;
        protected bool hasCalled;


        public override void OnFire() {
            delayTimer = 0;
            hasCalled = false;
            _OnFire();
        }

        public override void OnUpdate(float dt) {
            delayTimer += dt;
            if (delayTimer > delay) {
                if (!hasCalled) {
                    _OnDelayCall();
                    hasCalled = true;
                }

                _OnUpdate();
            }
        }

        protected virtual void _OnFire() { }
        protected virtual void _OnUpdate() { }
        protected virtual void _OnDelayCall() { }
    }
}