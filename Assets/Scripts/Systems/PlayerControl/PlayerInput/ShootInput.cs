using UnityEngine;
using UnityEngine.Events;

namespace Systems.PlayerControl.PlayerInput
{
    public class ShootInput : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode;
        [SerializeField] private UnityEvent onShootInputUpdates;

        private bool _inputValue;
        private bool _currentValue;
        
        private void Update()
        {
            _inputValue = UpdateInput();
            
            if (_currentValue != _inputValue)
            {
                onShootInputUpdates.Invoke();
                _currentValue = _inputValue;
            }
        }

        private bool UpdateInput() => Input.GetKey(keyCode);
    }
}