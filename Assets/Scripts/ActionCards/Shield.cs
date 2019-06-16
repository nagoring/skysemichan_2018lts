using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class Shield : ActionCards.ABase
	{
		// Use this for initialization
		void Start ()
		{
			Init();
		}

		public override void Init()
		{
			lv = 0;
			atk = 0;
			def = 2;
			eActionCardName = EActionCardName.Shield;
			cardUsageText = $" [盾]\n 防御 {def}";
		}

// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/Shield";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/Shield";
		}
	}
}
