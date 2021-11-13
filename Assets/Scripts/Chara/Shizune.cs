using System.Collections;
using System.Collections.Generic;
using Skysemi.With.ActionCards;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.Chara
{
	public class Shizune : MonoBehaviour, IChara
	{
		public static Shizune instance;
		public Game game;
		public CharaParameter param;
		protected ActionCards.ABase[] _actionCard = new ActionCards.ABase[4];

		public string CharaName
		{
			get { return param.charaName; }
			set { param.charaName = value; }
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

		public EChara id = EChara.SkysemiChan;
		private EBattleAction eBattleAction;


		// public static Player instance;
		public string playerName;
		public int maxhp;
		public int maxmp;
		// public int atk;

		public int lv;

		//筋力
		public int str;

		//丈夫さ/生命力
		public int vit;

		void Awake() {
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

		public void Init()
		{
			MaxHp = 1000;
			Hp = MaxHp;
			Atk = 2;
			Def = 4;
		}
		


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
			return ECharaType.SKYSEMICHAN;
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
		}

		public float GetWaitTimeByAnimation()
		{
			return 0.3f;
		}

		public void Act(IChara target)
		{
			// Game game = Game.instance;
			//
			// if (eBattleAction == EBattleAction.ATK)
			// {
			//     int damage = CalcDamage(target);
			//     target.Hp -= damage;
			//     game.enemyManager.hp.text = target.Hp.ToString();
			//
			//     //ナビゲーションメッセージ
			//     Text navText = game.uiManager.btnNavigationWindow.GetComponentInChildren<Text>();
			//     navText.color = new Color(0, 0, 0);
			//     navText.text = string.Format("{0}は{1}のダメージをうけた", target.CharaName, damage);
			// }
		}

		private int CalcDamage(IChara target)
		{
//		int damage = atk - target.Def;
			int playerLv = game.player.Lv;
			int damage = 0;
			if (isWithDefChara(target))
			{
				damage = Atk + playerLv - target.Def;
			}
			else
			{
				damage = Atk + playerLv - (int) (target.Def / 5);
			}

			damage += (int) Random.Range(-2.0f, 2.0f + playerLv);
			if (damage < 0) damage = 0;
			return damage;
		}

		/// <summary>
		/// スカゼミちゃんのDef無視効果の無い敵かどうか判別
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		private bool isWithDefChara(IChara target)
		{
			switch (target.Id)
			{
				case EChara.CameraStabilizer:
				case EChara.PowerShovel:
				case EChara.CableReel:
				case EChara.DoroDoroHukai:
					return true;
			}

			return false;
		}

		public void SayDamageAfterMsg()
		{
		}

		public float BeforeActStartWait()
		{
			return 0.3f;
		}

		public void BeforeActStartMsg(IChara target)
		{
			Game game = Game.instance;

			game.shizuneMsg.msgAttakDict[target.Id]();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public void SayAtkAfter(IChara target)
		{
			Game game = Game.instance;
			game.shizuneMsg.msgAttakEndDict[target.Id]();
		}

		void Start()
		{
			game = Game.instance;
			Init();
		}

		void Update()
		{
		}

		public ABase GetActionCard(int index)
		{
			throw new System.NotImplementedException();
		}

		public ABase[] GetActionCards()
		{
			throw new System.NotImplementedException();
		}

		public float DamageRate(IChara target)
		{
			return DamageRating.Calc(target, this);
		}
	}
}