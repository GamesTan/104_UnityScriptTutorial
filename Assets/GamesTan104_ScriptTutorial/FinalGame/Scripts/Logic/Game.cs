using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamesTan.Tutorial104_Final {
    public class AccountData {
        public string name = "游戏谭";
        public int level = 1;
        public int heroType = 0;
    }

    public class Game : MonoBehaviour {
        public static Game Instance { get; private set; }
        public static AccountData accountData { get; private set; } = new AccountData();

        public int Score;

        public string LoginSceneName = "Tutorial_Login";
        public string FightSceneName = "Tutorial_Fight";

        private void Awake() {
            Instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(LoginSceneName);
        }

        public static void OnLoginSucc(AccountData data) {
            accountData = data;
            SceneManager.LoadScene(Instance.FightSceneName);
        }
    }
}