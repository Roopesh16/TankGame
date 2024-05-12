namespace TankGame.Events
{
    public class EventService
    {
        public EventController<bool> OnLevelStart { get; private set; }
        public EventController OnGameOver { get; private set; }
        public EventController OnLevelComplete { get; private set; }

        public EventService()
        {
            OnLevelStart = new EventController<bool>();
            OnGameOver = new EventController();
            OnLevelComplete = new EventController();
        }
    }
}