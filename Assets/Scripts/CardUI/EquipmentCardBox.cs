using Skysemi.With.Core;
using UnityEngine;

namespace Skysemi.With.CardUI
{
    public class EquipmentCardBox : AppMonoBehaviour
    {
        private float _x = 0;
        private float _y = 0;
        private float _width = 200;
        private float _height = 200;
        private ActionCards.ABase _actionCard;

        void Start()
        {
            
        }

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