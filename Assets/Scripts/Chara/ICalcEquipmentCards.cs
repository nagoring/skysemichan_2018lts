using UnityEditor;

namespace Skysemi.With.Chara
{
    public interface ICalcEquipmentCards
    {
        ICharaParameter Calculate(IEquipmentCardFieldChara cardField);
    }
}