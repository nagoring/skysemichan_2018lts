using System;

namespace Skysemi.With.Events
{
    abstract public class BaseEventSender : IEventSender 
    {
        abstract public void Send(BaseEventArgs e);
        
        public delegate void EventDelegate(BaseEventArgs param);
        public virtual event EventDelegate Eventer = delegate (BaseEventArgs param) { };
    }
}