using System;
using System.Collections;
using Boo.Lang;

namespace Skysemi.With.Events
{
    public class BaseEventArgs : EventArgs
    {
        private object _obj;

        public BaseEventArgs(object obj = null)
        {
            _obj = obj;
        }

        public BaseEventArgs SetObject(object obj)
        {
            _obj = obj;
            return this;
        }
        public object GetObject()
        {
            return _obj;
        }
    }
}