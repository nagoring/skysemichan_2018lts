using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skysemi.With.Scenes
{
    public class HomeSecond : MonoBehaviour
    {
        public GameObject btnGoOut;
        public GameObject btnOtherStageA;
        public AudioClip musicHomeSecond;
        private int msgCounter = 0;

        // Use this for initialization
        void Start () {
//        SoundManager.instance.PlayMusic(musicHomeSecond);
//        GameSystem.instance.Load();
        }
        public void PushBtnTalk()
        {
//        ShizuneMsg.instance.msgHome[EMsgHome.Second](msgCounter);
            msgCounter++;
            if (msgCounter >= 5)
            {
                //ある程度会話をしたら外へボタンが表示
                btnGoOut.SetActive(true);
            }
            if (msgCounter >= 6) msgCounter = 6;

        }

        /// <summary>
        /// 外へボタン
        /// </summary>
        public void PushBtnGoOut()
        {
            btnOtherStageA.SetActive(true);
        }

        /// <summary>
        /// 先へ進むボタン
        /// </summary>
        public void PushBtnGoAhead()
        {
//        GameSystem.instance.destinationPlace = EStage.OTHER_STAGE1;
//        GameSystem.instance.Save();
            SceneManager.LoadScene("Scenes/GameMain");
        }
        // Update is called once per frame
        void Update () {
		
        }
    }
}
