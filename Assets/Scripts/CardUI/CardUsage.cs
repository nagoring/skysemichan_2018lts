using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Skysemi.With.CardUI
{
	public class CardUsage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
	{
		private RectTransform rectTransform;
		private IPointerEnterHandler _pointerEnterHandlerImplementation;
		private GameObject cardUsageObject = null;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
		}

		private Vector2 GetLocalPosition(Vector2 screenPosition)
		{
			Vector2 result = Vector2.zero;

			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPosition, Camera.main,
				out result);

			return result;
		}


		public void OnPointerEnter(PointerEventData eventData)
		{
//            Debug.Log(name);
//            int index = int.Parse(name.Replace("BoardArea", ""));
//            GameObject cardBoardGameObject = transform.parent.gameObject;
//            CardBoard cardBoard = cardBoardGameObject.GetComponent<CardBoard>();
//            Card card = cardBoard.GetCard(index);
//            ActionCards.ABase actionCard = card.GetActionCard();
//            Debug.Log(actionCard.GetEActionCardName());
//            
//            
/////////////////
//            int index = int.Parse(name.Replace("BoardArea", ""));

			if (cardUsageObject == null)
			{
				string PrefabPath = "Prefabs/CardUI/BtnUsageBoard";
				GameObject obj = (GameObject) Resources.Load(PrefabPath);
				// プレハブを元にBtnUsageBoardを生成して、CanvasUIの子供にする
				cardUsageObject = (GameObject) Instantiate(obj, Vector2.zero, Quaternion.identity);
				cardUsageObject.SetActive(true);
				Image image = this.GetComponent<Image>();
				Transform canvasTransform = transform.parent.parent.parent;
				// cardUsageObject.transform.parent = canvasTransform;
				cardUsageObject.transform.SetParent(canvasTransform);
				cardUsageObject.transform.SetAsLastSibling();
				RectTransform rectTransform = this.GetComponent<RectTransform>();
				float width = rectTransform.sizeDelta.x;
				float height = rectTransform.sizeDelta.y;
				float scaleX = rectTransform.localScale.x;
				float scaleY = rectTransform.localScale.y;
				cardUsageObject.transform.localScale = new Vector3(1, 1, 1);
				// ActionCardの右横に説明文を入れる
				float localPositionX = 0;
				float localPositionY = 0;

				//CardUsageScrollViewの場合
				// Debug.Log("Name:" + cardUsageObject.transform.parent.gameObject.name);
				if (cardUsageObject.transform.parent.gameObject.name == "CardBoardScrollView(Clone)")
				{
					// localPositionX = transform.localPosition.x + width / 1 + width / 2 + (1 - scaleX) * (width * 3.0f);
					// localPositionX = canvasTransform.transform.localPosition.x + 200;
					// localPositionY = canvasTransform.transform.localPosition.y - 120;

					// Vector2 vec2 = GetLocalPosition(eventData.position);
					// localPositionX = transform.localPosition.x - 200 - 41 + width;
					// localPositionY = transform.localPosition.y + 200 + 95 - height / 6;
					localPositionX = 459;
					localPositionY = 161;
				}
				else
				{
					localPositionX = transform.localPosition.x + width / 4 + (1 - scaleX) * (width * 3.0f);
					localPositionY = transform.localPosition.y + height / 4 + (1 - scaleY) * (-height);
				}

				//EnemyStatusWindowのための処置
				if (Math.Abs(transform.localPosition.x) < 1)
				{
					localPositionX = transform.parent.localPosition.x + width / 4 + (1 - scaleX) * (width * 2.0f);
					localPositionY = transform.parent.localPosition.y + height / 4 + (1 - scaleY) * (-height);
				}

				cardUsageObject.transform.localPosition = new Vector3(localPositionX, localPositionY);
				ActionCards.ABase actionCard = GetComponent<ActionCards.ABase>();

				Text textObject = cardUsageObject.GetComponentInChildren<Text>();
				textObject.text = actionCard.GetCardUsageText();
			}
			else
			{
				// Debug.Log("TTT:" + cardUsageObject.transform.parent.gameObject.name);
				// Debug.Log("TTT" + cardUsageObject.activeInHierarchy);
				;

				cardUsageObject.SetActive(true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			// Debug.Log("FFF");
			cardUsageObject.SetActive(false);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (cardUsageObject != null)
			{
				cardUsageObject.SetActive(false);
			}
		}
	}
}