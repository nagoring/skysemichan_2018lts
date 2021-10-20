using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class StrongShield : ActionCards.ABase
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
			def = 4;
			eActionCardName = EActionCardName.Shield;
			cardUsageText = $" [強盾] \n  防御 {def}";
		}

// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/StrongShield";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/StrongShield";
		}
		public EGroup GetGroup()
		{
			return EGroup.Mukibutu;
		}
	}
}
