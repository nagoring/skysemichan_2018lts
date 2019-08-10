using Skysemi.With.CardUI;
using UnityEngine;

namespace Skysemi.With.Scenes.WorldObject
{
    public interface ISetUpEnemy
    {
        MonoBehaviour GetMonoBehaviour();
        IEquipmentCardFieldUi GetEquipmentCardFieldUi();
        GameObject GetEnemyLayer();
        GameObject GetBtnNavigationWindow();
    }
}