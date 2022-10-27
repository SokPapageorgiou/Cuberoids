using UnityEngine;
using UnityEngine.Events;

namespace Entities.Utilities
{
    [CreateAssetMenu(fileName = "NewUnityEvent", menuName = "SO_Events/UnityEvent")]
    public class SO_UnityEvent : ScriptableObject
    {
        private UnityEvent<Transform> _event;

        public void Subscribe(UnityAction<Transform> action) => _event.AddListener(action);
        public void Unsubscribe(UnityAction<Transform> action) => _event.RemoveListener(action);
        public void Invoke(Transform transform) => _event.Invoke(transform);
    }
}
