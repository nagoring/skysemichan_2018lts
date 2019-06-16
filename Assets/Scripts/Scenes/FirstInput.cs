using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Skysemi.With.Scenes
{
    public class FirstInputManager : MonoBehaviour {
        public InputField inputField;
        public Button btnApply;
        public GameObject textError;
        // Use this for initialization

        public void InputName() {
        }
        public void PushBtnApply() {
            if (inputField.text.Length == 0 || inputField.text.Length > 8)
            {
                textError.SetActive(true);
                return;
            }
            PlayerPrefs.SetString(ESave.PlayerName.ToString(), inputField.text);
//        GameSystem.instance.SetGameProgress(EGameProgress.GAME_START);
//
//		
//        //プレイヤーの初期化
//        Player.instance.Init(inputField.text);
//        GameSystem.instance.Save();
            //最初の拠点イベントへ移動
//		SceneManager.LoadScene("Scenes/FirstEventScene");
            SceneManager.LoadScene("Scenes/HomeScene");
        }
    }
}
