using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Skysemi.With.Events
{
    public class CalculateActionCardsEventSender : BaseEventSender 
    {
//    	public delegate void CalculateActionCardsDelegate(CalculateActionCardsEventArgs param);
//	    public event CalculateActionCardsDelegate Eventer = delegate (CalculateActionCardsEventArgs param) { };
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