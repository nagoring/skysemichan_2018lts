using System;
using System.Collections;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes;
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
            EquipmentCardField equipmentCardField = cardUiController.GetEquipmentCardField();
            int selectedIndex = equipmentCardField.SelectedCardBoxIndex;
            if (selectedIndex > 3)
            {
                selectedIndex = 0;
            }
            ActionCards.ABase actoinCard = GetComponent<ActionCards.ABase>();
            equipmentCardField.Equip(selectedIndex, actoinCard);
            cardUiController.GetCardBoard().gameObject.SetActive(false);
            
            //イベントを発火させる
//            EquipmentCardFieldにあるActionCardを計算するイベントを発生させる
//            EquipmentCardBoxUi[] equipmentCardBoxs = equipmentCardField.GetEquipmentCardBoxs();
            CalculateActionCardsEventArgs calculateActionCardsEventArgs = new CalculateActionCardsEventArgs();
//            calculateActionCardsEventArgs.SetActionCard(0, equipmentCardBoxs[0]?.GetActionCard());
//            calculateActionCardsEventArgs.SetActionCard(1, equipmentCardBoxs[1]?.GetActionCard());
//            calculateActionCardsEventArgs.SetActionCard(2, equipmentCardBoxs[2]?.GetActionCard());
//            calculateActionCardsEventArgs.SetActionCard(3, equipmentCardBoxs[3]?.GetActionCard());
            calculateActionCardsEventArgs.SetActionCard(0, equipmentCardField.GetActionCard(0));
            calculateActionCardsEventArgs.SetActionCard(1, equipmentCardField.GetActionCard(1));
            calculateActionCardsEventArgs.SetActionCard(2, equipmentCardField.GetActionCard(2));
            calculateActionCardsEventArgs.SetActionCard(3, equipmentCardField.GetActionCard(3));

            game.eventManager.EventSenderFactory(EEvent.CalculateActionCards).Send(new BaseEventArgs(calculateActionCardsEventArgs));
            
            //計算後PlayerStatusUiに反映させる
            SyncStatusEventArgs syncStatusEventArgs = new SyncStatusEventArgs();
            syncStatusEventArgs.CharaParameter = game.GetPlayer().param;
            var baseEventArgs = new BaseEventArgs();
            baseEventArgs.SetObject(syncStatusEventArgs);
            game.eventManager.EventSenderFactory(EEvent.SyncPlayerStatus).Send(baseEventArgs);
            
            
            
            

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