using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyTomato : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.Id = EChara.Tomato;
        this.CharaName = "トマト";
        this.MaxHp = 54;
        // this.MaxMp = 54;
        this.Hp = MaxHp;
        // this.mp = MaxMp;
        this.Atk = 15;
        this.Def = 1;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.Exp =20;
        this.msg = "すべてを赤く染めてやる";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("そんな力じゃ血反吐もでない");
        this.msgDamageAfterList.Add("お前の口を赤く染めてやろう");
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
        return "Enemies/不快なトマト";
    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }
}
