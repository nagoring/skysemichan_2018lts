using System;
using Skysemi.With.Chara;

namespace Skysemi.With.Events
{
    public class SyncStatusEventArgs : EventArgs
    {
        public CharaParameter CharaParameter { get; set; }

        public SyncStatusEventArgs(CharaParameter charaParameter)
        {
            CharaParameter = charaParameter;
        }
    }
}