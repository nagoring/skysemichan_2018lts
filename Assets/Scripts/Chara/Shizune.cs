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
		public Game game;

		public int Hp
		{
			get { return this.hp; }
			set { hp = value; }
		}

		public int MaxHp
		{
			get { return this.maxhp; }
			set { maxhp = value; }
		}

		public int Mp
		{
			get { return this.mp; }
			set { mp = value; }
		}

		public int MaxMp
		{
			get { return this.maxmp; }
			set { maxmp = value; }
		}

		public int Atk
		{
			get { return this.atk; }
			set { atk = value; }
		}

		public int Def
		{
			get { return this.def; }
			set { def = value; }
		}

		public int Agi { get; set; }
		public int Spirit { get; set; }
		public int MaxSpirit { get; set; }
		public int Ext { get; set; }

		public EChara Id
		{
			get { return this.id; }
			set { id = value; }
		}

		public EChara id = EChara.SkysemiChan;
		private EBattleAction eBattleAction;

		public string CharaName
		{
			get { return this.playerName; }
			set { playerName = value; }
		}

		public static Player instance;
		public string playerName;
		public int maxhp;
		public int maxmp;
		public int hp;
		public int mp;
		public int atk;
		public int def;
		public int progress;
		public int exp;
		public int nextExp;

		public int lv;

		//筋力
		public int str;

		//丈夫さ/生命力
		public int vit;

		void Awake()
		{
			maxhp = 1000;
			hp = maxhp;
			maxmp = 8;
			mp = maxmp;
			atk = 2;
			def = 4;
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
				damage = atk + playerLv - target.Def;
			}
			else
			{
				damage = atk + playerLv - (int) (target.Def / 5);
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