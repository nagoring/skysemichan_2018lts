using Skysemi.With.CardUI;
using Skysemi.With.Chara;
using IEquipmentCardField = Skysemi.With.CardUI.IEquipmentCardField;

namespace Skysemi.With.Events
{
    public class SyncStatusEnemyEventArgs
    {
        public SyncStatusEnemyEventArgs(CharaParameter _charaParameter)
        {
            CharaParameter = _charaParameter;
        }
        public CharaParameter CharaParameter { get; set; } 
//        public IEquipmentCardField EquipmentCardField { get; set; } 

    }
}