using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
    public class KyuuriHeart : ActionCards.ABase
    {
        // Use this for initialization
        void Start ()
        {
            Init();
        }

        public override void Init()
        {
            lv = 0;
            atk = 4;
            def = 0;
            // maxhp = 24;
            maxhp = 1;
            // maxhp = 1400;
            spirit = 0;
            agi = 5;

            eActionCardName = EActionCardName.NasuHeart;
            cardUsageText = $" [胡瓜の心] \n 最大HP {maxhp}\n 攻撃 {atk}\n 速さ {agi}\n";
        }
	
        // Update is called once per frame
        void Update () {
		
        }
        public override string GetImageFilePath()
        {
            return "ActionCards/KyuuriHeart";
        }
        public override string GetPrefabFilePath()
        {
            return "Prefabs/ActionCards/KyuuriHeart";
        }
        public override EGroup GetGroup()
        {
            return EGroup.Meruhen;
        }
    }
    
}
