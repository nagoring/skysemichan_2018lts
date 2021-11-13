using System;
using System.Collections.Generic;
using UnityEngine;
using Skysemi.With.ActionCards;
using Skysemi.With.Chara;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes;
using Skysemi.With.Scenes.WorldObject;
using Skysemi.With.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Skysemi.With.Core
{
	public class Game : AppMonoBehaviour, IPlayer
	{
		public readonly int[] extTbl = new int[]
		{
			7,16,46,50, 60,               70,100, 140, 180, 220,
			400, 600, 900, 1500, 2200,    3000, 4000, 5000, 6000, 7000
		};
		private Dictionary<EGameProgress, EGameProgress> _gameProgressDict =
			new Dictionary<EGameProgress, EGameProgress>()
			{
				{EGameProgress.ZERO, EGameProgress.GAME_START},
				{EGameProgress.GAME_START, EGameProgress.SHOW_STAGE_1},
				{EGameProgress.SHOW_STAGE_1, EGameProgress.SHOW_STAGE_2},
				{EGameProgress.SHOW_STAGE_2, EGameProgress.SHOW_STAGE_3},
				{EGameProgress.SHOW_STAGE_3, EGameProgress.SHOW_STAGE_4},
				{EGameProgress.SHOW_STAGE_4, EGameProgress.SHOW_OTHER_STAGE_1},
				{EGameProgress.SHOW_OTHER_STAGE_1, EGameProgress.SHOW_OTHER_STAGE_GEDOUGARI},
			};


//        public event EventHandler CalculateActionCardsEvent;
//	public delegate void WayDelegate(WayEventParam param);
//	public event WayDelegate WayEvent = delegate (WayEventParam param) { };
//        public event CalculateActionCardsDelegate CalculateActionCardsEvent = delegate (CalculateActionCardsEventArgs param) { };
//        private CalculateActionCardsEventSender _calculateActionCardsEventSender;

		public static Game instance = null;
		[FormerlySerializedAs("_player")] public Player player = null;
		public ShizuneMsg shizuneMsg;
		public GameObject shizuneMsgGameObject;
		public EventManager eventManager = null;
		public EnemyManager enemyManager = null;
		public EffectManager effectManager = null;
		public EGameProgress gameProgress;
		public Dictionary<string, UnityEvent> events;

		public EStage destinationPlace;

//        public string SecneName {get {return _sceneName;}set{_sceneName = value;}}
//        private string _sceneName;
		private ISceneController _sceneCtrl;
		private IPlayerCardUiController _cardUiController;
		private IPlayerStatusWindow _playerStatusWindow;

		//効果音
		public AudioClip clipPanch;
		public AudioClip clipLpUp;
		public AudioClip clipLoser;
		public AudioClip clipEscape;
		public AudioClip clipEnemyAtk1;
		public AudioClip clipEnemyBlade1;
		public AudioClip clipSoundWalking;

		//ミュージック
		public AudioClip musicWalking;
		public AudioClip musicStageField4;
		public AudioClip musicBattle1;
		public AudioClip musicBladeRobo;
		public AudioClip musicStage4Boss;

		public readonly int[] expTbl = new int[]
		{
			7, 16, 36, 50, 60, 70, 100, 140, 180, 220,
			400, 600, 900, 1500, 2200, 3000, 4000, 5000, 6000, 7000,
		};

		void Awake()
		{
			if (instance == null)
			{
				GameObject obj = new GameObject();
				instance = this;
				destinationPlace = EStage.NONE;
				eventManager = obj.AddComponent<EventManager>();
				enemyManager = new EnemyManager();
				// shizuneMsg = obj.AddComponent<ShizuneMsg>();
				// effectManager = obj.AddComponent<EffectManager>();
			}
			else if (instance != this)
			{
				Destroy(gameObject);
			}

			DontDestroyOnLoad(gameObject);
		}

		// Use this for initialization
		void Start()
		{
			effectManager = EffectManager.instance;
			shizuneMsg.msg = shizuneMsgGameObject.GetComponentInChildren<Text>();
			// EffectManager.instance
			// Instantiate(effectManager);
//            eventManager = this.gameObject.AddComponent<EventManager>();
			// gameProgress = PlayerPrefs.GetInt("GameProgress");
		}

		// Update is called once per frame
		void Update()
		{
		}

		public void DeleteSaveData()
		{
			// PlayerPrefs.DeleteAll();
		}

		//FirstInputManagerとHomeManagerとBattleManaterのシーン切替時に呼ばれる
		public void Save()
		{
//            Player player = Player.instance;
//            Player.Param param = player.GetParam();
//            param.hp = param.maxhp;
//            param.mp = param.maxmp;
//            for (int i = 0; i < 3; i++)
//            {
//                int actionCardId = (int)param.actionCardNames[i];
//                Debug.Log("actionCardID" + i + "=" + actionCardId);
//            }
//            PlayerPrefsUtils.SetObject<Player.Param>(ESave.Player.ToString(), param);
		}

		public void Load()
		{
			SetGameProgress(EGameProgress.SHOW_STAGE_1);

			// Player player = player;
			// player.Progress;
//            Player.Param param = PlayerPrefsUtils.GetObject<Player.Param>(ESave.Player.ToString());
//            Debug.Log("LV:" + param.lv);
//            player.SetParam(param);
		}

		public void SetGameProgress(EGameProgress eGameProgress)
		{
			// PlayerPrefs.SetInt(ESave.GameProgress.ToString(), (int) eGameProgress);
			gameProgress = eGameProgress;
		}

		public void SetNextGameProgress(EGameProgress eGameProgress)
		{
			gameProgress = _gameProgressDict[eGameProgress];
			// PlayerPrefs.SetInt(ESave.GameProgress.ToString(), (int) eGameProgress);
		}

		public void SetCardUiController(IPlayerCardUiController ctrl)
		{
			_cardUiController = ctrl;
		}

		public IPlayerCardUiController GetCardUiController()
		{
			return _cardUiController;
		}

		public void SetPlayerStatusWindow(IPlayerStatusWindow ctrl)
		{
			_playerStatusWindow = ctrl;
		}

		public IPlayerStatusWindow GetPlayerStatusWindow()
		{
			return _playerStatusWindow;
		}



		public void InitPlayer(string playerName)
		{
			if (player == null)
			{
				player = gameObject.AddComponent<Player>();
				player.Init(playerName);
			}
		}

		public Player GetPlayer()
		{
			if (player == null)
			{
				player = gameObject.AddComponent<Player>();
				player.Init("名無し");
			}

			return player;
		}

		public EnemyManager GetEnemyManager()
		{
			return enemyManager;
		}


		public void GetBtnNavigationWindow()
		{
			throw new NotImplementedException();
		}

		public void PlayMusicBattle()
		{
			if (destinationPlace == EStage.OUTSIDE_ROAD)
			{
			}
			else
			{
				SoundManager.instance.PlayMusic(musicBattle1);
			}
		}

		public void PlayMusicBossBattle()
		{
			if (destinationPlace == EStage.METAL_DEFENCE)
			{
				SoundManager.instance.PlayMusic(musicBladeRobo);
			}
			else if (destinationPlace == EStage.OUTSIDE_ROAD)
			{
				SoundManager.instance.PlayMusic(musicStage4Boss);
			}
			else if (destinationPlace == EStage.OTHER_STAGE1)
			{
				SoundManager.instance.StopMusic();
			}
			else
			{
				SoundManager.instance.PlayMusic(musicBattle1);
			}
		}

		public void PlayMusicField()
		{
			EStage eStage = destinationPlace;
			if (eStage == EStage.OUTSIDE_ROAD)
			{
				SoundManager.instance.PlayMusic(musicStageField4);
			}
			else if (eStage == EStage.OTHER_STAGE1)
			{
				SoundManager.instance.StopMusic();
			}
			else
			{
				SoundManager.instance.PlayMusic(musicWalking);
			}
		}

		public void GoHomeForWinner()
		{
			// SetGameProgress(EGameProgress.SHOW_STAGE_1);
			SetNextGameProgress(gameProgress);

			if (gameProgress == EGameProgress.SHOW_OTHER_STAGE_1)
			{
				SceneManager.LoadScene("Scenes/HomeSecondScene");
				return;
			}

			// Game gs = Game.instance;
			// EGameProgress eGameProgress = (EGameProgress)PlayerPrefs.GetInt(ESave.GameProgress.ToString());
			// if (eGameProgress == EGameProgress.SHOW_STAGE_1)
			// {
			// 	//ステージ２をオープン
			// 	gs.SetGameProgress(EGameProgress.SHOW_STAGE_2);
			// }
			// if (eGameProgress == EGameProgress.SHOW_STAGE_2)
			// {
			// 	//ステージ３をオープン
			// 	gs.SetGameProgress(EGameProgress.SHOW_STAGE_3);
			// }
			// if (eGameProgress == EGameProgress.SHOW_STAGE_3)
			// {
			// 	//ステージ４をオープン予定
			// 	gs.SetGameProgress(EGameProgress.SHOW_STAGE_4);
			// }
			// if (eGameProgress == EGameProgress.SHOW_STAGE_4)
			// {
			// 	//異なる拠点エリアへ
			// 	gs.SetGameProgress(EGameProgress.SHOW_OTHER_STAGE_1);
			// 	Game.instance.Save();
			// 	SceneManager.LoadScene("Scenes/HomeSecondScene");
			// 	return;
			// }
			// if (eGameProgress == EGameProgress.SHOW_OTHER_STAGE_1)
			// {
			// 	//外道狩りステージへ
			// 	gs.SetGameProgress(EGameProgress.SHOW_OTHER_STAGE_GEDOUGARI);
			// 	Game.instance.Save();
			// 	SceneManager.LoadScene("Scenes/GameMainScene");
			// 	return;
			// }
			//
			// Game.instance.Save();
			// SceneManager.LoadScene("Scenes/HomeScene");
		}

		public ABase CreateActionCard(Type actionCardType)
		{
			ABase abaseActionCard = (ABase)(new GameObject()).AddComponent(actionCardType);
			GameObject instanceActionCard = GameObjectInstantiate(abaseActionCard.GetPrefabFilePath());
			ABase baseActionCard = (ABase)instanceActionCard.AddComponent(actionCardType);
			baseActionCard.Init();
			return baseActionCard;
		}

		public Enemy CreateEnemy(Type enemyType)
		{
			Enemy _enemy = (Enemy)(new GameObject()).AddComponent(enemyType);
			_enemy.Init();
			return _enemy;
		}

		public GameObject GameObjectInstantiate(string prefabFilePath)
		{
			GameObject actionCardPrefab = (GameObject)Resources.Load(prefabFilePath);
			GameObject instance = (GameObject)Object.Instantiate(actionCardPrefab,Vector2.zero,Quaternion.identity);
			return instance;
		}
	}
}