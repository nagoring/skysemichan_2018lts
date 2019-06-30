using System;
using Skysemi.With.CardUI;

namespace Skysemi.With.Events
{
    public class CalculateActionCardsEventArgs : EventArgs
    {
        ActionCards.ABase[] actionCards = new ActionCards.ABase[4];

        public CalculateActionCardsEventArgs(Skysemi.With.CardUI.IEquipmentCardField iEquipmentCardField)
        {
            SetActionCards(iEquipmentCardField);
        }
        private void InitActionCards()
        {
            actionCards = new ActionCards.ABase[4];
        }
        public void SetActionCard(int index, ActionCards.ABase actionCard)
        {
            actionCards[index] = actionCard;
        }
        public ActionCards.ABase GetActionCard(int index)
        {
            return actionCards[index];
        }
        public ActionCards.ABase[] GetActionCards()
        {
            return actionCards;
        }

        public void SetActionCards(IEquipmentCardField iEquipmentCardField)
        {
            InitActionCards();
            int index = 0;
            foreach (ActionCards.ABase actionCard in iEquipmentCardField.GetActionCards())
            {
                actionCards[index] = actionCard;
                index++;
            }
        }
    }
}