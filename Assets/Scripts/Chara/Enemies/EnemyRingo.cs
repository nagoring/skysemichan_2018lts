﻿using System.Collections;
using System.Collections.Generic;
using Skysemi.With.ActionCards;
using UnityEngine;
using Skysemi.With.Enum;

namespace Skysemi.With.Chara.Enemies
{
	public class EnemyRingo : Enemy {
		void Awake()
		{
			Init();
		}

		void Init()
		{
			this.Id = EChara.Ringo;
			this.CharaName = "りんご";
			this.MaxHp = 60;
			this.Hp = this.MaxHp;
			this.Atk = 6;
			this.Def = 0;
			this.Spirit = 1;
			this.MaxSpirit = 1;
			this.exp =16;
			this.msg = "俺様は果物だ。おいしいぞ。";
			//msgDamageAfterDict.Add(id)
			this.msgDamageAfterList = new List<string>()
			{
				"この程度じゃ食べられてやれんな",
				"俺様を食べるにふさわしいヤツかも知れん",
			};
			
			
			
			cardDict = new Dictionary<EActionCardName, ABase>();
			cardDict.Add(EActionCardName.NasuHeart, gameObject.AddComponent<RingoHeart>());
			
			cardSpareDict = new Dictionary<EActionCardName, ABase>();
			cardSpareDict.Add(EActionCardName.NasuHeart, gameObject.AddComponent<Punch>());
			
			// Equip(0, mono.gameObject.AddComponent<NasuHeart>());
			// Equip(1, mono.gameObject.AddComponent<MagicAddMaxHp>());
			// Equip(2, mono.gameObject.AddComponent<Punch>());
			// Equip(3, mono.gameObject.AddComponent<StrongPunch>());

		}
		void OnEnable()
		{
			Init();
		}
		public override string GetImageFilePath()
		{
			return "Enemies/りんごの大将";
		}

		public override string GetPrefabFilePath()
		{
			throw new System.NotImplementedException();
		}

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}
	}
	
}
