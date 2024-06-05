using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _railOffset = 2f;
        [SerializeField]
        private Transform _playerTransform;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Left()
        {
            float offset = (_playerTransform.localPosition.x - _railOffset < -_railOffset) ? 0f : -_railOffset;
            
            
            Debug.Log(offset);
           _playerTransform.localPosition += offset * Vector3.right;
        }
        public void Right()
        {
            float offset = (_playerTransform.localPosition.x + _railOffset > _railOffset) ? 0f : _railOffset;
          


            _playerTransform.localPosition += offset * Vector3.right;
        }
    }
}
