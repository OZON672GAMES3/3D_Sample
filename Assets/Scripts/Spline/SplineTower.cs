using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Spline
{
    [RequireComponent(typeof(SphereCollider))]
    public class SplineTower : MonoBehaviour
    {
        [SerializeField] private Transform _rotatePart;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private SplineBullet _bulletPrefab;
        
        [SerializeField] private float _attackRadius = 10f;
        [SerializeField] private float _attackRate = 1f;

        private List<Transform> _enemies = new();
        private Transform _target;
        private float _nextFireRate;
        private SphereCollider _attackRadiusCollider;

        private void Start()
        {
            _attackRadiusCollider = GetComponent<SphereCollider>();
            _attackRadiusCollider.radius = _attackRadius;
            _attackRadiusCollider.isTrigger = true;
        }

        private void Update()
        {
            UpdateTarget();

            if (!_target)
                return;
            
            _rotatePart.LookAt(_target);

            if (Time.time >= _nextFireRate)
            {
                Shoot();
                _nextFireRate = Time.time + 1f / _attackRate;
            }
        }

        private void UpdateTarget()
        {
            _enemies.RemoveAll(e => !e);
            
            float minDistance = float.MaxValue;
            Transform nearest = null;

            foreach (Transform enemy in _enemies)
            {
                float dist = Vector3.Distance(transform.position, enemy.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    nearest = enemy;
                }
            }

            _target = nearest && minDistance <= _attackRadius ? nearest : null;
        }

        private void Shoot()
        {
            SplineBullet bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            if (bullet.TryGetComponent(out Rigidbody rb) && _target)
                bullet.SetTarget(_target);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out SplineEnemy enemy) && !_enemies.Contains(enemy.transform))
                _enemies.Add(enemy.transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out SplineEnemy enemy))
                _enemies.Remove(enemy.transform);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }
    }
}
