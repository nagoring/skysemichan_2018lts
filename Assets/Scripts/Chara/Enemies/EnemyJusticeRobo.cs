using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyJusticeRobo : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.id = EChara.JusticeRobo;
        this.CharaName = "正義の怒れるロボ";
        this.MaxHp = 99;
        this.Hp = MaxHp;
        this.Atk = 15;
        this.Def = 1;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.exp =20;
        this.msg = "正義　執行スル";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("キカナイ　キカナイ");
        this.msgDamageAfterList.Add("イタイ　ユルサン");
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
        return "Enemies/外道刈茶ロホ";
    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }
    public EGroup GetGroup()
    {
        return EGroup.Mukibutu;
    }

}
