using System.Collections;
using System.Collections.Generic;
using Skysemi.With.Chara;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using Skysemi.With.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.Scenes.WorldObject
{
    public class EncountDebugRule : IEncountRule
    {
        private int _boss_encount_progress = 3;
        private int _random_encount = 10;
        private bool _is_boss = false;
        private EWorldMode _eWorldMode = EWorldMode.WALKING;
        private IGoFrontStateChangeParameter _worldParameter;

        public EncountDebugRule(IGoFrontStateChangeParameter worldParameter)
        {
            _worldParameter = worldParameter;
        }

        public void Run()
        {
            Game game = Game.instance;
            Player player = game.GetPlayer();
            _random_encount--;
            if (player.Progress == 0) return;

            if (player.Progress == _boss_encount_progress)
            {
                Debug.Log("ボス出現！！！");
                _is_boss = true;
                _eWorldMode = EWorldMode.BATTLE;
				EventManager.instance.EncountEnemyBoss(World.instance);
            }
            else if (_random_encount <= 0)
            {
                Debug.Log("雑魚出現！！！");
                game.PlayMusicBattle();
                _random_encount = Random.Range(1, 8) + 10;
                _is_boss = false;
                _eWorldMode = EWorldMode.BATTLE;
                // EventManager.instance.Enco(World.instance);
            }
        }

        public EWorldMode GetWorldMode()
        {
            return _worldParameter.GetWorldMode();
        }



        public bool IsBoss()
        {
            return _is_boss;
        }

        public bool IsEncount()
        {
            return _random_encount <= 0;
        }

        public void OutputEnemy(ISetUpEnemy iSetUpEnemy)
        {
            Debug.Log("OutputEnemy");
            Game game = Game.instance;
//            if (_worldParameter.GetWorldMode() != EWorldMode.BATTLE) return;

            game.eventManager.DoWayEvent(iSetUpEnemy);
            Enemy enemy = game.enemyManager.GetEnemy();
            //ナビゲーションウィンドウの表示
            iSetUpEnemy.GetBtnNavigationWindow().SetActive(true);
            Text navText = iSetUpEnemy.GetBtnNavigationWindow().GetComponentInChildren<Text>();
            navText.text = enemy.msg;
            navText.color = new Color(255, 0, 0);


//			game.turn = ETurn.PLAYER;

//			this.WayEvent += game.enemyManager.createEnemy;
//			this.WayEvent += game.uiManager.EncountEnemeyBegin;
//			this.WayEvent += game.skysemiChanMsg.EnemyCommentary;
        }
    }
    //==================
//         private readonly IGoFrontStateChangeParameter _worldParameter;
//         private bool _isBoss = true;
//         private int _boss_encount_progress = 10;
//         private int _random_encount = 50;
//
//         private EWorldMode _eWorldMode = EWorldMode.WALKING;
//         
//
//         public EncountDebugRule(IGoFrontStateChangeParameter worldParameter)
//         {
//             _worldParameter = worldParameter;
//         }
//
//         public void Run()
//         {
//             Game game = Game.instance;
//             Player player = game.GetPlayer();
//             _random_encount--;
//             if (player.Progress == 0) return;
//             
//             if (player.Progress == _boss_encount_progress)
//             {
//                 _isBoss = true;
//                 _eWorldMode = EWorldMode.BATTLE;
//                 EventManager.instance.EncountEnemyBoss(World.instance);
//             }
//             else if(_random_encount <= 0){
//                 game.PlayMusicBattle();
//                 _random_encount = Random.Range(1, 8) + 10;
//                 _isBoss = false;
//                 _eWorldMode = EWorldMode.BATTLE;
// //			WayEventParam param = new WayEventParam();
// //			this.WayEvent(param);
// //                EncountEvent();
//             }
//         }
//
//     //     public void Run()
//     //     {
//     //         Debug.Log("CheckingProgress");
//     //         Game game = Game.instance;
//     //         int boss_encount_progress = 5;
//     //         Player player = game.GetPlayer();
//     //         EStage eStage = game.destinationPlace;
//     //         if (player.Progress == boss_encount_progress)
//     //         {
// 				// // eventManager.EncountEnemyBoss();
//     //         }
//     //     }
//         public void OutputEnemy(ISetUpEnemy iSetUpEnemy)
//         {
//             Game game = Game.instance;
// //            if (_worldParameter.GetWorldMode() != EWorldMode.BATTLE) return;
//             
//             game.eventManager.DoWayEvent(iSetUpEnemy);
//             Enemy enemy = game.enemyManager.GetEnemy();
//             //ナビゲーションウィンドウの表示
//             iSetUpEnemy.GetBtnNavigationWindow().SetActive(true);
//             Text navText = iSetUpEnemy.GetBtnNavigationWindow().GetComponentInChildren<Text>();
//             navText.text = enemy.msg;
//             navText.color = new Color(255, 0, 0);
//             
//             game.eventManager.DoWayEvent(iSetUpEnemy);
//             World.instance.turn = ETurn.PLAYER;
// //			this.WayEvent += game.enemyManager.createEnemy;
// //			this.WayEvent += game.uiManager.EncountEnemeyBegin;
// //			this.WayEvent += game.skysemiChanMsg.EnemyCommentary;
//         }
//         public EWorldMode GetWorldMode()
//         {
//             return _worldParameter.GetWorldMode();
//         }
//
//
//
//         public bool IsBoss()
//         {
//             return _isBoss;
//         }
//
//         public bool IsEncount()
//         {
//             return _random_encount <= 0;
//         }
        
        //
        // public EWorldMode GetWorldMode()
        // {
        //     return EWorldMode.WALKING;
        // }
        //
        // public int GetRandomEncount()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public bool IsBoss()
        // {
        //     return _isBoss;
        // }
        //
        // public bool IsEncount()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
    // }
}
