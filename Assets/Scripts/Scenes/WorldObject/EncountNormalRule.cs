using Skysemi.With.Chara;
using Skysemi.With.Chara.Enemies;
using Skysemi.With.Core;
using Skysemi.With.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Skysemi.With.Scenes.WorldObject
{
    public class EncountNormalRule : IEncountRule
    {
        private int _boss_encount_progress = 100;
        private int _random_encount = 5;
        private bool _is_boss = false;
        private EWorldMode _eWorldModel = EWorldMode.WALKING;
        private IGoFrontStateChangeParameter _worldParameter;
        public EncountNormalRule(IGoFrontStateChangeParameter worldParameter)
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
                _is_boss = true;
                _eWorldModel = EWorldMode.BATTLE;
//				eventManager.EncountEnemyBoss();
            }
            else if(_random_encount <= 0){
//			game.PlayMusicBattle();
                _random_encount = Random.Range(1, 8) + 10;
                _is_boss = false;
                _eWorldModel = EWorldMode.BATTLE;
//			WayEventParam param = new WayEventParam();
//			this.WayEvent(param);
//                EncountEvent();
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
            Game game = Game.instance;
            if (_worldParameter.GetWorldMode() != EWorldMode.BATTLE) return;
            Enemy enemy = game.enemyManager.GetEnemy();
            game.enemyManager.createEnemy(iSetUpEnemy.GetMonoBehaviour(), iSetUpEnemy.GetEquipmentCardFieldUi());
            game.enemyManager.displayEnemy(iSetUpEnemy.GetEnemyLayer());
			
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
        
//        private void EncountEvent()
//        {
//
//        }
    }
}