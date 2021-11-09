using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyPowerShovel : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.Id = EChara.PowerShovel;
        this.CharaName = "パワーショベル";
        this.MaxHp = 50;
        this.MaxHp = 1;
        this.Hp = MaxHp;
        this.Atk = 32;
        this.Def = 5;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.Exp =80;
        this.msg = "お前らを解体してやる！！";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("解体することに変更無し！");
        this.msgDamageAfterList.Add("解体されるのは私なのかも・・・");
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
        return "Enemies/power_shovel";
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
