using UnityEngine;

namespace DefaultNamespace.LightPractice
{
    public class Torchlight : MonoBehaviour
    {
        private Camera _camera;
        private Vector2 _mousePosition;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(_mousePosition.x, _mousePosition.y, transform.position.z);
        }
    }
}