using UnityEngine;
using UnityEngine.Events;

namespace Systems.PlayerControl.PlayerInput
{
    public class ThrustInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> onThrustInputUpdates;

        private float _inputValue;
        
        private void Update() => onThrustInputUpdates.Invoke(Input.GetAxis("Vertical"));
    }
}
