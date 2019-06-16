using System;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using StatusUI;
using UnityEngine;

namespace Skysemi.With.Events
{
    public class EventManager 
    {
        private readonly Game game = Game.instance;
        private readonly Dictionary<EEvent, IEventSender>  _eventSenderDictionary = new Dictionary<EEvent, IEventSender>();
        

        public void RegisterEvent()
        {
            // 計算
            AddSenderEvent(EEvent.CalculateActionCards, new CalculateActionCardsEventSender());
            // playerStatusに反映
            AddSenderEvent(EEvent.SyncPlayerStatus, new SyncPlayerStatusEventSender());
            Player player = game.GetPlayer();
            EnemyManager enemyManager = game.GetEnemyManager();
            AddReceiver(EEvent.CalculateActionCards, player.CalculateEquipmentActionCardsReceiver);
            AddReceiver(EEvent.CalculateActionCards, enemyManager.CalculateEquipmentActionCardsReceiver);
            
            PlayerStatusWindow playerStatusWindow = game.GetPlayerStatusWindow().GetPlayerStatusWindow();
            AddReceiver(EEvent.SyncPlayerStatus, playerStatusWindow.SyncPlayerStatusReceiver);
//            this.RemoveEventer(EEvent.SyncPlayerStatus, playerStatusWindow.SyncPlayerStatusReceiver);
        }

        public void AddSenderEvent(EEvent eventKey, IEventSender iEventSender)
        {
            if (_eventSenderDictionary.ContainsKey(eventKey) == false)
            {
                _eventSenderDictionary.Add(eventKey, iEventSender);
            }
        }
        public void AddReceiver(EEvent eventKey, BaseEventSender.EventDelegate func)
        {
            _eventSenderDictionary[eventKey].Eventer += func;
        }
        public void RemoveReceiver(EEvent eventKey, BaseEventSender.EventDelegate func)
        {
            _eventSenderDictionary[eventKey].Eventer -= func;
        }
        public IEventSender EventSenderFactory(EEvent eventKey)
        {
            return _eventSenderDictionary[eventKey];
        }
        
    }
}
//
//public class EventManager : MonoBehaviour {
//	public GameMainManager game;
//
//	public delegate void WayDelegate(WayEventParam param);
//	public event WayDelegate WayEvent = delegate (WayEventParam param) { };
//
//	public delegate void BattleEndDelegate(BattleEndEventParam param);
//	public event BattleEndDelegate BattleEndEvent = delegate (BattleEndEventParam param) { };
//
//	public delegate void BattleEndForLoserDelegate();
//	public event BattleEndForLoserDelegate BattleEndEventForLoser = delegate () { };
//
//	public delegate void BattleEndForEscapeDelegate(BattleEndEventParam param);
//	public event BattleEndForEscapeDelegate BattleEndEventForEscape = delegate (BattleEndEventParam param) { };
//
//
//
//	// Use this for initialization
//	void Start () {
//		Register();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//	void Register() {
//		this.WayEvent += game.enemyManager.createEnemy;
//		this.WayEvent += game.uiManager.EncountEnemeyBegin;
//		this.WayEvent += game.skysemiChanMsg.EnemyCommentary;
//
//		
//		this.BattleEndEvent += game.enemyManager.EncountEnemeyEnd;
//		this.BattleEndEvent += game.playerManager.EncountEnemeyEnd;
//		this.BattleEndEvent += game.uiManager.EncountEnemeyEnd;
//		this.BattleEndEvent += game.skysemiChanMsg.EncountEnemeyEnd;
//		this.BattleEndEvent += game.enemyManager.EncountEnemeyEndDestroy;
//		
//		this.BattleEndEventForEscape += game.uiManager.EncountEnemeyEnd;
//		this.BattleEndEventForEscape += game.enemyManager.EncountEnemeyEndDestroy;
//		
//	}
//	public void EncountEnemy()
//	{
//		game.isBoss = false;
//		game.PlayMusicBattle();
//		game.mode = EMode.BATTLE;
//		WayEventParam param = new WayEventParam();
//		this.WayEvent(param);
//	}
//	public void EncountEnemyBoss()
//	{
//		game.isBoss = true;
//
//		game.PlayMusicBossBattle();
//		
//		game.mode = EMode.BATTLE;
//		WayEventParam param = new WayEventParam();
//		this.WayEvent(param);
//	}
//	public void DoBattleEndEvent() {
//		EStage eStage = GameSystem.instance.destinationPlace;
//		if (eStage == EStage.OUTSIDE_ROAD)
//		{
//			//ステージ４の外への道は音楽が一定のため再再生をしない
//		}
//		else
//		{
//			game.PlayMusicField();
//		}
//		
//		BattleEndEventParam param = new BattleEndEventParam();
//		this.BattleEndEvent(param);
//		game.mode = EMode.WALKING;
//		if (!game.isBoss) return;
//		
//		game.mode = EMode.BOSS_BATTLE_AFTER;
//		StartCoroutine(this.DelayMethod(2.3f, () =>
//		{
//			game.skysemiChanMsg.msgOther[EMsgOther.BossRingo]();
//			StartCoroutine(this.DelayMethod(2.5f, () =>
//			{
//				game.skysemiChanMsg.AreaClearMsg();
//				StartCoroutine(this.DelayMethod(2.5f, () =>
//				{
//					game.GoHomeForWinner();
//				}));
//			}));
//		}));
//	}
//	public void DoBattleEndEventForLoser()
//	{
//		game.PlayMusicField();
//		Player.instance.InitProgress();
//		game.mode = EMode.WALKING;
//		game.GoHomeForLoser();
////		this.BattleEndEventForLoser();
//	}
//
//	public void DoBattleEndEventForEscape()
//	{
//		game.PlayMusicField();
//		game.mode = EMode.WALKING;
//		BattleEndEventParam param = new BattleEndEventParam();
//		this.BattleEndEventForEscape(param);
//	}	
//}
