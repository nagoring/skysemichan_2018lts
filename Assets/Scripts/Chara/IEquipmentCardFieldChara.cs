namespace Skysemi.With.Chara
{
    public interface IEquipmentCardFieldChara
    {
        ActionCards.ABase GetActionCard(int index);
        void SetActionCard(int index, ActionCards.ABase card);
        int Length();
    }
}