using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skysemi.With.Scenes
{
    public class Home : MonoBehaviour
    {
        public GameObject btnStage1;
        public GameObject btnStage2;
        public GameObject btnStage3;
        public GameObject btnStage4;
        public GameObject canvas;
        public GameObject canvasSaveArea;

        public AudioClip musicHome;

        private int msgCounter = 0;

//         public void ScenedLoading()
//         {
//             EGameProgress eGameProgress = (EGameProgress) PlayerPrefs.GetInt(ESave.GameProgress.ToString());
//
//             if (PlayerPrefs.GetString(ESave.Player.ToString(), "") == "")
//             {
//                 //もしHomeから始まってデータがなかった場合の処理。通常は来ない分岐
//                 string playerName = PlayerPrefs.GetString(ESave.PlayerName.ToString(), "名無しさん");
//                 Player.instance.Init(playerName);
//                 PlayerPrefsUtils.SetObject<Player.Param>(ESave.Player.ToString(), Player.instance.GetParam());
//             }
//
//             if (eGameProgress == EGameProgress.ZERO)
//             {
//                 //もしHomeから始まってデータがなかった場合の処理。通常は来ない分岐
//                 Game.instance.SetGameProgress(EGameProgress.GAME_START);
//             }
//             else if (eGameProgress == EGameProgress.GAME_START)
//             {
//                 //ちゃんとタイトルから名前を入力してやってきた場合の分岐
//                 Game.instance.SetGameProgress(EGameProgress.SHOW_STAGE_1);
//             }
//             else
//             {
// //			Player.Param param = PlayerPrefsUtils.GetObject<Player.Param>(ESave.Player.ToString());
//             }
//
//             Game.instance.Load();
//         }
//
//         // Use this for initialization
         void Start()
         {
             SoundManager.instance.PlayMusic(musicHome);
             // ScenedLoading();
//
// //		var savejson = JsonUtility.ToJson( Player.instance );
// //		PlayerPrefs.SetString( ESave.Player.ToString(), savejson );
//
// //		var bytes = ZeroFormatterSerializer.Serialize(Player.instance);
// //		var bytes = ZeroFormatterSerializer.Serialize(mc);
// //		Player player = ZeroFormatterSerializer.Deserialize<Player>(bytes);		
//
// //		var json = PlayerPrefs.GetString( ESave.Player.ToString() );
// //		var obj = JsonUtility.FromJson<Player>( json );
//
// //		Player.Param saveParam = Player.instance.GetParam();
//		PlayerPrefsUtils.SetObject(ESave.Player.ToString(), saveParam);
// //		Player.Param param = PlayerPrefsUtils.GetObject<Player.Param>(ESave.Player.ToString());
         }
//
//         // Update is called once per frame
//         void Update()
//         {
//         }
//
         void SyncGameProgress()
         {
             Game.instance.Load();
             switch ((EGameProgress) Game.instance.gameProgress)
             {
                 case EGameProgress.SHOW_STAGE_1:
                     btnStage1.SetActive(true);
                     break;
                 case EGameProgress.SHOW_STAGE_2:
                     btnStage1.SetActive(true);
                     btnStage2.SetActive(true);
                     break;
                 case EGameProgress.SHOW_STAGE_3:
                     btnStage1.SetActive(true);
                     btnStage2.SetActive(true);
                     btnStage3.SetActive(true);
                     break;
                 default:
                     btnStage1.SetActive(true);
                     btnStage2.SetActive(true);
                     btnStage3.SetActive(true);
                     btnStage4.SetActive(true);
                     break;
             }
         }
         public void PushBtnStage1()
         {
             Game.instance.destinationPlace = EStage.WALKING_COURSE;
             // Game.instance.Save();
             SceneManager.LoadScene("Scenes/WorldScene");
         }

         public void PushBtnStage2()
         {
             Game.instance.destinationPlace = EStage.GOTO_SUICA;
             Game.instance.Save();
             SceneManager.LoadScene("Scenes/WorldScene");
         }

         public void PushBtnStage3()
         {
             Game.instance.destinationPlace = EStage.METAL_DEFENCE;
             Game.instance.Save();
             SceneManager.LoadScene("Scenes/WorldScene");
         }

         public void PushBtnStage4()
         {
         }

         public void PushBtnTalk()
         {
             // ShizuneMsg.instance.msgHome[EMsgHome.First](msgCounter);
             // msgCounter++;
         }

         public void PushBtnLvUp()
         {
             Player player = Game.instance.GetPlayer();
             player.Lv += 1;
             player.MaxHp += 5;
             // player.Str += 1;
             // player.Vit += 1;
         }

         public void PushBtnGoBackTitle()
         {
             SceneManager.LoadScene("Scenes/TitleScene");
         }

         public void PushBtnSave()
         {
             canvasSaveArea.SetActive(true);
             // canvas.SetActive(false);
         }
         public void PushGoOutMenu()
         {
//             //ゲームの進行度に応じて行ける場所を増やす
             SyncGameProgress();
             // btnStage1.SetActive(true);
             // btnStage2.SetActive(true);
             // btnStage3.SetActive(true);
             // btnStage4.SetActive(true);
         }
    }
}
