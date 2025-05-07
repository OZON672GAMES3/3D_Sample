using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.InventorySimple
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private Transform _slotParent;

        private List<GameObject> _currentSlots = new();

        public void Refresh(List<InventoryItem> items)
        {
            foreach (GameObject slot in _currentSlots)
                Destroy(slot);
            _currentSlots.Clear();

            foreach (InventoryItem item in items)
            {
                GameObject go = Instantiate(_slotPrefab, _slotParent);
                go.GetComponentInChildren<Image>().sprite = item.data.icon;
                go.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = item.amount.ToString();
                _currentSlots.Add(go);
            }
        }
    }
}