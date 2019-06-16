using UnityEditor;

namespace Skysemi.With.Chara
{
    public interface ICalcEquipmentCards
    {
        ICharaParameter Calculate(IEquipmentCardField cardField);
    }
}