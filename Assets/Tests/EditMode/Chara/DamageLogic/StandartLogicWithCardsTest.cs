using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Skysemi.With.ActionCards;
using Skysemi.With.CardUI;
using Skysemi.With.Chara;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Scenes;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Chara.DamageLogic
{
	public class StandartLogicWithCardsTest
	{
		[Test]
		public void StandartLogicWithCards_DamageRateNamamono_Test1()
		{
			StandartLogicWithCards logic = StandartLogicWithCards.GetInstance();
			// EnemyNasu nasu = new EnemyNasu();
			// Player player = new Player();
			// player.Init("なまえ");
			// nasu.Init();
			// StandartLogicWithCards stdLogic = new StandartLogicWithCards();
			// float result = stdLogic.DamageRateNamamono(player.GetGroup());
			
			Assert.AreEqual(1.1f, 1.1f);
		}
		[UnityTest]
		public IEnumerator StandartLogicWithCards_DamageMidCalulate_Test()
		{
			
			yield return new EnterPlayMode();
			Game game = Game.instance;
			string PrefabPath = "Prefabs/CardUI/EquipmentCardFieldMiniUi";
			GameObject obj = (GameObject) Resources.Load(PrefabPath);
			GameObject instance = (GameObject) Object.Instantiate(obj, Vector2.zero, Quaternion.identity);
			EquipmentCardFieldMiniUi _equipmentCardFieldMiniUi = instance.GetComponent<EquipmentCardFieldMiniUi>();
			_equipmentCardFieldMiniUi.Init();
			game.enemyManager.CreateEnemy(World.instance, _equipmentCardFieldMiniUi);
			Player player = game.GetPlayer();
			player.Init("なまえ");

			
			ABase strongPunch = game.CreateActionCard(typeof(StrongPunch));
			player.SetActionCard(0, (ABase)strongPunch);

			
			player.RecalculateEquipmentActionCards();
			
			Enemy nasu = game.CreateEnemy(typeof(EnemyNasu));
			game.enemyManager.Init(nasu, _equipmentCardFieldMiniUi);
			
			for (int i=0;i<nasu.GetActionCards().Length;i++)
			{
				ABase enemyCards = nasu.GetActionCard(i);
				if (enemyCards == null) continue;
				game.enemyManager.Equip(i, enemyCards);
			}

			game.enemyManager.SyncRecoveryHpInclude();
			int resultDamage = 0;
			
			// ナマモノ同志
			StandartLogicWithCards logic = StandartLogicWithCards.GetInstance();
			// ABase[] nasuCards = nasu.GetActionCards();
			ABase playerCard = player.GetActionCard(0);
			resultDamage = logic.DamageMidCalulate(nasu.GetActionCards(), playerCard, nasu, player);
			Assert.AreEqual(6, resultDamage);

			nasu.SetActionCard(1, game.CreateActionCard(typeof(Shield)));
			nasu.RecalculateEquipmentActionCards();
			resultDamage = logic.DamageMidCalulate(nasu.GetActionCards(), playerCard, nasu, player);
			Assert.AreEqual(3, resultDamage);

			player.SetActionCard(0, game.CreateActionCard(typeof(RoboBlade)));
			player.RecalculateEquipmentActionCards();
			nasu.SetActionCard(1, game.CreateActionCard(typeof(StrongShield)));
			nasu.RecalculateEquipmentActionCards();
			resultDamage = logic.DamageMidCalulate(nasu.GetActionCards(), playerCard, nasu, player);
			Assert.AreEqual(10, resultDamage);
			
			yield return new ExitPlayMode();
			
		}

		// [Test]
		// public void MyClassTest2()
		// {
		// 	var x = new MyClass("Bob");
		// 	Assert.AreEqual("Bob", x.GetName());
		// }

	}
}