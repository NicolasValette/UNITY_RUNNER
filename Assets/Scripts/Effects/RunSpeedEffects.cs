using Runner.Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Effects
{
    public class RunSpeedEffects : MonoBehaviour
    {
        [SerializeField]
        private float _speedForAnimation = 10;
        [SerializeField]
        private float _speedForParticle = 18;
        [SerializeField]
        private float _speedForDust = 14;
        [SerializeField]
        private float _speedForShake = 20;
        [SerializeField]
        private Animator _speedAnimator;
        [SerializeField]
        private ParticleSystem _speedParticleEffect;
        [SerializeField]
        private ParticleSystem _dustParticleEffect;
        [SerializeField]
        private ShakeCamera _shakeCamera;
        // Start is called before the first frame update
        void Start()
        {
            _speedAnimator.enabled = false;
           
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void RunEffects()
        {
            _speedAnimator.enabled = true;
            //_speedParticleEffect.Play();
            //_dustParticleEffect.Play();
            //_shakeCamera.Shake();
        }
        public void StopEffects()
        {
            _speedAnimator.enabled = false;
            _speedParticleEffect.Stop();
            _dustParticleEffect.Stop();
            _shakeCamera.StopShake();
        }

        public void AddSpeedEffectBasedOnSpeed(float speed)
        {
            if (_speedForAnimation <= speed)
            {
                _speedAnimator.enabled = true;
            }
            if (_speedForParticle <= speed)
            {
                _speedParticleEffect.Play();
            }
            if (_speedForDust <= speed)
            {
                _dustParticleEffect.Play();
            }
            if (_speedForShake <= speed)
            {
                _shakeCamera.Shake();
            }
        }
    }
}
