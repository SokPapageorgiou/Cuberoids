using UnityEngine;
using UnityEngine.Events;

namespace Entities.Utilities
{
    [CreateAssetMenu(fileName = "NewUnityEvent", menuName = "SO_Events/UnityEvent")]
    public class SO_UnityEvent : ScriptableObject
    {
        private UnityEvent<Vector2> _event;

        public void Subscribe(UnityAction<Vector2> action) => _event.AddListener(action);
        public void Unsubscribe(UnityAction<Vector2> action) => _event.RemoveListener(action);
        public void Invoke(Vector2 data) => _event.Invoke(data);
    }
}
