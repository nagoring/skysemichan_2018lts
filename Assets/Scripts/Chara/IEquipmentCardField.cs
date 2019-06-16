namespace Skysemi.With.Chara
{
    public interface IEquipmentCardField
    {
        ActionCards.ABase GetActionCard(int index);
        void SetActionCard(int index, ActionCards.ABase card);
        int Length();
    }
}