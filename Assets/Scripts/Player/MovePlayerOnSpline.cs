using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace Runner
{
    public class MovePlayerOnSpline : MonoBehaviour
    {
        [SerializeField]
        private SplineContainer _spline;
        [Header("Base speed attribute")]
        [SerializeField]
        private float _moveSpeed = 10f;
        [SerializeField]
        private float _rotationSpeed = 5f;
        [Header("Speed increment")]
        [SerializeField]
        private float _moveSpeedIncrement = 2f;
        [SerializeField]
        private float _rotationSpeedIncrement = 1f;
        [SerializeField]
        private float _rotationDuration = 1f;
        [SerializeField]
        private Transform _playerRotateTransform;
        [SerializeField]
        private Rigidbody _playerRigidbody;
        [SerializeField]
        private UnityEvent<float> _OnSpeedUp;

        private float _currentDistance = 0f;
        private bool _isRunning;
        private bool _isRotating;

        private void Start()
        {
            _isRunning = false;
        }

        void Update()
        {
            if (_isRunning)
            {


                float currentZRot = transform.rotation.eulerAngles.z;
                // Calculate the target position on the spline
                Vector3 targetPosition = _spline.EvaluatePosition(_currentDistance);

                // Move the character towards the target position on the spline
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);






                //// Calculate the target rotation on the spline
                Vector3 targetDirection = _spline.EvaluateTangent(_currentDistance);

                // Rotate the character towards the target rotation on the spline
                if (targetDirection != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(targetDirection, transform.up);

                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
                }

                Quaternion rot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentZRot);
                transform.rotation = rot;

                // If the end of the spline is reached, loop back to the beginning
                if (_currentDistance >= 1f)
                {
                    _currentDistance = 0f;
                }
                else
                {
                    // Adjust the movement based on the length of the spline
                    float splineLength = _spline.CalculateLength();
                    float movement = _moveSpeed * Time.deltaTime / splineLength;
                    _currentDistance += movement;
                }

            }
        }
        public void Rotate(float rotationAmount)
        {
            if (!_isRotating)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAmount);
                StartCoroutine(Rotate(rotation, _rotationDuration));
            }
        }
        public IEnumerator Rotate(Quaternion rotation, float duration)
        {
            _isRotating = true;
            float time = 0;
            Quaternion startValue = _playerRotateTransform.localRotation;
            Quaternion endRotation = _playerRotateTransform.localRotation * rotation;

            //Quaternion startValuePrognosticator = _prognosticatorRotateTransform.localRotation;
            //Quaternion endRotationPrognosticator = _prognosticatorRotateTransform.localRotation * rotation;

            while (time < duration)
            {
                _playerRotateTransform.localRotation = Quaternion.Lerp(startValue, endRotation, time / duration);
                //  _prognosticatorRotateTransform.localRotation = Quaternion.Lerp(startValuePrognosticator, endRotationPrognosticator, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            _playerRotateTransform.localRotation = endRotation;
            //_prognosticatorRotateTransform.localRotation = endRotationPrognosticator;

            _playerRigidbody.gameObject.transform.localPosition = new Vector3(0f, _playerRigidbody.gameObject.transform.localPosition.y, 0f);
            //_GOPrognosticator.transform.localPosition = new Vector3(0f, _GOPrognosticator.transform.localPosition.y, 0f);
            _isRotating = false;
        }
        public void Run()
        {
            _isRunning = true;
        }
        public void Stop()
        {
            _isRunning = false;
        }
        public void SpeedUp()
        {
            Debug.Log("Speed up !");
            _moveSpeed += _moveSpeedIncrement;
            _rotationSpeed += _rotationSpeedIncrement;
            _OnSpeedUp.Invoke(_moveSpeed);
            Debug.Log("Move speed : " + _moveSpeed);
        }
    }
}
