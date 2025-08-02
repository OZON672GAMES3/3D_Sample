using UnityEngine;

namespace DefaultNamespace.Spline
{
    public class SplineBullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 20f;
        
        private Transform _target;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out SplineEnemy enemy))
            {                
                Destroy(gameObject);
                Destroy(enemy.gameObject);
            }
        }

        private void Update()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            transform.position += direction * (_speed * Time.deltaTime);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}