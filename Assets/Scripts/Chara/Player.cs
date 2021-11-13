using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Skysemi.With.ActionCards;
using Skysemi.With.CardUI;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes;
using StatusUI;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

//シズネ　静音
namespace Skysemi.With.Chara
{
	public class Player : MonoBehaviour, IChara
	{
//		public static Player instance;
		public CharaParameter param;
		private EBattleAction eBattleAction;
		protected ActionCards.ABase[] _actionCard = new ActionCards.ABase[4];

		public string CharaName
		{
			get { return param.charaName; }
			set { param.charaName = value; }
		}

		public void SayAtkAfter(IChara target)
		{
		}

		public EChara Id
		{
			get { return param.id; }
			set { param.id = value; }
		}

		public int Hp
		{
			get { return param.hp; }
			set { param.hp = value; }
		}

		public int MaxHp
		{
			get { return param.maxhp + param.tmpMaxHp; }
			set { param.maxhp = value; }
		}

		public int Atk
		{
			get { return param.atk; }
			set { param.atk = value; }
		}

		public int Def
		{
			get { return param.def; }
			set { param.def = value; }
		}

		public int MaxSpirit
		{
			get { return param.maxspirit; }
			set { param.maxspirit = value; }
		}

		public int Agi
		{
			get { return param.agi; }
			set { param.agi = value; }
		}

		public int Spirit
		{
			get { return param.spirit; }
			set { param.spirit = value; }
		}

		public int Str
		{
			get { return param.str; }
			set { param.str = value; }
		}

		public int Vit
		{
			get { return param.vit; }
			set { param.vit = value; }
		}

		public int Exp
		{
			get { return param.exp; }
			set { param.exp = value; }
		}

		public int NextExp
		{
			get { return param.nextExp; }
			set { param.nextExp = value; }
		}

		public int Lv
		{
			get { return param.lv; }
			set { param.lv = value; }
		}

		public int Progress
		{
			get { return param.progress; }
			set { param.progress = value; }
		}

		public int TmpMaxHp
		{
			get { return param.tmpMaxHp; }
			set { param.tmpMaxHp = value; }
		}

		public int Ext
		{
			get { return param.exp; }
			set { param.exp = value; }
		}

		//	
		//	public EActionCardActive eActionCardActive = EActionCardActive.CMD1;
		//
		private ActionCards.ABase[] _actionCards = new ActionCards.ABase[4];

//		public struct Param
//		{
//			public EChara  id;
//			public string playerName;
//			public int maxhp;
//			public int tmpMaxHp;
////			public int maxmp;
//			public int hp;
////			public int mp;
//			public int atk;
//			public int def;
//			public int progress;
//			public int exp;
//			public int nextExp;
//			public int lv;
//			//筋力
//			public int str;
//			//丈夫さ/生命力
//			public int vit;
//			public EActionCardName[] actionCardNames;
//	
//		}
//		
//		private Param param;
//		
//		//updateParamのようなメソッドがセーブを行う前に必要。ActionCardが正しく保存されない
//		public Player.Param GetParam()
//		{
//			return param;
//		}
//	
//		public void SetParam(Player.Param _param)
//		{
//			this.param = _param;
//		}


		//行動を行う対象を決める。現在は攻撃しかできないからENEMY固定
		public IChara GetTarget(List<IChara> targetList)
		{
			foreach (IChara chara in targetList)
			{
				if (chara.GetCharaType() == ECharaType.ENEMY)
				{
					return chara;
				}
			}

			return null;
		}

		//対象に対してどんな行動をとる？
		public void SetBattleAction(IChara chara)
		{
			eBattleAction = EBattleAction.ATK;
			if (chara.GetCharaType() == ECharaType.ENEMY)
			{
				eBattleAction = EBattleAction.ATK;
			}
		}

		public EBattleAction GetBattleAction()
		{
			return eBattleAction;
		}

		public ECharaType GetCharaType()
		{
			return ECharaType.PLAYER;
		}

		public EGroup GetGroup()
		{
			return EGroup.Namamono;
		}

