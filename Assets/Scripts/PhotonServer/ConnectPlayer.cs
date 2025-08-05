using Photon.Pun;
using UnityEngine;

namespace DefaultNamespace
{
    public class ConnectPlayer : MonoBehaviour
    {
        [SerializeField] private UniversalPlayerController _player;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = new Vector3(Random.Range(_startPoint.position.x, _endPoint.position.x), 2,
                Random.Range(_startPoint.position.z, _endPoint.position.z));
            PhotonNetwork.Instantiate(_player.name, _startPosition, Quaternion.identity);
        }
    }
}