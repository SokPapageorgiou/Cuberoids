using System.Collections.Generic;
using UnityEngine;

namespace Systems.ObjectPool
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private CatalogEntry[] catalog;
        
        private Dictionary<PoolEntry, Queue<GameObject>> _dictionary = new ();

        private void Awake()
        {
            foreach (var item in catalog)
                FillEntry(item.entry, item.instance, item.amount);
        }

        private void FillEntry(PoolEntry entry, GameObject instance, int amount)
        {
            var queue = new Queue<GameObject>();
            
            for (int i = 0; i < amount; i++)
            {
                var temp = Instantiate(instance, this.transform);
                temp.SetActive(false);
                queue.Enqueue(temp);
            }
            
            _dictionary.Add(entry, queue);
        }

        public GameObject GetInstance(PoolEntry entry)
        {
            var instance = _dictionary[entry].Dequeue();
            _dictionary[entry].Enqueue(instance);

            return gameObject;
        }
    }
}