using System;
using System.Collections.Generic;

namespace GameScene
{
    public class EventAggregator
    {
        public static readonly TheGameIsOverEvent GameIsOver = new TheGameIsOverEvent();
        private static EventAggregator _instance = new EventAggregator();

        public static EventAggregator Instance
        {
            get { return _instance ?? (_instance = new EventAggregator()); }
        }
    }

    public class TheGameIsOverEvent
    {
        private readonly List<Action<Basket>> _callbacks = new List<Action<Basket>>();

        public void Subscribe(Action<Basket> callback)
        {
            _callbacks.Add(callback);
        }

        public void Publish(Basket basket)
        {
            foreach (var variable in _callbacks)
            {
                variable(basket);
            }

            _callbacks.Clear();
        }
    }
}