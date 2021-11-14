using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Skysemi.With.ActionCards;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Chara.DamageLogic
{
	public class StandartLogicWithCards : IDmageLogic
	{
		private static StandartLogicWithCards _instance = new StandartLogicWithCards();

		private StandartLogicWithCards()
		{
		}
		public static StandartLogicWithCards GetInstance()
		{
			return _instance;
		}

		public int CalcDamage(IChara target, IChara self)
		{
			// EGroup eSelfGroupCore = self.GetGroup();
			// EGroup eTargetGroupCore = target.GetGroup();
			ABase[] selfCards = self.GetActionCards();
			ABase[] targetCards = target.GetActionCards();
			int damageAccumulator = 0;
			float baseDefAccumulator =  0;
			foreach (ABase _selfCard in selfCards)
			{
				// damageAccumulator = 0;
				// baseDefAccumulator =  0;
				// float cardDefAccumulator = 0;
				// foreach (ABase _targetCard in targetCards)
				// {
				// 	cardDefAccumulator = 0;
				// 	if (_targetCard.GetGroup() == _selfCard.GetGroup())
				// 	{
				// 		float damageRating = DamageRating.CalcByCard(_targetCard, _selfCard);
				// 		float def = _targetCard.Def * damageRating;
				// 		cardDefAccumulator += def;
				// 		baseDefAccumulator += _targetCard.Def;
				// 	}
				// }
				// float _result = self.Atk - (target.Def - baseDefAccumulator + cardDefAccumulator);
				// int damage = (int)Math.Round(_result, 1, MidpointRounding.AwayFromZero);
				//
				int damage = DamageMidCalulate(targetCards, _selfCard, target, self);
				if (damage < 0) damage = 0;
				damageAccumulator += damage;
			}

			return (int)(damageAccumulator / 4);

			// int damage = self.Atk - target.Def;
			// damage += (int)Random.Range(-3.0f, 3.0f);
			// if (damage < 0) damage = 0;
			// return damage;
			// return 0;
		}

		//ダメージ計算の途中
		public int DamageMidCalulate(ABase[] targetCards, ABase _selfCard, IChara target, IChara self)
		{
			float baseDefAccumulator = 0;
			float cardDefAccumulator = 0;
			foreach (ABase _targetCard in targetCards)
			{
				if (_targetCard == null)
				{
					// Debug.Log("targetCard is Null");
					continue;
				}

				if (_selfCard == null)
				{
					// Debug.Log("seflCard is Null");
					continue;
				}

				float damageRating = DamageRating.CalcByCard(_targetCard, _selfCard);
				Debug.Log("damageRating:" + damageRating);
				float def = _targetCard.Def * damageRating;
				cardDefAccumulator += def;
				baseDefAccumulator += _targetCard.Def;
				
			}

			Debug.Log($"target.Def:{target.Def}");
			Debug.Log($"baseDefAccumulator:{baseDefAccumulator}");
			Debug.Log($"cardDefAccumulator:{cardDefAccumulator}");
			float _result = self.Atk - (target.Def - baseDefAccumulator + cardDefAccumulator);
			int damage = (int)Math.Round(_result, 1, MidpointRounding.AwayFromZero);

			return damage;
		}
		public float DamageRateNamamono(EGroup targetGroup)
		{
			Dictionary<EGroup, float> tbl = new Dictionary<EGroup, float>()
			{
				{EGroup.Mukibutu, 1.5f},
				{EGroup.Namamono, 1.0f},
				{EGroup.Meruhen, 0.5f},
			};
			return tbl[targetGroup];
		} 
		public float DamageRateMukibutu(EGroup targetGroup)
		{
			Dictionary<EGroup, float> tbl = new Dictionary<EGroup, float>()
			{
				{EGroup.Meruhen, 1.5f},
				{EGroup.Mukibutu, 1.0f},
				{EGroup.Namamono, 0.5f},
			};
			return tbl[targetGroup];
		} 
		public float DamageRateMeruhen(EGroup selfGroup)
		{
			Dictionary<EGroup, float> tbl = new Dictionary<EGroup, float>()
			{
				{EGroup.Namamono, 1.5f},
				{EGroup.Meruhen, 1.0f},
				{EGroup.Mukibutu, 0.5f},
			};
			return tbl[selfGroup];
		} 
	}
}