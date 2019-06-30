using Skysemi.With.Core;
using Skysemi.With.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Skysemi.With.CardUI
{
    public class PlayerEquipmentCardBoxClickEvent : MonoBehaviour, IPointerClickHandler
    {
        public Image iconImage;
        
        //　マウスがクリックされた時
        public void OnPointerClick(PointerEventData eventData) 
        {
            //CardBoardを表示・非表示
            int index = int.Parse(name.Replace("EquipmentCardBoxUi", ""));

            Game game = Game.instance;
            IPlayerCardUiController cardUiController =  game.GetCardUiController();
            CardBoard cardBoardUi = cardUiController.GetCardBoard();
            bool active = cardBoardUi.gameObject.activeSelf;
            cardBoardUi.gameObject.SetActive(!active);

            EquipmentCardField equipmentCardField = cardUiController.GetEquipmentCardField();
            equipmentCardField.SelectedCardBoxIndex = index;
            equipmentCardField.SelectedGameObjectCardBox = transform.gameObject;
            equipmentCardField.SelectedIconImage = iconImage;
            

        }
    }
}