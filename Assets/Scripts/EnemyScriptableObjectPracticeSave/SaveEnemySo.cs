using System.IO;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.EnemyScriptableObjectPracticeSave
{
    public class SaveEnemySo : MonoBehaviour
    {
        [SerializeField] private string _fileName;
        
        private EnemySops[] _enemySops;
        private string _jsonName;
        private string[] _readingFile;
        private string _readyFile;
        private EnemySopsData _tempEnemySo;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Save();
            if (Input.GetKeyDown(KeyCode.E))
                Load();
        }

        private void Save()
        {
            _enemySops = FindObjectsOfType<EnemySops>();

            using StreamWriter streamWriter = new StreamWriter(Application.dataPath + "/Data/EnemySo/" + _fileName);

            foreach (EnemySops enemySops in _enemySops)
            {
                enemySops.UpdateTransform();
                _jsonName = JsonUtility.ToJson(enemySops.EnemySopsData);
                streamWriter.WriteLine(_jsonName);
            }
            
            Debug.Log("saved");
        }

        private void Load()
        {
            EnemySops[] enemySops = FindObjectsOfType<EnemySops>();
            
            if (File.Exists(Application.dataPath + "/Data/EnemySo/" + _fileName))
            {
                _readingFile = File.ReadAllLines(Application.dataPath + "/Data/EnemySo/" + _fileName);

                foreach (string line in _readingFile)
                {
                    _tempEnemySo = JsonUtility.FromJson<EnemySopsData>(line);
                    EnemySops sops = enemySops.FirstOrDefault(e => e.EnemySopsData.id == _tempEnemySo.id);
                    sops.UpdateTransform(_tempEnemySo.position);
                }

                Debug.Log("loaded");
            }
        }
    }
}