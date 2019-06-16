using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Skysemi.With.CardUI
{
    public class CardUsage : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private IPointerEnterHandler _pointerEnterHandlerImplementation;
        private GameObject cardUsageObject = null;

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
                GameObject obj = (GameObject)Resources.Load (PrefabPath);
                // プレハブを元にBtnUsageBoardを生成して、CanvasUIの子供にする
                cardUsageObject = (GameObject)Instantiate(obj,Vector2.zero,Quaternion.identity);
                cardUsageObject.SetActive(true);
                Image image = this.GetComponent<Image>();
                Transform canvasTransform = transform.parent.parent;
                cardUsageObject.transform.parent = canvasTransform;
                RectTransform rectTransform = this.GetComponent<RectTransform>();
                float width = rectTransform.sizeDelta.x;
                float height = rectTransform.sizeDelta.y;
                cardUsageObject.transform.localScale = new Vector3(1,1,1);
                // ActionCardの右横に説明文を入れる
                cardUsageObject.transform.localPosition = new Vector3(transform.localPosition.x + width / 4, transform.localPosition.y - height / 4);
                ActionCards.ABase actionCard = GetComponent<ActionCards.ABase>();
                
                Text textObject = cardUsageObject.GetComponentInChildren<Text>();
                textObject.text = actionCard.GetCardUsageText();
            }
            else
            {
                cardUsageObject.SetActive(true);
            }
        }
        public void OnPointerExit( PointerEventData eventData )
        {
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