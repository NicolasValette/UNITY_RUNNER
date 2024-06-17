using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

namespace Runner.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _railOffset = 2f;
        //[SerializeField]
        //private Transform _playerTransform;
        [SerializeField]
        private Transform _playerRotateTransform;
        [SerializeField]
        private Rigidbody _playerRigidbody;
        [SerializeField]
        private float _jumpForce;
        [SerializeField]
        private float _rotationDuration = 1f;
        [Header("Previsualizer")]
        [SerializeField]
        private GameObject _GOPrognosticator;
        [SerializeField]
        private Transform _prognosticatorRotateTransform;
        private bool _isRotating;
        private SplineAnimate _splineAnimate;
        private SplineAnimate _splinePrognosticatorAnimate;
        // Start is called before the first frame update
        void Start()
        {
            _splineAnimate = GetComponent<SplineAnimate>();
            _splinePrognosticatorAnimate = _GOPrognosticator.GetComponent<SplineAnimate>();
            _isRotating = false;
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        //public void Left()
        //{
        //    float offset = (Mathf.RoundToInt(_playerTransform.localPosition.x - _railOffset) < -_railOffset) ? 0f : -_railOffset;                        
     
        //   _playerTransform.localPosition += offset * Vector3.right;
        //}
        //public void Right()
        //{
        //    float offset = (Mathf.RoundToInt(_playerTransform.localPosition.x + _railOffset) > _railOffset) ? 0f : _railOffset;
        //    _playerTransform.localPosition += offset * Vector3.right;
        //}
        public void Jump()
        {
            _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
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

            _playerRigidbody.gameObject.transform.localPosition = new Vector3 (0f, _playerRigidbody.gameObject.transform.localPosition.y, 0f);
            //_GOPrognosticator.transform.localPosition = new Vector3(0f, _GOPrognosticator.transform.localPosition.y, 0f);
            _isRotating = false;
        }
        public void Run()
        {
            _splineAnimate.Play();
            _splinePrognosticatorAnimate.Play();
        }
    }
}
