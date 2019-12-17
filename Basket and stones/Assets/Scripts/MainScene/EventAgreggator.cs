namespace MainScene
{
    public class EventAggregator
    {
        public static readonly BackpackIsFull GameIsOver = new BackpackIsFull();
        private static EventAggregator _instance;

        public static EventAggregator Instance
        {
            get { return _instance ?? (_instance = new EventAggregator()); }
        }
    }

    public class BackpackIsFull
    {
        /*private readonly List<Action<Basket>> _callbacks = new List<Action<Basket>>();

        public void Subscribe(Action<Backpack> callback)
        {
         
        }

        public void Publish(Basket basket)
        {
            foreach (var variable in _callbacks)
            {
                variable(basket);
            }

            _callbacks.Clear();
        }*/
    }
}