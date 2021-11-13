using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
    public class NasuHeart : ActionCards.ABase
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
            maxhp = 14;
            maxhp = 100;
            spirit = 0;
            agi = 9;

            eActionCardName = EActionCardName.NasuHeart;
            cardUsageText = $" [なすの心] \n 最大HP {maxhp}\n 攻撃 {atk}\n 速さ {agi}\n";
        }
	
        // Update is called once per frame
        void Update () {
		
        }
        public override string GetImageFilePath()
        {
            return "ActionCards/NasuHeart";
        }
        public override string GetPrefabFilePath()
        {
            return "Prefabs/ActionCards/NasuHeart";
        }
        public override EGroup GetGroup()
        {
            return EGroup.Meruhen;
        }
    }
}