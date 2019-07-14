using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Skysemi.With.ActionCards;
using Skysemi.With.CardUI;
using UnityEngine;

namespace Skysemi.With.Chara
{
    public class EquipmentCardField : IEquipmentCardFieldChara
    {
        private ActionCards.ABase[] _actionCardArray;
        private const int EquipmentLength = 4;

        public void Init()
        {
            _actionCardArray = new ActionCards.ABase[EquipmentLength];
            GameObject obj = new GameObject();
            _actionCardArray[0] = obj.AddComponent<Empty>();
            _actionCardArray[1] = obj.AddComponent<Empty>();
            _actionCardArray[2] = obj.AddComponent<Empty>();
            _actionCardArray[3] = obj.AddComponent<Empty>();
        }

        public ActionCards.ABase GetActionCard(int index)
        {
            return _actionCardArray[index];
        }
        public void SetActionCard(int index, ActionCards.ABase card)
        {
            _actionCardArray[index] = card;
        }

        public int Length()
        {
            return _actionCardArray.Length;
        }
    }
}