		public void PlayActionAnimation()
		{
			Game game = Game.instance;
			StartCoroutine(game.effectManager.attackPunchAnimation());
		}

		public void PlayActionSound()
		{
			Game game = Game.instance;
			SoundManager.instance.PlaySingleRepeat(game.clipPanch, 3, 0.3f);
			// GameMainManager game = GameMainManager.instance;
			// SoundManager.instance.PlaySingleRepeat(game.clipPanch, 3, 0.3f);
		}

		public float GetWaitTimeByAnimation()
		{
			return 0.3f;
		}

		public void Act(IChara target)
		{
			Game game = Game.instance;

			if (eBattleAction == EBattleAction.ATK)
			{
				IDmageLogic iDamageLogic = DamageLogicFactory.create(target, this);
				int damage = iDamageLogic.CalcDamage(target, this);
				// Debug.Log("damage:" + damage);
				// Debug.Log("target.Hp:" + target.Hp);
				target.Hp -= damage;
				EnemyStatusWindow enemyStatusWindow = World.instance.GetEnemyStatusWindow();
				enemyStatusWindow.Hp.text = target.Hp.ToString();

//				game.enemyManager.hp.text = target.Hp.ToString();

				//ナビゲーションメッセージ
				// Text navText = game.uiManager.btnNavigationWindow.GetComponentInChildren<Text>();
				Text navText = World.instance.btnNavigationWindow.GetComponentInChildren<Text>();
				navText.color = new Color(0, 0, 0);
				navText.text = $"{target.CharaName}は{damage}のダメージをうけた";
			}
		}

		public void SayDamageAfterMsg()
		{
		}

		public float BeforeActStartWait()
		{
			return 0;
		}

		public void BeforeActStartMsg(IChara target)
		{
		}
		//	
//		void Awake() {
//			if (instance == null)
//			{
//				instance = this;
//			}
//			else if (instance != this)
//			{
//				Destroy(gameObject);
//			}
//			DontDestroyOnLoad(gameObject);
//		}

		void Start()
		{
		}

		/// <summary>
		///  装備したときのカードの数値を内部パラメータに再計算する
		/// </summary>
		/// <param name="actionCards"></param>
		public void RecalculateEquipmentActionCards()
		{
			ActionCards.ABase[] actionCards = this.GetActionCards();
			int tmpMaxHp = 0;
			int tmpAtk = 0;
			int tmpDef = 0;
			int tmpSpirit = param.spirit;
			param.spirit = 0;
			int tmpAgi = param.agi;
			param.agi = 0;
			foreach (ActionCards.ABase actionCard in actionCards)
			{
				if (actionCard == null) continue;
				tmpMaxHp += actionCard.MaxHp;
				tmpAtk += actionCard.Atk;
				tmpDef += actionCard.Def;
				tmpSpirit += actionCard.Spirit;
				tmpAgi += actionCard.Agi;
			}

			param.tmpMaxHp = tmpMaxHp;
			param.atk = param.str + tmpAtk;
			param.def = param.vit + tmpDef;
			param.spirit = param.spirit + tmpSpirit;
			param.agi = param.agi + tmpAgi;


			//		GameMainManager game = GameMainManager.instance;
			//
			//		game.playerManager.textAtk.text = param.atk.ToString();
			//		game.playerManager.textDef.text = param.def.ToString();
			//
			//		
			//		//ActionCardやUIのステータスとパラメータを一致させる
			//		UIManager.instance.ShowActionCardArea(this);
			//		PlayerManager.instance.SyncUiStatusByPlayer(this);
		}

