using System;
using Systems.ObjectPool;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Entities.Asteroids
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private byte amountOnStart;
        [SerializeField] private float maxInitialForceMagnitude;

        [Header("Spawn area")] 
        [SerializeField] private float width;
        [SerializeField] private float height;
        [SerializeField] private float distanceToCenter;

        private Pool _pool;

        private void Awake() =>  _pool = FindObjectOfType<Pool>();

        private void Start()
        {
            for (int i = 0; i < amountOnStart; i++)
            {
                var instance = _pool.GetInstance(PoolEntry.Asteroid);
                instance.transform.position = SetRandomLocation();
            }
        }

        private Vector2 SetRandomLocation()
        {
            float x = Random.Range(distanceToCenter, width);
            float y = Random.Range(distanceToCenter, height);
            
            x = RandomInvertDirection(x);
            y = RandomInvertDirection(y);
            
            return new Vector2(x, y);
        }

        private float RandomInvertDirection(float number)
        {
            if (Random.value > 0.5f) number *= -1;
            return number;
        }

    }
}
