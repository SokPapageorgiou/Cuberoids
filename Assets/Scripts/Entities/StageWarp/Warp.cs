using System;
using UnityEngine;

namespace Entities.StageWarp
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Warp : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other) => other.transform.position *= -1;
    }
}
