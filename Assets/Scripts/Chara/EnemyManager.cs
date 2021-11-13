using UnityEngine;
using Skysemi.With.CardUI;
using Skysemi.With.Chara.Enemies;
using UnityEngine.UI;

namespace Skysemi.With.Chara
{
	public class EnemyManager
	{
		private Skysemi.With.CardUI.EquipmentCardFieldMiniUi _equipmentCardFieldUi;

		private Enemy _enemy;

		public void Init(Enemy enemy, Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldUiMini)
		{
			_enemy = enemy;
			_equipmentCardFieldUi = equipmentCardFieldUiMini;
		}


		public Enemy GetEnemy()
		{
			return _enemy;
		}


		public void Equip(Enemy enemy, int index, ActionCards.ABase actionCard)
		{
			_equipmentCardFieldUi.Equip(enemy, index, actionCard);
		}

		private void SetEquipmentCardField(Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldUi)
		{
			_equipmentCardFieldUi = equipmentCardFieldUi;
		}

		/// <summary>
		/// HPを全回復してステータスを同期させる
		/// </summary>
		public void SyncRestoreHpInclude()
		{
			Skysemi.With.CardUI.EquipmentCardFieldMiniUi equipmentCardFieldUi = _equipmentCardFieldUi;
			SetEquipmentCardField(equipmentCardFieldUi);
			_enemy.RecalculateEquipmentActionCardsAAA();
			_enemy.SyncUiParam();
			_enemy.RestoreHp();
		}


		public void CreateEnemy(MonoBehaviour mono, EquipmentCardFieldMiniUi inEquipmentCardFieldUi)
		{
			EnemyFactory enemyFactory = EnemyFactory.GetInstance();
			Enemy targetEnemy = enemyFactory.Factory(mono);
			targetEnemy.Init();
			Init(targetEnemy, inEquipmentCardFieldUi);
			int loopIndex = 0;
			foreach (ActionCards.ABase card in targetEnemy.GetActionCards())
			{
				if (card == null) continue;
				Equip(targetEnemy, loopIndex, card);
				loopIndex++;
				if (loopIndex >= 3) break;
			}

			// Equip(0, mono.gameObject.AddComponent<NasuHeart>());
			// Equip(1, mono.gameObject.AddComponent<MagicAddMaxHp>());
			// Equip(2, mono.gameObject.AddComponent<Punch>());
			// Equip(3, mono.gameObject.AddComponent<StrongPunch>());
			SyncRestoreHpInclude();

//            Game game = Game.instance;
//            if (world.WorldMode != EWorldMode.BATTLE) return;
//            imageEnemeyStatusWindow.SetActive(true);
		}

		public void displayEnemy(GameObject enemeyLayer)
		{
			Enemy enemy = GetEnemy();

			Sprite sprite = Resources.Load<Sprite>(enemy.GetImageFilePath());
			Image childImage = enemeyLayer.GetComponent<Image>();
			childImage.sprite = sprite;
			childImage.SetAlpha(1.0f);
			enemy.gameObject.SetActive(true);
			enemy.gameObject.transform.SetParent(enemeyLayer.transform, false);
//            enemeyLayer.SetActive(true);
		}
	}
}