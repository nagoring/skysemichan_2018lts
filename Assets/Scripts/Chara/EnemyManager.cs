using System;
using System.Collections.Generic;
using UnityEngine;
using Skysemi.With.ActionCards;
using Skysemi.With.CardUI;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using Skysemi.With.Scenes;
using StatusUI;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Skysemi.With.Chara
{
    public class EnemyManager : CardUI.IEquipmentCardFieldUi
    {
        private Skysemi.With.CardUI.EquipmentCardFieldMiniUi _equipmentCardFieldUi;
        private Enemy _enemy;
//        private GameObject _enemyGameObject;

        public void Init(Enemy enemy, Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldUiMini)
        {
            _enemy = enemy;
            _equipmentCardFieldUi = equipmentCardFieldUiMini;
        }
        

        public Enemy GetEnemy()
        {
            return _enemy;
        }

        public ABase GetActionCard(int index)
        {
            return _equipmentCardFieldUi.GetActionCard(index);
        }

        public ABase[] GetActionCards()
        {
            return _equipmentCardFieldUi.GetActionCards();
        }

        public void Equip(int index, ActionCards.ABase actionCard)
        {
            _equipmentCardFieldUi.Equip(index, actionCard);
        }

        private void SetEquipmentCardField(Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldUi)
        {
            _equipmentCardFieldUi = equipmentCardFieldUi;
        }

        /// <summary>
        ///  HPをMaxまで回復
        /// </summary>
        public void RecoveryHp()
        {
            _enemy.Hp = _enemy.MaxHp;
        }
        // public void CalculateEquipmentActionCardsReceiver(ActionCards.ABase[] actionCards)
        // {
        //     int tmpMaxHp = 0;
        //     int tmpAtk = 0;
        //     int tmpDef = 0;
        //     int tmpSpirit = _enemy.param.spirit;
        //     _enemy.param.spirit = 0;
        //     int tmpAgi = _enemy.param.agi;
        //     _enemy.param.agi = 0;
        //     // ActionCards.ABase[] actionCards = eventArgs.GetActionCards();
        //     foreach (ActionCards.ABase actionCard in actionCards)
        //     {
        //         if (actionCard == null) continue;
        //         tmpMaxHp += actionCard.MaxHp;
        //         tmpAtk += actionCard.Atk;
        //         tmpDef += actionCard.Def;
        //         tmpSpirit += actionCard.Spirit;
        //         tmpAgi += actionCard.Agi;
        //     }
        //     
        //     
        //     _enemy.param.maxhp = _enemy.param.maxhp + tmpMaxHp;
        //     _enemy.param.atk = _enemy.param.str + tmpAtk;
        //     _enemy.param.def = _enemy.param.vit + tmpDef;
        //     _enemy.param.spirit = _enemy.param.spirit + tmpSpirit;
        //     _enemy.param.agi = _enemy.param.agi + tmpAgi;
        //     //		GameMainManager game = GameMainManager.instance;
        //     //
        //     //		game.playerManager.textAtk.text = param.atk.ToString();
        //     //		game.playerManager.textDef.text = param.def.ToString();
        //     //
        //     //		
        //     //		//ActionCardやUIのステータスとパラメータを一致させる
        //     //		UIManager.instance.ShowActionCardArea(this);
        //     //		PlayerManager.instance.SyncUiStatusByPlayer(this);
			     //
        // }
        /// <summary>
        /// HPを全回復してステータスを同期させる
        /// </summary>
        public void SyncRecoveryHpInclude()
        {
            Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldUi = _equipmentCardFieldUi;
            SetEquipmentCardField(equipmentCardFieldUi);
            Game game = Game.instance;
            // CalculateEquipmentActionCardsReceiver(_enemy.GetActionCards());
            _enemy.RecalculateEquipmentActionCards();
            RecoveryHp();
            EnemyStatusWindow enemyStatusWindow = World.instance.GetEnemyStatusWindow();
            EnemyStatusWindow localEnemyStatusWindow = enemyStatusWindow.gameObject.GetComponent<EnemyStatusWindow>();
        }
        /// <summary>
        /// ステータスを同期させる
        /// </summary>
        public void Sync()
        {
            Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldUi = _equipmentCardFieldUi;
            SetEquipmentCardField(equipmentCardFieldUi);
            Game game = Game.instance;
            // CalculateEquipmentActionCardsReceiver(_enemy.GetActionCards());
            _enemy.RecalculateEquipmentActionCards();
            EnemyStatusWindow enemyStatusWindow = World.instance.GetEnemyStatusWindow();
            EnemyStatusWindow localEnemyStatusWindow = enemyStatusWindow.gameObject.GetComponent<EnemyStatusWindow>();
            localEnemyStatusWindow.SyncEnemyStatusReceiver(GetEnemy().param);
        }

        public void CreateEnemy(MonoBehaviour mono, EquipmentCardFieldMiniUi inEquipmentCardFieldUi)
        {
            EnemyFactory enemyFactory = EnemyFactory.GetInstance();
            Enemy targetEnemy = enemyFactory.Factory(mono);
            Init(targetEnemy, inEquipmentCardFieldUi);
            int loopIndex = 0;
            ;
            foreach (ActionCards.ABase card in targetEnemy.GetActionCards())
            {
                if (card == null) continue;
                Equip(loopIndex, card);
                loopIndex++;
                if (loopIndex >= 3) break;
            }
            // Equip(0, mono.gameObject.AddComponent<NasuHeart>());
            // Equip(1, mono.gameObject.AddComponent<MagicAddMaxHp>());
            // Equip(2, mono.gameObject.AddComponent<Punch>());
            // Equip(3, mono.gameObject.AddComponent<StrongPunch>());
            SyncRecoveryHpInclude();
            
//            Game game = Game.instance;
//            if (world.WorldMode != EWorldMode.BATTLE) return;
//            imageEnemeyStatusWindow.SetActive(true);
        }

        public void displayEnemy(GameObject enemeyLayer)
        {
            Enemy enemy = GetEnemy();

            Sprite sprite = Resources.Load<Sprite>(enemy.GetImageFilePath());
            Image childImage = enemeyLayer.GetComponent<Image>();
            childImage.sprite = sprite;
            childImage.SetAlpha( 1.0f );
            enemy.gameObject.SetActive(true);
            enemy.gameObject.transform.SetParent(enemeyLayer.transform, false);
//            enemeyLayer.SetActive(true);
        }
    }
}