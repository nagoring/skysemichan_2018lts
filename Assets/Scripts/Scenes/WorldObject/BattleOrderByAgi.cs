using System.Collections.Generic;
using UnityEngine;

namespace Skysemi.With.Scenes.WorldObject
{
	public class BattleOrderByAgi
	{
		static BattleOrderByAgi instance = null;
		private BattleOrderByAgi()
		{
		}

		public static BattleOrderByAgi GetInstance()
		{
			if (instance == null)
			{
				instance = new BattleOrderByAgi();
			}

			return instance;
		}

		public List<IChara> GetListForBattleOrder(IChara target, IChara self)
		{
			int selfAgi = self.Agi;
			if (selfAgi <= 0) selfAgi = 1;
			int targetAgi = target.Agi;
			if (targetAgi <= 0) targetAgi = 1;
			int targetAtkCount = targetAgi / selfAgi;
			int selfAtkCount = selfAgi / targetAgi;
			targetAtkCount = targetAtkCount == 0 ? 1 : targetAtkCount;
			selfAtkCount = selfAtkCount == 0 ? 1 : selfAtkCount;
			List<IChara> charaActOrderList = new List<IChara>();
			for (int i = 0; i < targetAtkCount; i++)
			{
				charaActOrderList.Add(target);
			}
			for (int i = 0; i < selfAtkCount; i++)
			{
				charaActOrderList.Add(self);
			}
			charaActOrderList.Sort((a, b) => b.Agi - a.Agi);
			return charaActOrderList;
		}
	}
}