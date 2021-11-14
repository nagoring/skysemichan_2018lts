using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Scenes.WorldObject;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// delegate void ShowMessage();
public class ShizuneMsg : MonoBehaviour
{
	public static ShizuneMsg instance;
	private Game game;
    public Text msg;
	public delegate void callbackBattleEndEventParam(BattleEndEventParam param);
	public delegate void callbackAttackDict();
	public delegate void callbackBattleManager(BattleManager battleManager);
	public delegate void callbackMsg();
	public delegate void callbackHomeMsg(int counter);
	
	
	
	public Dictionary<EChara, callbackBattleEndEventParam> msgEncountEndDict = new Dictionary<EChara, callbackBattleEndEventParam>();
	public Dictionary<EChara, callbackAttackDict> msgAttakDict = new Dictionary<EChara, callbackAttackDict>();
	public Dictionary<EChara, callbackAttackDict> msgAttakEndDict = new Dictionary<EChara, callbackAttackDict>();
	public Dictionary<EChara, callbackBattleManager> msgPlayerTurnInBattle = new Dictionary<EChara, callbackBattleManager>();
	public Dictionary<EChara, callbackBattleManager> msgBattleWinner = new Dictionary<EChara, callbackBattleManager>();
	public Dictionary<EMsgOther, callbackMsg> msgOther = new Dictionary<EMsgOther, callbackMsg>();
	public Dictionary<EMsgHome, callbackHomeMsg> msgHome = new Dictionary<EMsgHome, callbackHomeMsg>();

	private string[] homeMsgTbl;
	private string[] homeMsgTblShowStage2;
	private string[] homeMsgTblShowStage3;
	private string[] homeMsgTblShowStage4;
	private string[] homeMsgTblShowOtherStage1;
	
	

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

