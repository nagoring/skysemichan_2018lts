namespace Skysemi.With.CardUI
{
    public interface IEquipmentCardFieldUi
    {
        // ActionCards.ABase GetActionCard(int index);
        // ActionCards.ABase[] GetActionCards();
        void Equip(int index, ActionCards.ABase actionCard);
    }
}