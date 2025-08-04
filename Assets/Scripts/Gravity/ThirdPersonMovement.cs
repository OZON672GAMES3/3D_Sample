using UnityEngine;

namespace DefaultNamespace.Gravity
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private Camera _camera;

        private Rigidbody _rigidbody;
        private GravityController _gravityController;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _gravityController = GetComponent<GravityController>();
        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            Vector3 gravityDir = _gravityController.GravityDirection;
            
            Vector3 camForward = Vector3.ProjectOnPlane(_camera.transform.forward, -gravityDir).normalized;
            Vector3 camRight = Vector3.ProjectOnPlane(_camera.transform.right, -gravityDir).normalized;
            
            Vector3 move = (camForward * vertical + camRight * horizontal).normalized;
            
            if (move.sqrMagnitude > 0.01f)
            {
                Vector3 targetPosition = _rigidbody.position + move * (_moveSpeed * Time.fixedDeltaTime);
                _rigidbody.MovePosition(targetPosition);
                
                Quaternion targetRot = Quaternion.LookRotation(move, -gravityDir);
                _rigidbody.MoveRotation(Quaternion.Slerp(_rigidbody.rotation, targetRot, 10f * Time.fixedDeltaTime));
            }
        }
    }
}