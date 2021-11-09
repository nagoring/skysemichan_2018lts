using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyBrocoli : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.Id = EChara.Brocoli;
        this.CharaName = "ブロッコリー";
        MaxHp = 40;
        this.Hp = MaxHp;
        this.Atk = 15;
        this.Def = 2;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.Exp =16;
        this.msg = "ブロッコリーとカリフラワーの区別わかるかな？";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("そんなに非力じゃもぐこともできそうにないなぁ。\nカッカッカ");
        this.msgDamageAfterList.Add("ああ・・・もうだめかも・・・");
    }
    void OnEnable()
    {
        Init();
    }

    public override string GetImageFilePath()
    {
        return "Enemies/ブロッコリーお化け";
    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }
}
