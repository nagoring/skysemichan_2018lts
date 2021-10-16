using Skysemi.With.CardUI;

namespace Skysemi.With.Scenes
{
    public interface IPlayerCardUiController
    {
        CardBoardScrollView GetCardBoard();
        EquipmentCardFieldUi GetEquipmentCardField();
    }
}