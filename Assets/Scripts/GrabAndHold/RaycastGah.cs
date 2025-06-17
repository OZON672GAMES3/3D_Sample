using UnityEngine;

namespace DefaultNamespace.GrabAndHold
{
    public class RaycastGah : MonoBehaviour
    {
        [SerializeField] private Transform _holdPoint;
        [SerializeField] private float _pickupRange = 3f;
        [SerializeField] private float _throwForce = 5f;
        
        private CubeGah _heldObject;
        private Rigidbody _heldObjectRb;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!_heldObject)
                    TryPickupObject();
                else
                    DropObject();
            }

            if (_heldObject)
            {
                MoveHeldObject();
                Rotate();
            }
        }

        private void TryPickupObject()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _pickupRange))
            {
                if (hit.collider.gameObject.TryGetComponent(out CubeGah cubeGah))
                {
                    _heldObject = cubeGah;
                    _heldObjectRb = _heldObject.GetComponent<Rigidbody>();

                    if (_heldObjectRb)
                    {
                        _heldObjectRb.useGravity = false;
                        _heldObjectRb.drag = 10f;
                        _heldObjectRb.constraints =
                            RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    }
                }
            }
        }

        private void Rotate()
        {
            float rotateSpeed = 100f;
            
            if (Input.GetKey(KeyCode.E))
                _heldObject.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.Q))
                _heldObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }

        private void MoveHeldObject()
        {
            Vector3 desiredPosition = _holdPoint.position;
            Vector3 currentPosition = _heldObject.transform.position;
            Vector3 direction = desiredPosition - currentPosition;

            _heldObjectRb.velocity = direction * 10f;
        }

        private void DropObject()
        {
            _heldObjectRb.useGravity = true;
            _heldObjectRb.drag = 1f;
            _heldObjectRb.constraints = RigidbodyConstraints.None;
            
            _heldObjectRb.AddForce(transform.forward * _throwForce, ForceMode.Impulse);

            _heldObject = null;
            _heldObjectRb = null;
        }
    }
}