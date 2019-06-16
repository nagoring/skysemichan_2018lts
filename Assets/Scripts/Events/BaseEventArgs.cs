using System;
using System.Collections;
using Boo.Lang;
using TMPro;

namespace Skysemi.With.Events
{
    public class BaseEventArgs : EventArgs
    {
        private ArrayList _list;
        private object _obj;

        public BaseEventArgs SetObject(object obj)
        {
            _obj = obj;
            return this;
        }
        public object GetObject()
        {
            return _obj;
        }
        public void SetList(ArrayList list)
        {
            _list = list;
        }

        public ArrayList GetList()
        {
            return _list;
        }
    }
}