using System.Collections;
using UnityEngine;

namespace Entities.Utilities
{
    public class LifeSpan : MonoBehaviour
    {
        [SerializeField] private float seconds;

        void Start() => StartCoroutine(Disable());

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }

    }
}
