using System;
using System.Collections;
using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes;
using StatusUI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Skysemi.With.CardUI
{
    public class PlayerClickCardOnBoardEvent : MonoBehaviour, IPointerClickHandler
    {
        //　マウスがクリックされた時
        public void OnPointerClick(PointerEventData eventData)
        {
            //CardBoardを表示・非表示
            Game game = Game.instance;
            Skysemi.With.Scenes.IPlayerCardUiController cardUiController =  game.GetCardUiController();
            EquipmentCardFieldUi equipmentCardFieldUi = cardUiController.GetEquipmentCardField();
            int selectedIndex = equipmentCardFieldUi.SelectedCardBoxIndex;
            if (selectedIndex > 3)
            {
                selectedIndex = 0;
            }
            ActionCards.ABase actionCard = GetComponent<ActionCards.ABase>();
            equipmentCardFieldUi.Equip(selectedIndex, actionCard);
            cardUiController.GetCardBoard().gameObject.SetActive(false);
            
            //イベントを発火させる
//            EquipmentCardFieldにあるActionCardを計算するイベントを発生させる
//            EquipmentCardBoxUi[] equipmentCardBoxs = equipmentCardFieldUi.GetEquipmentCardBoxs();
            CalculateActionCardsEventArgs calculateActionCardsEventArgs = new CalculateActionCardsEventArgs(equipmentCardFieldUi);
//            game.FireEvent(EEvent.CalculateActionCards, new BaseEventArgs(calculateActionCardsEventArgs));
            Player player = game.GetPlayer();
            player.CalculateEquipmentActionCardsReceiver(calculateActionCardsEventArgs);
            
            //計算後PlayerStatusUiに反映させる
            SyncStatusEventArgs syncStatusEventArgs = new SyncStatusEventArgs(game.GetPlayer().param);
            PlayerStatusWindow playerStatusWindow = game.GetPlayerStatusWindow().GetPlayerStatusWindow();
            playerStatusWindow.SyncPlayerStatusReceiver(syncStatusEventArgs);

            
            
            

//            game.OnCalculateActionCardsEvent(calculateActionCardsEventArgs);
//            EventReturnVars calculatedVars = eventObject->fire(new EventArgs);
//            
//            
//            //計算後Playerに反映させる
//            PlayerManger playerManager = game.GetPlayerManager();
//            playerManager.SetNanntyara(calculatedVars);
//
//            //計算後PlayerStatusWindowに反映させる
//            IChara chara = playerManager.GetPlayer();
//            PlayerStatusWindow playerStatusWindow =  game.GetPlayerStatusWindow();
//            playerStatusWindow.SetChara(chara);

        }
    }
}