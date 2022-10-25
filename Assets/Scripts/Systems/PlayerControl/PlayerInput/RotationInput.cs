using UnityEngine;
using UnityEngine.Events;

namespace Systems.PlayerControl.PlayerInput
{
    public class RotationInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> onRotationInputUpdates;

        private void Update() => onRotationInputUpdates.Invoke(Input.GetAxis("Horizontal"));
    }
}