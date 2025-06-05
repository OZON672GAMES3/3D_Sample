using TMPro;
using UnityEngine;

namespace DefaultNamespace.Generics.Counters
{
    public class CounterG : MonoBehaviour
    {
        [Header("Cubes UI")]
        [SerializeField] private TMP_Text cubesCreatedText;
        [SerializeField] private TMP_Text cubesSpawnedText;
        [SerializeField] private TMP_Text cubesActiveText;

        [Header("Bombs UI")]
        [SerializeField] private TMP_Text bombsCreatedText;
        [SerializeField] private TMP_Text bombsSpawnedText;
        [SerializeField] private TMP_Text bombsActiveText;

        private int _cubesCreated;
        private int _cubesSpawned;
        private int _cubesActive;

        private int _bombsCreated;
        private int _bombsSpawned;
        private int _bombsActive;

        private void Update()
        {
            cubesCreatedText.text = _cubesCreated.ToString();
            cubesSpawnedText.text = _cubesSpawned.ToString();
            cubesActiveText.text = _cubesActive.ToString();

            bombsCreatedText.text = _bombsCreated.ToString();
            bombsSpawnedText.text = _bombsSpawned.ToString();
            bombsActiveText.text = _bombsActive.ToString();
        }
        
        private void OnEnable()
        {
            ObjectPoolG<CubeG>.OnObjectCreated += OnCubeCreated;
            ObjectPoolG<CubeG>.OnObjectSpawned += OnCubeSpawned;
            ObjectPoolG<CubeG>.OnObjectReleased += OnCubeReleased;
            
            ObjectPoolG<BombG>.OnObjectCreated += OnBombCreated;
            ObjectPoolG<BombG>.OnObjectSpawned += OnBombSpawned;
            ObjectPoolG<BombG>.OnObjectReleased += OnBombReleased;
        }

        private void OnDisable()
        {
            ObjectPoolG<CubeG>.OnObjectCreated -= OnCubeCreated;
            ObjectPoolG<CubeG>.OnObjectSpawned -= OnCubeSpawned;
            ObjectPoolG<CubeG>.OnObjectReleased -= OnCubeReleased;
            
            ObjectPoolG<BombG>.OnObjectCreated -= OnBombCreated;
            ObjectPoolG<BombG>.OnObjectSpawned -= OnBombSpawned;
            ObjectPoolG<BombG>.OnObjectReleased -= OnBombReleased;
        }
        
        private void OnCubeCreated() => _cubesCreated++;
        private void OnCubeSpawned()
        {
            _cubesSpawned++;
            _cubesActive++;
        }
        private void OnCubeReleased() => _cubesActive--;
        
        private void OnBombCreated() => _bombsCreated++;
        private void OnBombSpawned()
        {
            _bombsSpawned++;
            _bombsActive++;
        }
        private void OnBombReleased() => _bombsActive--;
    }
}