using System;
using UnityEngine;

namespace JSON_Practice
{
    [Serializable]
    public class JsonObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _isStackable;
        [SerializeField] private int _countSize;

        private int _countInCell = 1;

        public JsonObject(string id, string name, string description, ItemType itemType, Sprite icon, bool isStackable,
            int countSize)
        {
            _id = id;
            _name = name;
            _description = description;
            _itemType = itemType;
            _icon = icon;
            _isStackable = isStackable;
            _countSize = countSize;
        }

        public void ChangeCountDown()
        {
            _countInCell--;
        }

        public void ChangeCountUp()
        {
            _countInCell++;
        }

        public string GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public ItemType GetItemType()
        {
            return _itemType;
        }

        public Sprite GetIcon()
        {
            return _icon;
        }

        public bool IsStackable()
        {
            return _isStackable;
        }

        public int GetCountSize()
        {
            return _countSize;
        }
    }
}