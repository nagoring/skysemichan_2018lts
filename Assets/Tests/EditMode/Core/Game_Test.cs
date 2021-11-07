using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Skysemi.With.ActionCards;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class Game_Test
	{
		// A Test behaves as an ordinary method
		[UnityTest]
		public IEnumerator Game_CreateActionCard()
		{
			// Use the Assert class to test conditions
			yield return new EnterPlayMode();
			Game game = Game.instance;
			ABase punch = game.CreateActionCard(typeof(Punch));
			yield return new ExitPlayMode();
			Assert.AreEqual(EActionCardName.Punch, punch.GetEActionCardName());
			Assert.AreEqual(3, punch.Atk);
		}
		[UnityTest]
		public IEnumerator Game_CreateEnemy()
		{
			yield return new EnterPlayMode();
			Game game = Game.instance;
			Enemy enemy = game.CreateEnemy(typeof(EnemyNasu));
			yield return new ExitPlayMode();
			Assert.AreEqual("ナス", enemy.CharaName);
		}

		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		// [UnityTest]
		// public IEnumerator Game_TestWithEnumeratorPasses()
		// {
		// 	// Use the Assert class to test conditions.
		// 	// Use yield to skip a frame.
		// 	yield return null;
		// }
	}
}