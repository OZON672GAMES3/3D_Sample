using TMPro;
using UnityEngine;

namespace DefaultNamespace.InventorySimple
{
    public class InventoryPlayerLogic : MonoBehaviour
    {
        [SerializeField] private int _health = 50;
        [SerializeField] private TMP_Text _healthText;
        
        private readonly int _maxHealth = 100;

        public void SetHealth(int health)
        { 
            _health += health;
            
            if (_health >= _maxHealth)
                _health = _maxHealth;
        }

        private void Update()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            _healthText.text = _health.ToString();
        }
    }
}