using System.Collections.Generic;
using UnityEngine;

namespace Systems.ObjectPool
{
    public class Pool : MonoBehaviour
    {
        [SerializeField] private CatalogEntry[] catalog;
        
        private Dictionary<PoolEntry, Queue<Rigidbody2D>> _dictionary = new ();

        private void Awake()
        {
            foreach (var item in catalog)
                FillEntry(item.entry, item.instance, item.amount);
        }

        private void FillEntry(PoolEntry entry, Rigidbody2D instance, int amount)
        {
            var queue = new Queue<Rigidbody2D>();
            
            for (int i = 0; i < amount; i++)
            {
                var temp = Instantiate(instance, this.transform);
                temp.gameObject.SetActive(false);
                queue.Enqueue(temp.GetComponent<Rigidbody2D>());
            }
            
            _dictionary.Add(entry, queue);
        }

        public Rigidbody2D GetInstance(PoolEntry entry)
        {
            var instance = _dictionary[entry].Dequeue();
            _dictionary[entry].Enqueue(instance);
            instance.gameObject.SetActive(true);

            return instance;
        }
    }
}