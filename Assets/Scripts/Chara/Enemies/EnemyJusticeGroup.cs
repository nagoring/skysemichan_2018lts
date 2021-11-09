using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyJusticeGroup : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.Id = EChara.JusticeGroup;
        this.CharaName = "正義の集団";
        this.MaxHp = 99;
        this.Hp = MaxHp;
        this.Atk = 15;
        this.Def = 1;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.Exp =20;
        this.msg = "ひゃうっひゃー！悪だ！ちぎりつぶせ！！";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("歯向かったぞ！タコ殴りにしてやれ！");
        this.msgDamageAfterList.Add("ぐぼっ　処刑だ！処刑しろぉぉぉ！");
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
        return "Enemies/外道狩集団";
    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }

}
