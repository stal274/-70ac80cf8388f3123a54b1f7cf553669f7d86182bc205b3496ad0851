namespace GameScene.EventAggregator
{
    public class TheGameIsOverEvent : EventBase
    {
        public void Publish(Basket basket)
        {
            foreach (var variable in Callbacks)
            {
                variable(basket);
            }

            Callbacks.Clear();
        }
    }
}