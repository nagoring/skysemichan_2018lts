using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using UnityEngine;

public class EnemyCameraStabilizer : Enemy
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        this.Id = EChara.CameraStabilizer;
        this.CharaName = "カメラスタビライザー";
        this.MaxHp = 30;
        this.MaxHp = 1;
        this.Hp = MaxHp;
        this.Atk = 40;
        this.Def = 7;
        this.Spirit = 1;
        this.MaxSpirit = 1;
        this.exp =70;
        this.msg = "監視カメラに映ったやつ発見！";
        //msgDamageAfterDict.Add(id)
        this.msgDamageAfterList.Add("映像に捕えた奴は倒す。必ず倒す。");
        this.msgDamageAfterList.Add("壊れそう。高いレンズが壊れそう・・・");
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
        return "Enemies/camera_stabilizer";
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
