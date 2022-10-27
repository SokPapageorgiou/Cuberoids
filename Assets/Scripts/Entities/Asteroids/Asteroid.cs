using Entities.Utilities;
using UnityEngine;

namespace Entities.Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private SO_UnityEvent onAsteroidDisables;

        private void OnCollisionEnter2D(Collision2D col) => this.gameObject.SetActive(false);
        
        private void OnDisable() => onAsteroidDisables.Invoke(transform);
    }
}
