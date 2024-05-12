namespace TankGame.Events
{
    public class EventService
    {
        public EventController OnGameStart { get; private set; }
        public EventController OnGameOver { get; private set; }

        public EventService()
        {
            OnGameStart = new EventController();
            OnGameOver = new EventController();
        }
    }
}