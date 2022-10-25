using UnityEngine;
using UnityEngine.Events;

namespace Systems.PlayerControl.PlayerInput
{
    public class RotationInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> onRotationInputUpdates;

        private float _inputValue;
        
        private void Update()
        {
            _inputValue = UpdateInput();
            if (_inputValue != 0)
            {
                onRotationInputUpdates.Invoke(_inputValue);
                Debug.Log(_inputValue);
            }
        }

        private float UpdateInput() => Input.GetAxis("Horizontal");
    }
}