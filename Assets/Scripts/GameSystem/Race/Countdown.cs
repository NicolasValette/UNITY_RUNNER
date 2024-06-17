using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Runner
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField]
        private GameObject _rootCountdown;
        [SerializeField]
        private TMP_Text _countdownText;
        [SerializeField]
        private UnityEvent _OnStartRace;
        private bool _isCounting = false;
        private float _countdownTime = 0;
        private int _count;

        private const float SCALEDURATION = 0.75f;
        
        // Start is called before the first frame update
        void Start()
        {
            _countdownText.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isCounting)
            {
                _countdownTime += Time.deltaTime;
                if (_countdownTime >=1)
                {
                    _countdownTime = 0;
                    _count--;
                    StartCoroutine(ScaleNumber(_count));
                    if (_count == 0)
                    {
                        _isCounting = false;
                        _OnStartRace.Invoke();
                    }
                }
            }
        }


        private IEnumerator ScaleNumber(int count)
        {
            float time = 0;
            _countdownText.transform.localScale = Vector3.one;

            _countdownText.text = (count == 0)?"GO !":count.ToString();
            while (time < SCALEDURATION)
            {
                _countdownText.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, time / SCALEDURATION);
                time += Time.deltaTime;
                yield return null;
            }
            _countdownText.transform.localScale = Vector3.zero;
        }
        public void StartCountdown()
        {
            _countdownText.enabled = true;
            _countdownTime = 0;
            _count = 3;
            _isCounting = true;
            StartCoroutine(ScaleNumber(_count));
        }
    }
}
