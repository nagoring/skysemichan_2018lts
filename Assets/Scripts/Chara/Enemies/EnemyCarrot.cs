using System.Collections.Generic;
using Skysemi.With.ActionCards;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara.Enemies
{
	public class EnemyCarrot : Enemy {

        void Awake()
        {
            Init();
        }

        public override void Init()
        {
            this.Id = EChara.Carrot;
            this.CharaName = "人参さん";
            this.MaxHp = 14;
            this.Hp = MaxHp;
//            this.Atk = 5;
            // this.Atk = 1;
            // this.Def = 0;
            // this.Agi = 0;
            this.Spirit = 1;
            this.MaxSpirit = 0;
            param.str = 1;
            Def = 0;
            Agi = 1;
            
            this.Exp =4;
            this.msg = "食べなさい！好き嫌いだめよ！";
            //msgDamageAfterDict.Add(id)
            this.msgDamageAfterList = new List<string>();
            this.msgDamageAfterList.Add("弱いよ！弱いよ！");
            this.msgDamageAfterList.Add("あああ、赤い破片が！");

            // _enemyActionCard[0] = gameObject.AddComponent<NasuHeart>();
            GameObject _obj = new GameObject();
            // _obj.AddComponent(typeof(NasuHeart));
            _enemyActionCard[0] = (ABase)_obj.AddComponent(typeof(CarrotHeart));
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
            return "Enemies/Carrot";
        }

        public override string GetPrefabFilePath()
        {
            throw new System.NotImplementedException();
        }
    }

}
