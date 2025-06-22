using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.EnemyScriptableObjectPracticeSave
{
    [RequireComponent(typeof(SpriteRenderer))]
    [Serializable]
    public class EnemySops : MonoBehaviour
    {
        [SerializeField] private EnemySo _enemySo;
        [SerializeField] private EnemySopsData _enemySopsData;
        public EnemySopsData EnemySopsData => _enemySopsData; 
        
        private Vector2 _position;
        private string _id;
        private EnemyType _enemyType;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _enemySopsData = new EnemySopsData();
            UpdateData();
        }

        private void UpdateData()
        {
            _id = _enemySo.GetId();
            _enemyType = _enemySo.GetEnemyType();
            _position = _enemySo.GetPosition();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _enemySo.GetSprite();
            transform.position = _position;

            _enemySopsData.position = _position;
            _enemySopsData.id = _id;
        }

        public void UpdateTransform()
        {
            _position = transform.position;
            _enemySopsData.position = _position;
        }

        public void UpdateTransform(Vector2 position)
        {
            transform.position = position;
            _position = transform.position;
            _enemySopsData.position = _position;
        }
    }
}