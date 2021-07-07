using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamesTan.Tutorial104 {
    public class AccountData {
        public string name = "游戏谭";
        public int level = 1;
        public int heroType = 0;
    }

    public class Game : MonoBehaviour {
        public static AccountData accountData { get; private set; } = new AccountData();

        public int Score;

        private void Awake() {
            GameObject.DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("Tutorial0201_UILogin");
        }

        public static void OnLoginSucc(AccountData data) {
            accountData = data;
            SceneManager.LoadScene("Tutorial0202_UIGame");
        }
    }
}