using System.Collections.Generic;
using UnityEngine;

namespace Systems.ObjectPool
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private CatalogEntry[] catalog;
        
        private Dictionary<PoolEntry, Queue<GameObject>> _dictionary;

        private void Awake()
        {
            foreach (var item in catalog)
                FillEntry(item.entry, item.instance, item.amount);
        }

        private void FillEntry(PoolEntry entry, GameObject gameObject, int amount)
        {
            var queue = new Queue<GameObject>();
            for (int i = 0; i < amount; i++) queue.Enqueue(gameObject);
            
            _dictionary.Add(entry, queue);
        }

        public GameObject GetInstance(PoolEntry entry)
        {
            var gameObject = _dictionary[entry].Dequeue();
            _dictionary[entry].Enqueue(gameObject);

            return gameObject;
        }
    }
}