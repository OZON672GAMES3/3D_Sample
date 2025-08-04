using UnityEngine;

namespace DefaultNamespace.Gravity
{
    public class GravityController : MonoBehaviour
    {
        [SerializeField] private float _gravityStrength = 20f;
        [SerializeField] private float _rotationSpeed = 5f;

        private Camera _camera;
        private Rigidbody _rigidbody;
        private bool _isFlying;
        private Vector3 _gravityDirection;
        public Vector3 GravityDirection => _gravityDirection;
        
        private void Start()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
            _gravityDirection = Vector3.down;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                _gravityDirection = _camera.transform.forward;
                _isFlying = true;
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_gravityDirection * _gravityStrength, ForceMode.Acceleration);

            Quaternion targetRotation =
                Quaternion.FromToRotation(transform.up, -_gravityDirection) * transform.rotation;
            transform.rotation =
                Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!_isFlying)
                _gravityDirection = -collision.contacts[0].normal;
            else
            {
                _gravityDirection = -collision.contacts[0].normal;
                _isFlying = false;
            }
        }
    }
}