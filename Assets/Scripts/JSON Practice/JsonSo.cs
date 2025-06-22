using UnityEngine;

namespace JSON_Practice
{
    [CreateAssetMenu(fileName = "JsonSo", menuName = "JsonItem", order = 0)]
    public class JsonSo : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _isStackable;
        [SerializeField] private int _countSize;

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

    public enum ItemType
    {
        Tools,
        Food,
        Weapon,
        Armor,
        Resource
    }
}