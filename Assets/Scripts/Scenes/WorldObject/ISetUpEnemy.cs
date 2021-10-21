using Skysemi.With.CardUI;
using UnityEngine;

namespace Skysemi.With.Scenes.WorldObject
{
    public interface ISetUpEnemy
    {
        MonoBehaviour GetMonoBehaviour();
        EquipmentCardFieldMiniUi GetEquipmentCardFieldUi();
        GameObject GetEnemyLayer();
        GameObject GetBtnNavigationWindow();
    }
}