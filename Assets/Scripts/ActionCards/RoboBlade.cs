using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class RoboBlade : ActionCards.ABase {

		// Use this for initialization
		void Start ()
		{
			Init();
		}

		public override void Init()
		{
			lv = 0;
			atk = 15;
			def = -2;
			eActionCardName = EActionCardName.RoboBlade;
			cardUsageText = $" [ロボブレード] \n 攻撃 {atk}\n 防御 {def}";
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/RoboBlade";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/RoboBlade";
		}
		public override EGroup GetGroup()
		{
			return EGroup.Mukibutu;
		}
	}
}
