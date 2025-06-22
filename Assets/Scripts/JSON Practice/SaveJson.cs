using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JSON_Practice
{
    public class SaveJson : MonoBehaviour
    {
        [SerializeField] private JsonInventory _inventoryJson;
        [SerializeField] private string _fileName;

        private List<JsonObject> _inventory;
        private string _json;
        private string[] _readingFile;
        private JsonObject _tempJsonObject;
        private int _countItem;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                SaveDate();
            if (Input.GetKeyDown(KeyCode.S))
                LoadData();
        }

        public void SaveDate()
        {
            using StreamWriter streamWriter = new StreamWriter(Application.dataPath + "/Data/JsonSave/" + _fileName);

            _inventory = _inventoryJson.TakeToSave();

            foreach (JsonObject obj in _inventory)
            {
                _countItem = obj.GetCountSize();

                for (int j = 0; j < _countItem; j++)
                {
                    _json = JsonUtility.ToJson(obj);
                    streamWriter.WriteLine(_json);
                }
            }
            
            Debug.Log("saved");
        }

        public void LoadData()
        {
            if (File.Exists(Application.dataPath + "/Data/JsonSave/" + _fileName))
            {
                _readingFile = File.ReadAllLines(Application.dataPath + "/Data/JsonSave/" + _fileName);

                _inventoryJson.ClearInventory();

                foreach (string line in _readingFile)
                {
                    _tempJsonObject = JsonUtility.FromJson<JsonObject>(line);
                    _inventoryJson.LoadInventory(_tempJsonObject);
                }
                
                Debug.Log("loaded");
            }
        }
    }
}