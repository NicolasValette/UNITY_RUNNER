using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runner.MapObject
{
    public class Door : MonoBehaviour
    {

        [SerializeField]
        private UnityEvent OnNewLap;
        [SerializeField]
        private GameObject _doorObj;

        private bool _isRaceStarting = false;
        // Start is called before the first frame update
        void Start()
        {
            _doorObj.SetActive(false);
            _isRaceStarting = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (_isRaceStarting)
            {
                if (other.CompareTag("Player"))
                {
                    OnNewLap.Invoke();
                }
            }
        }
        public IEnumerator StartRaceInOneSecond()
        {
            yield return new WaitForSeconds(1);
            _doorObj.SetActive(true);
            _isRaceStarting=true;
        }
        public void StartRace()
        {
            StartCoroutine(StartRaceInOneSecond());
        }
    }
}
