using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.DamageLogic;
using UnityEngine;

namespace Skysemi.With.Chara.DamageLogic
{
    public class DamageLogicFactory
    {
        public static IDmageLogic create(IChara target, IChara iChara)
        {
            return StandartLogicWithCards.GetInstance();
            return new StandartLogic();
        }
    }    
}



    