	void Start ()
	{
		// Debug.Log(msg);
		
		game = Game.instance;
		homeMsgTbl = new string[]
		{
			"お外に出たら左下のアクションコマンド枠をちゃんと設定してくださいね。ドラッグアンドドロップでアイコンを置くことができるから。",
			string.Format("{0}さん\nここには色々な食べ物があります。\nみんな食べたがり屋なので優しく食べてあげてくださいね♪", game.GetPlayer().CharaName),
			"LVがアップするとアクションコマンドを使える枠が増えていきます。\n最大４つまで増えるので楽しみですね",
			"この世界で人間は見たことないですけど面白いものでいっぱいです。",
			"敵から食らったダメージは歩いていくとHPが自然と回復していくので安心です。",
			"敵が現れたらタップして攻撃しましょう。",
		};
		homeMsgTblShowStage2 = new string[]
		{
			"次はスイカ畑に行ってみましょうか。お散歩コースより強い敵が出ますが、アクションコマンドをしっかり設定すれば勝てます。",
			"この世界は目を見ただけで相手の名前が分かります。真名ではなくて最も親しまれている名前が頭によぎるのです",
			"ここに来る前の記憶は私も貴方も持っていません。でもそんなのは関係ないですよね。生活する分には何にも困らない世界ですから",
			"スイカって野菜なんですよねぇ。土から生まれるものは野菜。それならメロンも野菜かな？",
			"戦闘でHPが低いときは防御重視にして下さい。代わりに私が頑張りますから♪",
			"敵が現れたらタップして攻撃しましょう。アクションコマンドを敵に応じて変えていくと良いですよ",
			"進行が１００になったらそのエリアのボスが現れます。強いですが二人なら勝てないことはないです。",
			"MAXHPを一時的に増やすアクションコマンドがあります\n体力がMAXのときに装備して使いましょう",
		};
		homeMsgTblShowStage3 = new string[]
		{
			"次は私が通れなかったところに行ってみてもいいですか？ロボットがいて強くて通れないんです。",
			"食べられた野菜は死ぬわけじゃありません。すぐに転生して次の野菜になります。記憶も残ってるので顔を覚えてくれてるかもしれませんね。",
			"野菜より果物のほうが強い傾向がありますね。でも加工食品はもっと強いんですよ。",
			"野菜達は縄張り意識もあります。野菜同士で抗争することもあるんですよ。",
			"ボスの手前で現れたザコが強かったら\n逃げるのも一つの手です",
//			"本当に危ないときは逃げるのも一つの手です。",
			string.Format("私も{0}さんに負けないくらい強くなりますよ\n協力が大事ですからね★", game.GetPlayer().CharaName),
			string.Format("次は私がメインで攻撃します\n{0}さんは守りに集中してくださいね", game.GetPlayer().CharaName),
		};
		homeMsgTblShowStage4 = new string[]
		{
			"この世界は食べるモノと食べられるモノの二種類います。\n私達は食べるモノに属しますね。",
			"食べるモノは食べられるモノを食べないと行けません。\n食べるモノが食べるモノを食べるのは禁忌とされています。\nそれがルールです。",
			"人の言葉を話せる野菜、果物等は食べられるモノに属します。\n見分け方として人の言葉を話せる野菜、果物等は食べられるモノです。",
			"野菜、果物以外に動物もいますがルールは同じです。\n人の言葉を話せない動物は食べては行けません。",
			"MPが高いほど攻撃する順番が早く回ってきます。",
		};
		homeMsgTblShowOtherStage1 = new string[]
		{
			"食べ物が何もありませんね・・・・・・",
			"もっと先に進む必要がありそうです。",
			"一休みしたいところですが食料を確保するまでは休めませんね。",
			"禁忌覚えていますか？\n食べるモノと食べられるモノ\nそのルール\n絶対に破っちゃいけませんよ。",
			"食べるモノが食べるモノを食べる\nそれは禁忌。\n破れば外道になってしまいます。",
			"外道とは不死の壊れた生命体です\n知能は低くて醜い不快なモノです",
			"さあ、もう行きましょう",
		};

		foreach (EChara chara in System.Enum.GetValues(typeof(EChara)))
		{
			if (chara == EChara.SkysemiChan) continue;
			if (chara == EChara.Player) continue;
			msgEncountEndDict.Add(chara, this.SayEncountEndNasuAfter);
			msgAttakDict.Add(chara, this.SayAttackStandart);
			msgAttakEndDict.Add(chara, this.SayAttackEndStandart);
			msgPlayerTurnInBattle.Add(chara, this.SayPlayerTurnInBattle);
			msgBattleWinner.Add(chara, this.SayBattleWinner);
		}

		/// 重機用セリフ
		msgAttakDict[EChara.CableReel] = SayAttackHeavyEquipment;
		msgAttakDict[EChara.CameraStabilizer] = SayAttackHeavyEquipment;
		msgAttakDict[EChara.PowerShovel] = SayAttackHeavyEquipment;
		
		msgAttakEndDict[EChara.CableReel] = SayAttackEndHeavyEquipment;
		msgAttakEndDict[EChara.CameraStabilizer] = SayAttackEndHeavyEquipment;
		msgAttakEndDict[EChara.PowerShovel] = SayAttackEndHeavyEquipment;
		
		//にわとり用セリフ
		msgAttakDict[EChara.Niwatori] = SayAttackNiwatori;
		
//		msgEncountEndDict.Add(EChara.Nasu, this.SayEncountEndNasuAfter);
//		msgAttakDict.Add(EChara.Nasu, this.SayAttackStandart);
//		msgAttakEndDict.Add(EChara.Nasu, this.SayAttackEndStandart);
//		msgPlayerTurnInBattle.Add(EChara.Nasu, this.SayPlayerTurnInBattle);
//		msgBattleWinner.Add(EChara.Nasu, this.SayBattleWinner);
//		
		
		//ブレードロボと対峙した場合のセリフは特殊セリフなので上書き
		msgEncountEndDict[EChara.BladeRobo] =  (BattleEndEventParam param)=>{
			msg = GetComponentInChildren<Text>();
			msg.text = string.Format("あのブレード欲しいですね。エネルギー源はどうなっているんでしょうか？\n{0}さん分かりますか？", game.GetPlayer().CharaName);
		};
	
		msgAttakDict[EChara.BladeRobo] = this.SayAttackStandartNotFood;
		msgAttakEndDict[EChara.BladeRobo] = () => {
			int cnt = Random.Range(0,2);
			msg = GetComponentInChildren<Text>();
			switch (cnt)
			{
				case 0:
					msg.text = string.Format("なかなか硬いですね。");
					break;
				case 1:
					msg.text = string.Format("食べ物じゃないとテンション下がりますね");
					break;
				case 2:
					msg.text = string.Format("細い割に硬いです");
					break;
			}
		};
		
		msgPlayerTurnInBattle[EChara.BladeRobo] = this.SayPlayerTurnInBattle;
		msgBattleWinner[EChara.BladeRobo] = this.SayBattleWinner;

		//////////////////////////////
		
		msgOther.Add(EMsgOther.LVUP, this.SayLvUp);
		msgOther.Add(EMsgOther.BattleLoser, this.SayBattleLoser);
		msgOther.Add(EMsgOther.BattleEscape, this.SayBattleEscape);
		msgOther.Add(EMsgOther.BossRingo, this.SayBossRingo);
		msgOther.Add(EMsgOther.WalkingAreaClear, this.SayWalkingAreaClear);
		msgOther.Add(EMsgOther.Stage4AreaClear, this.SayStage4AreaClear);
		
		msgOther.Add(EMsgOther.BossEscape, this.SayBossEscape);
		msgOther.Add(EMsgOther.PushItem, () =>
		{
			msg = GetComponentInChildren<Text>();
			msg.text = string.Format("ごめんなさい、未実装なんです\n回復アイテムくらいは欲しかったですね");
		});
		msgOther.Add(EMsgOther.PushHome, () =>
		{
			msg = GetComponentInChildren<Text>();
			msg.text = string.Format("ごめんなさい、未実装なんです\nこのボタンで詳細なステータスや設定が出来たりする予定だったんです");
		});
//		msgLvUp.Add(2, string.Format("2回目のLVUPですね！{0}さん逞しいです", game.GetPlayer().CharaName));

		msgHome.Add(EMsgHome.First, SayHomeMsgFirst);
		msgHome.Add(EMsgHome.Second, SayHomeMsgSecond);
		
		msg = GetComponentInChildren<Text>();
		if (msg == null) return;
		
//		msg.text = String.Format("こんにちは{0}さん。\n私はみんなからスカゼミちゃんと呼ばれています。\nなので貴方もスカゼミちゃんと気軽に呼んでくださいね", game.GetPlayer().CharaName);
		
		int gameProgress = PlayerPrefs.GetInt("GameProgress");
		if (gameProgress >= (int) EGameProgress.SHOW_OTHER_STAGE_1)
		{
			msg.text = String.Format("{0}さん。\nもう夕暮れですね・・・\n", game.GetPlayer().CharaName);
		}
		else if (gameProgress == (int) EGameProgress.SHOW_STAGE_2)
		{
			msg.text = String.Format("{0}さん。\n美味しいりんごでしたね。\n", game.GetPlayer().CharaName);
		}
		else if (gameProgress == (int) EGameProgress.SHOW_STAGE_3)
		{
			msg.text = String.Format("{0}さん。\n美味しいスイカでしたね。\n", game.GetPlayer().CharaName);
		}
		else if (gameProgress == (int) EGameProgress.SHOW_STAGE_4)
		{
//			"金属の守護者を倒して外の道にいけるようになりました。\nでも怖いならここに留まっても良いんですよ。外の道はきっと危険ですから。",
			msg.text = String.Format("金属の守護者を倒して外の道にいけるようになりました\nでも無理して行かなくても良いんですよ\nこのエリアで引き篭もってるのも悪くない生活ですから");
		}
		
		else
		{
			msg.text = String.Format("{0}さん。\n今日はいい天気ですね。\n良い野菜が取れそうです。季節の野菜は美味しいですから。\n", game.GetPlayer().CharaName);
		}

	}
	
