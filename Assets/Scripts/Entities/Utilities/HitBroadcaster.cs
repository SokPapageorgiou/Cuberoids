using System;
using UnityEngine;

namespace Entities.Utilities
{
    public class HitBroadcaster : MonoBehaviour
    {
        [SerializeField] private SO_UnityEvent onGetHit;

        private void OnCollisionEnter2D(Collision2D col) => onGetHit.Invoke(this.transform);
    }
}
