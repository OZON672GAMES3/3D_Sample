using UnityEngine;

namespace DefaultNamespace.Pong3D
{
    public class EnemyRacket3D : MonoBehaviour
    {
        [SerializeField] private Transform _puck;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _reactionDelayMin = 0.1f;
        [SerializeField] private float _reactionDelayMax = 0.4f;
        [SerializeField] private float _errorRange = 0.5f;
        
        private float _nextReactionTime;
        private float _targetZ;

        private void Update()
        {
            if (Time.time >= _nextReactionTime)
            {
                _targetZ = _puck.position.x + Random.Range(-_errorRange, _errorRange);
                
                _nextReactionTime = Time.time + Random.Range(_reactionDelayMin, _reactionDelayMax);
            }

            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.MoveTowards(transform.position.x, _targetZ, _moveSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
    }
}