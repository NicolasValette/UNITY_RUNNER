using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Camera
{
    public class ShakeCamera : MonoBehaviour
    {
        // Transform of the camera to shake. Grabs the gameObject's transform
        [SerializeField]
        private Transform camTransform;

        // How long the object should shake for.
        [SerializeField]
        private float shakeDuration = 0f;

        // Amplitude of the shake. A larger value shakes the camera harder.
        [SerializeField]
        private float shakeAmount = 0.7f;
        private float decreaseFactor = 1.0f;

        private Vector3 originalPos;
        private bool _isShaking = false;



        void OnEnable()
        {
            originalPos = camTransform.localPosition;
            _isShaking = false;
        }

        void Update()
        {
            if (_isShaking)
            {

                if (shakeDuration > 0)
                {
                    camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                    shakeDuration -= Time.deltaTime * decreaseFactor;
                }
                else
                {
                    shakeDuration = 0f;
                    camTransform.localPosition = originalPos;
                }
            }
        }
        public void Shake ()
        {
            _isShaking=true;
        }
        public void StopShake()
        {
            _isShaking = false;
        }
    }
}
