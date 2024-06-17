using Runner.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runner.Events
{
    public class VoidGameEventListener : MonoBehaviour
    {
        // Game event to lisen to
        [SerializeField]
        private VoidGameEvent _gameEvent;
        //Response when game event is raised
        [SerializeField]
        private UnityEvent _response;

        private void OnEnable()
        {
            _gameEvent.Subscribe(this);
        }
        private void OnDisable()
        {
            _gameEvent.Unsubscribe(this);
        }
        public void OnEventRaised()
        {
            _response.Invoke();
        }
    }
}
