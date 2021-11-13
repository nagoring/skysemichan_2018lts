using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Events;
using UnityEngine;
using UnityEngine.UI;

namespace StatusUI
{
	public class PlayerStatusWindow : AppMonoBehaviour
	{
		private static PlayerStatusWindow _playerStatusWindow = null;
		private const string PrefabPath = "Prefabs/StatusUI/PlayerStatusWindow";
		public Text Lv { get; set; }
		public Text Hp { get; set; }
		public Text Spirit { get; set; }
		public Text Atk { get; set; }
		public Text Def { get; set; }
		public Text Agi { get; set; }
		public Text Progress { get; set; }
		public Text Exp { get; set; }
		public Text MaxHp { get; set; }
		public Text MaxSpirit { get; set; }


		public static PlayerStatusWindow CreatePlayerStatusWindowInCanvasUI(Canvas canvasUI)
		{
			if (_playerStatusWindow == null)
			{
				GameObject obj = (GameObject) Resources.Load(PrefabPath);
				obj.SetActive(true);
				GameObject instance = (GameObject) Instantiate(obj, Vector2.zero, Quaternion.identity);
				instance.transform.SetParent(canvasUI.transform);
				// instance.transform.parent = canvasUI.transform;
				instance.transform.localScale = new Vector3(1, 1, 1);
				instance.transform.localPosition = new Vector3(399, -60, 0);
				PlayerStatusWindow playerStatusWindow = instance.GetComponent<PlayerStatusWindow>();
				playerStatusWindow.Init();
				_playerStatusWindow = playerStatusWindow;
			}

			return _playerStatusWindow;
		}

		public void Init()
		{
			Lv = transform.Find("Lv").GetComponent<Text>();
			Hp = transform.Find("Hp").GetComponent<Text>();
			Spirit = transform.Find("Spirit").GetComponent<Text>();
			Atk = transform.Find("Atk").GetComponent<Text>();
			Def = transform.Find("Def").GetComponent<Text>();
			Agi = transform.Find("Agi").GetComponent<Text>();
			Progress = transform.Find("Progress").GetComponent<Text>();
			Exp = transform.Find("Exp").GetComponent<Text>();
			MaxHp = transform.Find("MaxHp").GetComponent<Text>();
			MaxSpirit = transform.Find("MaxSpirit").GetComponent<Text>();
		}


		public void SyncPlayerStatusReceiver(CharaParameter param)
		{
			Lv.text = param.lv.ToString();
			Hp.text = param.hp.ToString();
			Spirit.text = param.spirit.ToString();
			Atk.text = param.atk.ToString();
			Def.text = param.def.ToString();
			Agi.text = param.agi.ToString();
			MaxHp.text = (param.maxhp + param.tmpMaxHp).ToString();
			MaxSpirit.text = param.maxspirit.ToString();
			Progress.text = param.progress.ToString();
			Exp.text = param.exp.ToString();
		}
	}
}