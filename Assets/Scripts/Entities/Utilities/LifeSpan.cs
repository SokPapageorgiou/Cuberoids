using System.Collections;
using UnityEngine;

namespace Entities.Utilities
{
    public class LifeSpan : MonoBehaviour
    {
        [SerializeField] private float seconds;

        private void OnEnable() => StartCoroutine(Disable());

        private void OnCollisionEnter2D(Collision2D col) => gameObject.SetActive(false);

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }

    }
}
