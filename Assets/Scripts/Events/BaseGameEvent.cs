using System.Collections.Generic;
using UnityEngine;

namespace Runner.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private List<BaseGameEventListener<T>> _listeners = new List<BaseGameEventListener<T>>();

        public void Subscribe(BaseGameEventListener<T> listener)
        {
            _listeners.Add(listener);
        }
        public void Unsubscribe(BaseGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
        public void Raise(T item)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(item);
            }
        }
    }
}
