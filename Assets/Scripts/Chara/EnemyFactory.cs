using System.Collections.Generic;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Scenes;
using UnityEngine;

namespace Skysemi.With.Chara
{
	public class EnemyFactory
	{
		private static EnemyFactory _enemyFactory = null;

		public static EnemyFactory GetInstance()
		{
			if (_enemyFactory == null)
			{
				_enemyFactory = new EnemyFactory();
			}

			return _enemyFactory;
		}

		public Enemy Factory(MonoBehaviour mono)
		{
			if (Constants.Debug == 1)
			{
				// return CreateCharaObject(mono, EChara.Nasu);
			}

			Game game = Game.instance;
			Player player = game.GetPlayer();
			EStage eStage = game.destinationPlace;
			int randomValue = Random.Range(0, 100);
			switch (eStage)
			{
				case EStage.WALKING_COURSE:
					return game.CreateEnemy(typeof(EnemyCarrot));
					//雑魚：なす、きゅうり、人参　BOSS：りんご
					if (World.instance.isBoss)
					{
						return CreateCharaObject(mono, EChara.Ringo);
					}

					if (player.Progress >= 50)
					{
						if (randomValue >= 90)
						{
							return game.CreateEnemy(typeof(EnemyNasu));
						}
						else if (randomValue >= 60)
						{
							return game.CreateEnemy(typeof(EnemyKyuuri));
						}
						else
						{
							return game.CreateEnemy(typeof(EnemyCarrot));
						}
					}
					else
					{
						if (randomValue >= 60)
						{
							return game.CreateEnemy(typeof(EnemyNasu));
							return CreateCharaObject(mono, EChara.Nasu);
						}
						else if (randomValue < 60)
						{
							return game.CreateEnemy(typeof(EnemyKyuuri));
						}
						
					}

					break;
//                case EStage.GOTO_SUICA:
//                    //雑魚:なす、きゅうり、ダイコン、ブロッコリ BOSS:スイカ
//                    if (game.isBoss)
//                    {
//                        return enemySuica;
//                    }
//				
//                    if (randomValue >= 75)
//                    {
//                        if (Player.instance.Progress > 10)
//                        {
//                            return enemyBrocoli;
//                        }
//                        else
//                        {
//                            return enemyKyuuri;
//                        }
//                    }
//                    else if(randomValue >= 40)
//                    {
//                        return enemyDaikon;
//                    }
//                    else if (randomValue >= 20)
//                    {
//                        return enemyKyuuri;
//                    }
//                    else
//                    {
//                        return enemyNasuPrefab;
//                    }
//                    break;
//                case EStage.METAL_DEFENCE:
//                    //雑魚:ダイコン、ブロッコリ、ほうれんそう、トマト BOSS:ブレードロボ
//                    if (game.isBoss)
//                    {
//                        return enemyBladeRobo;
//                    }
//				
//                    if (randomValue >= 75)
//                    {
//                        return enemyHourensou;
//                    }
//                    else if(randomValue >= 40)
//                    {
//                        return enemyTomato;
//                    }
//                    else if (randomValue >= 20)
//                    {
//                        return enemyBrocoli;
//                    }
//                    else
//                    {
//                        return enemyDaikon;
//                    }
//                case EStage.OUTSIDE_ROAD:
//                    //雑魚:カメラインスタビライザー,パワーショベル,電工ドラム BOSS:ドロドロナ不快ナモノ
//                    if (game.isBoss)
//                    {
//                        Debug.Log("ボス");
//                        return enemyDoroDoroHukai;
//                    }
//                    if (randomValue >= 75)
//                    {
//                        Debug.Log("パワーショベル");
//                        return enemyPowerShovel;
//                    }
//                    else if(randomValue >= 40)
//                    {
//                        Debug.Log("電工ドラム");
//                        return enemyCableReel;
//                    }
//                    else
//                    {
//                        Debug.Log("カメラスタビライザー");
//                        return enemyCameraStabilizer;
//                    }
//                case EStage.OTHER_STAGE1:
//                    //BOSS：にわとり
//                    if (game.isBoss)
//                    {
//                        return enemyNiwatori;
//                    }
//
//                    break;
			}

			return CreateCharaObject(mono, EChara.Nasu);
		}

		public Enemy CreateCharaObject(MonoBehaviour mono, EChara eChara)
		{
			Dictionary<EChara, System.Type> dict = new Dictionary<EChara, System.Type>()
			{
				{EChara.Nasu, typeof(EnemyNasu)},
				{EChara.Kyuuri, typeof(EnemyKyuuri)},
				{EChara.Ringo, typeof(EnemyRingo)},
			};
			return mono.gameObject.AddComponent(dict[eChara]) as Enemy;
		}
	}
}