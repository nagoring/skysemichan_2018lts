using System.Collections.Generic;
using Skysemi.With.ActionCards;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara
{
	abstract public class CharaBase : MonoBehaviour
	{
		public abstract void Init();
		// public abstract IChara GetTarget(List<IChara> targetList);
		// public abstract void SetBattleAction(IChara chara);
		// public abstract EBattleAction GetBattleAction();
		// public abstract ECharaType GetCharaType();
		// public abstract EGroup GetGroup();
		// public abstract void PlayActionAnimation();
		// public abstract void PlayActionSound();
		// public abstract float GetWaitTimeByAnimation();
		// public abstract void Act(IChara target);
		// public abstract void SayDamageAfterMsg();
		// public abstract float BeforeActStartWait();
		// public abstract void BeforeActStartMsg(IChara target);
		// public abstract string CharaName { get; set; }
		// public abstract void SayAtkAfter(IChara target);
		// public abstract EChara Id { get; set; }
		// public abstract int Hp { get; set; }
		// public abstract int MaxHp { get; set; }
		// public abstract int Atk { get; set; }
		// public abstract int Def { get; set; }
		// public abstract int Agi { get; set; }
		// public abstract int Spirit { get; set; }
		// public abstract int MaxSpirit { get; set; }
		// public abstract ABase GetActionCard(int index);
		// public abstract ABase[] GetActionCards();
		// public virtual float DamageRate(EGroup group)
		// {
		// 	StandartLogicWithCards logic = StandartLogicWithCards.GetInstance();
		// 	if (GetGroup() == EGroup.Meruhen)
		// 	{
		// 		return logic.DamageRateMeruhen(group);
		// 	}
		// 	if (GetGroup() == EGroup.Meruhen)
		// 	{
		// 		return logic.DamageRateMeruhen(group);
		// 	}
		// 	if (GetGroup() == EGroup.Meruhen)
		// 	{
		// 		return logic.DamageRateMeruhen(group);
		// 	}
		//
		// 	return 1.0f;
		// }
	}
}