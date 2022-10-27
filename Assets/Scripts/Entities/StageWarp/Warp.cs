using UnityEngine;

namespace Entities.StageWarp
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Warp : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;

        private void Awake() => _boxCollider2D = GetComponent<BoxCollider2D>();

        private void OnTriggerExit2D(Collider2D other)
        {
            var otherPosition = other.transform.position;
            float newPosX = WarpInOneAxis(_boxCollider2D.size.x / 2, otherPosition.x);
            float newPosY = WarpInOneAxis(_boxCollider2D.size.y / 2, otherPosition.y);

            other.transform.position = new Vector3(newPosX, newPosY);
        } 

        public float WarpInOneAxis(float range, float number)
        {
            if (IsOutOfRange(range, number)) number = InvertNumber(number);
            return number;
        }

        private bool IsOutOfRange(float range, float number)
        {
            if (number >= -range && number <= range) return false;
            return true;
        }
        
        private float InvertNumber(float number) => number * -1;
    }
}
