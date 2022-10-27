using System;
using Entities.Utilities;
using UnityEngine;

namespace Entities.Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private SO_UnityEvent onAsteroidDisables;

        private void OnDisable() => onAsteroidDisables.Invoke(transform);
    }
}
