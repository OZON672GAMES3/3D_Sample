using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

namespace DefaultNamespace.Spline
{
    public class SplineEnemySpawner : MonoBehaviour
    {
        [SerializeField] private SplineEnemy _enemyPrefab;
        [SerializeField] private SplineContainer _splineContainer;
        [SerializeField] private float _spawnDelay = 2f;
        [SerializeField] private int _enemyCount = 10;
        [SerializeField] private float _yOffset = 1.5f;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_spawnDelay);
            }
        }

        private void SpawnEnemy()
        {
            float3 pos = _splineContainer.EvaluatePosition(0f);
            float3 up = _splineContainer.EvaluateUpVector(0f);
            Vector3 startPos = (Vector3)pos + (Vector3)up * _yOffset;
            
            SplineEnemy enemy = Instantiate(_enemyPrefab, startPos, Quaternion.identity);
            SplineEnemy movement = enemy.GetComponent<SplineEnemy>();
            movement.SetSpline(_splineContainer, _yOffset);
        }
    }
}