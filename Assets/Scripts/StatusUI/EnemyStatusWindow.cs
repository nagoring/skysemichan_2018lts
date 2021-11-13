using Skysemi.With.Chara;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Events;
using UnityEngine;
using UnityEngine.UI;

namespace StatusUI
{
	public class EnemyStatusWindow : AppMonoBehaviour
	{
//        private const string PrefabPath = "Prefabs/StatusUI/EnemyStatusWindow";

		public Text Name { get; set; }
		public Text Hp { get; set; }
		public Text Spirit { get; set; }
		public Text Atk { get; set; }
		public Text Def { get; set; }
		public Text Agi { get; set; }


//        public static EnemyStatusWindow CreateEnemyStatusWindowInCanvasUI(Canvas canvasUI)
//        {
//            GameObject obj = (GameObject)Resources.Load (PrefabPath);
//            obj.SetActive(true);
//            // プレハブを元にCardBoardを生成して、CanvasUIの子供にする
//            GameObject instance = (GameObject)Instantiate(obj,Vector2.zero,Quaternion.identity);
//            instance.transform.parent = canvasUI.transform;
//            instance.transform.localScale = new Vector3(1,1,1);
//            instance.transform.localPosition = new Vector3(399,-70, 0);
//            EnemyStatusWindow enemyStatusWindow = instance.GetComponent<EnemyStatusWindow>();
//            enemyStatusWindow.Init();
//            return enemyStatusWindow;
//        }

		public void Init()
		{
			Name = transform.Find("TextEnemyName").GetComponent<Text>();
			Hp = transform.Find("TextEnemyHp").GetComponent<Text>();
			Spirit = transform.Find("TextEnemySpirit").GetComponent<Text>();
			Atk = transform.Find("TextEnemyAtk").GetComponent<Text>();
			Def = transform.Find("TextEnemyDef").GetComponent<Text>();
			Agi = transform.Find("TextEnemyAgi").GetComponent<Text>();
		}


		public void SyncEnemyStatusReceiver(Enemy enemy, CharaParameter _charaParameter)
		{
			int hp = _charaParameter.hp;
			int spirit = _charaParameter.spirit;
			int atk = _charaParameter.atk;
			int def = _charaParameter.def;
			int agi = _charaParameter.agi;

			// 既に_charaParameterにカード情報は反映されているためカードの加算はいらない

			// Skysemi.With.ActionCards.ABase[] actionCards = enemy.GetActionCards();
			// foreach (Skysemi.With.ActionCards.ABase card in actionCards)
			// {
			//     if (card == null) continue;
			//     hp += card.MaxHp;
			//     spirit += card.Spirit;
			//     atk += card.Atk;
			//     def += card.Def;
			//     agi += card.Agi;
			// }

			Name.text = _charaParameter.charaName;
			Hp.text = hp.ToString();
			Spirit.text = spirit.ToString();
			Atk.text = atk.ToString();
			Def.text = def.ToString();
			Agi.text = agi.ToString();
		}
	}
}