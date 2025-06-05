using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Generics
{
    public class ObjectPoolG<T> where T : MonoBehaviour
    {
        public static event Action OnObjectCreated;
        public static event Action OnObjectSpawned;
        public static event Action OnObjectReleased;
        
        private readonly T _prefab;
        private readonly Queue<T> _pool = new();
        private readonly Transform _container;
        
        public ObjectPoolG(T prefab, int initialSize, Transform container)
        {
            _prefab = prefab;
            _container = container;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = GameObject.Instantiate(_prefab, _container);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
                OnObjectCreated?.Invoke();
            }
        }
        
        public T Get()
        {
            T obj = _pool.Count > 0 ? _pool.Dequeue() : GameObject.Instantiate(_prefab, _container);

            if (_pool.Count == 0)
                OnObjectCreated?.Invoke();

            obj.gameObject.SetActive(true);
            OnObjectSpawned?.Invoke();

            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
            OnObjectReleased?.Invoke();
        }
    }
}