using UnityEngine;

namespace Skysemi.With.Core
{
    public class Loader : MonoBehaviour {
        //GameManagerのプレファブを指定
        public GameObject game;
        // public GameObject sound;
	
        void Awake ()
        {
            //GameSystemが存在しない時、GameSystemを作成する
            if (Game.instance == null) {
                Instantiate (game);
            }
            // if (SoundManager.instance == null) {
            //     Instantiate (sound);
            // }
            
        }
    }}