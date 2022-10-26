using System;
using Systems.ObjectPool;
using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Characters.SpaceShip
{
    public class SS_Shoot : MonoBehaviour , IShootable
    {
        [SerializeField] private float fireRate;

        private Pool _pool;

        private void Awake() => _pool = FindObjectOfType<Pool>();
        

        public void Fire()
        {
            _pool.GetInstance(PoolEntry.Bullet);
            Debug.Log("Spaceship is shooting!");
        }
    }
}
