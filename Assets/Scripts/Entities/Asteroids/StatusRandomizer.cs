using UnityEngine;

namespace Entities.Asteroids
{
    public class StatusRandomizer
    {
        public Vector2 SetRandomLocation(float distanceFromCenter, float width, float height)
        {
            float x = Random.Range(distanceFromCenter, width);
            float y = Random.Range(distanceFromCenter, height);
            
            x = RandomInvertDirection(x);
            y = RandomInvertDirection(y);
            
            return new Vector2(x, y);
        }

        public Vector2 SetRandomVector2(float maxForceMagnitude)
        {
            float x = SetRandomNormalized();
            float y = SetRandomNormalized();
            
            float magnitude = Random.Range(0, maxForceMagnitude);
            
            return new Vector2(x,y).normalized * magnitude;
        }

        public float SetRandomAngularVelocity(float maxAngularSpeed) => SetRandomNormalized() * maxAngularSpeed;

        private float RandomInvertDirection(float number)
        {
            if (Random.value > 0.5f) number *= -1;
            return number;
        }

        private float SetRandomNormalized() => Random.Range(-1, 1);
    }
}