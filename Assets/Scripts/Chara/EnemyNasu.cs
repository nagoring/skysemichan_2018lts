using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara
{
    public class EnemyNasu : Enemy {

        //protected int hp;
        //protected int mp;
        //protected int atk;
        //protected int def;
        void Awake()
        {
            Init();
        }

        void Init()
        {
            this.id = EChara.Nasu;
            this.enemyName = "ナス";
            this.maxhp = 15;
            this.maxmp = 9;
            this.hp = maxhp;
            this.mp = maxmp;
            this.atk = 5;
            this.def = 0;
            this.spirit = 0;
            this.maxspirit = 0;
            this.exp =4;
            this.msg = "ぼくをたべて！ぼくをたべて！";
            //msgDamageAfterDict.Add(id)
            this.msgDamageAfterList.Add("そんなんじゃまだまだ食べられないよ！");
            this.msgDamageAfterList.Add("もうちょいで食べれるね！");
		
        }
        void OnEnable()
        {
            Init();
        }
        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update () {
		
        }
    }

}
