using UnityEngine;

namespace DefaultNamespace.Pong3D
{
    public class Ball3D : MonoBehaviour
    {
        [SerializeField] private float _launchForce = 10f;
        [SerializeField] private Transform _racketAnchor;
        
        private Rigidbody _rigidbody;
        private bool _isAttachedToRacket;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            LaunchInRandomDirection();
        }

        private void Update()
        {
            if (_isAttachedToRacket)
            {
                transform.position = _racketAnchor.position;
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Vector3 shootDir = _racketAnchor.transform.forward;
                    ApplyImpulse(shootDir);
                    _isAttachedToRacket = false;
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Racket3D racket))
            {
                Transform racketTransform = racket.transform;
                Vector3 localHitPoint = racketTransform.InverseTransformPoint(transform.position);

                float offsetZ = Mathf.Clamp(localHitPoint.z, -1f, 1f);

                Vector3 baseDirection = racketTransform.forward;
                Vector3 offsetDirection = racketTransform.right * offsetZ;
                Vector3 finalDirection = (baseDirection + offsetDirection).normalized;

                _rigidbody.velocity = Vector3.zero;
                ApplyImpulse(finalDirection);
            }
        }

        private void ApplyImpulse(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _launchForce, ForceMode.Impulse);
        }

        private void LaunchInRandomDirection()
        {
            Vector3 dir = GetRandomDirection();
            ApplyImpulse(dir);
        }

        private Vector3 GetRandomDirection()
        {
            return new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized;
        }

        private void OnTriggerEnter(Collider other)
        {
            AttachToRacket();
        }

        private void AttachToRacket()
        {
            _rigidbody.velocity = Vector3.zero;
            _isAttachedToRacket = true;
        }
    }
}