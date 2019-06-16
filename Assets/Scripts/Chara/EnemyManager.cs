using Skysemi.With.CardUI;
using Skysemi.With.Events;
using UnityEngine;

namespace Skysemi.With.Chara
{
    public class EnemyManager
    {
        private EquipmentCardFieldMini _equipmentCardFieldMini;
        
        private Enemy _enemy;
        public void SetEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }

        public Enemy GetEnemy()
        {
            return _enemy;
        }

        public void SetEquipmentCardFieldMini(EquipmentCardFieldMini equipmentCardFieldMini)
        {
            _equipmentCardFieldMini = equipmentCardFieldMini;
        }

        /// <summary>
        ///  HPをMaxまで回復
        /// </summary>
        public void RecoveryHp()
        {
            _enemy.Hp = _enemy.MaxHp;
        }
        public void CalculateEquipmentActionCardsReceiver(BaseEventArgs e)
        {
            CalculateActionCardsEventArgs eventArgs = (CalculateActionCardsEventArgs)e.GetObject();
			
            int tmpMaxHp = 0;
            int tmpAtk = 0;
            int tmpDef = 0;
            int tmpSpirit = _enemy.param.spirit;
            _enemy.param.spirit = 0;
            int tmpAgi = _enemy.param.agi;
            _enemy.param.agi = 0;
            ActionCards.ABase[] actionCards = eventArgs.GetActionCards();
            foreach (ActionCards.ABase actionCard in actionCards)
            {
                if (actionCard == null) continue;
                tmpMaxHp += actionCard.MaxHp;
                tmpAtk += actionCard.Atk;
                tmpDef += actionCard.Def;
                tmpSpirit += actionCard.Spirit;
                tmpAgi += actionCard.Agi;
            }

            _enemy.param.maxhp = _enemy.param.maxhp + tmpMaxHp;
            _enemy.param.atk = _enemy.param.str + 1 + tmpAtk;
            _enemy.param.def = _enemy.param.vit + tmpDef;
            _enemy.param.spirit = _enemy.param.spirit + tmpSpirit;
            _enemy.param.agi = _enemy.param.agi + tmpAgi;
			
            //		GameMainManager game = GameMainManager.instance;
            //
            //		game.playerManager.textAtk.text = param.atk.ToString();
            //		game.playerManager.textDef.text = param.def.ToString();
            //
            //		
            //		//ActionCardやUIのステータスとパラメータを一致させる
            //		UIManager.instance.ShowActionCardArea(this);
            //		PlayerManager.instance.SyncUiStatusByPlayer(this);
			
        }
        
        
    }
}