using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class JoinServer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _createRoom;
        [SerializeField] private TMP_InputField _joinRoom;
        
        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = 10
            };
            PhotonNetwork.CreateRoom(_createRoom.text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(_joinRoom.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel(2);
        }
    }
}