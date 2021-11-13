using System;
using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class StrongPunch : ActionCards.ABase
	{
		// Use this for initialization
		void Start ()
		{
			Init();
		}

		public override void Init()
		{
			lv = 0;
			atk = 5;
			def = -1;
			eActionCardName = EActionCardName.StrongPanch;
			cardUsageText = $" [強拳] \n 攻撃 {atk}\n 防御 {def}\n (ナマモノ)";
		}
		// Update is called once per frame
		void Update () {
		}

		public override string GetImageFilePath()
		{
			return "ActionCards/StrongPunch";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/StrongPunch";
		}
		
	}
}
