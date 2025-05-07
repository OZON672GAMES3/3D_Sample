using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.InventorySimple
{
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private ItemData _data;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Inventory inventory))
            {
                inventory.AddItem(_data);
                Destroy(gameObject);
            }
        }
    }
}