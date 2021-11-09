using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyNiwatori : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.Id = EChara.Niwatori;
        this.CharaName = "にわとり";
        this.MaxHp = 15;
        this.Hp = MaxHp;
        this.Atk = 5;
        this.Def = 0;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.exp =4;
        this.msg = "コケコッコー";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("コケーっ");
        this.msgDamageAfterList.Add("コケーっコケーっ");
		
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
        return "Enemies/にわとり";

    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }
}
