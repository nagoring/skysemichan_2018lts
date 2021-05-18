using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

namespace Skysemi.With.Chara.DamageLogic
{
    public class StandartLogic : IDmageLogic
    {
    
        public int CalcDamage(IChara target, IChara self)
        {
        
            int damage = self.Atk - target.Def;
            damage += (int)Random.Range(-3.0f, 3.0f);
            if (damage < 0) damage = 0;
            return damage;
        }
    }
}
