using UnityEngine;

namespace DefaultNamespace.UnitsSelector
{
    public class MoverUs : MonoBehaviour
    {
        [SerializeField] private float _speedMove;
        
        private bool _isSelected;
        private Vector3? _targetPoint;

        public void Select() => _isSelected = true;
        public void Deselect() => _isSelected = false;
        public bool IsSelected() => _isSelected;

        private void Update()
        {
            if (_targetPoint.HasValue)
                MoveToTarget(_targetPoint.Value);
        }

        private void MoveToTarget(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target,
                _speedMove * Time.deltaTime);
            transform.LookAt(target);

            if (Vector3.Distance(transform.position, target) < 0.1f)
                _targetPoint = null;
        }

        public void SetTargetVector(Vector3 target)
        {
            _targetPoint = target;
        }
    }
}