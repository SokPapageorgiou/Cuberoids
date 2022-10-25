using UnityEngine;
using UnityEngine.Events;

namespace Systems.PlayerControl.PawnControl
{
    public class ControlledTarget : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D target;

        [SerializeField] private UnityEvent<Rigidbody2D> onPawnChanges;

        private void Awake() => onPawnChanges.Invoke(target);
    }
}
