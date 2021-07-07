using NaughtyAttributes;

namespace GamesTan.Tutorial104 {
    public partial class Player {
        [ReadOnly] public Skill curSkill;
        public bool IsPlayingSkill => curSkill != null;
    }
}