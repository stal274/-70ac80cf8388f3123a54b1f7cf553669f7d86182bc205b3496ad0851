using System;
using System.Collections.Generic;

namespace GameScene
{
    public static class EventAggregator
    {
        public static readonly TheGameIsOverEvent GameIsOver = new TheGameIsOverEvent();
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
            foreach (var VARIABLE in _callbacks)
            {
                VARIABLE(basket);
            }
        }
    }
}