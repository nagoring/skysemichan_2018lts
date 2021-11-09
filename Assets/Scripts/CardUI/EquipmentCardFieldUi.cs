using System;
using Skysemi.With.Chara;
using Skysemi.With.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.CardUI
{
	/// <summary>
	/// Card欄のUIの作成
	/// 装備の管理
	/// 画像の切り替え
	/// </summary>
	public class EquipmentCardFieldUi : MonoBehaviour, IEquipmentCardFieldUi
	{
		private const string PrefabPath = "Prefabs/CardUI/EquipmentCardFieldUi";
		private readonly float[] _xTbl = {-300, -100, 100, 300};
		public int SelectedCardBoxIndex { get; set; }
		public GameObject SelectedGameObjectCardBox { get; set; }
		public Image SelectedIconImage { get; set; }

		private EquipmentCardBoxUi[] _equipmentCardBoxsUi;
		// private ActionCards.ABase[] _actionCard = new ActionCards.ABase[4];

		void Start()
		{
		}

		public static EquipmentCardFieldUi CreateEquipmentCardFieldInCanvas(Canvas canvasUi, float x = -240,
			float y = -300)
		{
			GameObject obj = (GameObject) Resources.Load(PrefabPath);
			obj.SetActive(true);
			// プレハブを元にEquipmentCardFieldを生成して、CanvasUIの子供にする
			GameObject instance = (GameObject) Instantiate(obj, Vector2.zero, Quaternion.identity);
			// instance.transform.parent = canvasUi.transform;
			instance.transform.SetParent(canvasUi.transform);
			instance.transform.localScale = new Vector3(1, 1, 1);
			instance.transform.localPosition = new Vector3(x, y, 0);
			return instance.GetComponent<EquipmentCardFieldUi>();
		}

		/// <summary>
		/// 空のボックスを生成する
		/// インデックス番号は1,2,3,4まで使用できる
		/// </summary>
		/// <param name="index">インデックス番号</param>        
		/// <param name="types">動的に使いするスクリプトの配列</param>        
		public void CreateEquipmentCardBox(int index, Type[] types = null)
		{
			string prefabFilePath = "Prefabs/CardUI/EquipmentCardBoxUi" + index;
			GameObject actionCardPrefab = (GameObject) Resources.Load(prefabFilePath);
			GameObject instance = (GameObject) Instantiate(actionCardPrefab, Vector2.zero, Quaternion.identity);
			instance.name = "EquipmentCardBoxUi" + index;
			// instance.transform.parent = transform;
			instance.transform.SetParent(transform);
			instance.transform.localScale = new Vector3(1, 1, 1);
			float x = _xTbl[index];
			instance.transform.localPosition = new Vector3(x, 0, 0);
			if (types != null)
			{
				for (int i = 0; i < types.Length; i++)
				{
					instance.AddComponent(types[i]);
				}
			}

			Type equipmentCardBoxType = Type.GetType("Skysemi.With.CardUI.EquipmentCardBoxUi");
			instance.AddComponent(equipmentCardBoxType);
			_equipmentCardBoxsUi[index] = instance.GetComponent<EquipmentCardBoxUi>();
		}

		public void Init()
		{
			Type[] types =
			{
				Type.GetType("Skysemi.With.CardUI.PlayerEquipmentCardBoxClickEvent"),
			};
			
			_equipmentCardBoxsUi = new EquipmentCardBoxUi[4];
			CreateEquipmentCardBox(0, types);
			CreateEquipmentCardBox(1, types);
			CreateEquipmentCardBox(2, types);
			CreateEquipmentCardBox(3, types);
			
			// _equipmentCardBoxsUi[1].gameObject.SetActive(false);
			// _equipmentCardBoxsUi[2].gameObject.SetActive(false);
			// _equipmentCardBoxsUi[3].gameObject.SetActive(false);
		}

		public void Equip(int index, ActionCards.ABase actionCard)
		{
			EquipmentCardBoxUi equipmentCardBoxUi = _equipmentCardBoxsUi[index];
			Game game = Game.instance;
			;
			// _actionCard[index] = actionCard;
			game.player.SetActionCard(index, actionCard);
			GameObject childGameObject = _equipmentCardBoxsUi[index].transform.Find("ImageInvisibleSprite").gameObject;
			Sprite sprite = Resources.Load<Sprite>(actionCard.GetImageFilePath());
			Image childImage = childGameObject.GetComponent<Image>();
			;
			childImage.sprite = sprite;
			childImage.SetAlpha(1.0f);
		}

		// public ActionCards.ABase GetActionCard(int index)
		// {
		//     return _actionCard?[index];
		// }
		// public ActionCards.ABase[] GetActionCards()
		// {
		//     return _actionCard;
		// }
	}
}