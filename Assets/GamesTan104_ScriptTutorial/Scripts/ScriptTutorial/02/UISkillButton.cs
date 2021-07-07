using System;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.Tutorial104 {
    public class UISkillButton : MonoBehaviour {
        public Image ImageMask;
        public Button BtnSkill;
        public Text TextCd;
        public int idx;

        private Skill skill;

        private void Start() {
            skill = Player.Instance.GetSkill(idx);
            BtnSkill.onClick.AddListener(OnClickBtnSkill);
        }

        private void Update() {
            if (skill == null) return;
            ImageMask.fillAmount = 1 - skill.CdProgress;
            TextCd.text = skill.CdTimer > 0 ? skill.CdTimer.ToString() : "";
        }

        private void OnClickBtnSkill() {
            Player.Instance.Fire(idx);
        }
    }
}