using Systems.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

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
        [SerializeField] private float distanceToCenter;

        private Pool _pool;

        private void Awake() =>  _pool = FindObjectOfType<Pool>();

        private void Start()
        {
            for (int i = 0; i < amountOnStart; i++)
            {
                var instance = _pool.GetInstance(PoolEntry.Asteroid);
                instance.transform.position = SetRandomLocation();
                instance.AddRelativeForce(SetRandomVector2());
                instance.angularVelocity = SetRandomAngularVelocity();
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

        private Vector2 SetRandomVector2()
        {
            float x = SetRandomNormalized();
            float y = SetRandomNormalized();
            
            float magnitude = Random.Range(0, maxForceMagnitude);
            
            return new Vector2(x,y).normalized * magnitude;
        }

        private float SetRandomNormalized() => Random.Range(-1, 1);
        private float SetRandomAngularVelocity() => SetRandomNormalized() * maxAngularSpeed;
    }
}
