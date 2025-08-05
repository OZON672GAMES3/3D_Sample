using Photon.Pun;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Connection : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene(1);
        }
    }
}