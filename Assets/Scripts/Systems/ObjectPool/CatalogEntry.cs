using UnityEngine;

namespace Systems.ObjectPool
{
    [CreateAssetMenu(fileName = "NewCatalogEntry", menuName = "Pool/CatalogEntry")]
    public class CatalogEntry : ScriptableObject
    {
        public PoolEntry entry;
        public Rigidbody2D instance;
        public int amount;
    }
}