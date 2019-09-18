using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Scenes.WorldObject
{
	public class BattleManager : MonoBehaviour
	{
		public static BattleManager instance = null;
		private World _world = World.instance;
		private Game game = Game.instance;
		private Enemy enemy;
		private List<IChara> charaActOrderList;

		private EBattleStatus eBattleStatus;

		// Use this for initialization
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else if (instance != this)
			{
				Destroy(gameObject);
			}

			eBattleStatus = EBattleStatus.IDLE;
		}

		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void PushBtnProgressBattle()
		{
			if (game == null) game = Game.instance;
			if (eBattleStatus == EBattleStatus.IDLE)
			{
				/////////////
				/// たまにステータスウィンドウが消えるバグがあるからその対処
//				game.enemyManager.imageEnemeyStatusWindow.SetActive(true);
				/////////////
//				PlayerManager.instance.SyncUpdationParameter();
				eBattleStatus = EBattleStatus.ACTIVE;
				Debug.Log(game);
				Debug.Log(game.enemyManager);
				enemy = game.enemyManager.GetEnemy();
				//行動順番を決める
				OrderAttackTurn();
				BattleFlow(0);
			}
		}

		private void BattleFlow(int currentChara)
		{
			//順番にもとづいて行動する。
			int charaListCount = charaActOrderList.Count;
			IChara chara = charaActOrderList[currentChara];
			float beforeActStartWait = chara.BeforeActStartWait();
			//攻撃する人とされる人を決める。
			IChara target = chara.GetTarget(charaActOrderList);
			if (target == null)
			{
				//ここに来たらバグ
				//例外でも投げる？？
				//逃げると同じ扱いにする。
				BattleEndForEscape();
				return;
			}

			chara.BeforeActStartMsg(target);
			StartCoroutine(this.DelayMethod(beforeActStartWait, () =>
			{
				//戦闘方法のセット
				chara.SetBattleAction(target);
				//行動アニメーション
				chara.PlayActionAnimation();
				//行動効果音
				chara.PlayActionSound();

				//アニメーションの待ち時間
				float wait = chara.GetWaitTimeByAnimation();
				StartCoroutine(this.DelayMethod(wait, () =>
				{
					//行動による結果
					chara.Act(target);

					StartCoroutine(this.DelayMethod(0.3f, () =>
					{
						switch (GetEndBattleStatus(target))
						{
							//Player側の勝利時
							case EBattleEndStatus.WINNER:
								BattleEndForWinner(target);
								return;
							//Player側の敗北時
							case EBattleEndStatus.LOSER:
								BattleEndForLoser();
								return;
						}

						//targetのナビゲーションメッセージ
						target.SayDamageAfterMsg();
						//攻撃したキャラクターのメッセージ
						chara.SayAtkAfter(target);
						//次のターンへ
						currentChara++;
						//すべてのキャラが終わったら現在のバトルターン終了
						if (currentChara >= charaListCount)
						{
							eBattleStatus = EBattleStatus.IDLE;
							return;
						}

						StartCoroutine(this.DelayMethod(0.5f, () => { BattleFlow(currentChara); }));

					}));
				}));
			}));
			//次のターンに移動するには敵をタッチ
		}

		/// <summary>
		/// 勝利処理
		/// </summary>
		/// <param name="target"></param>
		void BattleEndForWinner(IChara target)
		{
//			game.skysemiChanMsg.msgBattleWinner[target.Id](this);
//			game.eventManager.DoBattleEndEvent();
			eBattleStatus = EBattleStatus.IDLE;
		}

		/// <summary>
		/// 戦闘に敗北
		/// </summary>
		void BattleEndForLoser()
		{
			_world.WorldMode = EWorldMode.WALKING;
//			SoundManager.instance.PlaySingle(game.clipLoser);
//			//スカゼミちゃんメッセージ
//			game.skysemiChanMsg.msgOther[EMsgOther.BattleLoser]();
//			StartCoroutine(this.DelayMethod(4.2f, () => { game.eventManager.DoBattleEndEventForLoser(); }));

		}

		/// <summary>
		/// 戦闘から逃げる
		/// </summary>
		public void BattleEndForEscape()
		{
			_world.WorldMode = EWorldMode.WALKING;
//			SoundManager.instance.PlaySingle(game.clipEscape);
//			game.skysemiChanMsg.msgOther[EMsgOther.BattleEscape]();
//			StartCoroutine(this.DelayMethod(0.5f, () =>
//			{
				eBattleStatus = EBattleStatus.IDLE;
//				game.eventManager.DoBattleEndEventForEscape();
//			}));
		}


		EBattleEndStatus GetEndBattleStatus(IChara target)
		{
			if (target.GetCharaType() == ECharaType.ENEMY)
			{
				if (target.Hp <= 0)
				{
					return EBattleEndStatus.WINNER;
				}
			}
			else if (target.GetCharaType() == ECharaType.PLAYER)
			{
				if (target.Hp <= 0)
				{
					return EBattleEndStatus.LOSER;
				}
			}

			return EBattleEndStatus.NONE;
		}

		//
		/// <summary>
		/// ターン制。１ターンの最初に呼ばれる。MPの高い順に行動する
		/// </summary>
		private void OrderAttackTurn()
		{
//			SkysemiChan skysemiChan = game.skysemiChanManager.skysemiChan;
//			charaActOrderList = new List<IChara>();
//			charaActOrderList.Add(Player.instance);
//			charaActOrderList.Add(enemy);
//			charaActOrderList.Add(skysemiChan);
//			charaActOrderList.Sort((a, b) => b.Mp - a.Mp);
		}

		public void PushBtnEscape()
		{
			if (_world.WorldMode != EWorldMode.BATTLE) return;
			if (eBattleStatus != EBattleStatus.IDLE) return;
//			//戦闘中だったら逃げ出す
			eBattleStatus = EBattleStatus.ESCAPE;
//			//boss戦だったら拠点に帰る
//			if (game.isBoss)
//			{
//				_world.WorldMode = EWorldMode.WALKING;
//				SoundManager.instance.PlaySingle(game.clipEscape);
//				game.skysemiChanMsg.msgOther[EMsgOther.BossEscape]();
//				StartCoroutine(this.DelayMethod(2.0f, () =>
//				{
//					//シーン切り替え
//					eBattleStatus = EBattleStatus.IDLE;
//
//					game.GoHomeForLoser();
//				}));
//			}
//			else
//			{
//				//通常はフィールドに戻る
//				BattleEndForEscape();
//			}
		}
//	private void ToTarget(IChara actionChara, IChara targetChara)
//	{
//		//行動アニメーション
//		actionChara.PlayActionAnimation();
//		//行動効果音
//		actionChara.PlayActionSound();
//		
//		//アニメーションの待ち時間
//		float wait = actionChara.GetWaitTimeByAnimation();
//		StartCoroutine(this.DelayMethod(wait, () =>
//		{
//			//行動による結果
//			actionChara.Act(targetChara);
//
//			StartCoroutine(this.DelayMethod(0.8f, () =>
//			{
//			}));
//
//		}));
//	}
	
//	private void TurnPlayer() {
//		Player player = Player.instance;
//		Enemy enemy = game.enemyManager.enemy;
//		//攻撃アニメーション
//		StartCoroutine(game.effectManager.attackPunchAnimation());
//		SoundManager.instance.PlaySingleRepeat(game.clipPanch, 3, 0.3f);
//
//		//0.3秒後に実行する
//		StartCoroutine(this.DelayMethod(0.3f, () =>
//		{
//			//ダメージ処理
//			int damage = AttackPlayerToEnemy(player, enemy);
//			enemy.hp -= damage;
//			game.enemyManager.hp.text = enemy.hp.ToString();
//
//			//ナビゲーションメッセージ
//			Text navText = game.uiManager.btnNavigationWindow.GetComponentInChildren<Text>();
//			navText.color = new Color(0, 0, 0);
//			navText.text = string.Format("{0}は{1}のダメージをうけた", enemy.enemyName, damage);
//
//			StartCoroutine(this.DelayMethod(0.8f, () =>
//			{
//				//敵の死亡判定
//				if (IsDeadEnemy(enemy))
//				{
//					//戦闘終了へ
//					game.eventManager.DoBattleEndEvent();
//					return;
//				}
//				//敵のメッセージ
//				game.enemyManager.sayDamageAfterMsg(enemy);
//				//敵のターンへ
//				game.turn = ETurn.ENEMY;
//				StartCoroutine(this.DelayMethod(0.5f, () =>
//				{
//					TurnEnemy();
//				}));
//			}));
//		}));
//	}
//	private int AttackPlayerToEnemy(Player player, Enemy enemy) {
//		int damage = player.atk - enemy.def;
//		damage += (int)Random.Range(-3.0f, 3.0f);
//		if (damage < 0) damage = 0;
//		return damage;
//	}
//	private bool IsDeadEnemy(Enemy enemy) {
//		return enemy.hp <= 0;
//	}

//	private void TurnEnemy() {
//		Player player = Player.instance;
//		
//		Enemy enemy = game.enemyManager.enemy;
//		//攻撃アニメーション
//		StartCoroutine(game.effectManager.attackAnimationNormalByEnemy());
//		//0.3秒後に実行する
//		StartCoroutine(this.DelayMethod(0.3f, () =>
//		{
//			//ダメージ処理
//			int damage = AttackEnemyToPlayer(enemy, player);
//			player.hp -= damage;
//			game.playerManager.textHp.text = player.hp.ToString();
//
//			//ナビゲーションメッセージ
//			Text navText = game.uiManager.btnNavigationWindow.GetComponentInChildren<Text>();
//			navText.color = new Color(0, 0, 0);
//			navText.text = string.Format("{0}は{1}のダメージをうけた", player.playerName, damage);
//
//			//プレイヤーの死亡判定
//			if (IsDeadPlayer(player))
//			{
//				//戦闘終了へ
//				//スカゼミちゃんメッセージ
//				//ナビゲーションメッセージ
//				return;
//			}
//			////スカゼミちゃんのターンへ
//			game.turn = ETurn.SKYSEMICHAN;
//			TurnSkysemiChan();
//		}));
//
//	}
//	private int AttackEnemyToPlayer(Enemy enemy, Player player) {
//		int damage = enemy.atk - player.def;
//		damage += (int)Random.Range(-3.0f, 3.0f);
//		if (damage < 0) damage = 0;
//		return damage;
//	}
//	private bool IsDeadPlayer(Player player) {
//		return player.hp <= 0;
//	}
//
//	private void TurnSkysemiChan() {
//		Player player = Player.instance;
//		Enemy enemy = game.enemyManager.enemy;
//		SkysemiChan skysemiChan = game.skysemiChanManager.skysemiChan;
//		//スカゼミちゃんのメッセージ
//		game.skysemiChanMsg.msgAttakDict[enemy.Id]();
//		//0.3秒後に実行する
//		StartCoroutine(this.DelayMethod(0.5f, () => {
//			//攻撃アニメーション
//			StartCoroutine(game.effectManager.attackPunchAnimation());
//			SoundManager.instance.PlaySingleRepeat(game.clipPanch, 3, 0.2f);
//			
//			StartCoroutine(this.DelayMethod(0.3f, () => {
//				//ダメージ処理
//				int damage = AttackSkysemiChanToEnemy(skysemiChan, enemy);
//				enemy.hp -= damage;
//				game.enemyManager.hp.text = enemy.hp.ToString();
//
//				//ナビゲーションメッセージ
//				Text navText = game.uiManager.btnNavigationWindow.GetComponentInChildren<Text>();
//				navText.color = new Color(0, 0, 0);
//				navText.text = string.Format("{0}は{1}のダメージをうけた", enemy.enemyName, damage);
//				game.skysemiChanMsg.msgAttakEndDict[enemy.Id]();
//
//				StartCoroutine(this.DelayMethod(0.8f, () =>
//				{
//					GameMainManager _game = GameMainManager.instance;
//					Enemy _enemy = _game.enemyManager.enemy;
//					//敵の死亡判定
//					if (IsDeadEnemy(_enemy))
//					{
//						//スカゼミちゃんメッセージ
//						_game.skysemiChanMsg.msgBattleWinner[_enemy.Id](this);
//						//戦闘終了へ
//						_game.eventManager.DoBattleEndEvent();
//						return;
//					}
//					_game.skysemiChanMsg.msgPlayerTurnInBattle[_enemy.Id](this);
//					//敵が生きていればプレイヤーのターンへ
//					_game.turn = ETurn.PLAYER;
//				}));
//			}));
//		}));
//	}
//	private int AttackSkysemiChanToEnemy(SkysemiChan skysemiChan, Enemy enemy) {
//		//ダメージ処理
//		int damage = skysemiChan.atk - enemy.def;
//		damage += (int)Random.Range(0.0f, 6.0f);
//		if(damage < 0)damage = 0;
//		return damage;
//	}
	}
}

