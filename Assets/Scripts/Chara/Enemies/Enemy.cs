using System.Collections;
using System.Collections.Generic;
using Skysemi.With.ActionCards;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Scenes;
using StatusUI;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.Chara.Enemies
{
	abstract public class Enemy : MonoBehaviour, IChara
	{
		
		public abstract void Init();
		protected ActionCards.ABase[] _enemyActionCard = new ActionCards.ABase[4];
		public Dictionary<EActionCardName, ABase> cardSpareDict;
		public CharaParameter param;
		public int Hp{get {return param.hp;}set{param.hp = value;}}
		public int MaxHp{get {return param.maxhp;}set{param.maxhp = value;}}
//		public int Mp{get {return this.mp;}set{mp = value;}}
//		public int MaxMp{get {return this.maxmp;}set{maxmp = value;}}
		public int Atk{get {return param.atk;}set{param.atk = value;}}
		public int Def{get {return param.def;}set{param.def = value;}}
		public int Agi{get {return param.agi;}set{param.agi = value;}}	
		public int Spirit { get { return param.spirit; } set { param.spirit = value; } }
		public int MaxSpirit { get { return param.maxspirit; } set { param.maxspirit = value; } }

		public EChara Id{get {return param.id;}set{param.id = value;}}
		public string CharaName{get {return param.charaName;}set{param.charaName = value;}}
	
		// public string enemyName;
		public int spirit = 0;
		public int maxspirit = 10;
		public string msg;
		public List<string> msgDamageAfterList = new List<string>();
		public int exp;

		// public EChara id;
	
		// public GameObject buttonEnemyLayer;
		public Sprite[] imageEnemeies = new Sprite[1];
	
		private EBattleAction eBattleAction;
	
		void Awake() {
		}
	
		// Use this for initialization
		void Start() {
	
		}
	
		// Update is called once per frame
		void Update() {
	
		}
		// public void display() {
		// 	buttonEnemyLayer.SetActive(true);
		// 	Sprite sprite = buttonEnemyLayer.GetComponent<Sprite>();
		// 	sprite = imageEnemeies[0];
		// }
		
		public IChara GetTarget(List<IChara> targetList)
		{
			foreach (IChara target in targetList)
			{
				if (target.GetCharaType() == ECharaType.PLAYER)
				{
					return target;
				}
			}
			return null;
		}
	
		public void SetBattleAction(IChara iChara)
		{
			eBattleAction = EBattleAction.ATK;
		}
	
		public EBattleAction GetBattleAction()
		{
			return eBattleAction;
		}
	
		public ECharaType GetCharaType()
		{
			return ECharaType.ENEMY;
		}

		public virtual EGroup GetGroup()
		{
			return EGroup.Namamono;
		}
		public void PlayActionAnimation()
		{
			Game game = Game.instance; 
			StartCoroutine(game.effectManager.attackAnimationNormalByEnemy());
		}
	
		public virtual void PlayActionSound()
		{
			Game game = Game.instance;
			SoundManager.instance.PlaySingleRepeat(game.clipEnemyAtk1, 1, 0.3f);
		}
	
		public float GetWaitTimeByAnimation()
		{
			return 0.2f;
		}
	
		public void Act(IChara target)
		{
			Game game = Game.instance;
			if (eBattleAction == EBattleAction.ATK)
			{
				IDmageLogic iDamageLogic = DamageLogicFactory.create(target, this);
				int damage = iDamageLogic.CalcDamage(target, this);
				target.Hp -= damage;
				IPlayerStatusWindow iPlayerStatusWindow = game.GetPlayerStatusWindow();
				iPlayerStatusWindow.GetPlayerStatusWindow().Hp.text = target.Hp.ToString();
				
				//ナビゲーションメッセージ
				Text navText = World.instance.GetEnemyMsgText();
				navText.color = new Color(0, 0, 0);
				navText.text = $"{target.CharaName}は{damage}のダメージをうけた";
			}
		}
	
		public void SayDamageAfterMsg()
		{
//			GameMainManager game = GameMainManager.instance;
//			game.enemyManager.SayDamageAfterMsg(this);
		}
	
//		private int CalcDamage(IChara target)
//		{
//			int damage = Atk - target.Def;
//			damage += (int)Random.Range(-3.0f, 3.0f);
//			if (damage < 0) damage = 0;
//			return damage;
//		}
		public float BeforeActStartWait()
		{
			return 0;
		}
		public void BeforeActStartMsg(IChara target)
		{
		}
		public void SayAtkAfter(IChara target){}
		public abstract string GetImageFilePath();
		public abstract string GetPrefabFilePath();
		public ABase GetActionCard(int index)
		{
			return _enemyActionCard?[index];
		}
		public Enemy SetActionCard(int index, ActionCards.ABase actionCard)
		{
			_enemyActionCard[index] = actionCard;
			return this;
		}
		public ABase[] GetActionCards()
		{
			return _enemyActionCard;
		}

		public float DamageRate(IChara target)
		{
			return DamageRating.Calc(target, this);
		}
		public virtual void RecalculateEquipmentActionCards()
		{
			ABase[] actionCards = GetActionCards(); 
			int tmpMaxHp = 0;
			int tmpAtk = 0;
			int tmpDef = 0;
			int tmpSpirit = this.param.spirit;
			this.param.spirit = 0;
			int tmpAgi = this.param.agi;
			this.param.agi = 0;
			// ActionCards.ABase[] actionCards = eventArgs.GetActionCards();
			foreach (ActionCards.ABase actionCard in actionCards)
			{
				if (actionCard == null) continue;
				tmpMaxHp += actionCard.MaxHp;
				tmpAtk += actionCard.Atk;
				tmpDef += actionCard.Def;
				tmpSpirit += actionCard.Spirit;
				tmpAgi += actionCard.Agi;
			}
            
            
			this.param.maxhp = this.param.maxhp + tmpMaxHp;
			this.param.atk = this.param.str + tmpAtk;
			this.param.def = this.param.vit + tmpDef;
			this.param.spirit = this.param.spirit + tmpSpirit;
			this.param.agi = this.param.agi + tmpAgi;

			// TODO 構造が気に入らないから直すかも
			Game game = Game.instance;;
			EnemyStatusWindow enemyStatusWindow = World.instance.GetEnemyStatusWindow();
			EnemyStatusWindow localEnemyStatusWindow = enemyStatusWindow.gameObject.GetComponent<EnemyStatusWindow>();
			localEnemyStatusWindow.SyncEnemyStatusReceiver(this.param);
			
			// game.enemyManager.Sync();
			//		GameMainManager game = GameMainManager.instance;
			//
			//		game.playerManager.textAtk.text = param.atk.ToString();
			//		game.playerManager.textDef.text = param.def.ToString();
			//
			//		
			//		//ActionCardやUIのステータスとパラメータを一致させる
					// UIManager.instance.ShowActionCardArea(this);
			//		PlayerManager.instance.SyncUiStatusByPlayer(this);
			
		}

		public int Ext { get; set; }

	}
}
