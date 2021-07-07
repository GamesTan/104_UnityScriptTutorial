using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace GamesTan.Tutorial104_Final {
    [Serializable]
    public partial class Player : MonoBehaviour {
        public static Player Instance { get; private set; }

        private List<BaseSkill> skills = new List<BaseSkill>();
        [ReadOnly] public BaseSkill curSkill;
        public bool IsPlayingSkill => curSkill != null;
        
        public Action<float> onPowerChanged;
        public Action<float> onHealthChanged;
        
        public int maxPower = 100;
        public int maxHealth = 100;
        
        
        [ReadOnly] [SerializeField] private int _health;

        public int health {
            get => _health;
            set {
                _health = value;
                _health = Mathf.Clamp(_health, 0, maxHealth);
                onHealthChanged?.Invoke(value * 1.0f / maxHealth);
            }
        }

        [ReadOnly] [SerializeField] private int _power;

        public int power {
            get => _power;
            set {
                _power = value;
                _power = Mathf.Clamp(_power, 0, maxPower);
                onPowerChanged?.Invoke(value * 1.0f / maxPower);
            }
        }


        public BaseSkill GetSkill(int idx) {
            if (idx < 0 || idx >= skills.Count) return null;
            return skills[idx];
        }

        public virtual void Awake() {
            Instance = this;
            health = maxHealth;
            skills.AddRange(GetComponents<BaseSkill>());
        }


        public bool Fire(int idx) {
            if (idx < 0 || idx >= skills.Count) return false;
            var skill = skills[idx];
            if (skill == null) return false;
            return skill.Fire();
        }
    }
}