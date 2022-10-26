using UnityEngine;
using UnityEngine.Events;

namespace Systems.PlayerControl.PlayerInput
{
    public class ShootInput : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCode;
        [SerializeField] private UnityEvent<bool> onShootInputUpdates;

        private bool _inputValue;
        private bool _currentValue;
        
        private void Update()
        {
            if(Input.GetKeyDown(keyCode)) onShootInputUpdates.Invoke(true);
            if(Input.GetKeyUp(keyCode)) onShootInputUpdates.Invoke(false);
        }
    }
}