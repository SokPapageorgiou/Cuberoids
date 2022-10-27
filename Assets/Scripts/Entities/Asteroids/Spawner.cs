using Systems.ObjectPool;
using UnityEngine;

namespace Entities.Asteroids
{
    public class Spawner : MonoBehaviour
    {
        [Header("Initial Status")]
        [SerializeField] private byte amountOnStart;
        [SerializeField] private float maxForceMagnitude;
        [SerializeField] private float maxAngularSpeed;

        [Header("Spawn area")] 
        [SerializeField] private float width;
        [SerializeField] private float height;
        [SerializeField] private float distanceFromCenter;

        private Pool _pool;
        private readonly StatusRandomizer _randomizer = new();
        
        private void Awake() => _pool = FindObjectOfType<Pool>();

        private void Start()
        {
            for (int i = 0; i < amountOnStart; i++)
            {
                var instance = _pool.GetInstance(PoolEntry.Asteroid);
                instance.transform.position = _randomizer.SetRandomLocation(distanceFromCenter, width, height);
                instance.AddRelativeForce(_randomizer.SetRandomVector2(maxForceMagnitude));
                instance.angularVelocity = _randomizer.SetRandomAngularVelocity(maxAngularSpeed);
            }
        }
    }
}
