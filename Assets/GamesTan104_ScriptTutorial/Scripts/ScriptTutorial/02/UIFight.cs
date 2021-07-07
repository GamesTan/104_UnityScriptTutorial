using System;
using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.Tutorial104 {
    public class UIFight : MonoBehaviour {
        //public Text text
        public Text TextLevel;
        public Text TextName;
        public Image ImageHero;

        public Slider SliderHealth;
        public Slider SliderPower;

        private void Start() {
            SliderHealth.onValueChanged.AddListener((fval) => { });
            Player.Instance.onHealthChanged += OnHealthChanged;
            Player.Instance.onPowerChanged += OnPowerChanged;
            OnHealthChanged(Player.Instance.health);
            OnPowerChanged(Player.Instance.power);
            TextName.text = Game.accountData.name;
            TextLevel.text = Game.accountData.level.ToString();
        }

        private void OnHealthChanged(float value) {
            SliderHealth.value = value;
        }

        private void OnPowerChanged(float value) {
            SliderPower.value = value;
        }
    }
}