		/// <summary>
		/// FirstSceneのFirstInputManagerから一度だけ呼び出す
		/// </summary>
		public void Init(string inPlayerName)
		{
			Lv = 1;
			CharaName = inPlayerName;
			Id = EChara.Player;
			// MaxHp = 30;
			MaxHp = 3000;
			Hp = MaxHp;
			TmpMaxHp = 0;
			Str = 1;
			Vit = 0;
			Atk = Str + 1;
			Def = Vit;
			Progress = 0;
			Exp = 0;
			MaxSpirit = 10;
			Spirit = 5;
			Agi = 10;
			Progress = (int) EGameProgress.GAME_START;
			NextExp = Game.instance.expTbl[0];
//			param.nextExp = GameSystem.instance.expTbl[0];
//			
//			param.actionCardNames = new EActionCardName[4];
//			param.actionCardNames[0] = EActionCardName.Empty;
//			param.actionCardNames[1] = EActionCardName.Empty;
//			param.actionCardNames[2] = EActionCardName.Empty;
//			param.actionCardNames[3] = EActionCardName.Empty;
//			CharaName = _playerName;
		}

		//	
		//
		//	public void InitProgress()
		//	{
		//		param.hp = param.maxhp;
		//		param.mp = param.maxmp;
		//		param.progress = 0;
		//	}
		private void DoLvUp()
		{
			param.maxhp += 5;
			param.str += 1;
			// param.vit += 1;
			//自UIのステータス反映
			// SyncUiParam();
		}

		//
		//	void FormatingParamaters()
		//	{
		//		param.atk = param.str + 1;
		//		param.def = param.vit;
		//	}
		//
		//
		//
		//
		//
		//
		private int CalcDamage(IChara target)
		{
			int damage = param.atk - target.Def;
			damage += (int) Random.Range(-3.0f, 3.0f);
			if (damage < 0) damage = 0;
			return damage;
		}

		// Update is called once per frame
		void Update()
		{
		}

		//
		//	
		////	//ステータスの更新を行う。ActionCardや己のステータスからATK,DEFを決める
		////	public void SyncUpdationParameter()
		////	{
		////		int tmpAtk = 0;
		////		int tmpDef = 0;
		////		
		////		foreach (ActionCards.ABase actionCard in _actionCards)
		////		{
		////			if (actionCard == null) continue;
		////			tmpAtk += actionCard.Atk;
		////			tmpDef += actionCard.Def;
		////		}
		////		param.atk = param.str + 1 + tmpAtk;
		////		param.def = param.vit + tmpDef;
		////		GameMainManager game = GameMainManager.instance;
		////
		////		game.playerManager.textAtk.text = param.atk.ToString();
		////		game.playerManager.textDef.text = param.def.ToString();
		////
		////		
		////		//ActionCardやUIのステータスとパラメータを一致させる
		////		UIManager.instance.ShowActionCardArea(this);
		////		PlayerManager.instance.SyncUiStatusByPlayer(this);
		////		
		////	}
		//
		public void NaturalHealingByWalk()
		{
			Game game = Game.instance;
			if (MaxHp > Hp)
			{
				Hp += 1;
			}

			//自UIのステータス反映
			SyncUiParam();
		}

		public void BattleEnd(BattleEndEventParam param)
		{
			this.Exp += param.enemy.Exp;
			Game game = Game.instance;
			// Game gs = Game.instance;
			if (this.NextExp < this.Exp)
			{
				//レベルアップ
				this.Lv += 1;
				int nextLv = this.Lv + 1;
				if (game.expTbl.Length <= nextLv)
				{
					this.NextExp = Int32.MaxValue;
					;
				}
				else
				{
					this.NextExp = game.expTbl[nextLv];
				}

				//レベルアップの時のセリフとSE
				SoundManager.instance.Stop();
				SoundManager.instance.PlaySingle(game.clipLpUp);
				ShizuneMsg.instance.DelayMsgOther();
				this.DoLvUp();

				
			}

			SyncUiParam();
			game.player.SyncUiStatusByPlayer(game.player);
		}

