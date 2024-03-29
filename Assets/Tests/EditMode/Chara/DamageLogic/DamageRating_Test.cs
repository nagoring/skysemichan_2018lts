﻿using System.Collections;
using NUnit.Framework;
using Skysemi.With.CardUI;
using UnityEngine.TestTools;
using Skysemi.With.Chara;
using Skysemi.With.Chara.DamageLogic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Events;
using Skysemi.With.Scenes;
using Skysemi.With.Scenes.WorldObject;
using UnityEngine;

namespace Tests
{
	public class DamageRating_Test
	{
		// A Test behaves as an ordinary method
		[UnityTest]
		public IEnumerator DamageRating_TestDamageRating_Calc()
		{
			yield return new EnterPlayMode();
			Game game = Game.instance;
			string PrefabPath = "Prefabs/CardUI/EquipmentCardFieldMiniUi";
			GameObject obj = (GameObject) Resources.Load(PrefabPath);
			GameObject instance = (GameObject) Object.Instantiate(obj, Vector2.zero, Quaternion.identity);
			EquipmentCardFieldMiniUi equipmentCardFiled = instance.GetComponent<EquipmentCardFieldMiniUi>();
			equipmentCardFiled.Init();
			game.enemyManager.CreateEnemy(World.instance, equipmentCardFiled);
			Player player = game.GetPlayer();
			player.Init("なまえ");
			
			Enemy nasu = game.CreateEnemy(typeof(EnemyNasu));
			float result = DamageRating.Calc(nasu, player);
			Assert.AreEqual(1.0f, result);
			
			Enemy robo = game.CreateEnemy(typeof(EnemyBladeRobo));
			float resultRobo = DamageRating.Calc(robo, player);
			Assert.AreEqual(1.5f, resultRobo);
			
			Enemy split = game.CreateEnemy(typeof(EnemyJusticeLivingSplit));
			float resultSplit = DamageRating.Calc(split, player);
			Assert.AreEqual(0.5f, resultSplit);
			yield return new ExitPlayMode();
		}
	}
}