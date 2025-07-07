using UnityEngine;

namespace DefaultNamespace.Test
{
    public class PlayerMechanicTest : MonoBehaviour
    {
        [SerializeField] private float _attractSpeed = 5f;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CoinMagnetTest coinMagnet))
            {
                Transform coin = other.transform;
                Vector3 direction = (transform.position - coin.position).normalized;
                coin.position += direction * _attractSpeed * Time.deltaTime;
            }
        }
    }
}