using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.Player.Previewer
{
    public class Prognosticator : MonoBehaviour
    {
        public enum Indicator
        {
            North,
            East,
            South,
            West
        }
        public enum MapObjectType
        {
            Empty,
            Wall,
            Collectible
        }
        [SerializeField]
        private Color _predictiveWallColor;
        [SerializeField]
        private Color _predictiveColectibleColor;
        [SerializeField]
        private Color _predictiveEmptyColor;

        [SerializeField]
        private Image _northIndicator;
        [SerializeField]
        private Image _eastIndicator;
        [SerializeField]
        private Image _southIndicator;
        [SerializeField]
        private Image _westIndicator;
        [SerializeField]
        private Transform _prognosticatorWiewer;

        private bool _isRotating = false;
        // Start is called before the first frame update
        void Start()
        {
            _northIndicator.color = _predictiveEmptyColor;
            _eastIndicator.color = _predictiveEmptyColor;
            _southIndicator.color = _predictiveEmptyColor;
            _westIndicator.color = _predictiveEmptyColor;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void RotateViewer (float rotationAmount)
        {
            if (!_isRotating)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, -rotationAmount);
                StartCoroutine(RotateSprite(rotation, 1f));
            }
        }
        private IEnumerator RotateSprite(Quaternion rotation, float duration)
        {

            _isRotating = true;
            float time = 0;
            Quaternion startValue = _prognosticatorWiewer.localRotation;

            Quaternion endRotation = _prognosticatorWiewer.localRotation * rotation;


            while (time < duration)
            {
                _prognosticatorWiewer.localRotation = Quaternion.Lerp(startValue, endRotation, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            _prognosticatorWiewer.localRotation = endRotation;

            _isRotating = false;
        }
        

        public void SetColors(Indicator indic, MapObjectType type)
        {
            Color color;
            if (type  == MapObjectType.Collectible)
            {
                color = _predictiveColectibleColor;
            }
            else if (type == MapObjectType.Wall)
            {
                color = _predictiveWallColor;
            }
            else
            {
                color = _predictiveEmptyColor;
            }
            _northIndicator.color = _predictiveEmptyColor;
            _eastIndicator.color = _predictiveEmptyColor;
            _southIndicator.color = _predictiveEmptyColor;
            _westIndicator.color = _predictiveEmptyColor;
            if (indic == Indicator.North)
            {
                _northIndicator.color = color;
            }
            else if (indic == Indicator.East)
            {
                _eastIndicator.color = color;
            }
            else if (indic == Indicator.South)
            {
                _southIndicator.color = color;
            }
            else if (indic == Indicator.West)
            {
                _westIndicator.color = color;
            }
        }

     
    }
}
