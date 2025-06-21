using UnityEngine;

namespace DefaultNamespace.LightPractice
{
    public class HoverLight : MonoBehaviour
    {
        [SerializeField] private string _lightId;
        public string LightId => _lightId;
        
        private Light _light;

        private void Start()
        {
            _light = GetComponent<Light>();
            _light.enabled = false;
        }

        public void EnableLight()
        {
            _light.enabled = true;
        }
    }
}