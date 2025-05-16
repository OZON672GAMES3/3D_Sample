using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.InventorySimple
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryUI _inventoryUI;
        [SerializeField] private Transform _dropPoint;
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private ParticleSystem _explosion;
        
        private List<InventoryItem> _items = new();
        private bool _isInventoryOpen;
        private InventoryPlayerLogic _playerLogic;
        private Bomb _bomb;

        private void Start()
        {
            _playerLogic = GetComponent<InventoryPlayerLogic>();
        }

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

        public void TakeHealth(int index)
        {
            if (index < 0 || index >= _items.Count)
                return;
            
            var item = _items[index];
            RemoveItem(item.data);
            _playerLogic.SetHealth(10);
        }

        private void ExplodeBomb(int index, Transform dropPoint)
        {
            if (index < 0 || index >= _items.Count)
                return;

            var item = _items[index];
            GameObject go = Instantiate(item.data.prefab, dropPoint.position, Quaternion.identity);
            Bomb bomb = go.GetComponent<Bomb>();
            RemoveItem(item.data);
            
            if (bomb)
                bomb.GetExplosion();
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
            
            if (Input.GetKeyDown(KeyCode.R))
                TakeHealth(0);

            if (Input.GetKeyDown(KeyCode.F))
            {
                ExplodeBomb(1, _dropPoint);
            }
        }
    }
}