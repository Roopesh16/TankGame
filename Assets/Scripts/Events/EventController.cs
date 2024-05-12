using System;

namespace TankGame.Events
{
    public class EventController
    {
        private event Action baseEvent;
        public void Invoke() => baseEvent.Invoke();
        public void AddListener(Action listener) => baseEvent += listener;
        public void RemoveListener(Action listener) => baseEvent -= listener;
    }
}