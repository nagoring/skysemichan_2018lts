using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyDoroDoroHukai : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.Id = EChara.DoroDoroHukai;
        this.CharaName = "ドロドロナ不快ナモノ";
        MaxHp = 200;
        MaxHp = 1;
        this.Hp = MaxHp;
        this.Atk = 44;
        this.Def = 1;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.exp =10;
        this.msg = "ハラヘッタ";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("オマエヲタベル");
        this.msgDamageAfterList.Add("イタイ");
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
        return "Enemies/dorodoro_hukai";
    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }
}
