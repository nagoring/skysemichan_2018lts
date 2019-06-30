﻿using System.Collections;
using Skysemi.With.ActionCards;
using Skysemi.With.CardUI;
using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes.WorldObject;
using StatusUI;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using EquipmentCardField = Skysemi.With.CardUI.EquipmentCardField;

namespace Skysemi.With.Scenes
{
    public class World : AppMonoBehaviour, ISceneController, IPlayerCardUiController, IPlayerStatusWindow
    {
		public static World instance;
		public static Game game;
	    private CardBoard _cardBoard;
	    private EquipmentCardField _equipmentCardField;
	    private PlayerStatusWindow _playerStatusWindow;
	    private EquipmentCardFieldMini _equipmentCardFieldMini;
	    public GameObject enemyLayer;
	    public Canvas canvasUI;
	    public Image enemyStatusWindow;


	    public EMode Mode {get;set;}
	    private EMode _mode = EMode.WALKING;

//		public SkysemiChanManager skysemiChanManager;
//		public SkysemiChanMsg skysemiChanMsg;
//		public EventManager eventManager;
//		public EnemyManager enemyManager;
//		public UIManager uiManager;
//		public PlayerManager playerManager;
		public EffectManager effectManager;
//		public Image imageFlatLand;
//		public Sprite imageFlatLandEveningSprite;
//		public Image loadLayer;
//		public GameObject enemeyLayer;
//		public Canvas canvas;
//		public Sprite[] imageRoads = new Sprite[3];


//		public ETurn turn = ETurn.PLAYER;
//		public bool isBoss = false;
//	
//		//効果音
//		public AudioClip clipPanch;
//		public AudioClip clipLpUp;
//		public AudioClip clipLoser;
//		public AudioClip clipEscape;
//		public AudioClip clipEnemyAtk1;
//		public AudioClip clipEnemyBlade1;
//		public AudioClip clipSoundWalking;
//	
//		//ミュージック
//		public AudioClip musicWalking;
//		public AudioClip musicStageField4;
//		public AudioClip musicBattle1;
//		public AudioClip musicBladeRobo;
//		public AudioClip musicStage4Boss;
//		
//		private int randomEncount = 5;
//		//エフェクト
//		public GameObject damageEffect1Prefab;
//		
//		//public FlatLand flatLand = new FlatLand();
//		public void enemyAppear() {
//			//進行UIの停止
//			//行動UIの開始
//		}
		//シングルトンの処理
		void Awake ()
		{
			if (instance == null)
			{
				instance = this;
			}
			else if (instance != this)
			{
				Destroy (gameObject);
			}
		}
//	
//		// Use this for initialization
		void Start ()
		{
			game = Game.instance;
			game.SetCardUiController(this);
			game.SetPlayerStatusWindow(this);
			_playerStatusWindow = PlayerStatusWindow.CreatePlayerStatusWindowInCanvasUI(canvasUI);
			_cardBoard = CardBoard.CreateCardBoardInCanvasUI(canvasUI);
			_cardBoard.Init();
			_cardBoard.gameObject.SetActive(false);
			_equipmentCardField = EquipmentCardField.CreateEquipmentCardFieldInCanvas(canvasUI, -240, -300);
			_equipmentCardField.Init();
			
			
			EnemyStatusWindow localEnemyStatusWindow = enemyStatusWindow.gameObject.GetComponent<EnemyStatusWindow>();
			localEnemyStatusWindow.Init();
			
			game.eventManager.RegisterEvent();
			game.eventManager.AddSenderEvent(EEvent.SyncEnemyStatus, new StandartEventSender());
			game.eventManager.AddReceiver(EEvent.SyncEnemyStatus, localEnemyStatusWindow.SyncEnemyStatusReceiver);
			
			//自UIのステータス反映
			SyncStatusEventArgs syncStatusEventArgs = new SyncStatusEventArgs();
			syncStatusEventArgs.CharaParameter = game.GetPlayer().param;
			var baseEventArgsForPlayer = new BaseEventArgs();
			baseEventArgsForPlayer.SetObject(syncStatusEventArgs);
			game.eventManager.EventSenderFactory(EEvent.SyncPlayerStatus).Send(baseEventArgsForPlayer);
			
			//＊実験＊ 敵の装備をセットする
			game.enemyManager.SetEnemy(gameObject.AddComponent<EnemyNasu>());
			_equipmentCardFieldMini = EquipmentCardFieldMini.CreateEquipmentCardFieldMiniInParentTransform(enemyStatusWindow.transform, 0, -125f);
			_equipmentCardFieldMini.Init();
			_equipmentCardFieldMini.Equip(0, gameObject.AddComponent<NasuHeart>());
			_equipmentCardFieldMini.Equip(1, gameObject.AddComponent<Punch>());
			_equipmentCardFieldMini.Equip(2, gameObject.AddComponent<MagicAddMaxHp>());
			_equipmentCardFieldMini.Equip(3, gameObject.AddComponent<MagicAddMaxHp>());
			game.enemyManager.SetEquipmentCardFieldMini(_equipmentCardFieldMini);
			
			// 敵装備計算 装備カードの能力反映イベントの発火 PlayerもEnemyも両方起こる
//			EquipmentCardBoxMiniUi[] equipmentCardBoxMinis = _equipmentCardFieldMini.GetEquipmentCardBoxs();
			CalculateActionCardsEventArgs calculateActionCardsEventArgs = new CalculateActionCardsEventArgs();
			calculateActionCardsEventArgs.SetActionCard(0, _equipmentCardFieldMini.GetActionCard(0));
			calculateActionCardsEventArgs.SetActionCard(1, _equipmentCardFieldMini.GetActionCard(1));
			calculateActionCardsEventArgs.SetActionCard(2, _equipmentCardFieldMini.GetActionCard(2));
			calculateActionCardsEventArgs.SetActionCard(3, _equipmentCardFieldMini.GetActionCard(3));
			game.eventManager.EventSenderFactory(EEvent.CalculateActionCards)?.Send(new BaseEventArgs(calculateActionCardsEventArgs));
			game.enemyManager.RecoveryHp();
			
			

			// 敵UIのステータス反映
			SyncStatusEnemyEventArgs syncStatusEnemyEventArgs = new SyncStatusEnemyEventArgs();
			syncStatusEnemyEventArgs.CharaParameter = game.enemyManager.GetEnemy().param;
			syncStatusEnemyEventArgs.EquipmentCardFieldMini = _equipmentCardFieldMini;
			game.eventManager.EventSenderFactory(EEvent.SyncEnemyStatus).Send(new BaseEventArgs(syncStatusEnemyEventArgs));
			
			//実験 途中でカードをすげ替える場合のケース 設定が多すぎなのでまとめたい
//			_equipmentCardFieldMini.Equip(0, gameObject.AddComponent<StrongPunch>());
//			_equipmentCardFieldMini.Equip(1, gameObject.AddComponent<StrongPunch>());
//			_equipmentCardFieldMini.Equip(2, gameObject.AddComponent<StrongPunch>());
//			_equipmentCardFieldMini.Equip(3, gameObject.AddComponent<StrongPunch>());
//			game.enemyManager.SetEquipmentCardFieldMini(_equipmentCardFieldMini);
////			equipmentCardBoxMinis = _equipmentCardFieldMini.GetEquipmentCardBoxs();
//			calculateActionCardsEventArgs = new CalculateActionCardsEventArgs();
////			calculateActionCardsEventArgs.SetActionCard(0, equipmentCardBoxMinis[0]?.GetActionCard());
////			calculateActionCardsEventArgs.SetActionCard(1, equipmentCardBoxMinis[1]?.GetActionCard());
////			calculateActionCardsEventArgs.SetActionCard(2, equipmentCardBoxMinis[2]?.GetActionCard());
////			calculateActionCardsEventArgs.SetActionCard(3, equipmentCardBoxMinis[3]?.GetActionCard());
//			game.eventManager.EventSenderFactory(EEvent.CalculateActionCards)?.Send(new BaseEventArgs(calculateActionCardsEventArgs));
//			syncStatusEnemyEventArgs = new SyncStatusEnemyEventArgs();
//			syncStatusEnemyEventArgs.CharaParameter = game.enemyManager.GetEnemy().param;
//			syncStatusEnemyEventArgs.EquipmentCardFieldMini = _equipmentCardFieldMini;
//			game.eventManager.EventSenderFactory(EEvent.SyncEnemyStatus)?.Send(new BaseEventArgs(syncStatusEnemyEventArgs));
			//実験END

			
			
			_mode = EMode.WALKING;
			
//			PlayerManager.instance.LoadData();
//			Player player = Player.instance;
//			player.Progress = 0;
//			PlayMusicField();
//			SetBackGround();
//			playerManager.SyncUpdationParameter();
		}
//	
//		public void SetBackGround()
//		{
//			if (Game.instance.destinationPlace == EStage.OTHER_STAGE1)
//			{
//				imageFlatLand.sprite = imageFlatLandEveningSprite;
//			}
//			
//		}
//		public void PlayMusicBattle()
//		{
//			if (Game.instance.destinationPlace == EStage.OUTSIDE_ROAD)
//			{
//			}
//			else
//			{
//				SoundManager.instance.PlayMusic(musicBattle1);
//			}
//		}
//		public void PlayMusicBossBattle()
//		{
//			
//			if (Game.instance.destinationPlace == EStage.METAL_DEFENCE)
//			{
//				SoundManager.instance.PlayMusic(musicBladeRobo);
//			}
//			else if (Game.instance.destinationPlace == EStage.OUTSIDE_ROAD)
//			{
//				SoundManager.instance.PlayMusic(musicStage4Boss);
//			}
//			else if (Game.instance.destinationPlace == EStage.OTHER_STAGE1)
//			{
//				SoundManager.instance.StopMusic();
//			}
//			else
//			{
//				SoundManager.instance.PlayMusic(musicBattle1);
//			}
//		}
//		
//		public void PlayMusicField()
//		{
//			EStage eStage = Game.instance.destinationPlace;
//			if (eStage == EStage.OUTSIDE_ROAD)
//			{
//				SoundManager.instance.PlayMusic(musicStageField4);
//			}
//			else if (eStage == EStage.OTHER_STAGE1)
//			{
//				SoundManager.instance.StopMusic();
//			}
//			else
//			{
//				SoundManager.instance.PlayMusic(musicWalking);
//			}
//		}
//	
//	
//		// Update is called once per frame
//		void Update () {
//			
//		}
//		public void CheckingProgress()
//		{
//			int boss_encount_progress = 100;
//			Player player = Player.instance;
//			EStage eStage = Game.instance.destinationPlace;
//			if (eStage == EStage.OTHER_STAGE1)
//			{
//				if (player.Progress == boss_encount_progress)
//				{
//					eventManager.EncountEnemyBoss();
//				}
//				return;
//			}
//			
//			randomEncount--;
//			if (player.Progress == 0) return;
//			if (player.Progress == boss_encount_progress)
//			{
//				eventManager.EncountEnemyBoss();
//			}
//			else if(randomEncount <= 0){
//				randomEncount = Random.Range(1, 8) + 10;
//				eventManager.EncountEnemy();
//			}
//		}
//	
//		public void GoHomeForWinner()
//		{
//			Game gs = Game.instance;
//			EGameProgress eGameProgress = (EGameProgress)PlayerPrefs.GetInt(ESave.GameProgress.ToString());
//			if (eGameProgress == EGameProgress.SHOW_STAGE_1)
//			{
//				//ステージ２をオープン
//				gs.SetGameProgress(EGameProgress.SHOW_STAGE_2);
//			}
//			if (eGameProgress == EGameProgress.SHOW_STAGE_2)
//			{
//				//ステージ３をオープン
//				gs.SetGameProgress(EGameProgress.SHOW_STAGE_3);
//			}
//			if (eGameProgress == EGameProgress.SHOW_STAGE_3)
//			{
//				//ステージ４をオープン予定
//				gs.SetGameProgress(EGameProgress.SHOW_STAGE_4);
//			}
//			if (eGameProgress == EGameProgress.SHOW_STAGE_4)
//			{
//				//異なる拠点エリアへ
//				gs.SetGameProgress(EGameProgress.SHOW_OTHER_STAGE_1);
//				Game.instance.Save();
//				SceneManager.LoadScene("Scenes/HomeSecondScene");
//				return;
//			}
//			if (eGameProgress == EGameProgress.SHOW_OTHER_STAGE_1)
//			{
//				//外道狩りステージへ
//				gs.SetGameProgress(EGameProgress.SHOW_OTHER_STAGE_GEDOUGARI);
//				Game.instance.Save();
//				SceneManager.LoadScene("Scenes/GameMainScene");
//				return;
//			}
//			
//			Game.instance.Save();
//			SceneManager.LoadScene("Scenes/HomeScene");
//		}
//		public void GoHomeForLoser()
//		{
//			Game.instance.Save();
//			SceneManager.LoadScene("Scenes/HomeScene");
//		}
//	
//		public void PushBtnItem()
//		{
//	//		GameMainManager game = GameMainManager.instance;
//	//		if (game._mode != EMode.WALKING) return;
//	//		SkysemiChanMsg.instance.msgOther[EMsgOther.PushItem]();
//		}
//		public void PushBtnHome()
//		{
//	//		GameMainManager game = GameMainManager.instance;
//	//		if (game._mode != EMode.WALKING) return;
//	//		SkysemiChanMsg.instance.msgOther[EMsgOther.PushHome]();
//		}
	    public ISceneController GetSelfController()
	    {
		    return this;
	    }

	    public CardBoard GetCardBoard()
	    {
		    return _cardBoard;
	    }

	    public EquipmentCardField GetEquipmentCardField()
	    {
		    return _equipmentCardField;
	    }

	    public PlayerStatusWindow GetPlayerStatusWindow()
	    {
		    return _playerStatusWindow;
	    }
	    
		public void PushGoFrontButton()
		{
//			if (game.mode == EMode.BOSS_BATTLE_AFTER) return;
//			if (GameSystem.instance.destinationPlace == EStage.OTHER_STAGE1)
//			{
//				SoundManager.instance.PlaySingle(game.clipSoundWalking);
//			}
//			
//			Player player = Player.instance;
//			player.Progress++;
//
//			int landIndex = player.Progress % 3;
//			game.loadLayer.sprite = game.imageRoads[landIndex];
//			game.playerManager.textProgress.text = player.Progress.ToString();
//			Player.instance.NaturalHealingByWalk();
//			game.CheckingProgress();
		}
    }
}
