using System.Collections;
using System.Collections.Generic;
using Skysemi.With.ActionCards;
using Skysemi.With.Chara;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara.Enemies
{
    public class EnemyNasu : Enemy {

        void Awake()
        {
            Init();
        }

        public override void Init()
        {
            this.Id = EChara.Nasu;
            this.CharaName = "ナス";
            this.MaxHp = 1;
            this.Hp = MaxHp;
//            this.Atk = 5;
            // this.Atk = 1;
            // this.Def = 0;
            // this.Agi = 0;
            this.Spirit = 1;
            this.MaxSpirit = 0;
            param.str = 1;
            param.def = 0;
            param.agi = 0;
            
            this.exp =4;
            this.msg = "ぼくをたべて！ぼくをたべて！";
            //msgDamageAfterDict.Add(id)
            this.msgDamageAfterList = new List<string>();
            this.msgDamageAfterList.Add("そんなんじゃまだまだ食べられないよ！");
            this.msgDamageAfterList.Add("もうちょいで食べれるね！");

            // _enemyActionCard[0] = gameObject.AddComponent<NasuHeart>();
            GameObject _obj = new GameObject();
            // _obj.AddComponent(typeof(NasuHeart));
            _enemyActionCard[0] = (ABase)_obj.AddComponent(typeof(NasuHeart));
            // _enemyActionCard[0] = gameObject.AddComponent<NasuHeart>();
            // _enemyActionCard[1] = gameObject.AddComponent<Punch>();
            cardSpareDict = new Dictionary<EActionCardName, ABase>();
            
            // cardDict.Add(EActionCardName.NasuHeart, gameObject.AddComponent<NasuHeart>());
            ActionCards.ABase spareCard = _obj.AddComponent(typeof(NasuHeart)) as ActionCards.ABase;
            cardSpareDict.Add(EActionCardName.NasuHeart, spareCard);
            // cardSpareDict = new Dictionary<EActionCardName, ABase>();
            // _enemyActionCard[0] = gameObject.AddComponent<KyuuriHeart>();
            // cardSpareDict.Add(EActionCardName.NasuHeart, gameObject.AddComponent<Punch>());

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

        public override string GetImageFilePath()
        {
            return "Enemies/nasu";
        }

        public override string GetPrefabFilePath()
        {
            throw new System.NotImplementedException();
        }
    }

}
