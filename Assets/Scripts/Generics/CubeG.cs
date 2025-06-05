using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Generics
{
    public class CubeG : MonoBehaviour
    {
        public event Action<CubeG> PoolReleaseCube;
        
        private MeshRenderer _meshRenderer;
        private Color _color;
        private bool _isTouched;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            _meshRenderer.material.color = Color.white;
            _isTouched = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_isTouched && other.gameObject.TryGetComponent(out PlatformG platformG))
            {
                _isTouched = true;
                _meshRenderer.material.color = Random.ColorHSV();
                
                float lifetime = Random.Range(2f, 5f);
                Invoke(nameof(ReleaseCube), lifetime);
            }
        }

        private void ReleaseCube()
        {
            PoolReleaseCube?.Invoke(this);
        }
    }
}