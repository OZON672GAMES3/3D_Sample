using UnityEngine;

namespace DefaultNamespace.LightPractice
{
    public class OnMouseDownObjects : MonoBehaviour
    {
        [SerializeField] private string _objectId;
        [SerializeField] private int _objectScore;

        private bool _isFind;

        public bool IsFind => _isFind;
        public string ObjectId => _objectId;
        public int ObjectScore => _objectScore;


        public void Find()
        {
            _isFind = true;
        }
    }
}