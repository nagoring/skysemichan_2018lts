using System;
using Skysemi.With.Chara;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Skysemi.With.Events
{
    public class SyncPlayerStatusEventSender : BaseEventSender
    {
        public override event EventDelegate Eventer = delegate (BaseEventArgs param) { };

        public override void Send(BaseEventArgs e)
        {
            OnEventHandle((BaseEventArgs)e);
        }
        protected virtual void OnEventHandle(BaseEventArgs e)
        {
            this.Eventer(e);
//            EventHandle?.Invoke(this, e);
        }

    }
}