namespace Skysemi.With.Events
{
    public class StandartEventSender : BaseEventSender 
    {
        public override event EventDelegate Eventer = delegate (BaseEventArgs param) { };
        public override void Send(BaseEventArgs e)
        {
            OnEventHandle((BaseEventArgs)e);
        }
        protected virtual void OnEventHandle(BaseEventArgs e)
        {
            this.Eventer(e);
        }
    }
}