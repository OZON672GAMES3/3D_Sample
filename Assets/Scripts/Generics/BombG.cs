using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Generics
{
    public class BombG : MonoBehaviour
    {
        [SerializeField] private float _radius = 2f;
        
        public event Action<BombG> PoolReleaseBomb;
        
        private MeshRenderer _meshRenderer;
        
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private IEnumerator FadeOutRoutine()
        {
            float duration = Random.Range(2f, 5f);
            float timer = 0f;

            while (timer < duration)
            {
                float alpha = Mathf.Lerp(1f, 0f, timer / duration);
                Color color = _meshRenderer.material.color;
                color.a = alpha;
                _meshRenderer.material.color = color;
                
                timer += Time.deltaTime;
                yield return null;
            }
            
            Explosion();
            ReleaseBomb();
        }

        private void OnEnable()
        {
            StartCoroutine(FadeOutRoutine());
        }

        private void ReleaseBomb()
        {
            PoolReleaseBomb?.Invoke(this);
        }

        private void Explosion()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (Collider coll in colliders)
                if (coll.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddForce(transform.position, ForceMode.Impulse);

        }
    }
}