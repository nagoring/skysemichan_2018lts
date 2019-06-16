using System;

namespace Skysemi.With.Events
{
    public abstract class BaseEventSender : IEventSender 
    {
        public abstract  void Send(BaseEventArgs e);
        
        public delegate void EventDelegate(BaseEventArgs param);
        public virtual event EventDelegate Eventer = delegate (BaseEventArgs param) { };
    }
}