	// Update is called once per frame
	void Update () {
	}
	public void EnemyCommentary(WayEventParam param) {
		if (param.enemy == null) return;
		msg = GetComponent<Text>();
		switch (param.enemy.CharaName)
		{
			case "ナス": 
				// msg.text = string.Format("あいつは{0}です！\n弱いので安心して倒しましょう",param.enemy.CharaName);
				msg.text = $"あいつは{param.enemy.CharaName}です！\n弱いので安心して倒しましょう";
					break;
			case "きゅうり": 
				msg.text = $"あいつは{param.enemy.CharaName}です！\nちょっと攻撃力がありますが代わりに防御力が疎かです。ガンガン叩いてやりましょう！！";
				break;
			case "りんご": 
				msg.text = $"あいつは{param.enemy.CharaName}です！\nバランスのとれた強さです。\n医者殺しとも呼ばれていますね♪";
				break;
			case "ダイコン": 
				msg.text = $"あいつは{param.enemy.CharaName}です！\n見た目弱そうですがナスやきゅうりより一枚上手です。\n大根おろしにすると消化に良いんですよ。";
				break;
			case "ブロッコリー": 
				msg.text = $"見た目が怪物ですが{param.enemy.CharaName}です。\nこのエリアではかなり強いですが貴重な食材なので\nゆでブロッコリーにして食べちゃいましょう！";
				break;
			case "スイカ": 
				msg.text = $"この畑の主「{param.enemy.CharaName}」です！\n夏にはかかせませんよね！\n{game.GetPlayer().CharaName}さんは塩かける派ですか？";
				break;
			case "ほうれんそう": 
				msg.text = $"あいつはβカロテン豊富な\n「{param.enemy.CharaName}」です！\n鉄分も侮れません！";
				break;
			case "トマト": 
				msg.text = $"あいつは利便性の多い食材「{param.enemy.CharaName}」です！\n赤いのは抗酸化作用の強いリコピンの成分があるからです！";
				break;
			case "ブレードロボ": 
				msg.text = "あいつがブレードロボです！\nあのブレードを食らったら凄いダメージ食らっちゃいます！\n私は攻撃を頑張ります。";
				break;
			case "電工ドラム":
				msg.text = "あいつは電工ドラムです！\n野菜でないので食べれませんが倒しましょう。";
				break;
			case "カメラスタビライザー":
				msg.text = "あいつはカメラスタビライザーです！\n私達より素早く動くので対策しましょう。";
				break;
			case "パワーショベル":
				msg.text = "あいつはパワーショベルです！\n強敵です。\n私の攻撃ではたいしたダメージを与えられなそうです。";
				break;
			case "ドロドロナ不快ナモノ":
				msg.text = "あいつはドロドロです\n倒してあげましょう。";
				break;
			case "にわとり":
				msg.text = "あいつはにわとりです\n私達と同じ食べるモノに属しています";
				break;
			default: 
				msg.text = $"あいつは{param.enemy.CharaName}です！\nどんな風に行動してくるんでしょうかね？";
				break;
		}
	}
	public void BattleEnd(BattleEndEventParam param) {
		EChara id = param.enemy.Id;
		callbackBattleEndEventParam cb = msgEncountEndDict[id];
		cb(param);
		SayBattleWinner();
	}
	public void SayEncountEndNasuAfter(BattleEndEventParam param) {
		msg = GetComponentInChildren<Text>();
		// msg.text = $"楽勝でしたね！これで{param.ICharaEnemy.CharaName}が手に入りました♪";
		msg.text = $"楽勝でしたね！";
	}
	public void SayAttackStandart() {
		msg = GetComponentInChildren<Text>();
		Debug.Log(msg);
		int cnt = Random.Range(0,2);
		switch (cnt)
		{
			case 0:
				msg.text = string.Format("私の攻撃ですね！エイっ！！");
				break;
			case 1:
				msg.text = string.Format("これでもくらいなさい！！");
				break;
			case 2:
				msg.text = string.Format("ちゃんと食べてあげるからね！エーイ！");
				break;
		}
	}
	public void SayAttackStandartNotFood() {
		msg = GetComponentInChildren<Text>();
		int cnt = Random.Range(0,2);
		switch (cnt)
		{
			case 0:
				msg.text = string.Format("私の攻撃ですね！エイっ！！");
				break;
			case 1:
				msg.text = string.Format("これでもくらいなさい！！");
				break;
			case 2:
				msg.text = string.Format("ちゃんと加工してあげるからね！エーイ！");
				break;
		}
	}
	public void SayAttackNiwatori() {
		msg = GetComponentInChildren<Text>();
		int cnt = Random.Range(0,2);
		switch (cnt)
		{
			case 0:
				msg.text = string.Format("・・・エイっ！！");
				break;
			case 1:
				msg.text = string.Format("・・・ヤーっ！！");
				break;
			case 2:
				msg.text = string.Format("・・・うりゃ！！");
				break;
		}
	}
	public void SayAttackEndStandart()
	{
		int cnt = Random.Range(0,2);
		msg = GetComponentInChildren<Text>();
		switch (cnt)
		{
			case 0:
				msg.text = string.Format("なかなか硬いですね。");
				break;
			case 1:
				msg.text = string.Format("食べごろには遠いなぁ。{0}さん任せました。",game.GetPlayer().CharaName);
				break;
			case 2:
				msg.text = string.Format("こいつもなかなかやりますね");
				break;
			
		}
	}
	public void SayPlayerTurnInBattle(BattleManager battleManager)
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("{0}さんの番です。\n頑張って！！", game.GetPlayer().CharaName);
	}

	public void SayBattleWinner(BattleManager battleManager = null)
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("やったー！私達の勝利です★\n{0}さん次も一緒に頑張りましょう！", game.GetPlayer().CharaName);
	}

	public void SayLvUp()
	{
		string[] msgTbl = new string[]
		{
			"",
			$"おめでとうございます！！\n初めてのLVUPですね！{game.GetPlayer().CharaName}さんならもっともっと強くなりますよ",
			$"2回目のLVUPですね！{game.GetPlayer().CharaName}さん逞しいです",
		};
		int index = game.GetPlayer().Lv - 1;
		msg = GetComponentInChildren<Text>();

		if (msgTbl.Length <= index)
		{
			msg.text = string.Format("{0}さんも強くなりましたね♪", game.GetPlayer().CharaName);
		}
		else
		{
			msg.text = msgTbl[index];
		}
	}

	public void SayBattleLoser()
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("ああ！！{0}さんが大変なことに！\n一度拠点に戻りましょう。", game.GetPlayer().CharaName);
	}
	public void DelayMsgOther()
	{
		//スカゼミちゃんメッセージ
		// game.shizuneMsg.msgOther[EMsgOther.LVUP]();
		StartCoroutine(this.DelayMethod(1.5f, () =>
		{
			//スカゼミちゃんメッセージ
			// game.shizuneMsg.msgOther[EMsgOther.LVUP]();
			SayLvUp();
		}));
	}
	public void SayBattleEscape()
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("{0}さん!!\n逃げましょう！！", game.GetPlayer().CharaName);
	}
	public void SayBossRingo()
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("やったー！!このエリアのボスを倒しましたよ！！\n私と{0}さんの協力による賜物ですね♫", game.GetPlayer().CharaName);
	}

	public void SayWalkingAreaClear()
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("さあ、{0}さん。\n私達の拠点へ帰りましょう。", game.GetPlayer().CharaName);
	}
	public void SayStage4AreaClear()
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("さあ、{0}さん。\n先へ進みましょう。", game.GetPlayer().CharaName);
	}
	public void SayBossEscape()
	{
		msg = GetComponentInChildren<Text>();
		msg.text = string.Format("{0}さん！あいつは今の私達では危険です！\n大勢を立て直してまた再挑戦しましょう！！", game.GetPlayer().CharaName);
	}

	public void SayHomeMsgFirst(int counter = 0)
	{
		msg = GetComponentInChildren<Text>();
		if (game.gameProgress ==  EGameProgress.SHOW_STAGE_4)
		{
			int index = counter % homeMsgTblShowStage4.Length;
			msg.text = homeMsgTblShowStage4[index];
		}
		else if (game.gameProgress == EGameProgress.SHOW_STAGE_3)
		{
			int index = counter % homeMsgTblShowStage3.Length;
			msg.text = homeMsgTblShowStage3[index];
		}
		else if (game.gameProgress == EGameProgress.SHOW_STAGE_2)
		{
			int index = counter % homeMsgTblShowStage2.Length;
			msg.text = homeMsgTblShowStage2[index];
		}
		else
		{
			int index = counter % homeMsgTbl.Length;
			msg.text = homeMsgTbl[index];
		}
	}

	public void SayHomeMsgSecond(int counter = 0)
	{
		Game gs = game;
		msg = GetComponentInChildren<Text>();
		int index = counter % homeMsgTblShowOtherStage1.Length;
		msg.text = homeMsgTblShowOtherStage1[index];
//		if (gs.progress == (int) EGameProgress.SHOW_OTHER_STAGE_1)
//		{
//			int index = counter % homeMsgTblShowOtherStage1.Length;
//			msg.text = homeMsgTblShowOtherStage1[index];
//		}
//		else
//		{
//			int index = counter % homeMsgTbl.Length;
//			msg.text = homeMsgTbl[index];
//		}
		
	}
	
	/// <summary>
	///  重機系に対するセリフ
	/// </summary>
	public void SayAttackEndHeavyEquipment()
	{
		int cnt = Random.Range(0,2);
		msg = GetComponentInChildren<Text>();
		switch (cnt)
		{
			case 0:
				msg.text = string.Format("流石に鉄系は硬いですね。");
				break;
			case 1:
				msg.text = string.Format("壊れないですね。{0}さん任せました。",game.GetPlayer().CharaName);
				break;
			case 2:
				msg.text = string.Format("なかなか手ごわいですね");
				break;
			
		}
	}
	public void SayAttackHeavyEquipment() {
		msg = GetComponentInChildren<Text>();
		int cnt = Random.Range(0,2);
		switch (cnt)
		{
			case 0:
				msg.text = string.Format("硬そうだけどダメージ通るかな？エイっ！！");
				break;
			case 1:
				msg.text = string.Format("壊してあげる！！");
				break;
			case 2:
				msg.text = string.Format("ちゃんと壊してあげるからね！エーイ！");
				break;
		}
	}

	public void AreaClearMsg()
	{
		if (game.destinationPlace == EStage.OUTSIDE_ROAD)
		{
			game.shizuneMsg.msgOther[EMsgOther.Stage4AreaClear]();
		}
		else
		{
			game.shizuneMsg.msgOther[EMsgOther.WalkingAreaClear]();
		}

	}

}
