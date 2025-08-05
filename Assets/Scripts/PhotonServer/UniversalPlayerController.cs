using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [RequireComponent(typeof(CharacterController))]
    public class UniversalPlayerController : MonoBehaviourPun
    {
        [SerializeField] private BallThrower _ballThrowerPrefab;
        [SerializeField] private Transform _throwOrigin;
        [SerializeField] private float _throwForce = 1000f;
        
        public float moveSpeed = 10f;
        public float mouseSensitivity = 2f;
        public float jumpHeight = 1.5f;
        public float gravity = -9.81f;

        public Transform cameraTransform;

        private CharacterController controller;
        private Vector3 velocity;
        private float xRotation;
        private MeshRenderer _meshRenderer;
        private Camera _camera;
        private PhotonView _view;

        private void Awake()
        {
            _view = GetComponent<PhotonView>();
        }

        void Start()
        {
            _camera = GetComponentInChildren<Camera>();
            cameraTransform = _camera.transform;
            controller = GetComponent<CharacterController>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);

            if (_view.IsMine)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
                _camera.gameObject.SetActive(false);
        }

        private void ThrowObject()
        {
            Vector3 force = _throwOrigin.forward.normalized * _throwForce;
            Debug.Log($"ThrowObject called with _throwForce={_throwForce}, force={force}");

            GameObject go = PhotonNetwork.Instantiate(
                _ballThrowerPrefab.name,
                _throwOrigin.position,
                _throwOrigin.rotation,
                0,
                new object[] { force.x, force.y, force.z }
            );
        }

        void Update()
        {
            if (_view.IsMine && Input.GetMouseButtonDown(0))
                ThrowObject();
            
            if (_view.IsMine)
            {
                Move();
                Look();
            }
        }

        void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            controller.Move(move * (moveSpeed * Time.deltaTime));

            if (controller.isGrounded && velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        void Look()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

}