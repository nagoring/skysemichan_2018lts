using System;

namespace Skysemi.With.Events
{
    public interface IEventSender
    {
        void Send(BaseEventArgs e);
        event BaseEventSender.EventDelegate Eventer;
    }
}