		//
		//	private void InitActionCardsParam()
		//	{
		//		ActionCards.ABase newEmpty = PlayerManager.instance.emptyObj.GetComponent<ActionCards.ABase>();
		//		_actionCards[0] = Instantiate(newEmpty);
		//		_actionCards[1] = Instantiate(newEmpty);
		//		_actionCards[2] = Instantiate(newEmpty);
		//		_actionCards[3] = Instantiate(newEmpty);
		//	}
		//
		//	public void SetActionCard(ActionCards.ABase abaseActionCard, int index)
		//	{
		//		_actionCards[index] = abaseActionCard;
		//		EActionCardName eName = abaseActionCard.GetEActionCardName();
		//		SetActionCardNames(eName, index);
		//	}
		//
		//	public void SetActionCardNames(EActionCardName eActionCardName, int index)
		//	{
		//		param.actionCardNames[index] = eActionCardName;
		//	}
		//
		//	private Image GetChildImage(int index)
		//	{
		//		GameObject btnActionCard = UIManager.instance.btnActionCards[index];
		//		Image[] childs = btnActionCard.GetComponentsInChildren<Image>();
		//		foreach (Image child in childs)
		//		{
		//			if (child.name == "ImageInvisibleSprite")
		//			{
		//				return child;
		//			}
		//		}
		//		return null;
		//	}
		//
		//	public ActionCards.ABase GetActionCardsForParamName(int index)
		//	{
		//		return _actionCards[index];
		//	}
		public void SyncUiParam()
		{
			Game game = Game.instance;
			PlayerStatusWindow playerStatusWindow = game.GetPlayerStatusWindow().GetPlayerStatusWindow();
			playerStatusWindow.SyncPlayerStatusReceiver(param);
		}

		public void SyncUiStatusByPlayer(Player player)
		{
			// textLv.text = player.Lv.ToString();
			// textMaxHp.text = player.MaxHp.ToString();
			// textMp.text = player.Mp.ToString();
			// textHp.text = player.Hp.ToString();
			// textAtk.text = player.Atk.ToString();
			// textDef.text = player.Def.ToString();
			// textExp.text = player.Exp.ToString();
			// textProgress.text = player.Progress.ToString();
		}

		public ActionCards.ABase GetActionCard(int index)
		{
			return _actionCard[index];
			// Game game = Game.instance;
			// Skysemi.With.Scenes.IPlayerCardUiController cardUiController =  game.GetCardUiController();
			// EquipmentCardFieldUi equipmentCardFieldUi = cardUiController.GetEquipmentCardField();
			// return equipmentCardFieldUi.GetActionCard(index);
		}

		public Player SetActionCard(int index, ActionCards.ABase actionCard)
		{
			_actionCard[index] = actionCard;
			return this;
			// Game game = Game.instance;
			// Skysemi.With.Scenes.IPlayerCardUiController cardUiController =  game.GetCardUiController();
			// EquipmentCardFieldUi equipmentCardFieldUi = cardUiController.GetEquipmentCardField();
			// return equipmentCardFieldUi.GetActionCard(index);
		}

		public Player Eqpt(int index, ActionCards.ABase actionCard)
		{
			return SetActionCard(index, actionCard);
		}

		public ActionCards.ABase[] GetActionCards()
		{
			return _actionCard;
			// Game game = Game.instance;
			// Skysemi.With.Scenes.IPlayerCardUiController cardUiController =  game.GetCardUiController();
			// EquipmentCardFieldUi equipmentCardFieldUi = cardUiController.GetEquipmentCardField();
			// return equipmentCardFieldUi.GetActionCards();
		}

		public float DamageRate(IChara target)
		{
			return DamageRating.Calc(target, this);
		}
	}
}
//	//未定
//	
//	
////	public List<ActionCards.ABase> actionCardList = new List<ActionCards.ABase>();
//	//Elona http://elona.wikiwiki.jp/?%BC%E7%C7%BD%CE%CF
////	//器用さ
////	public int dex;
////	//賢さ
////	public int inte;
////	//精神/意思
////	public int mind;
////	//素早さ
////	public int agi;
////	//運
////	public int luc;
////	//クリティカル
////	public int cri;
////	//感覚
////	public int sense;
////	//習得
////	public int mastery;
////	//魔力
////	public int magic;
////	//魅力
////	public int charm;
////	//速度
////	public int speed;
////	//潜在能力
////	public int potential;