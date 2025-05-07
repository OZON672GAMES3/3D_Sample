using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.InventorySimple
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryUI _inventoryUI;
        [SerializeField] private Transform _dropPoint;
        [SerializeField] private GameObject _inventoryPanel;
        
        private List<InventoryItem> _items = new();
        private bool _isInventoryOpen;

        public void AddItem(ItemData itemData)
        {
            InventoryItem existing = _items.Find(i=> i.data == itemData);
            
            if (existing != null)
                existing.amount++;
            else
                _items.Add(new InventoryItem(itemData));
            
            _inventoryUI.Refresh(_items);
        }

        public void RemoveItem(ItemData itemData)
        {
            InventoryItem existing = _items.Find(i=> i.data == itemData);

            if (existing != null)
            {
                existing.amount--;
                if (existing.amount <= 0)
                    _items.Remove(existing);
            }
            
            _inventoryUI.Refresh(_items);
        }

        public void DropItem(int index, Transform dropPoint)
        {
            if (index < 0 || index >= _items.Count)
                return;
            
            var item = _items[index];
            Instantiate(item.data.prefab, dropPoint.position, Quaternion.identity);
            RemoveItem(item.data);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isInventoryOpen = !_isInventoryOpen;
                _inventoryPanel.SetActive(_isInventoryOpen);
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
                DropItem(0, _dropPoint);
        }
    }
}