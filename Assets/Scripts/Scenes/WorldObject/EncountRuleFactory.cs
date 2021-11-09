using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Scenes.WorldObject
{
	public class EncountRuleFactory
	{
		public static IEncountRule Create(IGoFrontStateChangeParameter worldParameter)
		{
			if (Constants.Debug == 1)
			{
				return new EncountDebugRule(worldParameter);
			}

			Game game = Game.instance;
			Player player = game.GetPlayer();
			EStage eStage = game.destinationPlace;
			if (eStage == EStage.OTHER_STAGE1)
			{
				return new EncountBossOnlyRule(worldParameter);
			}

			return new EncountNormalRule(worldParameter);
		}
	}
}