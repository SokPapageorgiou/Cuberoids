using System.Numerics;
using Systems.ObjectPool;
using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Characters.SpaceShip
{
    public class SS_Shoot : MonoBehaviour , IShootable
    {
        [SerializeField] private float shotsPerSecond;
        [SerializeField] private Transform gun;
       
        private Pool _pool;

        private void Awake() => _pool = FindObjectOfType<Pool>();

        public void Fire()
        {
           var bullet= _pool.GetInstance(PoolEntry.Bullet);

           bullet.transform.position = gun.position;
        }
    }
}
