using System.Collections.Generic;
using UnityEngine;

namespace JSON_Practice
{
    public class JsonInventory : MonoBehaviour
    {
        [SerializeField] private List<JsonObject> _inventory;
        [SerializeField] private CellRendererJson _cellPrefab;
        [SerializeField] private Transform _cellContainer;
        
        private JsonObject _tempJsonObject;
        private CellRendererJson _tempCellRenderer;

        [SerializeField] private List<JsonSo> _testItems;
        [SerializeField] private List<int> _testCounts;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                int number = Random.Range(0, _testCounts.Count);
                AddItem(_testItems[number]);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                int number = Random.Range(0, _inventory.Count);
                RemoveItem(_inventory[number]);
            }
        }

        private void DrawInventory()
        {
            for (int i = 0; i < _cellContainer.childCount; i++)
                Destroy(_cellContainer.GetChild(i).gameObject);

            foreach (JsonObject obj in _inventory)
            {
                _tempCellRenderer = Instantiate(_cellPrefab, _cellContainer);
                _tempCellRenderer.UpdateInfo(obj);
            }
        }

        public void AddItem(JsonSo item)
        {
            _tempJsonObject = new JsonObject(item.GetId(), item.GetName(), item.GetDescription(), item.GetItemType(),
                item.GetIcon(), item.IsStackable(), item.GetCountSize());

            if (_inventory.Count == 0 || !item.IsStackable())
                _inventory.Add(_tempJsonObject);
            else if (_inventory.Count > 0)
            {
                for (int i = 0; i < _inventory.Count; i++)
                {
                    if (_inventory[i].GetId() == _tempJsonObject.GetId() 
                        && _inventory[i].IsStackable() 
                        && _inventory[i].GetCountSize() + 1 <= _inventory[i].GetCountSize())
                    {
                        _inventory[i].ChangeCountUp();
                        break;
                    }
                    else if (i == _inventory.Count - 1 && _inventory[i].GetId() != _tempJsonObject.GetId())
                    {
                        _inventory.Add(_tempJsonObject);
                        break;
                    }
                }
            }
            
            DrawInventory();
        }

        public void RemoveItem(JsonObject item)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i].GetId() == item.GetId() && _inventory[i].GetCountSize() > 0)
                {
                    _inventory[i].ChangeCountDown();
                    break;
                }
                else if (_inventory[i].GetId() == item.GetId() && _inventory[i].GetCountSize() == 1)
                {
                    _inventory.RemoveAt(i);
                    break;
                }
            }
            
            DrawInventory();
        }

        public List<JsonObject> TakeToSave()
        {
            return _inventory;
        }

        public void ClearInventory()
        {
            _inventory.Clear();
        }

        public void LoadInventory(JsonObject item)
        {
            if (_inventory.Count == 0 || !item.IsStackable())
                _inventory.Add(item);
            else if (_inventory.Count > 0)
            {
                for (int i = 0; i < _inventory.Count; i++)
                {
                    if (_inventory[i].GetId() == _tempJsonObject.GetId() 
                        && _inventory[i].IsStackable() 
                        && _inventory[i].GetCountSize() + 1 <= _inventory[i].GetCountSize())
                    {
                        _inventory[i].ChangeCountUp();
                        break;
                    }
                    else if (i == _inventory.Count - 1 && _inventory[i].GetId() != item.GetId())
                    {
                        _inventory.Add(item);
                        break;
                    }
                }
            }
            
            DrawInventory();
        }
    }
}