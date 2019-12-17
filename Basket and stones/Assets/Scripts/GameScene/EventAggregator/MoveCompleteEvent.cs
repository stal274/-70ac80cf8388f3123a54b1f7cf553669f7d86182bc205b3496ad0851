namespace GameScene.EventAggregator
{
    public class MoveCompleteEvent : EventBase
    {
        public void Publish(object obj)
        {
            foreach (var variable in Callbacks)
            {
                variable(obj);
            }
        }
    }
}