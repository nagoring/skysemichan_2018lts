using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyBladeRobo : Enemy
{
    void Awake()
    {
        Init();
    }
	
    public override void Init()
    {
        this.id = EChara.BladeRobo;
        this.CharaName = "ブレードロボ";
        this.MaxHp = 120;
        this.Hp = MaxHp;
        this.Atk = 35;
        this.Def = 9;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.exp = 300;
        this.msg = "不審者発見。排除する。";
        //msgDamageAfterDict.Add(id)
        msgDamageAfterList = new List<string>(); 
        this.msgDamageAfterList.Add("ダメージあり。戦闘続行可能");
        this.msgDamageAfterList.Add("戦闘に支障を来たすダメージを受けている。このままでは破壊される");
    }
    void OnEnable()
    {
        Init();
    }
    public override void PlayActionSound()
    {
        Game game = Game.instance;
        SoundManager.instance.PlaySingle(game.clipEnemyBlade1);
    }

    public override string GetImageFilePath()
    {
        return "Enemies/blade_robo";

    }

    public override string GetPrefabFilePath()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
		
    }
    public override EGroup GetGroup()
    {
        return EGroup.Mukibutu;
    }

}
