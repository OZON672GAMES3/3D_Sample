using UnityEngine;

namespace DefaultNamespace.Test
{
    public class CoinMagnetTest : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMechanicTest player))
                Destroy(gameObject);
        }
    }
}