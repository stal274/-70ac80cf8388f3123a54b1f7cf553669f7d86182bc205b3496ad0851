using System;
using System.Collections.Generic;

namespace GameScene.EventAggregator
{
    public abstract class EventBase
    {
        internal readonly List<Action<object>> Callbacks =
            new List<Action<object>>();

        public void Subscribe(Action<object> callback)
        {
            Callbacks.Add(callback);
        }

        public void Unsubscribe(Action<object> callback)
        {
            Callbacks.Remove(callback);
        }

        public void Clear()
        {
            Callbacks.Clear();
        }
    }
}