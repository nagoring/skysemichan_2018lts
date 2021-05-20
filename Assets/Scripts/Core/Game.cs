using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Boo.Lang;
using Skysemi.With.Chara;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes;
using Skysemi.With.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Video;

namespace Skysemi.With.Core
{
    public class Game : AppMonoBehaviour, IPlayer
    {
//        public event EventHandler CalculateActionCardsEvent;
//	public delegate void WayDelegate(WayEventParam param);
//	public event WayDelegate WayEvent = delegate (WayEventParam param) { };
//        public delegate void CalculateActionCardsDelegate(CalculateActionCardsEventArgs param);
//        public event CalculateActionCardsDelegate CalculateActionCardsEvent = delegate (CalculateActionCardsEventArgs param) { };
//        private CalculateActionCardsEventSender _calculateActionCardsEventSender;
        
        public static Game instance = null;
        private Player _player = null;
        public EventManager eventManager = null;
        public EnemyManager enemyManager = null;
        public int progress;
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
            7,  16,  36,   50,   60,     70, 100, 140, 180, 220,
            400, 600, 900, 1500, 2200,   3000, 4000, 5000, 6000, 7000, 
        };

        public void OnCalculateActionCardsEvent(CalculateActionCardsEventArgs e)
        {
//            CalculateActionCardsEvent(e);
        }
	
        void Awake()
        {
		
            if (instance == null)
            {
                instance = this;
                destinationPlace = EStage.NONE;
                eventManager = new EventManager();
                enemyManager = new EnemyManager();
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
	
        // Use this for initialization
        void Start () {
//            eventManager = this.gameObject.AddComponent<EventManager>();
            progress = PlayerPrefs.GetInt("GameProgress");
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void CheckProgress()
        {
            progress = PlayerPrefs.GetInt("GameProgress");
        }
        public void DeleteSaveData()
        {
            PlayerPrefs.DeleteAll();
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
//            Player player = Player.instance;
//            Player.Param param = PlayerPrefsUtils.GetObject<Player.Param>(ESave.Player.ToString());
//            Debug.Log("LV:" + param.lv);
//            player.SetParam(param);
        }

        public void SetGameProgress(EGameProgress eGameProgress)
        {
            PlayerPrefs.SetInt(ESave.GameProgress.ToString(), (int) eGameProgress);
            progress = (int) eGameProgress;
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

        
//        public void RegisterEvent()
//        {
//            if(_calculateActionCardsEventSender == null)
//            {
//                _calculateActionCardsEventSender = new CalculateActionCardsEventSender();
//            }
//            Player player = GetPlayer();
//            _calculateActionCardsEventSender.CalculateActionCardsEvent += player.CalculateEquipmentActionCardsReceiver;
//        }

        public void InitPlayer(string playerName)
        {
            if (_player == null)
            {
                _player = gameObject.AddComponent<Player>();
                _player.Init(playerName);
            }
        }

        public Player GetPlayer()
        {
            if (_player == null)
            {
                _player = gameObject.AddComponent<Player>();
                _player.Init("名無し");
            }
            return _player;
        }

        public EnemyManager GetEnemyManager()
        {
            return enemyManager;
        }

        public void FireEvent(EEvent eventKey, BaseEventArgs args)
        {
            eventManager.EventSenderFactory(eventKey).Send(args);
        }
//        public void SetEvent(string key, UnityAction call)
//        {
//            if (!events.ContainsKey(key))
//            {
//                events[key] = new UnityEvent();
//            }
//            events[key].AddListener(call);
//        }
//
//        public void FireEvent(string key)
//        {
//            if (events.ContainsKey(key))
//            {
//                events[key].Invoke();
//            }
//        }
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
    }
}


