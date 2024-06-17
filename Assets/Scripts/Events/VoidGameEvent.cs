using Runner.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Events
{
    [CreateAssetMenu(menuName = "Events/Void Event", fileName = "New Void Event")]
    public class VoidGameEvent : ScriptableObject
    {
        private List<VoidGameEventListener> _listeners = new List<VoidGameEventListener>();

        public void Subscribe(VoidGameEventListener listener)
        {
            _listeners.Add(listener);
        }
        public void Unsubscribe(VoidGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }
    }
}
