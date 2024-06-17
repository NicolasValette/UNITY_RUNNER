using UnityEngine;
using UnityEngine.Events;

namespace Runner.Events
{
    public class BaseGameEventListener<T> : MonoBehaviour
    {
        // Game event to lisen to
        [SerializeField]
        private BaseGameEvent<T> _gameEvent;
        //Response when game event is raised
        [SerializeField]
        private UnityEvent<T> _response;

        private void OnEnable()
        {
            _gameEvent.Subscribe(this);
        }
        private void OnDisable()
        {
            _gameEvent.Unsubscribe(this);
        }
        public void OnEventRaised(T item)
        {
            _response.Invoke(item);
        }
    }
  
}
