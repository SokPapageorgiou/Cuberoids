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
            _inputValue = Input.GetKey(keyCode);
            
            if (_currentValue != _inputValue)
            {
                onShootInputUpdates.Invoke();
                _currentValue = _inputValue;
            }
        }
    }
}