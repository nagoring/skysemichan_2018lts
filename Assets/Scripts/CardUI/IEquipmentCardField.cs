namespace Skysemi.With.CardUI
{
    public interface IEquipmentCardField
    {
        ActionCards.ABase GetActionCard(int index);
        ActionCards.ABase[] GetActionCards();
        void Equip(int index, ActionCards.ABase actionCard);
    }
}