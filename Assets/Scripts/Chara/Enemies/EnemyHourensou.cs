using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyHourensou : Enemy
{
	void Awake()
	{
		Init();
	}

	void Init()
	{
		this.id = EChara.Hourensou;
		this.CharaName = "ほうれんそう";
		this.MaxHp = 36;
		this.Hp = MaxHp;
		this.Atk = 18;
		this.Def = 6;
		this.Spirit = 1;
		this.MaxSpirit = 1;
		this.exp =20;
		this.msg = "炒めるんじゃねーぞ。";
		//msgDamageAfterDict.Add(id)
		this.msgDamageAfterList.Add("まぁお前らの実力じゃ俺を超えられないのは仕方ないな");
		this.msgDamageAfterList.Add("茹でたほうが栄養たっぷりなんだぜ・・・");
	}
	void OnEnable()
	{
		Init();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override string GetImageFilePath()
	{
		return "Enemies/ほうれんそうキーパー";
	}

	public override string GetPrefabFilePath()
	{
		throw new System.NotImplementedException();
	}
}
