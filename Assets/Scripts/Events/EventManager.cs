using System;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Scenes;
using Skysemi.With.Scenes.WorldObject;
using StatusUI;
using UnityEngine;

namespace Skysemi.With.Events
{
    public class EventManager : MonoBehaviour
    {
	    public static EventManager instance = null;
        private readonly Game game = Game.instance;
        private readonly Dictionary<EEvent, IEventSender>  _eventSenderDictionary = new Dictionary<EEvent, IEventSender>();
        void Awake()
        {
	        if (instance == null)
	        {
		        instance = this;
	        }
	        else if (instance != this)
	        {
		        Destroy(gameObject);
	        }
	        DontDestroyOnLoad(gameObject);
        }
        public void DoWayEvent(ISetUpEnemy iSetUpEnemy)
        {
	        //
	        //
//		1. this.WayEvent += game.enemyManager.CreateEnemy;
//		2. this.WayEvent += game.uiManager.EncountEnemeyBegin;
//		3. this.WayEvent += game.skysemiChanMsg.EnemyCommentary;
	        
	        // Activeで初期化されてしまうため一番始めにActiveにしておく
	        iSetUpEnemy.GetEnemyLayer().SetActive(true);
	        // 1.　敵の生成(内部) -> CreateEnemy in EncountNormalRule.OutputEnemyで変更 
	        game.enemyManager.CreateEnemy(iSetUpEnemy.GetMonoBehaviour(), iSetUpEnemy.GetEquipmentCardFieldUi());
	        // 2.　敵のUI作成(外部) -> displayEnemy in EncountNormalRule.OutputEnemey 
	        game.enemyManager.displayEnemy(iSetUpEnemy.GetEnemyLayer()); 
	        // 3.　スカゼミちゃんの敵に対するコメント 
	        WayEventParam param = new WayEventParam();
	        ShizuneMsg.instance.EnemyCommentary(param);
	        
        }
        public void DoBattleEndEvent()
        {
	        World world = World.instance;
	        EStage eStage = Game.instance.destinationPlace;
	        if (eStage == EStage.OUTSIDE_ROAD)
	        {
		        //ステージ４の外への道は音楽が一定のため再再生をしない
	        }
	        else
	        {
		        game.PlayMusicField();
	        }
	        
	        BattleEndEventParam param = new BattleEndEventParam();
//	         0. this.BattleEndEvent(param);
	        
//		1. this.BattleEndEvent += game.enemyManager.EncountEnemeyEnd;
//		2. this.BattleEndEvent += game.playerManager.EncountEnemeyEnd;
//		3. this.BattleEndEvent += game.uiManager.EncountEnemeyEnd;
//		4. this.BattleEndEvent += game.skysemiChanMsg.EncountEnemeyEnd;
//		5. this.BattleEndEvent += game.enemyManager.EncountEnemeyEndDestroy;
			// 1.
			this.EncountEnemeyEnd(param);
			// 2. 
			game.player.EncountEnemeyEnd(param);
			// 3. 
			UIManager.instance.EncountEnemeyEnd(param);
	        // 4. 
	        ShizuneMsg.instance.EncountEnemeyEnd(param);
	        // 5. 
	        BattleManager.instance.EncountEnemeyEndDestroy(param);
	        
	        world.WorldMode = EWorldMode.WALKING;
	        if (!world.isBoss) return;
	        world.WorldMode = EWorldMode.BOSS_BATTLE_AFTER;
	        // StartCoroutine(this.DelayMethod(2.3f, () =>
	        // {
		        // game.skysemiChanMsg.msgOther[EMsgOther.BossRingo]();
		        // StartCoroutine(this.DelayMethod(2.5f, () =>
		        // {
			        // game.skysemiChanMsg.AreaClearMsg();
			      StartCoroutine(this.DelayMethod(2.5f, () => { game.GoHomeForWinner(); }));
		        // }));
	        // }));
        }
        

        // public void RegisterEvent()
        // {
            //イベントでのobserverパターンはソースの可読性が著しく落ちるため廃止
            //どこかにHookをかけるように使う可能性があるのでソースは残しておく
            // 計算
//            AddSenderEvent(EEvent.CalculateActionCards, new StandartEventSender());
//            AddSenderEvent(EEvent.CalculateActionCardsByEnemy, new StandartEventSender());
            // playerStatusに反映
//            AddSenderEvent(EEvent.SyncPlayerStatus, new StandartEventSender());
//            Player player = game.GetPlayer();
//            EnemyManager enemyManager = game.GetEnemyManager();
//            AddReceiver(EEvent.CalculateActionCards, player.RecalculateEquipmentActionCards);
//            AddReceiver(EEvent.CalculateActionCardsByEnemy, enemyManager.RecalculateEquipmentActionCards);
            
//            PlayerStatusWindow playerStatusWindow = game.GetPlayerStatusWindow().GetPlayerStatusWindow();
//            AddReceiver(EEvent.SyncPlayerStatus, playerStatusWindow.SyncPlayerStatusReceiver);
//            this.RemoveEventer(EEvent.SyncPlayerStatus, playerStatusWindow.SyncPlayerStatusReceiver);
        // }

        public void AddSenderEvent(EEvent eventKey, IEventSender iEventSender = null)
        {
            if (iEventSender == null)
            {
                iEventSender = new StandartEventSender();
            }
            
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
        public void EncountEnemyBoss(World world)
        {
	        world.isBoss = true;
	        game.PlayMusicBossBattle();
	        world.WorldMode = EWorldMode.BATTLE;
	        WayEventParam param = new WayEventParam();
	        this.DoWayEvent(world);
        }
        public void EncountEnemy(World world)
        {
	        world.isBoss = false;
	        game.PlayMusicBattle();
	        world.WorldMode = EWorldMode.BATTLE;
	        WayEventParam param = new WayEventParam();
	        this.DoWayEvent(world);
        }
        public void EncountEnemeyEnd(BattleEndEventParam param) {
	        // param.enemy = this.enemy;
	        StartCoroutine(this.DelayMethod(1.0f, () =>
	        {
		        EnemyStatusWindow enemyStatusWindow = World.instance.GetEnemyStatusWindow();
		        enemyStatusWindow.gameObject.SetActive(false);
	        }));

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
//		this.WayEvent += game.enemyManager.CreateEnemy;
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
//		game.mode = EWorldMode.BATTLE;
//		WayEventParam param = new WayEventParam();
//		this.WayEvent(param);
//	}
//	public void DoBattleEndEventForLoser()
//	{
//		game.PlayMusicField();
//		Player.instance.InitProgress();
//		game.mode = EWorldMode.WALKING;
//		game.GoHomeForLoser();
////		this.BattleEndEventForLoser();
//	}
//
//	public void DoBattleEndEventForEscape()
//	{
//		game.PlayMusicField();
//		game.mode = EWorldMode.WALKING;
//		BattleEndEventParam param = new BattleEndEventParam();
//		this.BattleEndEventForEscape(param);
//	}	
//}
