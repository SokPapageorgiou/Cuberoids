using System;
using System.Collections;
using UnityEngine;

namespace Entities.WanderingObj
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class WO_Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeSpanInSeconds;
        
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void OnEnable()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0;
            
            _rigidbody2D.AddForce(transform.up * speed);
            
            Debug.Log(transform.rotation);
            
            StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(lifeSpanInSeconds);
            this.gameObject.SetActive(false);
        }
    }
}
