using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;

public interface IChara
{
    IChara GetTarget(List<IChara> targetList);
    void SetBattleAction(IChara chara);
    EBattleAction GetBattleAction();
    ECharaType GetCharaType();
    void PlayActionAnimation();
    void PlayActionSound();
    float GetWaitTimeByAnimation();
    void Act(IChara target);
    void SayDamageAfterMsg();
    float BeforeActStartWait();
    void BeforeActStartMsg(IChara target);
    string CharaName { get; set; }
    void SayAtkAfter(IChara target);
    EChara Id {get;set;}
    int Hp {get;set;}
//    int Mp {get;set;}
    int MaxHp {get;set;}
//    int MaxMp {get;set;}
    int Atk {get;set;}
    int Def	{get;set;}
    //以下新規追加
    //速さ。行動順番を決める
    int Agi	{get;set;}
    //気力。10貯まると特殊技が使える
    int Spirit	{get;set;}
    //最大値は10固定
    int MaxSpirit	{get;set;}
    
}
