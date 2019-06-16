using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skysemi.With.Scenes
{
    public class Title : MonoBehaviour
    {
        public Canvas canvas;
        public GameObject panelDialog;
        // Start is called before the first frame update
        void Start()
        {
//            SoundManager.instance.StopMusic();
            EquipmentCardField eqpt = new EquipmentCardField();
            eqpt.Init();

//            CardBoard cardBoard = CardBoard.CreateCardBoardInCanvasUI(canvas);
//            cardBoard.Init();

        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void PushStart() {
            /// DEBUG用
//		SceneManager.LoadScene("Scenes/HomeScene");
//		return;
            //セーブデータが有る場合は続きからスタートする
            //SceneManager.LoadScene("Scenes/GameMain");
            int gameProgress = PlayerPrefs.GetInt("GameProgress");
            ;
            if (gameProgress >= (int)EGameProgress.SHOW_OTHER_STAGE_1)
            {
                SceneManager.LoadScene("Scenes/HomeSecondScene");
            }
            else if (gameProgress >= (int)EGameProgress.GAME_START)
            {
                SceneManager.LoadScene("Scenes/HomeScene");
            }
            else
            {
                SceneManager.LoadScene("Scenes/FirstInputScene");
            }
        }
        public void PushBtnGameShutdown()
        {
            Application.Quit();
        }
    
        public void PushDialogForSaveYesNo()
        {
            panelDialog.SetActive(true);
        }
        public void PushDelete()
        {
            Game.instance.DeleteSaveData();	
            panelDialog.SetActive(false);
        }
        public void PushCancel()
        {
            panelDialog.SetActive(false);
        }
    }
}
