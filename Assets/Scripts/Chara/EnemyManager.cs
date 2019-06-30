using Skysemi.With.ActionCards;
using Skysemi.With.CardUI;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;

namespace Skysemi.With.Chara
{
    public class EnemyManager : CardUI.IEquipmentCardField
    {
        private Skysemi.With.CardUI.IEquipmentCardField _equipmentCardField;
        private Enemy _enemy;

        public void Init(Enemy enemy, Skysemi.With.CardUI.IEquipmentCardField equipmentCardFieldMini)
        {
            _enemy = enemy;
            _equipmentCardField = equipmentCardFieldMini;
        }
        

        public Enemy GetEnemy()
        {
            return _enemy;
        }

        public ABase GetActionCard(int index)
        {
            return _equipmentCardField.GetActionCard(index);
        }

        public ABase[] GetActionCards()
        {
            return _equipmentCardField.GetActionCards();
        }

        public void Equip(int index, ActionCards.ABase actionCard)
        {
            _equipmentCardField.Equip(index, actionCard);
        }

        private void SetEquipmentCardField(Skysemi.With.CardUI.IEquipmentCardField equipmentCardField)
        {
            _equipmentCardField = equipmentCardField;
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
        /// <summary>
        /// HPを全回復してステータスを同期させる
        /// </summary>
        public void SyncRecoveryHpInclude()
        {
            Skysemi.With.CardUI.IEquipmentCardField equipmentCardField = _equipmentCardField;
            SetEquipmentCardField(equipmentCardField);
            Game game = Game.instance;
            game.eventManager.EventSenderFactory(EEvent.CalculateActionCardsByEnemy)?.Send(new BaseEventArgs(new CalculateActionCardsEventArgs(equipmentCardField)));
            RecoveryHp();
            game.eventManager.EventSenderFactory(EEvent.SyncEnemyStatus)?.Send(new BaseEventArgs(new SyncStatusEnemyEventArgs(GetEnemy().param)));
        }
        /// <summary>
        /// ステータスを同期させる
        /// </summary>
        public void Sync()
        {
            Skysemi.With.CardUI.IEquipmentCardField equipmentCardField = _equipmentCardField;
            SetEquipmentCardField(equipmentCardField);
            Game game = Game.instance;
            game.eventManager.EventSenderFactory(EEvent.CalculateActionCardsByEnemy)?.Send(new BaseEventArgs(new CalculateActionCardsEventArgs(equipmentCardField)));
            game.eventManager.EventSenderFactory(EEvent.SyncEnemyStatus)?.Send(new BaseEventArgs(new SyncStatusEnemyEventArgs(GetEnemy().param)));
        }
        
    }
}