using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyDaikon : Enemy
{
    void Awake()
    {
        Init();
    }
    public override void Init()
    {
        this.id = EChara.Daikon;
        this.CharaName = "ダイコン";
        MaxHp = 40;
        this.Hp = MaxHp;
        this.Atk = 13;
        this.Def = 1;
        this.Spirit = 1;
        this.MaxSpirit = 1;

        this.exp =10;
        this.msg = "ダイコンしゃりしゃり消化に良いんじゃ";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("これじゃあ、ヒゲすら取れんなぁ");
        this.msgDamageAfterList.Add("そろそろ皮が無くなりそうじゃわい");
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
        return "Enemies/大根";
    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }
}
