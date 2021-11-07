using Skysemi.With.ActionCards;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara.DamageLogic
{
	public static class DamageRating
	{
		public static float Calc(IChara target, IChara self)
		{
			EGroup targetGroup = target.GetGroup();
			StandartLogicWithCards logic = StandartLogicWithCards.GetInstance();
			float result = DamageRating.CalcByGroup(targetGroup, self.GetGroup());
			return result;
		}
		public static float CalcByCard(ABase target, ABase self)
		{
			EGroup targetGroup = target.GetGroup();
			StandartLogicWithCards logic = StandartLogicWithCards.GetInstance();
			float result = DamageRating.CalcByGroup(targetGroup, self.GetGroup());
			return result;
		}
		public static float CalcByGroup(EGroup targetGroup, EGroup selfGroup)
		{
			StandartLogicWithCards logic = StandartLogicWithCards.GetInstance();
			if (selfGroup == EGroup.Meruhen)
			{
				return logic.DamageRateMeruhen(targetGroup);
			}
			if (selfGroup == EGroup.Mukibutu)
			{
				return logic.DamageRateMukibutu(targetGroup);
			}
			if (selfGroup == EGroup.Namamono)
			{
				return logic.DamageRateNamamono(targetGroup);
			}

			return 0.1f;
		}
	}
}