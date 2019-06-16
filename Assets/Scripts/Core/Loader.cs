using UnityEngine;

namespace Skysemi.With.Core
{
    public class Loader : MonoBehaviour {
        //GameManagerのプレファブを指定
        public GameObject game;
	
        void Awake ()
        {
            //GameSystemが存在しない時、GameSystemを作成する
            if (Game.instance == null) {
                Instantiate (game);
            }
        }
    }}