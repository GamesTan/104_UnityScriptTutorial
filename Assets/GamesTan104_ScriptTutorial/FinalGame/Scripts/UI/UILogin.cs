using UnityEngine;
using UnityEngine.UI;

namespace GamesTan.Tutorial104_Final {
    public class UILogin : MonoBehaviour {
        public InputField InputFieldAccount;
        public InputField InputFieldPassword;
        public Toggle ToggleRemember;
        public Button ButtonLogin;

        private const string PlayerAccount = "_GAMES_TAN_LOGIN_ACCOUNT";
        private const string PlayerPassword = "_GAMES_TAN_LOGIN_PASSWORD";
        private const string PlayerRememberALL = "_GAMES_TAN_REMEMBER_ALL";

        void Start() {
            ButtonLogin.onClick.AddListener(OnClick_BtnLogin);
            //ToggleRemember.onValueChanged.AddListener((isOn) => { });
            //InputFieldPassword.onValueChanged.AddListener((text) => { });
            
            ToggleRemember.isOn = PlayerPrefs.GetInt(PlayerRememberALL, 1) != 0;
            if (ToggleRemember.isOn) {
                Load();
            }
            else {
                InputFieldAccount.text ="";
                InputFieldPassword.text ="";
            }
        }

        public void Save(string account, string password) {
            PlayerPrefs.SetString(PlayerAccount, account);
            PlayerPrefs.SetString(PlayerPassword, password);
            PlayerPrefs.SetInt(PlayerRememberALL, ToggleRemember.isOn ? 1 : 0);
        }

        private void Load() {
            InputFieldAccount.text = PlayerPrefs.GetString(PlayerAccount, InputFieldAccount.text);
            InputFieldPassword.text = PlayerPrefs.GetString(PlayerPassword, InputFieldPassword.text);
        }

        private void OnClick_BtnLogin() {
            var account = InputFieldAccount.text;
            var password = InputFieldPassword.text;
            if (ToggleRemember.isOn) {
                Save(account, password);
            }
            else {
                Save("", "");
            }
            Login(account, password);
        }

        private void Login(string account, string password) {
            // TODO send msg to server
            Debug.Log($"Login {account} {password}");
            Game.OnLoginSucc(new AccountData() {
                name = "游戏谭",
                level = 3,
                heroType = 0
            });
        }
    }
}