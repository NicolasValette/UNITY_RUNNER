using Runner.MapObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Player.Previewer
{
    public class PrognosticatorCollider : MonoBehaviour
    {
        [SerializeField]
        private Prognosticator.Indicator _direction;
        [SerializeField]
        private Prognosticator _rootPrognosticator;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                Debug.Log("Wall");
                _rootPrognosticator.SetColors(_direction, Prognosticator.MapObjectType.Wall);
            }
            else if (other.CompareTag("Collectible"))
            {
                Debug.Log("Collectible");
                _rootPrognosticator.SetColors(_direction, Prognosticator.MapObjectType.Collectible);
            }
        }
    }
}
