using System;

namespace Skysemi.With.Events
{
    public class CalculateActionCardsEventArgs : EventArgs
    {
        ActionCards.ABase[] actionCards = new ActionCards.ABase[4];

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
    }
}