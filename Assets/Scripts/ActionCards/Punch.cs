using System;
using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class Punch : ActionCards.ABase
	{
		private void Awake()
		{
		}

		// Use this for initialization
		void Start ()
		{
			Init();
		}

		public override void Init()
		{
			lv = 0;
			atk = 3;
			eActionCardName = EActionCardName.Punch;
			cardUsageText = $" [拳] \n 攻撃 {atk}";
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/Punch";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/Punch";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Namamono;
		}
	}
}
