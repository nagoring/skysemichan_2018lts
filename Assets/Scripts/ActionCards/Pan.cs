using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class Pan : ActionCards.ABase {

		// Use this for initialization
		void Start () {
			Init();
		}

		public override void Init()
		{
			lv = 0;
			atk = 2;
			def = 1;
			eActionCardName = EActionCardName.Pan;
			cardUsageText = $" [フライパン] \n 攻撃 {atk}\n 防御 {def}";
		}
	
		// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/Pan";
		}

		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/Pan";
		}
		public EGroup GetGroup()
		{
			return EGroup.Mukibutu;
		}
	}
}
