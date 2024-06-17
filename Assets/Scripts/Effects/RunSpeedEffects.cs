using Runner.Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Effects
{
    public class RunSpeedEffects : MonoBehaviour
    {
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
            _speedParticleEffect.Play();
            _dustParticleEffect.Play();
            _shakeCamera.Shake();
        }
        public void StopEffects()
        {
            _speedAnimator.enabled = false;
            _speedParticleEffect.Stop();
            _dustParticleEffect.Stop();
            _shakeCamera.StopShake();
        }
    }
}
