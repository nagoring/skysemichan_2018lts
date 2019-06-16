using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara
{
    public class EnemyNasu : Enemy {

        void Awake()
        {
            Init();
        }

        void Init()
        {
            this.Id = EChara.Nasu;
            this.CharaName = "ナス";
//            this.MaxHp = 15;
            this.MaxHp = 1;
            this.Hp = MaxHp;
//            this.Atk = 5;
            this.Atk = 1;
            this.Def = 0;
            this.Spirit = 1;
            this.MaxSpirit = 0;
            this.exp =4;
            this.msg = "ぼくをたべて！ぼくをたべて！";
            //msgDamageAfterDict.Add(id)
            this.msgDamageAfterList = new List<string>();
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
