using Skysemi.With.Core;

namespace Skysemi.With.CardUI
{
    public class EquipmentCardBoxMini : AppMonoBehaviour
    {
        private float _x = 0;
        private float _y = 0;
        private float _width = 100;
        private float _height = 100;
        private ActionCards.ABase _actionCard;

        public void Equip(ActionCards.ABase inActionCard)
        {
            _actionCard = inActionCard;
        }

        public ActionCards.ABase GetActionCard()
        {
            return _actionCard;
        }

        public string GetImageFilePath()
        {
            return _actionCard.GetImageFilePath();
        }

    }
}