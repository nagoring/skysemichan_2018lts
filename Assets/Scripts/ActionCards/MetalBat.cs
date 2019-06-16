using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class MetalBat : ActionCards.ABase
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
			def = 2;
			maxhp = 0;
			spirit = 0;

			eActionCardName = EActionCardName.MetalBat;
			cardUsageText = $" [バット] \n 攻撃 {atk}\n 防御 {def}";
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/MetalBat";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/MetalBat";
		}
	}
}
