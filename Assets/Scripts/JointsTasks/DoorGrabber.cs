using UnityEngine;

namespace DefaultNamespace.JointsTasks
{
    public class DoorGrabber : MonoBehaviour
    {
        [SerializeField] private float _grabDistance = 3f;
        [SerializeField] private float _forceMultiplier = 100f;
        [SerializeField] private LayerMask _doorMask;

        private Rigidbody _rigidbody;
        private Vector3 _grabOffset;
        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, _grabDistance, _doorMask))
                {
                    _rigidbody = hit.rigidbody;
                    _grabOffset = hit.point - _rigidbody.worldCenterOfMass;
                }
            }

            if (Input.GetMouseButtonUp(0))
                _rigidbody = null;
        }

        private void FixedUpdate()
        {
            if (!_rigidbody)
                return;

            _rigidbody.angularVelocity *= 0.0f;
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Vector3 targetPoint = ray.GetPoint(_grabDistance);
            Vector3 forceDirection = targetPoint - (_rigidbody.worldCenterOfMass + _grabOffset);
            _rigidbody.AddForce(forceDirection * (_forceMultiplier * Time.deltaTime), ForceMode.VelocityChange);
        }
    }
}