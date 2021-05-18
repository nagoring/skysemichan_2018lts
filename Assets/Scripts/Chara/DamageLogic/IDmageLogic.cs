using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skysemi.With.Chara.DamageLogic
{
    public interface IDmageLogic
    {
        int CalcDamage(IChara target, IChara self);
    }    
}
