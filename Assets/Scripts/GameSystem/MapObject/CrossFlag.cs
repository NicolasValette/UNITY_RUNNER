using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runner.MapObject
{
    public class CrossFlag : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnCrossFlag;

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
            if (other.CompareTag("Player"))
            {
                OnCrossFlag.Invoke();
            }
        }
    }
}
