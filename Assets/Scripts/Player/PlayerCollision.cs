using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace Runner
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField]
        private GameObject _rootPlayerGO;
        [SerializeField]
        private MeshRenderer _playerRenderer;
        [SerializeField]
        private ParticleSystem _deathParticleSystem;
        [SerializeField]
        private UnityEvent OnPlayerDeath;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                //_rootPlayerGO.GetComponent<SplineAnimate>().Pause();
                _rootPlayerGO.GetComponent<MovePlayerOnSpline>().Stop();
                _deathParticleSystem.Play();
                _playerRenderer.enabled = false;
                OnPlayerDeath.Invoke();
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Door"))
            {
               // Debug.Log("time : " + _rootPlayerGO.GetComponent<SplineAnimate>().NormalizedTime);

               //Debug.Log("duration : " + _rootPlayerGO.GetComponent<SplineAnimate>().Duration);
               // Debug.Log("speed : " + _rootPlayerGO.GetComponent<SplineAnimate>().MaxSpeed);
               // _rootPlayerGO.GetComponent<SplineAnimate>().MaxSpeed = 50f;
               // Debug.Log("time : " + _rootPlayerGO.GetComponent<SplineAnimate>().NormalizedTime);
               // Debug.Log("duration2 : " + _rootPlayerGO.GetComponent<SplineAnimate>().Duration);
               // Debug.Log("speed2 : " + _rootPlayerGO.GetComponent<SplineAnimate>().MaxSpeed);

            }

        }
    }
}
