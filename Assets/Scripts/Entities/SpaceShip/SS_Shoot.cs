using System.Collections;
using Systems.ObjectPool;
using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Entities.SpaceShip
{
    public class SS_Shoot : MonoBehaviour , IShootable
    {
        [SerializeField] private float shotsPerSecond;
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
            bullet.transform.rotation = transform.rotation;
            
            Debug.Log( bullet.transform.rotation);
            
            yield return new WaitForSeconds(1 / shotsPerSecond);

            if(_isTriggerPulledBuffer) StartCoroutine(Shoot());
        }

        private void InvertIsTriggerPulledBuffer() => _isTriggerPulledBuffer = !_isTriggerPulledBuffer;
    }
}
