﻿using System;

namespace Skysemi.With.Events
{
    public class Programmer
    {
        public event EventHandler GetPayRise;
        private readonly System.Random _Random = new System.Random();

        public Programmer(int id)
        {
            
        }

        public void Work(int quantity)
        {
            if (_Random.Next(1000) == 0)
                OnGetPayRise(EventArgs.Empty);
        }        
        protected virtual void OnGetPayRise(EventArgs e)
        {
            GetPayRise?.Invoke(this, e);  // C#6.0以上でのみ可能
        }
    }
}