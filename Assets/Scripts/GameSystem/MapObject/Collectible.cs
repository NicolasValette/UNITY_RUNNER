using Runner.MapObject;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Runner.MapObject
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private UnityEvent OnCollect;
       
        private ParticleSystem _particleCollectible;
        private Renderer _renderer;
        // Start is called before the first frame update
        void Start()
        {
            _renderer = GetComponentInChildren<MeshRenderer>();
            _particleCollectible = GetComponent<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 euleurAngles = new Vector3(0f, 1f, 0f) * _speed * Time.deltaTime;

            transform.rotation *= Quaternion.Euler(euleurAngles);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("collect");
                _particleCollectible.Play();
                _renderer.enabled = false;
                StartCoroutine(WaitBeforeAction(1f, () =>
                {
                    Destroy(gameObject, 1f);
                }));
                OnCollect.Invoke();
            }
        }

        private IEnumerator WaitBeforeAction(float duration, Action action)
        {
            yield return new WaitForSeconds(duration);
            action();
        }
    }
}
