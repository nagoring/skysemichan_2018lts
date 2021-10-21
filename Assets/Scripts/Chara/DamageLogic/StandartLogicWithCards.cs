using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Enum;
using UnityEngine;

public class StandartLogicWithCards : IDmageLogic

{
    public int CalcDamage(IChara target, IChara self)
    {
        EGroup eSelfGroup = self.GetGroup();
        EGroup eTargetGroup = target.GetGroup();
        // int damage = self.Atk - target.Def;
        // damage += (int)Random.Range(-3.0f, 3.0f);
        // if (damage < 0) damage = 0;
        // return damage;

        return 0;
    }
}
