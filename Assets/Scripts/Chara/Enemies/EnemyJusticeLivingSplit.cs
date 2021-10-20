using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyJusticeLivingSplit : Enemy
{
    void Awake()
    {
        Init();
    }

    void Init()
    {
        this.id = EChara.JusticeLivingSplit;
        this.CharaName = "正義の生霊";
        this.MaxHp = 99;
        this.Hp = MaxHp;
        this.Atk = 15;
        this.Def = 1;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.exp =20;
        this.msg = "邪悪な存在許さん許さん";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("歯向かうな！お前が悪だ！");
        this.msgDamageAfterList.Add("グエーグえー");
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
        return "Enemies/外道狩ショウキ";
    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }
    public EGroup GetGroup()
    {
        return EGroup.Meruhen;
    }

}
