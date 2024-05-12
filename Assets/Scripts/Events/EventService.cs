namespace TankGame.Events
{
    public class EventService
    {
        public EventController<bool> OnGameStart { get; private set; }
        public EventController OnGameOver { get; private set; }

        public EventService()
        {
            OnGameStart = new EventController<bool>();
            OnGameOver = new EventController();
        }
    }
}