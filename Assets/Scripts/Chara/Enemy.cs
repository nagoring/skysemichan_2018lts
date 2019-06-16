using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.Chara
{
	public class Enemy : MonoBehaviour, IChara
	{
		public CharaParameter param;
		public int Hp{get {return this.hp;}set{hp = value;}}
		public int MaxHp{get {return this.maxhp;}set{maxhp = value;}}
		public int Mp{get {return this.mp;}set{mp = value;}}
		public int MaxMp{get {return this.maxmp;}set{maxmp = value;}}
		public int Atk{get {return this.atk;}set{atk = value;}}
		public int Def{get {return this.def;}set{def = value;}}
		public int Agi { get; set; }
		public int Spirit { get { return this.spirit; } set { spirit = value; } }
		public int MaxSpirit { get { return this.maxspirit; } set { maxspirit = value; } }
		public EChara Id{get {return this.id;}set{id = value;}}
		public string CharaName{get {return this.enemyName;}set{enemyName = value;}}
	
		public string enemyName;
		public int maxhp;
		public int maxmp;
		public int hp;
		public int mp;
		public int atk;
		public int def;
		public int spirit = 0;
		public int maxspirit = 10;
		public string msg;
		public List<string> msgDamageAfterList;
		public int exp;
		public EChara id;
	
		public GameObject buttonEnemyLayer;
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
		public void display() {
			buttonEnemyLayer.SetActive(true);
			Sprite sprite = buttonEnemyLayer.GetComponent<Sprite>();
			sprite = imageEnemeies[0];
		}
		
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
	
		public void PlayActionAnimation()
		{
//			GameMainManager game = GameMainManager.instance; 
//			StartCoroutine(game.effectManager.attackAnimationNormalByEnemy());
		}
	
		public virtual void PlayActionSound()
		{
//			GameMainManager game = GameMainManager.instance;
//			SoundManager.instance.PlaySingleRepeat(game.clipEnemyAtk1, 1, 0.3f);
		}
	
		public float GetWaitTimeByAnimation()
		{
			return 0.2f;
		}
	
		public void Act(IChara target)
		{
//			GameMainManager game = GameMainManager.instance;
//			if (eBattleAction == EBattleAction.ATK)
//			{
//				int damage = CalcDamage(target);
//				target.Hp -= damage;
//				game.playerManager.textHp.text = target.Hp.ToString();
//				
//				//ナビゲーションメッセージ
//				Text navText = game.uiManager.btnNavigationWindow.GetComponentInChildren<Text>();
//				navText.color = new Color(0, 0, 0);
//				navText.text = string.Format("{0}は{1}のダメージをうけた", target.CharaName, damage);
//			}
			
		}
	
		public void SayDamageAfterMsg()
		{
//			GameMainManager game = GameMainManager.instance;
//			game.enemyManager.SayDamageAfterMsg(this);
		}
	
		private int CalcDamage(IChara target)
		{
			int damage = atk - target.Def;
			damage += (int)Random.Range(-3.0f, 3.0f);
			if (damage < 0) damage = 0;
			return damage;
		}
		public float BeforeActStartWait()
		{
			return 0;
		}
		public void BeforeActStartMsg(IChara target)
		{
		}
		public void SayAtkAfter(IChara target){}
		
	}
}
