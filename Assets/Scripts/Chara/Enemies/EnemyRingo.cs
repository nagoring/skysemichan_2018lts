using System.Collections;
using System.Collections.Generic;
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
