using Skysemi.With.CardUI;
using Skysemi.With.Chara;

namespace Skysemi.With.Events
{
    public class SyncStatusEnemyEventArgs
    {
        public SyncStatusEnemyEventArgs(CharaParameter _charaParameter)
        {
            CharaParameter = _charaParameter;
        }
        public CharaParameter CharaParameter { get; set; } 
//        public IEquipmentCardFieldUi EquipmentCardFieldUi { get; set; } 

    }
}