using Entities.Utilities;
using Systems.ObjectPool;
using UnityEngine;

namespace Entities.Asteroids
{
    public class Spawner : MonoBehaviour
    {
        [Header("Asteroid Status")]
        [SerializeField] private byte amountOnStart;
        [SerializeField] private float maxForceMagnitude;
        [SerializeField] private float maxAngularSpeed;
        [SerializeField] private float minScale;
        [SerializeField] private float scale;

        [Header("Spawn area")] 
        [SerializeField] private float width;
        [SerializeField] private float height;
        [SerializeField] private float distanceFromCenter;

        [Header("Dependencies")] 
        [SerializeField] private SO_UnityEvent onAsteroidDisables;

        private Pool _pool;
        private readonly StatusRandomizer _randomizer = new();
        
        private void Awake() => _pool = FindObjectOfType<Pool>();

        private void Start()
        {
            onAsteroidDisables.Subscribe(SummonPair);
            for (int i = 0; i < amountOnStart; i++) SummonInstance();
        }

        private void OnDestroy() => onAsteroidDisables.Unsubscribe(SummonPair);
        
        private void SummonInstance()
        {
            var instance = _pool.GetInstance(PoolEntry.Asteroid);
            
            instance.transform.position = _randomizer.SetRandomLocation(distanceFromCenter, width, height);
            instance.AddRelativeForce(_randomizer.SetRandomVector2(maxForceMagnitude));
            instance.angularVelocity = _randomizer.SetRandomAngularVelocity(maxAngularSpeed);
        }

        private void SummonInstance(Transform disabled)
        {
            var instance = _pool.GetInstance(PoolEntry.Asteroid);
            
            instance.transform.position = disabled.position;
            instance.transform.localScale = disabled.localScale / scale;
            instance.AddRelativeForce(_randomizer.SetRandomVector2(maxForceMagnitude * scale));
            instance.angularVelocity = _randomizer.SetRandomAngularVelocity(maxAngularSpeed * scale);
        }

        private void SummonPair(Transform disabled)
        {
            if (disabled.localScale.x > minScale)
            {
                for (int i = 0; i < 2; i++) SummonInstance(disabled);
            }
        }
    }
}
