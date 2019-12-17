namespace GameScene.EventAggregator
{
    public static class EventAggregator
    {
        public static readonly TheGameIsOverEvent GameIsOver = new TheGameIsOverEvent();

        public static readonly ButtonsActionsHaveChangedEvent ButtonsActionsHaveChanged =
            new ButtonsActionsHaveChangedEvent();

        public static readonly MoveCompleteEvent MoveComplete = new MoveCompleteEvent();
    }
}