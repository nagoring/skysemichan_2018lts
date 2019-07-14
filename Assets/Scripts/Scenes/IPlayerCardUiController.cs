using Skysemi.With.CardUI;

namespace Skysemi.With.Scenes
{
    public interface IPlayerCardUiController
    {
        CardBoard GetCardBoard();
        EquipmentCardFieldUi GetEquipmentCardField();
    }
}