using System.Collections;
using DefaultNamespace.Generics.Counters;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Generics
{
    public class SpawnerG : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private CubeG _cubeGPrefab;
        [SerializeField] private BombG _bombGPrefab;
        
        [Header("Spawn Points")]
        [SerializeField] private Transform _firstSpawnPoint;
        [SerializeField] private Transform _secondSpawnPoint;
        
        [Header("Containers")]
        [SerializeField] private Transform _cubesContainer;
        [SerializeField] private Transform _BombsContainer;
        [SerializeField] private float _spawnDelay = 3f;

        private ObjectPoolG<CubeG> _cubeGPool;
        private ObjectPoolG<BombG> _bombGPool;

        private void Awake()
        {
            _cubeGPool = new ObjectPoolG<CubeG>(_cubeGPrefab, 8, _cubesContainer);
            _bombGPool = new ObjectPoolG<BombG>(_bombGPrefab, 8, _BombsContainer);
            
            StartCoroutine(SpawnCubesRoutine());
        }

        private IEnumerator SpawnCubesRoutine()
        {
            WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

            while (enabled)
            {
                CubeG cube = _cubeGPool.Get();
                cube.PoolReleaseCube += OnReturn;
                
                cube.transform.position =
                    new Vector3(Random.Range(_firstSpawnPoint.position.x, _secondSpawnPoint.position.x), 40,
                        Random.Range(_firstSpawnPoint.position.z, _secondSpawnPoint.position.z));
                
                yield return wait;
            }
        }

        private void SpawnBomb(CubeG cube)
        {
            BombG bomb = _bombGPool.Get();
            bomb.transform.position = cube.transform.position;
            bomb.PoolReleaseBomb += OnReturn;
        }

        private void OnReturn(CubeG cube)
        {
            cube.PoolReleaseCube -= OnReturn;
            _cubeGPool.Release(cube);
            
            SpawnBomb(cube);
        }

        private void OnReturn(BombG bomb)
        {
            bomb.PoolReleaseBomb -= OnReturn;
            _bombGPool.Release(bomb);
        }
    }
}