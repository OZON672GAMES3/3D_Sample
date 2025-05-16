using UnityEngine;

namespace DefaultNamespace.InventorySimple
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private void Explode()
        {
            _particleSystem.Play();
            Debug.Log("bomb explodes");
            Destroy(gameObject, 0.1f);
        }

        public void GetExplosion()
        {
            Invoke(nameof(Explode), 1f);
        }
    }
}