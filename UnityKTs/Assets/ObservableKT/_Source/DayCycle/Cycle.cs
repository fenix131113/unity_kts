using System.Collections.Generic;
using ObservableKT._Source.Observable;
using UnityEngine;

namespace ObservableKT._Source.DayCycle
{
    public class Cycle : MonoBehaviour, IPublisher
    {
        [SerializeField] private float cycleTime;

        private float _timer;
        private float _progress;

        private readonly List<ISubscriber> _subscribers = new();

        private void Update()
        {
            if (_timer <= cycleTime)
                _timer += Time.deltaTime;
            else
                _timer = 0;

            _progress = _timer / cycleTime;
            Publish(_progress);
        }

        public void Register(ISubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
                _subscribers.Add(subscriber);
        }

        public void Unregister(ISubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
                _subscribers.Remove(subscriber);
        }

        public void Publish(float progress)
        {
            foreach (var subscriber in _subscribers)
                subscriber.Notify(progress);
        }
    }
}