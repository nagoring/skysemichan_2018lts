using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.ActionCards
{
	public class MagicAddMaxHp : ActionCards.ABase
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
			def = 0;
			maxhp = 10;
			spirit = 0;

			eActionCardName = EActionCardName.MagicAddMaxHp;
			cardUsageText = $" [最大HP増加魔法] \n 最大HP {maxhp}";
		}
		// Update is called once per frame
		void Update () {
		
		}
		public override string GetImageFilePath()
		{
			return "ActionCards/MagicAddMaxHp";
		}
		public override string GetPrefabFilePath()
		{
			return "Prefabs/ActionCards/MagicAddMaxHp";
		}
		public EGroup GetGroup()
		{
			return EGroup.Meruhen;
		}
		
	}
}
