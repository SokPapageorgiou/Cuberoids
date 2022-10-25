using UnityEngine;
using UnityEngine.Events;

namespace PlayerInput
{
    public class ThrustInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> onThrustInputUpdates;

        private float _inputValue;
        
        private void Update()
        {
            _inputValue = UpdateThrust();
            if (_inputValue > 0) onThrustInputUpdates.Invoke(_inputValue);
        }

        private float UpdateThrust() => Input.GetAxis("Vertical");
    }
}
