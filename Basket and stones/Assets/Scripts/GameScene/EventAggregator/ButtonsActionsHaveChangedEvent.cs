namespace GameScene.EventAggregator
{
    public class ButtonsActionsHaveChangedEvent : EventBase
    {
        public void Publish(SafeDepositOfButtonActions bank)
        {
            foreach (var variable in Callbacks)
            {
                variable(bank);
            }
        }
    }
}