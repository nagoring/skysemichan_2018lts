using Skysemi.With.Chara;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;

namespace Skysemi.With.Scenes.WorldObject
{
	public class EncountBossOnlyRule : IEncountRule
	{
		private readonly IGoFrontStateChangeParameter _worldParameter;

		public EncountBossOnlyRule(IGoFrontStateChangeParameter worldParameter)
		{
			_worldParameter = worldParameter;
		}


		public void Run()
		{
			Debug.Log("CheckingProgress");
			Game game = Game.instance;
			int boss_encount_progress = 100;
			Player player = game.GetPlayer();
			EStage eStage = game.destinationPlace;
			if (player.Progress == boss_encount_progress)
			{
				// game.eventManager.EncountEnemyBoss
				// eventManager.EncountEnemyBoss();
			}
		}

		public EWorldMode GetWorldMode()
		{
			throw new System.NotImplementedException();
		}

		public int GetRandomEncount()
		{
			throw new System.NotImplementedException();
		}

		public bool IsBoss()
		{
			throw new System.NotImplementedException();
		}

		public bool IsEncount()
		{
			throw new System.NotImplementedException();
		}

		public void OutputEnemy(ISetUpEnemy iSetUpEnemy)
		{
			throw new System.NotImplementedException();
		}

		public virtual void ShuffleRandomEncount()
		{
			throw new System.NotImplementedException();
		}
	}
}