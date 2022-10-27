using System.Collections;
using Systems.ObjectPool;
using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Entities.SpaceShip
{
    public class SS_Shoot : MonoBehaviour , IShootable
    {
        [Header("Bullet")] 
        [SerializeField] private float speed;
        [SerializeField] private float shotsPerSecond;
        
        [Header("Dependencies")]
        [SerializeField] private Transform gun;
       
        private Pool _pool;
        private bool _isTriggerPulledBuffer;

        private void Awake() => _pool = FindObjectOfType<Pool>();

        public void Fire(bool isTriggerPulled)
        {
            if (isTriggerPulled && !_isTriggerPulledBuffer)
            {
                StartCoroutine(Shoot());
                InvertIsTriggerPulledBuffer();
            }
            else if (!isTriggerPulled && _isTriggerPulledBuffer)
                InvertIsTriggerPulledBuffer();
        }

        private IEnumerator Shoot()
        {
            var bullet= _pool.GetInstance(PoolEntry.Bullet);

            bullet.transform.position = gun.position;

            bullet.velocity = Vector2.zero;
            var forceDirection = gun.position - transform.position;
            bullet.AddRelativeForce(forceDirection.normalized * speed);
            
            yield return new WaitForSeconds(1 / shotsPerSecond);

            if(_isTriggerPulledBuffer) StartCoroutine(Shoot());
        }

        private void InvertIsTriggerPulledBuffer() => _isTriggerPulledBuffer = !_isTriggerPulledBuffer;
    }
}
