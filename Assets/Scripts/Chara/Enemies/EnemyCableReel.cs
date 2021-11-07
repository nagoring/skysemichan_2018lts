using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyCableReel : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.id = EChara.CableReel;
        this.CharaName = "電工ドラム";
        MaxHp = 50;
        MaxHp = 1;
        this.Hp = MaxHp;
        this.Atk = 35;
        this.Def = 1;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.exp =70;
        this.msg = "おまえをコンセントにしてやる！！";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("俺の差込プラグは痛ってぇぞ！");
        this.msgDamageAfterList.Add("お、お前を配線用差込接続器の一部にしてやりたい・・・");
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
        return "Enemies/電工ドラム";
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
