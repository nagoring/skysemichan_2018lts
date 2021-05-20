using Boo.Lang;
using Skysemi.With.ActionCards;
using Skysemi.With.CardUI;
using Skysemi.With.Chara;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes.WorldObject;
using StatusUI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Skysemi.With.Scenes
{
    public class World : AppMonoBehaviour, ISceneController, IPlayerCardUiController, 
	    IPlayerStatusWindow,IGoFrontStateChangeParameter, ISetUpEnemy
    {
		public static World instance;
		public static Game game;
	    private CardBoard _cardBoard;
	    private Skysemi.With.CardUI.EquipmentCardFieldUi _equipmentCardFieldUi;
	    private PlayerStatusWindow _playerStatusWindow;
	    private Skysemi.With.CardUI.EquipmentCardFieldMiniUi _equipmentCardFieldMiniUi;
	    public GameObject enemyLayer;
	    public Canvas canvasUI;
	    public Image enemyStatusWindow;
	    [FormerlySerializedAs("buttonGoFront")] public GameObject btnGoFront;
	    public GameObject btnNavigationWindow;
	    public GameObject btnBattleFlow;

	    public EWorldMode WorldMode {get;set;}
	    private EWorldMode _worldMode = EWorldMode.WALKING;
	    public Sprite[] imageRoads = new Sprite[3];

		public Image roadLayer;
//		private int _randomEncount = 5;
		private bool _isBoss = false;

//		public SkysemiChanManager skysemiChanManager;
//		public SkysemiChanMsg skysemiChanMsg;
//		public EventManager eventManager;
//		public EnemyManager enemyManager;
//		public UIManager uiManager;
//		public PlayerManager playerManager;
		public EffectManager effectManager;

		private ISetUpEnemy _setUpEnemyImplementation;
//		public Image imageFlatLand;
//		public Sprite imageFlatLandEveningSprite;
//		public Canvas canvas;
//		public Sprite[] imageRoads = new Sprite[3];

		private ETurn _turn = ETurn.PLAYER;

		private IEncountRule _encountRule;
//		public ETurn turn = ETurn.PLAYER;
//		public bool _isBoss = false;
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
//		private int _randomEncount = 5;
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
			_equipmentCardFieldUi = EquipmentCardFieldUi.CreateEquipmentCardFieldInCanvas(canvasUI, -240, -300);
			_equipmentCardFieldUi.Init();
			
			
			EnemyStatusWindow localEnemyStatusWindow = enemyStatusWindow.gameObject.GetComponent<EnemyStatusWindow>();
			localEnemyStatusWindow.Init();
			//Eventの登録
			game.eventManager.RegisterEvent();
//			game.eventManager.AddSenderEvent(EEvent.SyncEnemyStatus, new StandartEventSender());
//			game.eventManager.AddReceiver(EEvent.SyncEnemyStatus, localEnemyStatusWindow.SyncEnemyStatusReceiver);
			
			//自UIのステータス反映
			SyncStatusEventArgs syncStatusEventArgs = new SyncStatusEventArgs(game.GetPlayer().param);
//			game.FireEvent(EEvent.SyncPlayerStatus, new BaseEventArgs(syncStatusEventArgs));
			PlayerStatusWindow playerStatusWindow = game.GetPlayerStatusWindow().GetPlayerStatusWindow();
			playerStatusWindow.SyncPlayerStatusReceiver(syncStatusEventArgs);

			
			//＊実験＊ 敵の装備をセットする
			_equipmentCardFieldMiniUi = EquipmentCardFieldMiniUi.CreateEquipmentCardFieldMiniInParentTransform(enemyStatusWindow.transform, 0, -125f);
//			Enemy enemy = game.enemyManager.CreateCharaObject(this, EChara.Nasu);
//			game.enemyManager.Init(enemy, _equipmentCardFieldMiniUi);
//			game.enemyManager.Equip(0, gameObject.AddComponent<NasuHeart>());
//			game.enemyManager.Equip(1, gameObject.AddComponent<MagicAddMaxHp>());
//			game.enemyManager.Equip(2, gameObject.AddComponent<Punch>());
//			game.enemyManager.Equip(3, gameObject.AddComponent<Punch>());
//			game.enemyManager.SyncRecoveryHpInclude();
			
			


			//実験 途中でカードをすげ替える場合のケース 設定が多すぎなのでまとめたい。19.07.01 だいぶまとまった
//			game.enemyManager.Equip(0, gameObject.AddComponent<MagicAddMaxHp>());
//			game.enemyManager.Equip(1, gameObject.AddComponent<NasuHeart>());
//			game.enemyManager.Equip(2, gameObject.AddComponent<MagicAddMaxHp>());
//			game.enemyManager.Equip(3, gameObject.AddComponent<MagicAddMaxHp>());
//			game.enemyManager.SyncRecoveryHpInclude();
			//実験END

			
			
			_worldMode = EWorldMode.WALKING;
			_encountRule = EncountRuleFactory.Create((IGoFrontStateChangeParameter)this);
			
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
//			_randomEncount--;
//			if (player.Progress == 0) return;
//			if (player.Progress == boss_encount_progress)
//			{
//				eventManager.EncountEnemyBoss();
//			}
//			else if(_randomEncount <= 0){
//				_randomEncount = Random.Range(1, 8) + 10;
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
//	//		if (game._worldMode != EWorldMode.WALKING) return;
//	//		SkysemiChanMsg.instance.msgOther[EMsgOther.PushItem]();
//		}
//		public void PushBtnHome()
//		{
//	//		GameMainManager game = GameMainManager.instance;
//	//		if (game._worldMode != EWorldMode.WALKING) return;
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

	    public EquipmentCardFieldUi GetEquipmentCardField()
	    {
		    return _equipmentCardFieldUi;
	    }

	    public PlayerStatusWindow GetPlayerStatusWindow()
	    {
		    return _playerStatusWindow;
	    }
	    
		public void PushGoFrontButton()
		{
//			if (game.mode == EWorldMode.BOSS_BATTLE_AFTER) return;
//			if (GameSystem.instance.destinationPlace == EStage.OTHER_STAGE1)
//			{
//				SoundManager.instance.PlaySingle(game.clipSoundWalking);
//			}
//			
			Player player = game.GetPlayer();
			player.Progress++;
			int landIndex = player.Progress % 3;
			roadLayer.sprite = imageRoads[landIndex];
			_playerStatusWindow.Progress.text = player.Progress.ToString();
			player.NaturalHealingByWalk();
			
//			CheckingProgress();

			/// encountRule EncountNormalRule
			_encountRule.Run();
			_worldMode = _encountRule.GetWorldMode();
//			_randomEncount = _encountRule.GetRandomEncount();
			_isBoss = _encountRule.IsBoss();
			if (_encountRule.IsBoss())
			{
				
			}
			else if (_encountRule.IsEncount())
			{
				_worldMode = _encountRule.GetWorldMode();
				_encountRule.OutputEnemy(this);
				btnGoFront.SetActive(false);
//				btnNavigationWindow.SetActive(true);
				btnBattleFlow.SetActive(true);
				_turn = ETurn.PLAYER;
				
////			this.WayEvent += game.enemyManager.createEnemy;
////			this.WayEvent += game.uiManager.EncountEnemeyBegin;
////			this.WayEvent += game.skysemiChanMsg.EnemyCommentary;
				
			}
		}
//		public void CheckingProgress()
//		{
//			Debug.Log("CheckingProgress");
//			int boss_encount_progress = 100;
//			Player player = game.GetPlayer();
//			EStage eStage = game.destinationPlace;
////			if (eStage == EStage.OTHER_STAGE1)
////			{
////				if (player.Progress == boss_encount_progress)
////				{
////					eventManager.EncountEnemyBoss();
////				}
////				return;
////			}
//		
//			_randomEncount--;
//			Debug.Log(_randomEncount);
//			if (player.Progress == 0) return;
//			if (player.Progress == boss_encount_progress)
//			{
////				eventManager.EncountEnemyBoss();
//			}
//			else if(_randomEncount <= 0){
//				_randomEncount = Random.Range(1, 8) + 10;
//				Debug.Log("call EncountEnemy");
//				EncountEnemy();
//			}
//		}
		public void EncountEnemy()
		{
			_isBoss = false;
//			game.PlayMusicBattle();
			_worldMode = EWorldMode.BATTLE;
//			WayEventParam param = new WayEventParam();
//			this.WayEvent(param);
//			EncountEvent();
		}
//		public void EncountEnemyBoss()
//		{
//			game.isBoss = true;
//
//			game.PlayMusicBossBattle();
//		
//			game.mode = EMode.BATTLE;
//			WayEventParam param = new WayEventParam();
//			this.WayEvent(param);
//		}

//		private void EncountEvent()
//		{
//            if (_worldMode != EWorldMode.BATTLE) return;
//			game.enemyManager.createEnemy(this, _equipmentCardFieldMiniUi);
//			game.enemyManager.displayEnemy(enemyLayer);
//			
////			EncountEnemeyBegin(game.enemyManager.GetEnemy());
////			this.WayEvent += game.enemyManager.createEnemy;
////			this.WayEvent += game.uiManager.EncountEnemeyBegin;
////			this.WayEvent += game.skysemiChanMsg.EnemyCommentary;
//
//		}

		public Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldMini()
		{
			return _equipmentCardFieldMiniUi;
		}
//		public void EncountEnemeyBegin(Enemy enemy) {
//			if (_worldMode != EWorldMode.BATTLE) return;
//			//GoFrontButton stop
//			btnGoFront.SetActive(false);
//			//ActionCommand Begin
//
//			//ナビゲーションウィンドウの表示
//			btnNavigationWindow.SetActive(true);
//			Text navText = btnNavigationWindow.GetComponentInChildren<Text>();
//			navText.text = enemy.msg;
//			navText.color = new Color(255, 0, 0);
//
//			//攻撃用の戦闘の進行ボタンを作成
////			btnBattleFlow.SetActive(true);
////			game.turn = ETurn.PLAYER;
//		}

		public void SetWorldMode(EWorldMode eWorldMode)
		{
			_worldMode = eWorldMode;
		}

		public EWorldMode GetWorldMode()
		{
			return _worldMode;
		}

//		public int GetRandomEncount()
//		{
//			return _randomEncount;
//		}
//		public int SetRandomEncount(int randomEncount)
//		{
//			return _randomEncount = randomEncount;
//		}

//		public int DecrementRandomEncount()
//		{
//			_randomEncount--;
//			return _randomEncount;
//		}
		public bool IsBoss()
		{
			return _isBoss;
		}

		public void SetIsBoss(bool isBoss)
		{
			_isBoss = isBoss;
		}

		public MonoBehaviour GetMonoBehaviour()
		{
			return this;
		}

		public IEquipmentCardFieldUi GetEquipmentCardFieldUi()
		{
			return _equipmentCardFieldMiniUi;
		}

		public GameObject GetEnemyLayer()
		{
			return enemyLayer;
		}

		public GameObject GetBtnNavigationWindow()
		{
			return btnNavigationWindow;
		}

	    public EnemyStatusWindow GetEnemyStatusWindow()
	    {
		    return enemyStatusWindow.gameObject.GetComponent<EnemyStatusWindow>();
	    }

	    public void SetEnemyMsgTextString(string text)
	    {
		    GetBtnNavigationWindow().GetComponentInChildren<Text>().text = text;
	    }

	    public Text GetEnemyMsgText()
	    {
		    return GetBtnNavigationWindow().GetComponentInChildren<Text>();
	    }

    }
    
}
