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
//		1. this.WayEvent += game.enemyManager.CreateEnemy;
//		2. this.WayEvent += game.uiManager.EncountEnemeyBegin;
//		3. this.WayEvent += game.shizuneMsg.EnemyCommentary;

			// Activeで初期化されてしまうため一番始めにActiveにしておく
			
			iSetUpEnemy.GetButtonEnemyLayer().SetActive(true);
			
			// // 1.　敵の生成(内部) -> CreateEnemy in EncountNormalRule.OutputEnemyで変更 
			// game.enemyManager.CreateEnemy(
			// 	iSetUpEnemy.GetMonoBehaviour(), 
			// 	iSetUpEnemy.GetEquipmentCardFieldUi()
			// 	);
			// 2.　敵のUI作成(外部) -> displayEnemy in EncountNormalRule.OutputEnemey 
			game.enemyManager.displayEnemy(iSetUpEnemy.GetButtonEnemyLayer());
			// 3.　スカゼミちゃんの敵に対するコメント 
			WayEventParam param = new WayEventParam(game.GetPlayer(), game.enemyManager.GetEnemy());
			ShizuneMsg.instance.EnemyCommentary(param);
		}

		public void DoBattleEndEvent(IChara target)
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
			param.enemy = game.enemyManager.GetEnemy();
//	         0. this.BattleEndEvent(param);

//		1. this.BattleEndEvent += game.enemyManager.BattleEnd;
//		2. this.BattleEndEvent += game.playerManager.BattleEnd;
//		3. this.BattleEndEvent += game.uiManager.BattleEnd;
//		4. this.BattleEndEvent += game.shizuneMsg.BattleEnd;
//		5. this.BattleEndEvent += game.enemyManager.BattleEnd;
			// 1.
			this.BattleEnd(param);
			// 2. 
			game.player.BattleEnd(param);
			// 3. 
			UIManager.instance.BattleEnd(param);
			// 4. 
			ShizuneMsg.instance.BattleEnd(param);
			// 5. 
			BattleManager.instance.BattleEnd(param);
			

			world.WorldMode = EWorldMode.WALKING;
			world.ShuffleRandomEncount();
			
			if (!world.isBoss) return;
			world.WorldMode = EWorldMode.BOSS_BATTLE_AFTER;
			StartCoroutine(this.DelayMethod(2.3f, () =>
			{
				game.shizuneMsg.msgOther[EMsgOther.BossRingo]();
				StartCoroutine(this.DelayMethod(2.5f, () =>
				{
					game.shizuneMsg.AreaClearMsg();
					StartCoroutine(this.DelayMethod(2.5f, () => { game.GoHomeForWinner(); }));
				}));
			}));
		}


		public void EncountEnemyBoss(World world)
		{
			world.isBoss = true;
			game.PlayMusicBossBattle();
			world.WorldMode = EWorldMode.BATTLE;
			WayEventParam param = new WayEventParam(game.GetPlayer(), game.enemyManager.GetEnemy());
			this.DoWayEvent(world);
		}

		public void EncountEnemy(World world)
		{
			world.isBoss = false;
			game.PlayMusicBattle();
			world.WorldMode = EWorldMode.BATTLE;
		}

		public void BattleEnd(BattleEndEventParam param)
		{
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
//		this.WayEvent += game.shizuneMsg.EnemyCommentary;
//
//		
//		this.BattleEndEvent += game.enemyManager.BattleEnd;
//		this.BattleEndEvent += game.playerManager.BattleEnd;
//		this.BattleEndEvent += game.uiManager.BattleEnd;
//		this.BattleEndEvent += game.shizuneMsg.BattleEnd;
//		this.BattleEndEvent += game.enemyManager.BattleEnd;
//		
//		this.BattleEndEventForEscape += game.uiManager.BattleEnd;
//		this.BattleEndEventForEscape += game.enemyManager.BattleEnd;
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