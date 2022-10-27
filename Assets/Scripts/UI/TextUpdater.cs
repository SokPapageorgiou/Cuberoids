using System;
using Entities.Utilities;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class TextUpdater : MonoBehaviour
    {
        [SerializeField] private string prefix;
        
        [FormerlySerializedAs("unityEvent")]
        [Header("Dependencies")]
        [SerializeField] private SO_UnityEvent uEvent;
        [SerializeField] private Text text;

        private float _counter;

        private void Start()
        {
            text.text = prefix + _counter;
            uEvent.Subscribe(UpdateText);
        }

        private void OnDestroy() => uEvent.Unsubscribe(UpdateText);
        
        private void UpdateText(Transform transform) => text.text = prefix + ++_counter;
    }
}
