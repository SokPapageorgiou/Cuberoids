using UnityEngine;
using UnityEngine.Events;

namespace Systems.PlayerControl.PlayerInput
{
    public class ThrustInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> onThrustInputUpdates;

        private float _inputValue;
        
        private void Update()
        {
            _inputValue = UpdateInput();
            if (_inputValue > 0) onThrustInputUpdates.Invoke(_inputValue);
        }

        private float UpdateInput() => Input.GetAxis("Vertical");
    }
}
